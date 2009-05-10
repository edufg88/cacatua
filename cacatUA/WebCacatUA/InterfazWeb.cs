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
            String idioma = (String)Session["idioma"];

            if (idioma != null)
            {
                CultureInfo cultureInfo = new CultureInfo(idioma);
                Thread.CurrentThread.CurrentUICulture = cultureInfo;
                base.InitializeCulture();
            }
        }

        protected void escribir(string cadena)
        {
            const string fic = @"C:\log.txt";
            System.IO.StreamWriter sw = new System.IO.StreamWriter(fic, true);
            sw.WriteLine(cadena);
            sw.Close();
        }

        /// <summary>
        /// Dado un string, elimina todos sus caracteres peligrosos: <, >, =, /, \, etc.
        /// </summary>
        /// <param name="cadena">Cadena que se va a filtrar.</param>
        /// <returns>Devuelve la cadena ya filtrada.</returns>
        public string filtrarCadena(string cadena)
        {
            cadena = cadena.Replace("<", "");
            cadena = cadena.Replace(">", "");
            cadena = cadena.Replace("=", "");
            cadena = cadena.Replace("/", "");
            cadena = cadena.Replace("\\", "");
            return cadena;
        }
    }
}