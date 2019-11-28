using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoAudioMerge
{
    public class TextAttribute : Attribute
    {
        public string Text;
        public TextAttribute(string text)
        {
            Text = text;
        }
    }

}
