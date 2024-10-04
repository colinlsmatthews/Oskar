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

            var oskar_button = new Button { Text = "See Oskar", Image =  new Bitmap("../Resources/OskarIcon.png")};
            oskar_button.Click += (sender, e) => OnOskarButton();

            var other_button = new Button { Text = "Some other thing", TextColor = Eto.Drawing.Color.FromRgb(255) };
            other_button.Click += (sender, e) => OnOtherButton();
        }

        public void OnOskarButton()
        {
            var dialog = new Catlet();
            dialog.ShowModal(this);
        }

        #region IPanel methods
        protected void OnOtherButton()
        {
            Dialogs.ShowMessage("Some other thing here.", Title);
        }

        public void PanelShown(uint documentSerialNumber, ShowPanelReason reason)
        {
            throw new NotImplementedException();
        }

        public void PanelHidden(uint documentSerialNumber, ShowPanelReason reason)
        {
            throw new NotImplementedException();
        }

        public void PanelClosing(uint documentSerialNumber, bool onCloseDocument)
        {
            throw new NotImplementedException();
        }
        #endregion IPanel methods
    }
}