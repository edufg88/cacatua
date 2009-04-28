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

    protected void Page_Load(object sender, EventArgs e)
    {
           
    }

    protected void DropDownList_Idiomas_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["idioma"] = DropDownList_Idiomas.SelectedValue.ToString();
        
        //Refrescar la pagina
        /*string[] arrResult = HttpContext.Current.Request.RawUrl.Split('/');
        String result = arrResult[arrResult.GetUpperBound(0)];
        arrResult = result.Split('?');
        Response.Redirect(arrResult[arrResult.GetLowerBound(0)]);*/
    }
}
