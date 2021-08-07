using System;
using System.Threading;
using System.Windows;

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

                _ = ThreadPool.RegisterWaitForSingleObject(eventWaitHandle,
                    waitOrTimerCallback, app, Timeout.Infinite, false);

                // Do not need any more.
                eventWaitHandle.Close();
            }
            else
            {
                eventWaitHandle.Set();

                // Let's produce an exit whith no possible interceptions.
                Environment.Exit(0);
            }
        }

        private delegate void dispatcherInvoker();

        private static void waitOrTimerCallback(object state, bool timedOut)
        {
            Application app = (Application)state;
            _ = app.Dispatcher.BeginInvoke(
                new dispatcherInvoker(delegate ()
                {
                    Application.Current.MainWindow.Activate();
                }),
                null
            );
        }
    }
}
