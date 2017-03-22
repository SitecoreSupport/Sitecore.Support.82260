namespace Sitecore.Support.ExperienceEditor.Speak.Ribbon.Panels
{
    using Sitecore.Collections;
    using Sitecore.ExperienceEditor.Speak.Ribbon;
    using Sitecore.Shell.Web.UI.WebControls;
    using Sitecore.Support.ExperienceEditor.Speak.Ribbon.Panels.PreviewDatePanel;
    using System;

    public class DefaultPreviewDatePanel : CustomRibbonPanel
    {
        private static readonly SafeDictionary<Type, object> DatePanels;

        static DefaultPreviewDatePanel()
        {
            SafeDictionary<Type, object> dictionary = new SafeDictionary<Type, object> {
                { 
                    typeof(RibbonComponentControlBase),
                    new Sitecore.Support.ExperienceEditor.Speak.Ribbon.Panels.PreviewDatePanel.PreviewDatePanel()
                },
                { 
                    typeof(RibbonPanel),
                    new Sitecore.Support.ExperienceEditor.Speak.Ribbon.Panels.PreviewDatePanel.PreviewDatePanel()
                }
            };
            DatePanels = dictionary;
        }

        protected override SafeDictionary<Type, object> Panels
        {
            get
            {
                return DatePanels;
            }
        }
    }
}

