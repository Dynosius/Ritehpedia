using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Clanak : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string idKategorije = this.Request.QueryString["idKategorije"];
        string idKolegija = this.Request.QueryString["idKolegija"];
    }
}