# BorderlandsPatcher
Patcher for borderlands2.exe and borderlandspresequel.exe for ability to use community patch. More info about patch: https://youtu.be/o_ee3BM1TQQ 

# Downloading
You can find binary(.exe) file here: https://github.com/bugworm/BorderlandsPatcher/releases/

To use Community Patch you need to patch your borderlands2(presequel).exe (it will backup original file, don't worry), add console hotkey if you doesn't have one and place patch file(patch.txt) to Binaries directory. Program will find your game path and download latest patch automaticly, if won't find it, you still can choose path manually. Then launch your game, open console, type \"exec Patch.txt\"(or PatchOffline.txt if you want to play offline) and press enter. Do it after game downloads all stuff(when you see actual menu). That's all, you can now enjoy patch! It will work only for current session, you need to enter console command every time you launch the game. You can press \"Arrow Up\" to show your last typed command on console.

Repository with custom pathces: https://github.com/BL2CP/community-custom-weapons
Beta patcher can download patches from this repo

Also there is a patched file `engine.upk` for Linux/Mac, instructions: https://www.reddit.com/r/Borderlands/comments/5y35js/community_patch_for_linuxand_probably_mac/
and Syntax Highlighting for Kate Editor. Put `bpf.xml` file to `C:\Users\username\AppData\Local\katepart5\syntax` (`~/.local/share/org.kde.syntax-highlighting/syntax` on linux) and restart Kate if you have it launched. If you don't have this directory you can create it or launch update for syntax(`Settings > Configure Kate > Open/Save > Modes & Filetypes > Download Highlighting Files`) and it will create needed dir. It will be used by default for *.bpf files, but you can use it for *.txt files too. It can be on with `Tools > Mode(Highlighting) > Other > Borderlands Patch File`.

If you have any question to me or about mods/modding, you can join Shadow's Discord server and ask https://discord.gg/0YjZxbVBS9b3bXUS
