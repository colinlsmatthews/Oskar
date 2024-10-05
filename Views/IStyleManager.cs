using Eto.Drawing;
using Eto.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oskar.Views
{
    public interface IStyleManager
    {
        Color PrimaryColor { get; }
        Color SecondaryColor { get; }
        Color TertiaryColor { get; }
        Color PrimaryTextColor { get; }
        Color SecondaryTextColor { get; }
        Font PrimaryFont { get; }
        Font SecondaryFont { get; }
        void ApplyButtonStyle(Button button);
    }
}
