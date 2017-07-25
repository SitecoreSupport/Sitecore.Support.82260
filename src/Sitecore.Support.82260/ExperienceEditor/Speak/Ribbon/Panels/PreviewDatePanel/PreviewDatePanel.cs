namespace Sitecore.Support.ExperienceEditor.Speak.Ribbon.Panels.PreviewDatePanel
{
    using Sitecore.ExperienceEditor.Speak.Ribbon.Panels.PreviewDatePanel;
    using Sitecore.Support.ExperienceEditor.Speak.Ribbon.Requests.PreviewDate;
    using System;
    using System.Web.UI;

    public class PreviewDatePanel : Sitecore.ExperienceEditor.Speak.Ribbon.Panels.PreviewDatePanel.PreviewDatePanel
    {
        protected override void Render(HtmlTextWriter output)
        {
            this.AddAttributes(output);
            output.RenderBeginTag(HtmlTextWriterTag.Div);
            output.Write(new ChangeDayLink(ChangeDayLink.DayChange.Previous).Render());
            output.Write(new Sitecore.Support.ExperienceEditor.Speak.Ribbon.Panels.PreviewDatePanel.DateAndTime().Render());
            output.Write(new ChangeDayLink(ChangeDayLink.DayChange.Next).Render());
            output.RenderEndTag();
        }

        public DateTime Current
        {
            get
            {
                return AddDaysRequest.GetCurrentDate("dummy");
            }
            set
            {
                AddDaysRequest.SetCurrentDate(value, "dummy");
            }
        }
    }
}

