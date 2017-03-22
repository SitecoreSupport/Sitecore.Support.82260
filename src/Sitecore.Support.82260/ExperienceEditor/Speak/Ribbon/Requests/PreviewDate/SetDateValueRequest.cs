namespace Sitecore.Support.ExperienceEditor.Speak.Ribbon.Requests.PreviewDate
{
    using Newtonsoft.Json.Linq;
    using Sitecore;
    using Sitecore.Configuration;
    using Sitecore.Diagnostics;
    using Sitecore.ExperienceEditor.Speak.Ribbon.Requests.PreviewDate;
    using Sitecore.ExperienceEditor.Speak.Server.Responses;
    using Sitecore.Sites;
    using Sitecore.Web;
    using System;

    public class SetDateValueRequest : Sitecore.ExperienceEditor.Speak.Ribbon.Requests.PreviewDate.SetDateValueRequest
    {
        public override PipelineProcessorResponseValue ProcessRequest()
        {
            string str = base.RequestContext.Value;
            Assert.IsNotNull(str, "Could not get cookie value for requestArgs:{0}", new object[] { base.Args.Data });
            SiteContext context = Factory.GetSite(JObject.Parse(base.Args.Data).GetValue("siteName").ToString()) ?? Context.Site;
            object[] args = new object[] { Settings.Preview.DefaultSite };
            Assert.IsNotNull(context, "Site \"{0}\" not found.", args);
            WebUtil.SetCookieValue(context.GetCookieKey("sc_date"), DateUtil.IsoDateToUtcIsoDate(str));
            return new PipelineProcessorResponseValue();
        }
    }
}

