using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamCloudMusic
{
    class Config
    {
        public const int FIND_TASKBAR = 1;
        public const int FIND_TRAY = 2;
        public const int FIND_TRAY_COLLAPSED = 4;

        public string username;
        public string encPassword;
        public string process;
        public string pattern;
        public string replacement;
        public int find_flag;
        public bool save_passwd;

        public void SetUserPass(string u, string p)
        {
            byte[] s = new byte[p.Length];
            for (int i = 0; i < p.Length; i++)
            {
                s[i] = (byte)(p[i] ^ u[i % u.Length]);
            }
            username = u;
            encPassword = System.Convert.ToBase64String(s);
        }
        public string GetPass()
        {
            if (encPassword == null)
            {
                return "";
            }

            byte[] decPassword = System.Convert.FromBase64String(encPassword);
            for (int i = 0; i < decPassword.Length; i++)
            {
                decPassword[i] = (byte)(decPassword[i] ^ username[i % username.Length]);
            }
            return System.Text.Encoding.UTF8.GetString(decPassword);
        }

        public void Save()
        {
            var dirName = Path.Combine(
                Environment.GetFolderPath(
                    Environment.SpecialFolder.ApplicationData
                ), "SteamCloudMusic");
            var fileName = Path.Combine(
                dirName, "SteamCloudMusic.json");
            System.IO.Directory.CreateDirectory(dirName);
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(fileName, false))
            {
                file.Write(JsonConvert.SerializeObject(this));
            }
        }
        static public Config Load()
        {
            var dirName = Path.Combine(
                Environment.GetFolderPath(
                    Environment.SpecialFolder.ApplicationData
                ), "SteamCloudMusic");
            var fileName = Path.Combine(
                dirName, "SteamCloudMusic.json");
            if (System.IO.File.Exists(fileName))
            {
                using (System.IO.StreamReader file = new System.IO.StreamReader(fileName, false))
                {
                    return JsonConvert.DeserializeObject<Config>(file.ReadToEnd());
                }
            }
            return new Config();
        }
    }
}
