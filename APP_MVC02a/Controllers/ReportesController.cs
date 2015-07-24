using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APP_MVC02a.Models;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using System.IO;

namespace APP_MVC02a.Controllers
{
    public class ReportesController : Controller
    {
        bdpasteleliasEntities2 db = new bdpasteleliasEntities2();

        public ActionResult PedidoxCliente() 
        {
            ViewBag.idCliente = new SelectList(db.Cliente, "idCliente", "nombre");
            
            return View();
        }

  /*      [HttpPost]
        public ActionResult PedidoxCliente(int idCliente, string fecha1, string fecha2)
        {
            ReportDocument rpt = new ReportDocument();
          
            rpt.Load(Path.Combine(Server.MapPath("~/Reportes"), "rptPedidos4.rpt"));
            rpt.SetDatabaseLogon("sa", "sql");

            rpt.SetParameterValue("@idCliente", idCliente);
            rpt.SetParameterValue("@fecha1", fecha1);
            rpt.SetParameterValue("@fecha2", fecha2);

            return new CrystalReportPdfResult(rpt);
        }*/

        public ActionResult PedidoxCliente1(int idCliente, string fecha1, string fecha2)
        {
            ReportDocument rpt = new ReportDocument();

            rpt.Load(Path.Combine(Server.MapPath("~/Reportes"), "rptPedidos4.rpt"));
            rpt.SetDatabaseLogon("sa", "sql");

            rpt.SetParameterValue("@idCliente", idCliente);
            rpt.SetParameterValue("@fecha1", fecha1);
            rpt.SetParameterValue("@fecha2", fecha2);

            return new pdfToCrystalReport(rpt);
        }

        public ActionResult PedidoxProducto()
        {
            ViewBag.idProducto = new SelectList(db.producto, "idproducto", "nomProducto");
            return View();
        }

        /*      [HttpPost]
              public ActionResult PedidoxProducto(int idProducto, string fecha1, string fecha2)
              {
                  ReportDocument rpt = new ReportDocument();

                  rpt.Load(Path.Combine(Server.MapPath("~/Reportes"), "rptPedidoxProducto.rpt"));
                  rpt.SetDatabaseLogon("sa", "sql");

                  rpt.SetParameterValue("@idproducto", idProducto);
                  rpt.SetParameterValue("@fecha1", fecha1);
                  rpt.SetParameterValue("@fecha2", fecha2);

                  return new CrystalReportPdfResult(rpt);

                  PARTE DE CODIGO PARA DESCARGAR EL PDF----
               * Stream stream = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                  stream.Seek(0, SeekOrigin.Begin);
                  return File(stream, "application/pdf", "ReporteDePedidoxProducto.pdf");
         
              }*/
        public ActionResult PedidoxProducto1(int idProducto, string fecha1, string fecha2)
        {
            ReportDocument rpt = new ReportDocument();

            rpt.Load(Path.Combine(Server.MapPath("~/Reportes"), "rptPedidoxProducto.rpt"));
            rpt.SetDatabaseLogon("sa", "sql");

            rpt.SetParameterValue("@idproducto", idProducto);
            rpt.SetParameterValue("@fecha1", fecha1);
            rpt.SetParameterValue("@fecha2", fecha2);

            return new pdfToCrystalReport(rpt);
        }

        public ActionResult PedidoxEstado()
        {
            ViewBag.idEstado = new SelectList(db.estado.Where(e =>e.cnPedido==1), "idestado", "descrip");

            return View();
        }

        public ActionResult PedidoxEstado1(int idEstado, string fecha1, string fecha2)
        {
            ReportDocument rpt = new ReportDocument();

            rpt.Load(Path.Combine(Server.MapPath("~/Reportes"), "rptPedidoxEstado.rpt"));
            rpt.SetDatabaseLogon("sa", "sql");

            rpt.SetParameterValue("@idEstado", idEstado);
            rpt.SetParameterValue("@fecha1", fecha1);
            rpt.SetParameterValue("@fecha2", fecha2);

            return new pdfToCrystalReport(rpt);
        }

      
        public ActionResult VentasxMes()
        {
            ViewBag.totalpedido = new SelectList(db.pedido, "TOTAL DEL MES");

            return View();
        }
        public ActionResult VentasxMes1(int totalpedido, string fecha1, string fecha2)
        {
            ReportDocument rpt = new ReportDocument();

            rpt.Load(Path.Combine(Server.MapPath("~/Reportes"), "VentasxMes.rpt"));
            rpt.SetDatabaseLogon("sa", "sql");

            rpt.SetParameterValue("@totalpedido", totalpedido);
            rpt.SetParameterValue("@fecha1", fecha1);
            rpt.SetParameterValue("@fecha2", fecha2);

            return new pdfToCrystalReport(rpt);

        }

