﻿using Eto.Drawing;
using Eto.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oskar.Views
{
    internal class StyleManagerLight : IStyleManager
    {       
        public Color PrimaryColor => Colors.LightBlue;
        public Color SecondaryColor => Colors.LightSlateGray;
        public Color TertiaryColor() => Colors.Navy;
        public Color PrimaryTextColor => Colors.Black;
        public Color SecondaryTextColor => Colors.DarkGray;
        public Font PrimaryFont() => new Font(SystemFont.Default, 12);
        public Font SecondaryFont() => new Font(SystemFont.Bold, 12);
        public void ApplyButtonStyle(Button button)
        {
            button.BackgroundColor = Colors.White;
        }
    }
}
