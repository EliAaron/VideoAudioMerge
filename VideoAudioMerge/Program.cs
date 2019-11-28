using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;

namespace VideoAudioMerge
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);

            Application.Run(new VideoAudioMerge());
        }

        // Log error and display error message.
        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            string msg = string.Format(
                "An unhandled exception occurred.\n\nError: {0}\n\nFor more iformatin, see {1}",
                e.Exception.Message,
                ErrorLogger.FileNeme);

            MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            string errorLogMsg =
                "Error Mesege:\r\n" + e.Exception.Message + "\r\n\r\n" +
                "Error Source:\r\n" + e.Exception.Source + "\r\n\r\n" +
                "Stack Trace:\r\n" + e.Exception.StackTrace;

            ErrorLogger.Log(ErrorLogger.ErrorType.UnhandledException, errorLogMsg, DateTime.Now);
        }
    }
}
