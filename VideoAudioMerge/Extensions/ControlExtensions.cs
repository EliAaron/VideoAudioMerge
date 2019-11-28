using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Drawing;

namespace VideoAudioMerge
{
    public static class ControlExtensions
    {
        public static void DoubleBufferedAll(this Control control, bool value)
        {
            typeof(Control).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, control, new object[] { value });

            foreach (Control childControl in control.Controls)
            {
                childControl.DoubleBufferedAll(value);
            }
        }

        public static void ResizeRedrawAll(this Control control, bool value)
        {
            typeof(Control).InvokeMember("ResizeRedraw",
                    BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                    null, control, new object[] { value });

            foreach (Control childControl in control.Controls)
            {
                childControl.ResizeRedrawAll(value);
            }
        }

        public static void SetStyleAll(this Control control, ControlStyles controlStyles, bool value)
        {
            typeof(Control).InvokeMember("SetStyle",
                    BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.NonPublic,
                    null, control, new object[] { controlStyles, value });

            foreach (Control childControl in control.Controls)
            {
                childControl.SetStyleAll(controlStyles, value);
            }
        }

        public static void SuspendLayoutAll(this Control control)
        {
            control.SuspendLayout();
            foreach (Control childControl in control.Controls)
            {
                childControl.SuspendLayoutAll();
            }
        }

        public static void ResumeLayouAll(this Control control)
        {
            control.ResumeLayout();
            foreach (Control childControl in control.Controls)
            {
                childControl.ResumeLayouAll();
            }
        }

        public static void PerformLayoutAll(this Control control)
        {
            control.PerformLayout();
            foreach (Control childControl in control.Controls)
            {
                childControl.PerformLayoutAll();
            }
        }

        public static void DisableSelectStyles(this Control control)
        {
            if (control is Button)
            {
                typeof(Button).InvokeMember("SetStyle",
                    BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.InvokeMethod,
                    null, control, new object[] { ControlStyles.Selectable, false });
            }

            foreach (Control childControl in control.Controls)
            {
                childControl.DisableSelectStyles();
            }
        }

        public static void Invoke(this Control control, MethodInvoker fnc)
        {
            control.Invoke(new Action(fnc));
        }

        public static void InvokeIfRequired(this Control control, MethodInvoker fnc)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(fnc);
            }
            else
            {
                fnc();
            }
        }

        public static IAsyncResult BeginInvoke(this Control control, MethodInvoker fnc)
        {
            return control.BeginInvoke(new Action(fnc));
        }

        public static bool IsOpened(this Form form)
        {
            return Application.OpenForms.Cast<Form>().Where(frm => frm == form).Count() == 0;
        }

        public static void SetPositionNextToScreenPoint(this Form form, Point ScreenPoint)
        {
            int formLeft;
            int formTop;
            Rectangle screenRect = Screen.PrimaryScreen.WorkingArea;


            if (ScreenPoint.Y > screenRect.Height / 2) formTop = ScreenPoint.Y - form.Height;
            else formTop = ScreenPoint.Y;

            formTop = Math.Max(screenRect.Top, formTop);
            formTop = Math.Min(screenRect.Bottom - form.Height, formTop);


            if (ScreenPoint.X > screenRect.Width / 2) formLeft = ScreenPoint.X - form.Width;
            else formLeft = ScreenPoint.X;

            formLeft = Math.Max(screenRect.Left, formLeft);
            formLeft = Math.Min(screenRect.Right - form.Width, formLeft);


            form.Top = formTop;
            form.Left = formLeft;
        }

        public static void SetPositionToCenter(this Form form)
        {
            int formLeft;
            int formTop;
            Rectangle screenRect = Screen.PrimaryScreen.WorkingArea;
            formTop = (screenRect.Height - form.Height) /2;
            formLeft = (screenRect.Width - form.Width) / 2;

            form.Top = formTop;
            form.Left = formLeft;
        }
    }
}
