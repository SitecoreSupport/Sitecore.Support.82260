namespace Sitecore.Support.ExperienceEditor.Speak.Ribbon.Requests.PreviewDate
{
  using Newtonsoft.Json.Linq;
  using Sitecore;
  using Sitecore.Configuration;
  using Sitecore.Diagnostics;
  using Sitecore.ExperienceEditor.Speak.Server.Contexts;
  using Sitecore.ExperienceEditor.Speak.Server.Requests;
  using Sitecore.ExperienceEditor.Speak.Server.Responses;
  using Sitecore.Sites;
  using Sitecore.Web;
  using System;

  public class AddDaysRequest : PipelineProcessorRequest<IntegerContext>
    {
        public static DateTime GetCurrentDate(string dataFromJson)
        {
            if (!dataFromJson.Equals("dummy"))
            {
                SiteContext context = Factory.GetSite(JObject.Parse(dataFromJson).GetValue("siteName").ToString()) ?? Sitecore.Context.Site;
                string str = WebUtil.GetCookieValue(context.GetCookieKey("sc_date"));
                if (string.IsNullOrEmpty(str))
                {
                    return DateTime.UtcNow;
                }
                return DateUtil.ToUniversalTime(DateUtil.IsoDateToDateTime(str));
            }
            SiteRequest request = Sitecore.Context.Request;
            string siteName = request.QueryString["pagesite"];
            if (siteName == null)
            {
                siteName = request.QueryString["sc_pagesite"] ?? Settings.Preview.DefaultSite;
            }
            SiteContext context2 = Factory.GetSite(siteName) ?? Factory.GetSite(siteName);
            string cookieValue = WebUtil.GetCookieValue(context2.GetCookieKey("sc_date"));
            if (string.IsNullOrEmpty(cookieValue))
            {
                return DateTime.UtcNow;
            }
            return DateUtil.ToUniversalTime(DateUtil.IsoDateToDateTime(cookieValue));
        }

        public override PipelineProcessorResponseValue ProcessRequest()
        {
            SetCurrentDate(GetCurrentDate(base.Args.Data).AddDays((double) base.RequestContext.Value), base.Args.Data);
            return new PipelineProcessorResponseValue();
        }

        public static void SetCurrentDate(DateTime value, string dataFromJson)
        {
            if (!dataFromJson.Equals("dummy"))
            {
                SiteContext context = Factory.GetSite(JObject.Parse(dataFromJson).GetValue("siteName").ToString()) ?? Sitecore.Context.Site;
                object[] args = new object[] { Settings.Preview.DefaultSite };
                Assert.IsNotNull(context, "Site \"{0}\" not found.", args);
                WebUtil.SetCookieValue(context.GetCookieKey("sc_date"), DateUtil.ToIsoDate(DateUtil.ToUniversalTime(value)));
            }
            else
            {
                SiteRequest request = Sitecore.Context.Request;
                string siteName = request.QueryString["pagesite"];
                if (siteName == null)
                {
                    siteName = request.QueryString["sc_pagesite"] ?? Settings.Preview.DefaultSite;
                }
                SiteContext context2 = Factory.GetSite(siteName) ?? Sitecore.Context.Site;
                object[] objArray2 = new object[] { Settings.Preview.DefaultSite };
                Assert.IsNotNull(context2, "Site \"{0}\" not found.", objArray2);
                WebUtil.SetCookieValue(context2.GetCookieKey("sc_date"), DateUtil.ToIsoDate(DateUtil.ToUniversalTime(value)));
            }
        }
    }
}

