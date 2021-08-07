using System;
using System.Threading;
using System.Windows;
using System.IO;
using System.IO.IsolatedStorage;

namespace WpfSingleInstanceByEventWaitHandle
{
    public static class WpfSingleInstance
    {
        internal static void Make(string name, Application app)
        {
            EventWaitHandle eventWaitHandle = null;
            string eventName = Environment.MachineName + "-" + name;

            bool isFirstInstance = false;

            try
            {
                eventWaitHandle = EventWaitHandle.OpenExisting(eventName);
            }
            catch
            {
                // This code only runs on the first instance.
                isFirstInstance = true;
            }

            if (isFirstInstance)
            {
                eventWaitHandle = new EventWaitHandle(
                    false,
                    EventResetMode.AutoReset,
                    eventName);

                ThreadPool.RegisterWaitForSingleObject(eventWaitHandle,
                    waitOrTimerCallback, app, Timeout.Infinite, false);

                // Do not need any more.
                eventWaitHandle.Close();


                // !!! delete it if not use
                setFirstArgs();
            }
            else
            {
                // !!! delete it if not use
                setArgs();


                eventWaitHandle.Set();

                // For that exit no interceptions
                Environment.Exit(0);
            }
        }


        private delegate void dispatcherInvoker();

        private static void waitOrTimerCallback(Object state, Boolean timedOut)
        {
            Application app = (Application)state;
            app.Dispatcher.BeginInvoke(
                new dispatcherInvoker(delegate ()
                {
                    Application.Current.MainWindow.Activate();

                    // !!! delete it if not use
                    processArgs();

                }),
                null
            );
        }



        // Args functionality for test purpose and not developed carefuly

        internal static readonly object StartArgKey = "StartArg";

        private static readonly String isolatedStorageFileName = "SomeFileInTheRoot.txt";

        private static void setArgs()
        {
            string[] args = Environment.GetCommandLineArgs();
            if (1 < args.Length)
            {
                IsolatedStorageFile isoStore =
                    IsolatedStorageFile.GetStore(
                        IsolatedStorageScope.User | IsolatedStorageScope.Assembly,
                        null,
                        null);

                IsolatedStorageFileStream isoStream1 = new IsolatedStorageFileStream(isolatedStorageFileName, FileMode.Create, isoStore);
                StreamWriter sw = new StreamWriter(isoStream1);
                string arg = args[1];
                sw.Write(arg);
                sw.Close();
            }
        }

        private static void setFirstArgs()
        {
            string[] args = Environment.GetCommandLineArgs();
            if (1 < args.Length)
            {
                Application.Current.Resources[WpfSingleInstance.StartArgKey] = args[1];
            }
        }

        private static void processArgs()
        {
            IsolatedStorageFile isoStore =
                IsolatedStorageFile.GetStore(
                    IsolatedStorageScope.User | IsolatedStorageScope.Assembly,
                    null,
                    null);


            IsolatedStorageFileStream isoStream1 = new IsolatedStorageFileStream(isolatedStorageFileName, FileMode.OpenOrCreate, isoStore);
            StreamReader sr = new StreamReader(isoStream1);
            string arg = sr.ReadToEnd();
            sr.Close();

            isoStore.DeleteFile(isolatedStorageFileName);

            SingleInstanceWindow.ProcessArg(arg);
        }
    }
}
