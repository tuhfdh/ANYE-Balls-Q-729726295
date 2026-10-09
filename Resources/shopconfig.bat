"D:\Program Files\Netease\MuMu Player 12\nx_main\"adb.exe connect 127.0.0.1:16384
"D:\Program Files\Netease\MuMu Player 12\nx_main\"adb.exe -s 127.0.0.1:16384 root
"D:\Program Files\Netease\MuMu Player 12\nx_main\"adb.exe -s 127.0.0.1:16384 shell chmod 000 /storage/emulated/0/Android/data/com.ztgame.bob/files/vercache2022/android/common/data/shopconfig.unity3d_u_bf3ecdc26573a2f6f8c919c569faac93
"D:\Program Files\Netease\MuMu Player 12\nx_main\"adb.exe -s 127.0.0.1:16384 shell sed -i '/shopconfig.unity3d/d' /storage/emulated/0/Android/data/com.ztgame.bob/files/vercache2022/android/ver.xml
