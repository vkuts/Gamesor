using System;
using System.Windows.Forms;
using System.Threading;

namespace XLevelEditor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Set the unhandled exception mode to force all Windows Forms errors
            // to go through our handler.
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            // Add the event handler for handling UI thread exceptions to the event.
            Application.ThreadException += new ThreadExceptionEventHandler(UiThreadException);

            // Add the event handler for handling non-UI thread exceptions to the event. 
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            using (FormMain frmMain = new FormMain())
            {
                

                Application.Run(frmMain);
            }
        }

        static void UiThreadException(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show(string.Format("Exception thrown up by sender: '{0}'\nStack: {1}", sender, e.Exception));
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {

        }

    }
}

