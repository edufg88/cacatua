using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Threading;
using System.Globalization;

namespace WebCacatUA
{
    public class InterfazWeb : Page
    {
        protected override void InitializeCulture()
        {

            CultureInfo cultureInfo = new CultureInfo(PaginaMaestra.lenguaje);
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
            base.InitializeCulture();
            if (PaginaMaestra.lenguaje == "es")
                PaginaMaestra.lenguaje = "en";
            else
                PaginaMaestra.lenguaje = "es";
        }
    }
}