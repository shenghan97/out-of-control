::cmd script

"C:\Program Files (x86)\ffmpegyag\bin\ffmpeg.exe" -i "C:\Users\Public\Documents\Unity Projects\test\Assets\Resources\cup\_blue_red_yellow_人.webm" -strict experimental -f webm -map_chapters -1 -map 0:0 -map 0:1 -sn -c:a:0 copy -c:v:0 copy -t 00:00:30.300 -y "C:\Users\Public\Documents\Unity Projects\test\Assets\Resources\cup\_blue_red_yellow_人2.webm"

