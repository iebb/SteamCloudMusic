using SteamKit2;
using SteamKit2.Discovery;
using SteamKit2.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SteamCloudMusic
{
    public partial class Form : System.Windows.Forms.Form
    {
        public SteamClient client;
        public SteamConfiguration cfg;
        public CallbackManager cb;
        public SteamUser user;
        public SteamFriends friends;
        public SteamUser.LogOnDetails logon = new SteamUser.LogOnDetails();
        public BackgroundWorker worker = new BackgroundWorker { 
            WorkerSupportsCancellation = true
        };
        private bool loggedIn = false;
        private bool loop = false;
        private bool initialized = false;
        private string steamNickname = "";
        private string steamID = "";
        private string lastPresence = "";

        private delegate void SafeCallDelegateStringColor(string a, Color b);
        private delegate void SafeCallDelegate();

        void UpdateState()
        {
            if (this.InvokeRequired)
            {
                var d = new SafeCallDelegate(UpdateState);
                this.Invoke(d);
            }
            else
            {
                panelLoggedIn.Visible = loggedIn;
                panelLogin.Visible = !loggedIn;
                lblNickname.Text = steamNickname;
                lblSteamID.Text = steamID;
            }
        }

        void SaveConfig()
        {
            Config c = new Config();
            if (chkSavePasswd.Checked)
            {
                c.SetUserPass(txtUserName.Text, txtPassword.Text);
                c.save_passwd = true;
            }
            else
            {
                c.username = txtUserName.Text;
                c.save_passwd = false;
            }
            c.pattern = txtPattern.Text;
            c.process = txtProcess.Text;
            c.replacement = txtRepl.Text;
            c.find_flag = 0;
            if (chkCollapse.Checked) c.find_flag |= Config.FIND_TRAY_COLLAPSED;
            if (chkTray.Checked) c.find_flag |= Config.FIND_TRAY;
            if (chkTaskbar.Checked) c.find_flag |= Config.FIND_TASKBAR;
            c.Save();
        }
        void LoadConfig()
        {
            Config c = Config.Load();
            txtUserName.Text = c.username;
            txtPassword.Text = c.GetPass();
            chkSavePasswd.Checked = c.save_passwd;

            txtPattern.Text = c.pattern;
            txtProcess.Text = c.process;
            txtRepl.Text = c.replacement;

            chkCollapse.Checked = ((c.find_flag & Config.FIND_TRAY_COLLAPSED) != 0);
            chkTray.Checked = ((c.find_flag & Config.FIND_TRAY) != 0);
            chkTaskbar.Checked = ((c.find_flag & Config.FIND_TASKBAR) != 0);
        }

        void Log(string text)
        {
            Log(text, Color.White);
        }
        void Log(string text, Color color)
        {
            if (labelStatus.InvokeRequired)
            {
                var d = new SafeCallDelegateStringColor(Log);
                labelStatus.Invoke(d, new object[] { text, color });
            }
            else
            {
                labelStatus.Text = text.Replace("\n", "\\n").Replace("\r", "\\r");
                labelStatus.ForeColor = color;
                Console.WriteLine(text);
            }
        }

        public Form()
        {
            InitializeComponent();
            client = new SteamClient();
            cb = new CallbackManager(client);
            user = client.GetHandler<SteamUser>();
            friends = client.GetHandler<SteamFriends>();
            initCallback();
            LoadConfig();
        }


        static byte[] SHAHash(byte[] input)
        {
            SHA1Managed sha = new SHA1Managed();
            byte[] output = sha.ComputeHash(input);
            sha.Clear();
            return output;
        }

        void OnUpdateMachineAuthCallback(SteamUser.UpdateMachineAuthCallback machineAuth)
        {
            byte[] hash = SHAHash(machineAuth.Data);

            Directory.CreateDirectory(System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "sentryfiles"));

            File.WriteAllBytes(System.IO.Path.Combine("sentryfiles", String.Format("{0}.sentryfile", logon.Username)), machineAuth.Data);

            var authResponse = new SteamUser.MachineAuthDetails
            {
                BytesWritten = machineAuth.BytesToWrite,
                FileName = machineAuth.FileName,
                FileSize = machineAuth.BytesToWrite,
                Offset = machineAuth.Offset,

                SentryFileHash = hash,
                OneTimePassword = machineAuth.OneTimePassword,
                LastError = 0,
                Result = EResult.OK,
                JobID = machineAuth.JobID,
            };

            // send off our response
            user.SendMachineAuthResponse(authResponse);
        }

        class Listener : IDebugListener
        {
            public Form f;
            public Listener(Form fm)
            {
                f = fm;
            }
            public void WriteLine(string category, string msg)
            {
                Console.WriteLine("{0}: {1}", category, msg);
                f.Log(msg);
            }
        }

        void initCallback()
        {

            DebugLog.AddListener(new Listener(this));
            DebugLog.Enabled = true;

            cb.Subscribe<SteamClient.ConnectedCallback>(callback =>
            {
                Log("Steam server connected", Color.LightGreen);
                UpdateState();
                user.LogOn(logon);
            });

            cb.Subscribe<SteamClient.DisconnectedCallback>(callback =>
            {
                Log("Steam server disconnected", Color.LightSalmon);
                loggedIn = false;
                loop = false;
                UpdateState();
                if (loop)
                {
                    client.Connect();
                }
            });

            cb.Subscribe<SteamUser.LoggedOffCallback>(callback =>
            {
                Log("User logged off", Color.LightSalmon);
                loggedIn = false;
                loop = false;
                UpdateState();
            });

            cb.Subscribe<SteamUser.UpdateMachineAuthCallback>(
                authCallback => OnUpdateMachineAuthCallback(authCallback)
            );

            cb.Subscribe<SteamUser.LoggedOnCallback>(callback =>
            {

                Log(String.Format("Logged On Callback: {0}", callback.Result), Color.Yellow);

                if (callback.Result == EResult.OK)
                {
                    Log("LoggedOnCallback: ok", Color.LightGreen);
                    loggedIn = true;
                    steamNickname = friends.GetPersonaName();
                    steamID = callback.ClientSteamID.ToString();
                    UpdateState();
                }
                else
                {
                    Log(String.Format("Login Error: {0}", callback.Result), Color.Yellow);
                    if (callback.Result == EResult.AccountLoginDeniedNeedTwoFactor)
                    {
                        Log("AccountLoginDeniedNeedTwoFactor", Color.Yellow);
                        worker.CancelAsync();
                    }
                    else if (callback.Result == EResult.TwoFactorCodeMismatch)
                    {
                        Log("TwoFactorCodeMismatch", Color.Yellow);
                        worker.CancelAsync();
                    }
                    else if (callback.Result == EResult.AccountLogonDenied)
                    {
                        Log("This account is SteamGuard enabled. Enter the code via the `auth' command.", Color.Yellow);
                        worker.CancelAsync();
                    }
                    else if (callback.Result == EResult.InvalidLoginAuthCode)
                    {
                        Log("The given SteamGuard code was invalid. Try again using the `auth' command.", Color.Yellow);
                        worker.CancelAsync();
                    }
                    worker.CancelAsync();
                }

            });


            if (!worker.IsBusy)
            {
                worker.DoWork += doWork;
                worker.RunWorkerAsync();
                initialized = true;
            }

        }

        string getTray(string process)
        {
            if (chkTray.Checked)
            {
                foreach (var i in Tray.GetTrayIcons())
                {
                    if (i.Item1.ToLower() == process.ToLower() && i.Item2.Length > 0)
                    {
                        return i.Item2;
                    }
                }
            }
            if (chkCollapse.Checked)
            {
                foreach (var i in Tray.GetCollapsedTrayIcons())
                {
                    if (i.Item1.ToLower() == process.ToLower() && i.Item2.Length > 0)
                    {
                        return i.Item2;
                    }
                }
            }
            if (chkTaskbar.Checked)
            {
                foreach (var i in Tray.GetTaskbarIcons())
                {
                    if (i.Item1.ToLower() == process.ToLower() && i.Item2.Length > 0)
                    {
                        return i.Item2;
                    }
                }
            }
            return "";
        }

        void doWork(object sender, DoWorkEventArgs e)
        {
            loop = true;

            while (true)
            {
                if (worker.CancellationPending)
                {
                    loop = false;
                    e.Cancel = true;
                    client.Disconnect();
                    return;
                }
                try
                {
                    cb.RunWaitCallbacks(TimeSpan.FromSeconds(5));
                }
                catch (Exception ex)
                {
                    Log(ex.Message, Color.Red);
                }

                try
                {
                    var tray = getTray(txtProcess.Text);
                    labelStatusBar.Text = tray.Replace("\n", "\\n").Replace("\r", "\\r");
                    if (tray.Length > 0)
                    {
                        var presence = Regex.Replace(tray, txtPattern.Text, txtRepl.Text);
                        if (loggedIn)
                        {
                            if (presence != lastPresence)
                            {
                                friends.SetPersonaState(EPersonaState.Busy);
                                var gamePlaying = new SteamKit2.ClientMsgProtobuf<CMsgClientGamesPlayed>(EMsg.ClientGamesPlayed);
                                gamePlaying.Body.games_played.Add(new CMsgClientGamesPlayed.GamePlayed
                                {
                                    game_id = new GameID(15190414816125648896),
                                    game_extra_info = presence
                                });
                                client.Send(gamePlaying);
                                lastPresence = presence;
                                Log(presence, Color.LightPink);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Log(ex.Message, Color.Red);
                }
            }
        }


        void LogOn()
        {
            client.Connect();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            logon.LoginID = 114514;
            logon.Username = txtUserName.Text;
            logon.Password = txtPassword.Text;
            if (txt2FA.Text.Length > 0)
            {
                logon.TwoFactorCode = txt2FA.Text;
            }
            SaveConfig();
            Directory.CreateDirectory(System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "sentryfiles"));
            FileInfo fi = new FileInfo(System.IO.Path.Combine("sentryfiles", String.Format("{0}.sentryfile", logon.Username)));

            if (fi.Exists && fi.Length > 0)
                logon.SentryFileHash = SHAHash(File.ReadAllBytes(fi.FullName));
            else
                logon.SentryFileHash = null;

            LogOn();
            UpdateState();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            loop = false;
            if (initialized)
            {
                worker.CancelAsync();
            }
            SaveConfig();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveConfig();
            loggedIn = false;
            loop = false;
            client.Disconnect();
            UpdateState();
        }

        private void chkSavePasswd_CheckedChanged(object sender, EventArgs e)
        {
            SaveConfig();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/iebb/SteamCloudMusic");
        }
    }
}
