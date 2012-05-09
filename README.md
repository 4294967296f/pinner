pinner
======

Description:

This tool aims to help system administrators pin and unpin items from both the
Windows Taskbar and Start Menu.


License:

MIT License

Copyright (c) 2012 46742330f

Permission is hereby granted, free of charge, to any person obtaining a copy of 
this software and associated documentation files (the "Software"), to deal in 
the Software without restriction, including without limitation the rights to 
use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies 
of the Software, and to permit persons to whom the Software is furnished to do
so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all 
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR 
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE 
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER 
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, 
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE 
SOFTWARE.


Build Environment:
	Windows 7 x64
	Visual Studio C# 2010 Express

Required External Libraries:
	Mono.Options (https://github.com/mono/mono/tree/master/mcs/class/Mono.Options)

Dependencies:
	.NET 4.0



Usage:
pinner [--pin-taskbar] [--unpin-taskbar] [--pin-startmenu] [--unpin-startmenu] "path to target"
Pin or unpin a program to or from the Taskbar and/or Start Menu.

Options:
      --pin-taskbar          Pin the item to the Taskbar
      --unpin-taskbar        Unpin the item from the Taskbar.
      --pin-startmenu        Pin the item to the Start Menu
      --unpin-startmenu      Unpin the item from the Start Menu.
  -h, --help                 Show this message and exit.