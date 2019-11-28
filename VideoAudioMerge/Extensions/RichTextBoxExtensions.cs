using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VideoAudioMerge
{
    public static class RichTextBoxExtensions
    {
        public static void Write(this RichTextBox txt, string fmt, params object[] objects)
        {
            txt.AppendText(string.Format(fmt, objects));
        }

        public static void WriteLine(this RichTextBox txt, string fmt, params object[] objects)
        {

            txt.AppendText(string.Format(fmt, objects));
            txt.AppendText(Environment.NewLine);

        }

        public static void WriteLine(this RichTextBox txt)
        {
            txt.AppendText(Environment.NewLine);
        }
    }
}
