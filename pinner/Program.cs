//Copyright (c) 2012 46742330f

//Permission is hereby granted, free of charge, to any person obtaining a copy of 
//this software and associated documentation files (the "Software"), to deal in 
//the Software without restriction, including without limitation the rights to 
//use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies 
//of the Software, and to permit persons to whom the Software is furnished to do
//so, subject to the following conditions:

//The above copyright notice and this permission notice shall be included in all 
//copies or substantial portions of the Software.

//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR 
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE 
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER 
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, 
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE 
//SOFTWARE.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Mono.Options;


namespace pinner
{
    class Program
    {
        static void Main(string[] args)
        {
            bool show_help = false;
            bool pin_taskbar = false;
            bool unpin_taskbar = false;
            bool pin_startmenu = false;
            bool unpin_startmenu = false;
            string path_to_exe = string.Empty;

            var p = new OptionSet() {
                "",
			    "Usage: pinner [--pin-taskbar] [--unpin-taskbar] [--pin-startmenu] [--unpin-startmenu] \"path to target\"",
			    "Pin or unpin a program to or from the Taskbar and/or Start Menu.",
			    "",
			    "Options:",
			    { "pin-taskbar", "Pin the item to the Taskbar", v => pin_taskbar = true },
			    { "unpin-taskbar", "Unpin the item from the Taskbar.", v => unpin_taskbar = true },
                { "pin-startmenu", "Pin the item to the Start Menu", v => pin_startmenu = true },
			    { "unpin-startmenu", "Unpin the item from the Start Menu.", v => unpin_startmenu = true },
			    { "h|help",  "Show this message and exit.", v => show_help = v != null },
                "",
		    };


            List<string> extra;
            try
            {
                extra = p.Parse(args);
            }
            catch (OptionException e)
            {
                print_error(e.Message);
                return;
            }

            //If they want the help, give it to them
            if (show_help)
            {
                p.WriteOptionDescriptions(Console.Out);
                return;
            }

            //Make sure we have all the info we need to proceed
            if ((pin_taskbar && unpin_taskbar) || (pin_startmenu && unpin_startmenu)) //Invalid Options
            {
                print_error("Invalid selection.");
                return;
            }

            if (extra.Count > 0) //Grab all of the unknown arguments and merge them
            {
                path_to_exe = string.Join(" ", extra.ToArray());
            }
            else //No target was given
            {
                print_error("Target could not be found.");
                return;
            }

            if (String.IsNullOrEmpty(path_to_exe)) //Double check that our target isnt null
            {
                print_error("Target could not be found.");
                return;
            }
            
            //If we have gotten this far then lets get to work
            if(File.Exists(path_to_exe))
            {
                var shell_type = Type.GetTypeFromProgID("Shell.Application");
                dynamic shell_app = Activator.CreateInstance(shell_type);

                FileInfo file_info = new FileInfo(path_to_exe);
                dynamic file_dir = shell_app.NameSpace(file_info.DirectoryName);
                dynamic file_link = file_dir.ParseName(file_info.Name);

                dynamic file_verbs = file_link.Verbs();

                for (int i = 0; i < file_verbs.Count(); ++i)
                {
                    dynamic verb = file_verbs.Item(i);
                    string verb_name = verb.Name.Replace(@"&", string.Empty).ToLower();

                    //Taskbar
                    if(pin_taskbar && verb_name.Equals("pin to taskbar"))
                        verb.DoIt();
                    else if(unpin_taskbar && verb_name.Equals("unpin from taskbar"))
                        verb.DoIt();

                    //Start Menu
                    if(pin_startmenu && verb_name.Equals("pin to start menu"))
                        verb.DoIt();
                    else if(unpin_startmenu && verb_name.Equals("unpin from start menu"))
                        verb.DoIt();
                }
                
                shell_app = null;
            }
            else
            {
                print_error("Target not found.");
                return;
            }
        }

        private static void print_error(string message)
        {
            Console.WriteLine();
            Console.WriteLine("pinner: ");
            Console.WriteLine();
            Console.WriteLine(message);
            Console.WriteLine("Try `pinner --help' for more information.");
        }
    }
}


