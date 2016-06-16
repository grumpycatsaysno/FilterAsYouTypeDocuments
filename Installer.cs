using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitefinityWebApp.CustomWidgets.DownloadList;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Modules.Pages.Configuration;
using Telerik.Sitefinity.Services;

namespace SitefinityWebApp
{
    /// <summary>
    /// Public class for registering custom components in Sitefinity.
    /// </summary>
    public class Installer
    {
        /// <summary>
        /// Method that is called by ASP.NET before application start to install the custom controls on the site
        /// </summary>
        public static void PreApplicationStart()
        {
            SystemManager.ApplicationStart += SystemManager_ApplicationStart;
        }

        private static void SystemManager_ApplicationStart(object sender, EventArgs e)
        {
            RegisterSectionInBackend(Installer.pageControlsToolboxName, Installer.CustomControlSectioName);

            RegisterControlInToolbox(Installer.pageControlsToolboxName,
                      Installer.CustomControlSectioName, 
                      typeof(CustomDownloadListView).AssemblyQualifiedName, 
                      "CustomDownloadList Widget");
        }

        /// <summary>
        /// Registers the control in toolbox.
        /// </summary>
        /// <param name="toolboxName">Name of the toolbox.</param>
        /// <param name="sectionName">Name of the section.</param>
        /// <param name="controlType">Type of the control.</param>
        /// <param name="controlName">Name of the control.</param>
        private static void RegisterControlInToolbox(string toolboxName, string sectionName, string controlType, string controlName)
        {
            RegisterControlInToolbox(toolboxName, sectionName, controlType, controlName, string.Empty);
        }

        /// <summary>
        /// Registers the section in back-end.
        /// </summary>
        /// <param name="toolboxName">Name of the toolbox.</param>
        /// <param name="sectionName">Name of the section.</param>
        private static void RegisterSectionInBackend(string toolboxName, string sectionName)
        {
            var configManager = ConfigManager.GetManager();
            var config = configManager.GetSection<ToolboxesConfig>();

            var controls = config.Toolboxes[toolboxName];

            var section = controls.Sections.Where<ToolboxSection>(e => e.Name == sectionName).FirstOrDefault();

            if (section == null)
            {
                configManager.Provider.SuppressSecurityChecks = true;
                section = new ToolboxSection(controls.Sections)
                {
                    Name = sectionName,
                    Title = sectionName,
                    Description = sectionName,
                    ResourceClassId = string.Empty
                };
                controls.Sections.Add(section);
                configManager.SaveSection(config);

                configManager.Provider.SuppressSecurityChecks = false;
            }
        }

        /// <summary>
        /// Registers the control in toolbox.
        /// </summary>
        /// <param name="toolboxName">Name of the toolbox.</param>
        /// <param name="sectionName">Name of the section.</param>
        /// <param name="controlType">Type of the control.</param>
        /// <param name="controlName">Name of the control.</param>
        /// <param name="layoutTemplate">The layout template.</param>
        private static void RegisterControlInToolbox(string toolboxName, string sectionName, string controlType, string controlName, string layoutTemplate)
        {
            var configManager = ConfigManager.GetManager();
            configManager.Provider.SuppressSecurityChecks = true;
            var config = configManager.GetSection<ToolboxesConfig>();

            var controls = config.Toolboxes[toolboxName];
            var section = controls.Sections.Where<ToolboxSection>(e => e.Name == sectionName).FirstOrDefault();

            if (section != null && !section.Tools.Any<ToolboxItem>(e => e.Name == controlName))
            {
                var tool = new ToolboxItem(section.Tools)
                {
                    Name = controlName,
                    Title = controlName,
                    Description = controlName,
                    ControlType = controlType,
                };

                if (!string.IsNullOrEmpty(layoutTemplate))
                {
                    tool.LayoutTemplate = layoutTemplate;
                }
                section.Tools.Add(tool);

                configManager.SaveSection(config);
            }

            configManager.Provider.SuppressSecurityChecks = false;
        }

        #region Private fields and constants

        private const string pageControlsToolboxName = "PageControls";
        private const string CustomControlSectioName = "CustomWidgets";

        #endregion
    }
}