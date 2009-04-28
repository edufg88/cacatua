using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

public partial class PaginaMaestra : System.Web.UI.MasterPage
{

    public static String lenguaje = "en";

    public string Lenguaje
    {
        get { return lenguaje; }
        set { lenguaje = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}
