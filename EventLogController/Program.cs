using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace EventLogController
{
    class Program
    {
        static void Main(string[] args)
        {
        lineStart:

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("To add a source: add <source>");

            Console.WriteLine("To delete a source: del <source>");

            Console.WriteLine("To end the program enter 0 then hit enter\n");

            try
            {
                var command = Console.ReadLine();

                if (!string.IsNullOrEmpty(command))
                {

                    if (command.ToLower().StartsWith("add "))
                    {
                  
                        var source = command.Substring(4);
                        if (!EventLog.SourceExists(source))
                        {
                            EventLog.CreateEventSource(source, source);
                            Console.WriteLine(string.Format("{0} created\n", source));
                        }
                        else
                        {
                            Console.WriteLine("Source already exists");
                        }
                        goto lineStart;

                    }
                    else if (command.ToLower().StartsWith("del "))
                    {

                        var source = command.Substring(4);
                        if (EventLog.SourceExists(source))
                        {
                            EventLog.DeleteEventSource(source);
                            Console.WriteLine(string.Format("{0} deleted\n", source));
                        }
                        else
                        {
                            Console.WriteLine("Source not found");
                        }
                        goto lineStart;

                    }
                    else if (command != "0")
                    {

                        goto lineStart;

                    }
                }
                else
                {
                    goto lineStart;
                }

            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                goto lineStart;
            }
        }
    }
}
