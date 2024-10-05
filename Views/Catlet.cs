using Eto.Drawing;
using Eto.Forms;
using Rhino.UI.Forms;

namespace SampleCsEto.Views
{
    class Catlet : CommandDialog
    {
        public Catlet()
        {
            Padding = new Padding(10);
            Title = "Oskar";
            Resizable = true;
            Content = new StackLayout()
            {
                Padding = new Padding(0),
                Spacing = 8,
                Items =
                {
                    new Label { Text = "This is Oskar!" },
                    new ImageView { Image = new Bitmap("C:\\Users\\Colin.Matthews\\source\\repos\\Oskar\\Resources\\OskarIcon.png"), ToolTip = "Oskar" }
                }
            };
        }
    }
}
