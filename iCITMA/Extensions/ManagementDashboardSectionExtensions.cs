namespace MOROPO.CITMA.CMG.iCITMA.Extensions
{
    public static class ManagementDashboardSectionExtensions
    {
        public static Microsoft.AspNetCore.Html.HtmlString ToIconographyHtmlString(this SAPRESSC.Core.Web.Backend.Models.View.ManagementDashboardSectionViewModel target)
        {
            if (target.Controller == "users") return new Microsoft.AspNetCore.Html.HtmlString("<span class=\"mdi mdi-account\"></span>");

            if (target.Controller == "roles") return new Microsoft.AspNetCore.Html.HtmlString("<span class=\"mdi mdi-account-group\"></span>");

            if (target.Controller == "traces") return new Microsoft.AspNetCore.Html.HtmlString("<span class=\"mdi mdi-foot-print\"></span>");

            if (target.Controller == "impactindicators") return new Microsoft.AspNetCore.Html.HtmlString("<span class=\"mdi mdi-palette\"></span>");

            if (target.Controller == "projectstates") return new Microsoft.AspNetCore.Html.HtmlString("<span class=\"mdi mdi-palette\"></span>");

            if (target.Controller == "researchareas") return new Microsoft.AspNetCore.Html.HtmlString("<span class=\"mdi mdi-palette\"></span>");

            if (target.Controller == "OutputKinds") return new Microsoft.AspNetCore.Html.HtmlString("<span class=\"mdi mdi-palette\"></span>");

            if (target.Controller == "SceneryKinds") return new Microsoft.AspNetCore.Html.HtmlString("<span class=\"mdi mdi-palette\"></span>");

            if (target.Controller == "FundingSources") return new Microsoft.AspNetCore.Html.HtmlString("<span class=\"mdi mdi-palette\"></span>");

            if (target.Controller == "researchercategories") return new Microsoft.AspNetCore.Html.HtmlString("<span class=\"mdi mdi-palette\"></span>");

            if (target.Controller == "teachingcategories") return new Microsoft.AspNetCore.Html.HtmlString("<span class=\"mdi mdi-palette\"></span>");

            if (target.Controller == "projectcategories") return new Microsoft.AspNetCore.Html.HtmlString("<span class=\"mdi mdi-palette\"></span>");

            if (target.Controller == "programcategories") return new Microsoft.AspNetCore.Html.HtmlString("<span class=\"mdi mdi-palette\"></span>");

            if (target.Controller == "states") return new Microsoft.AspNetCore.Html.HtmlString("<span class=\"mdi mdi-account\"></span>");

            if (target.Controller == "municipalities") return new Microsoft.AspNetCore.Html.HtmlString("<span class=\"mdi mdi-account\"></span>");

            return new Microsoft.AspNetCore.Html.HtmlString("<span class=\"mdi mdi-toy-brick-outline\"></span>");
        }
    }
}
