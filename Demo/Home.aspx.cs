using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;
using System.Resources;
using System.Threading;
using System.Reflection;

namespace Demo
{
    public partial class Home : System.Web.UI.Page
    {
        ResourceManager rm;
        CultureInfo ci;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["Language"] = "en-US";
            //if (!IsPostBack)
            //{
            //    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            //    rm = new ResourceManager("Resources.Home.aspx.resx", System.Reflection.Assembly.Load("App_LocalResources"));
            //    ci = Thread.CurrentThread.CurrentCulture;
            //    LoadString(ci);
            //}
            //else
            //{
            //    rm = new ResourceManager("Resources.Home.aspx.resx", System.Reflection.Assembly.Load("App_LocalResources")); ci = Thread.CurrentThread.CurrentCulture;
            //    LoadString(ci);
            //}


        }

        
        protected void Ar_Click(object sender, EventArgs e)
        {
           

           
            LblHeader.Text = Demo.App_LocalResources.Resource1.ArabicHeader;
            
            

            





        }

        protected void EN_Click(object sender, EventArgs e)
        {
            LblHeader.Text = Demo.App_LocalResources.Home_aspx.LblHeaderResource_Text;
        }
    }
}