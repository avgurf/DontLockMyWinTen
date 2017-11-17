# DontLockMyWinTen
Small and simple app to prevent Windows 10 from locking
(which is apperantly not so easy to configure out of the box, and requires persmissions)

This app uses the systems call `SetThreadExecutionState` to `ES_DISPLAY_REQUIRED` and `ES_CONTINUOUS` (which tricks windows into thinking the dispaly is used, like in VLC for instance) and results in making the screeen on for as long as the app runs :)

# :arrow_down: Download

Go to the [Release section](https://github.com/avgurf/DontLockMyWinTen/releases/tag/v1.0) or just :small_red_triangle_down:[Download  the latest binary](https://github.com/avgurf/DontLockMyWinTen/releases/download/v1.0/DontLockMyWinTen.exe)
