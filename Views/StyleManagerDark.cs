using Eto.Drawing;
using Eto.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oskar.Views
{
    internal class StyleManagerDark : IStyleManager
    {       
        public Color PrimaryColor => Colors.Navy;
        public Color SecondaryColor => Colors.DarkSlateGray;
        public Color TertiaryColor() => Colors.LightBlue;
        public Color PrimaryTextColor => Colors.AntiqueWhite;
        public Color SecondaryTextColor => Colors.LightGrey;
        public Font PrimaryFont() => new Font(SystemFont.Default, 12);
        public Font SecondaryFont() => new Font(SystemFont.Bold, 12);
        public void ApplyButtonStyle(Button button)
        {
            button.BackgroundColor = Colors.White;
        }
    }
}
