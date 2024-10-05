using Microsoft.Extensions.DependencyInjection;
using Oskar.Views;
using Rhino;
using Rhino.UI;
using System;
using System.Collections.Generic;

namespace Oskar
{
    ///<summary>
    /// <para>Every RhinoCommon .rhp assembly must have one and only one PlugIn-derived
    /// class. DO NOT create instances of this class yourself. It is the
    /// responsibility of Rhino to create an instance of this class.</para>
    /// <para>To complete plug-in information, please also see all PlugInDescription
    /// attributes in AssemblyInfo.cs (you might need to click "Project" ->
    /// "Show All Files" to see it in the "Solution Explorer" window).</para>
    ///</summary>
    public class OskarPlugin : Rhino.PlugIns.PlugIn
    {
        public static OskarPlugin Instance { get; private set; }

        private ServiceProvider _serviceProvider;        
        
        public OskarPlugin()
        {
            Instance = this;
        }

        // Set up dependency injection
        private void ConfigureServices(bool isDarkMode)
        {
            var services = new ServiceCollection();

            // Register the appropriate style manager based on the theme
            if (isDarkMode)
            {
                services.AddSingleton<IStyleManager, StyleManagerDark>();
            }
            else
            {
                services.AddSingleton<IStyleManager, StyleManagerLight>();
            }

            _serviceProvider = services.BuildServiceProvider();
        }

        // Method to get the IStyleManager instance
        public IStyleManager GetStyleManager()
        {
            return _serviceProvider.GetService<IStyleManager>();
        }

        private bool GetUserThemePreference()
        {
            // Hardcoding preference for now, but could be used to
            // fetch preference from settings, environment variables, etc.
            return true; // Assume dark mode preference by default
        }





        // You can override methods here to change the plug-in behavior on
        // loading and shut down, add options pages to the Rhino _Option command
        // and maintain plug-in wide options in a document.
        //protected override void DocumentPropertiesDialogPages(RhinoDoc doc, List<OptionsDialogPage> pages)
        //{
        //    var page = new Views.SampleCsEtoOptionsPage();
        //    pages.Add(page);
        //}

        //protected override void OptionsDialogPages(List<OptionsDialogPage> pages)
        //{
        //    var page = new Views.SampleCsEtoOptionsPage();
        //    pages.Add(page);
        //}

        //protected override void ObjectPropertiesPages(ObjectPropertiesPageCollection collection)
        //{
        //    var page = new Views.SampleCsEtoPropertiesPage();
        //    collection.Add(page);
        //}
    }
}