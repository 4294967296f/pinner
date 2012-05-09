@echo off
pushd %0\..
REM Tests

SET PINNER=pinner.exe
SET TEST_EXE=%WINDIR%\system32\notepad.exe

echo.
echo ::Pinning To Taskbar
"%PINNER%" --pin-taskbar "%TEST_EXE%"
pause

echo.
echo ::Unpinning From Taskbar
"%PINNER%" --unpin-taskbar "%TEST_EXE%"
pause

echo.
echo ::Pinning To Start Menu
"%PINNER%" --pin-startmenu "%TEST_EXE%"
pause

echo.
echo ::Unpinning From Start Menu
"%PINNER%" --unpin-startmenu "%TEST_EXE%"
pause

echo.
echo ::Pinning To Taskbar and Start menu
"%PINNER%" --pin-taskbar --pin-startmenu "%TEST_EXE%"
pause

echo.
echo ::Pinning To Taskbar and Unpinning from Start Menu
"%PINNER%" --pin-taskbar --unpin-startmenu "%TEST_EXE%"
pause

echo.
echo ::Pinning To Start Menu and Unpinning from Taskbar
"%PINNER%" --unpin-taskbar --pin-startmenu "%TEST_EXE%"
pause

echo.
echo ::Contradictory Taskbar
"%PINNER%" --pin-taskbar --unpin-taskbar "%TEST_EXE%"
pause

echo.
echo ::Contradictory Start Menu
"%PINNER%" --pin-startmenu --unpin-startmenu "%TEST_EXE%"
pause

echo.
echo ::Contradictory Taskbar and Start Menu
"%PINNER%" --pin-taskbar --unpin-taskbar --pin-startmenu --unpin-startmenu "%TEST_EXE%"
pause

echo.
echo ::Help 1
"%PINNER%" --help --pin-taskbar --unpin-taskbar --pin-startmenu --unpin-startmenu "%TEST_EXE%"
pause

echo.
echo ::Help 2
"%PINNER%" --help
pause

echo.
echo ::Help 3
"%PINNER%" --pin-taskbar --unpin-taskbar --pin-startmenu --unpin-startmenu "%TEST_EXE%" -h
pause

echo.
echo ::Help 4
"%PINNER%" -h
pause

echo.
echo ::Help 5
"%PINNER%" -h --pin-taskbar --unpin-taskbar --pin-startmenu --unpin-startmenu "%TEST_EXE%"
pause

echo.
echo ::Help 6
"%PINNER%" --pin-taskbar --unpin-taskbar --pin-startmenu --unpin-startmenu "%TEST_EXE%" --help
pause

popd