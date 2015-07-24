using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;
using System.IO;

namespace APP_MVC02a.Views.rptsAspx
{
    public partial class rptPedidoCli : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ReportDocument rpt = new ReportDocument();
            rpt.Load(Path.Combine(Server.MapPath("~/Reportes"), "rptPedidos4.rpt"));
          //  rpt.SetDatabaseLogon("sa", "sql");

            rpt.SetParameterValue("@idCliente", 1);
            rpt.SetParameterValue("@fecha1", "23/06/2015");
            rpt.SetParameterValue("@fecha2", "29/06/2015");
            crvClientes.ReportSource = rpt;
            crvClientes.DataBind();
            
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            ReportDocument rpt = new ReportDocument();
            rpt.Load(Path.Combine(Server.MapPath("~/Reportes"), "rptPedidos4.rpt"));
            rpt.SetDatabaseLogon("sa", "sql");

            rpt.SetParameterValue("@idCliente", 1);
            rpt.SetParameterValue("@fecha1", "23/06/2015");
            rpt.SetParameterValue("@fecha2", "29/06/2015");
            crvClientes.ReportSource = rpt;
            crvClientes.DataBind();


        }
    }
}