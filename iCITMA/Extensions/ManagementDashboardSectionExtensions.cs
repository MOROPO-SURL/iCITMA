namespace MOROPO.CITMA.CMG.iCITMA.Extensions
{
    public static class ManagementDashboardSectionExtensions
    {
        public static Microsoft.AspNetCore.Html.HtmlString ToIconographyHtmlString(this Framework.Guama.Core.Presentation.Web.Backend.Models.View.ManagementDashboardSectionViewModel target)
        {
            if (target.Controller == "users") return new Microsoft.AspNetCore.Html.HtmlString("<span class=\"mdi mdi-account\"></span>");

            if (target.Controller == "roles") return new Microsoft.AspNetCore.Html.HtmlString("<span class=\"mdi mdi-account-group\"></span>");

            if (target.Controller == "traces") return new Microsoft.AspNetCore.Html.HtmlString("<span class=\"mdi mdi-timeline-clock\"></span>");

            if (target.Controller == "impactindicators") return new Microsoft.AspNetCore.Html.HtmlString("<span class=\"mdi mdi-gauge\"></span>");

            if (target.Controller == "projectstates") return new Microsoft.AspNetCore.Html.HtmlString("<span class=\"mdi mdi-progress-clock\"></span>");

            if (target.Controller == "researchareas") return new Microsoft.AspNetCore.Html.HtmlString("<span class=\"mdi mdi-bullseye-arrow\"></span>");

            if (target.Controller == "outputkinds") return new Microsoft.AspNetCore.Html.HtmlString("<span class=\"mdi mdi-arrow-decision\"></span>");

            if (target.Controller == "scenerykinds") return new Microsoft.AspNetCore.Html.HtmlString("<span class=\"mdi mdi-wallpaper\"></span>");

            if (target.Controller == "fundingsources") return new Microsoft.AspNetCore.Html.HtmlString("<span class=\"mdi mdi-cash-multiple\"></span>");

            if (target.Controller == "researchercategories") return new Microsoft.AspNetCore.Html.HtmlString("<span class=\"mdi mdi-flask-outline\"></span>");

            if (target.Controller == "teachingcategories") return new Microsoft.AspNetCore.Html.HtmlString("<span class=\"mdi mdi-school-outline\"></span>");

            if (target.Controller == "projectcategories") return new Microsoft.AspNetCore.Html.HtmlString("<span class=\"mdi mdi-settings-outline\"></span>");

            if (target.Controller == "programcategories") return new Microsoft.AspNetCore.Html.HtmlString("<span class=\"mdi mdi-folder-settings-variant-outline\"></span>");

            if (target.Controller == "keywords") return new Microsoft.AspNetCore.Html.HtmlString("<span class=\"mdi mdi-tag-text\"></span>");

            if (target.Controller == "states") return new Microsoft.AspNetCore.Html.HtmlString("<span class=\"mdi mdi-sign-text\"></span>");

            if (target.Controller == "municipalities") return new Microsoft.AspNetCore.Html.HtmlString("<span class=\"mdi mdi-sign-direction\"></span>");

            if (target.Controller == "regions") return new Microsoft.AspNetCore.Html.HtmlString("<span class=\"mdi mdi-earth-box\"></span>");

            if (target.Controller == "ODSIndicators") return new Microsoft.AspNetCore.Html.HtmlString("<span class=\"mdi mdi-chart-donut-variant\"></span>");

            if (target.Controller == "institutions") return new Microsoft.AspNetCore.Html.HtmlString("<span class=\"mdi mdi-bank\"></span>");

            if (target.Controller == "persons") return new Microsoft.AspNetCore.Html.HtmlString("<span class=\"mdi mdi-face\"></span>");

            if (target.Controller == "traces") return new Microsoft.AspNetCore.Html.HtmlString("<span class=\"mdi mdi-foot-print\"></span>");

            if (target.Controller == "programs") return new Microsoft.AspNetCore.Html.HtmlString("<span class=\"mdi mdi-folder-settings-variant\"></span>");           

            if (target.Controller == "projects") return new Microsoft.AspNetCore.Html.HtmlString("<span class=\"mdi mdi-settings\"></span>");

            return new Microsoft.AspNetCore.Html.HtmlString("<span class=\"mdi mdi-toy-brick-outline\"></span>");
        }
    }
}