        public ActionResult VentasxFecha()
        {
            ViewBag.ventasxfecha = new SelectList(db.pedido, "VENTAS");

            return View();
        }
        public ActionResult VentasxFecha1(string fecha1, string fecha2)
        {
            ReportDocument rpt = new ReportDocument();

            rpt.Load(Path.Combine(Server.MapPath("~/Reportes"), "VentaxFecha.rpt"));
            rpt.SetDatabaseLogon("sa", "sql");

            rpt.SetParameterValue("@fecha1", fecha1);
            rpt.SetParameterValue("@fecha2", fecha2);

            return new pdfToCrystalReport(rpt);

        }

        //Romario
        public ActionResult NProductos()
        {

            return View();
        }

        public ActionResult NProductos1(int numTop, string startDate)
        {
            string mes = startDate.Substring(0, 2);
            string año = startDate.Substring(3, 4);
            Console.WriteLine(mes);
            Console.WriteLine(año);



            ReportDocument rpt = new ReportDocument();

            rpt.Load(Path.Combine(Server.MapPath("~/Reportes"), "rtpRoma01.rpt"));
            rpt.SetDatabaseLogon("sa", "sql");

            rpt.SetParameterValue("@cantLista", numTop);
            rpt.SetParameterValue("@mes", mes);
            rpt.SetParameterValue("@año", año);

            return new pdfToCrystalReport(rpt);
        }


        public ActionResult NClientes()
        {

            return View();
        }

        public ActionResult NClientes1(int numTop, string startDate)
        {
            string mes = startDate.Substring(0, 2);
            string año = startDate.Substring(3, 4);
            Console.WriteLine(mes);
            Console.WriteLine(año);



            ReportDocument rpt = new ReportDocument();

            rpt.Load(Path.Combine(Server.MapPath("~/Reportes"), "rptNClientes.rpt"));
            rpt.SetDatabaseLogon("sa", "sql");

            rpt.SetParameterValue("@cantLista", numTop);
            rpt.SetParameterValue("@mes", mes);
            rpt.SetParameterValue("@año", año);

            return new pdfToCrystalReport(rpt);
        }

        //REPORTE SDE LUIS ULTIMA

        public ActionResult TotalxMes()
        {
            ViewBag.pedido = new SelectList(db.pedido);
            return View();
        }

        public ActionResult TotalxMes1(string mes, string año)
        {
            ReportDocument rpt = new ReportDocument();

            rpt.Load(Path.Combine(Server.MapPath("~/Reportes"), "rptTotalxMes.rpt"));
            rpt.SetDatabaseLogon("sa", "sql");

            rpt.SetParameterValue("@mes", mes);
            rpt.SetParameterValue("@año", año);

            return new pdfToCrystalReport(rpt);
        }


        public ActionResult VentasxRango()
        {
            ViewBag.pedido = new SelectList(db.pedido);
            return View();
        }

        public ActionResult VentasxRango1(string fecha1, string fecha2)
        {
            ReportDocument rpt = new ReportDocument();

            rpt.Load(Path.Combine(Server.MapPath("~/Reportes"), "rptVentasxRango.rpt"));
            rpt.SetDatabaseLogon("sa", "sql");

            rpt.SetParameterValue("@fecha1", fecha1);
            rpt.SetParameterValue("@fecha2", fecha2);

            return new pdfToCrystalReport(rpt);
        }

        //BRAYAN REPORTES

        public ActionResult CategoriaxProducto()
        {
            ViewBag.idcategoriaProd = new SelectList(db.categoriaProd, "idcategoriaProd", "descrip");

            return View();
        }
        public ActionResult CategoriaxProducto1(int idcategoriaProd)
        {
            ReportDocument rpt = new ReportDocument();

            rpt.Load(Path.Combine(Server.MapPath("~/Reportes"), "rptProductoxCategoria.rpt"));
            rpt.SetDatabaseLogon("sa", "sql");

            rpt.SetParameterValue("@idcategoriaProd", idcategoriaProd);


            return new pdfToCrystalReport(rpt);
        }
        public ActionResult RegistroxCliente()
        {
            ViewBag.idCliente = new SelectList(db.Cliente, "idCliente", "nombre");
            return View();
        }
        public ActionResult RegistroxCliente1(int idCliente, string fecha1, string fecha2)
        {
            ReportDocument rpt = new ReportDocument();

            rpt.Load(Path.Combine(Server.MapPath("~/Reportes"), "rptClientes2.rpt"));
            rpt.SetDatabaseLogon("sa", "sql");

            rpt.SetParameterValue("@idCliente", idCliente);
            rpt.SetParameterValue("@fecha1", fecha1);
            rpt.SetParameterValue("@fecha2", fecha2);

            return new pdfToCrystalReport(rpt);
        }


    }
}
