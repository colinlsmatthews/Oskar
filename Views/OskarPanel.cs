using System;
using Eto.Drawing;
using Eto.Forms;
using Rhino.UI;
using SampleCsEto.Views;

namespace Oskar.Views
{
    [System.Runtime.InteropServices.Guid("0E86A44C-5837-4371-A498-B2B6231F560E")]
    public class OskarPanel : Panel, IPanel
    {
        readonly uint m_document_sn = 0;

        public static System.Guid PanelId => typeof(OskarPanel).GUID;

        public string Title { get; }

        public OskarPanel(uint documentSerialNumber)
        {
            m_document_sn = documentSerialNumber;

            Title = GetType().Name;

            var oskar_button = new Button { Text = "See Oskar", Image =  new Bitmap("C:\\Users\\Colin.Matthews\\source\\repos\\Oskar\\Resources\\OskarIcon.png") };
            oskar_button.Click += (sender, e) => OnOskarButton();

            var other_button = new Button { Text = "Some other thing", TextColor = Eto.Drawing.Color.FromRgb(0xFF0000) };
            other_button.Click += (sender, e) => OnOtherButton();

            var document_sn_label = new Label { Text = $"Document serial number: {documentSerialNumber}" };

            var layout = new DynamicLayout { DefaultSpacing = new Size(20, 20), Padding = new Padding(10) };
            layout.AddSeparateRow(oskar_button, null);
            layout.AddSeparateRow(other_button, null);
            layout.AddSeparateRow(document_sn_label, null);
            layout.Add(null);
            Content = layout;
        }

        public void OnOskarButton()
        {
            var dialog = new Catlet();
            dialog.ShowModal(this);
        }
        protected void OnOtherButton()
        {
            Dialogs.ShowMessage("Some other thing here.", Title);
        }

        #region IPanel methods
        public void PanelShown(uint documentSerialNumber, ShowPanelReason reason)
        {
            // Called when the panel tab is made visible, in Mac Rhino this will happen
            // for a document panel when a new document becomes active, the previous
            // documents panel will get hidden and the new current panel will get shown.
            Rhino.RhinoApp.WriteLine($"Panel shown for document {documentSerialNumber}, this serial number {m_document_sn} should be the same");
        }

        public void PanelHidden(uint documentSerialNumber, ShowPanelReason reason)
        {
            // Called when the panel tab is hidden, in Mac Rhino this will happen
            // for a document panel when a new document becomes active, the previous
            // documents panel will get hidden and the new current panel will get shown.
            Rhino.RhinoApp.WriteLine($"Panel hidden for document {documentSerialNumber}, this serial number {m_document_sn} should be the same");
        }

        public void PanelClosing(uint documentSerialNumber, bool onCloseDocument)
        {
            // Called when the document or panel container is closed/destroyed
            Rhino.RhinoApp.WriteLine($"Panel closing for document {documentSerialNumber}, this serial number {m_document_sn} should be the same");
        }
        #endregion IPanel methods
    }
}