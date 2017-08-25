using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HelloWorldConsole
{
    class Program
    {
        static string _result = string.Empty;
        static ManualResetEvent resetEvent = new ManualResetEvent(false);

        static void Main(string[] args)
        {
            using (var client = new WebClient())
            {
                Uri uri = new Uri(@"http://localhost/HelloWorldAPI/api/Msg");
                client.Headers.Add(@"Content-Type:application/json");
                client.Headers.Add(@"Accept:application/json");

                client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(DownloadComplete_Callback);
                client.DownloadStringTaskAsync(uri);
                
            }

            resetEvent.WaitOne();

            Output displayResult = null;
            string outputDevice = ConfigurationManager.AppSettings.Get("Output");

            switch(outputDevice)
            {
                case "Console":
                    ConsoleOutput consoleResult = new ConsoleOutput();
                    displayResult = consoleResult;
                    break;
                default:
                    throw new Exception("Output API result to [" + outputDevice + "] not implemented");
                    break;
            }

            displayResult.Export(_result);
        }

        static void DownloadComplete_Callback(object sender, DownloadStringCompletedEventArgs e)
        {
            _result = e.Result;

        }

        
    }
}
