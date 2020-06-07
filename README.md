# SteamCloudMusic

Synchronize Your Music Player with Steam!


----
### How does it work?

It searches your system tray (including both visible and hidden items) for the process name you provided, 
and tooltip is returned if something is found. 

Because lots of music/video players (even some games) has infomative tray icons (not limited to CloudMusic), 
it can also be used as an alternative tool for game state integration.

----
### Supported Apps

- Netease CloudMusic (default) ($1 for Title, $2 for Artist)
- Spotify `spotify` / `^(.*?) - (.*)$` / `♫ $2` ($2 for Title, $1 for Artist)
- VLC Player `vlc` / `^(.*?)(\..*)?$` / `♫ $1` ($1 for Filename)

and a lot more...

----
### Credit

https://github.com/SteamRE/SteamKit

App Icon made by Freepik from www.flaticon.com
