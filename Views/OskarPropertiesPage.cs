using System.Diagnostics;
using Eto.Drawing;
using Eto.Forms;
using Rhino.UI;
using SampleCsEto.Views;

namespace Oskar.Views
{
    class OskarPropertiesPage : ObjectPropertiesPage
    {
        private OskarPropertiesPageControl m_page_control;

        public override string EnglishPageTitle => "Oskar Model Publisher";

        public override System.Drawing.Icon PageIcon(System.Drawing.Size sizeInPixels)
        {
            var icon = Rhino.UI.DrawingUtilities.LoadIconWithScaleDown(
                "Oskar.Resources.OskarIcon.ico",
                sizeInPixels.Width,
                GetType().Assembly);
            return icon;
        }

        public override object PageControl => m_page_control ?? (m_page_control = new OskarPropertiesPageControl());

        public override bool ShouldDisplay(ObjectPropertiesPageEventArgs e)
        {
            Debug.WriteLine("OskarPropertiesPage.ShouldDisplay()");
            return true;
        }

        public override void UpdatePage(ObjectPropertiesPageEventArgs e)
        {
            Debug.WriteLine("OskarPropertiesPage.UpdatePage()");
        }
    }

    class OskarPropertiesPageControl : Panel
    {
        public OskarPropertiesPageControl()
        {
            var hello_button = new Button { Text = "Option1" };
            hello_button.Click += (sender, e) => OnHelloButton();

            var child_button = new Button { Text = "Option2" };
            child_button.Click += (sender, e) => OnChildButton();

            var layout = new DynamicLayout { DefaultSpacing = new Size(5, 5), Padding = new Padding(10) };
            layout.AddSeparateRow(hello_button, null);
            layout.AddSeparateRow(child_button, null);
            layout.Add(null);
            Content = layout;
        }

        /// <summary>
        /// Example of proper way to display a message box
        /// </summary>
        protected void OnHelloButton()
        {
            // Use the Rhino common message box and NOT the Eto MessageBox,
            // the Eto version expects a top level Eto Window as the owner for
            // the MessageBox and will cause problems when running on the Mac.
            // Since this panel is a child of some Rhino container it does not
            // have a top level Eto Window.
            Dialogs.ShowMessage("Oskar Model Publisher", "Placeholder");
        }

        /// <summary>
        /// Sample of how to display a child Eto dialog
        /// </summary>
        protected void OnChildButton()
        {
            var dialog = new Catlet();
            dialog.ShowModal(this);
        }
    }
}
