using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;
using System.IO;
using APP_MVC02a.Models;
using System.Data.SqlClient;
using System.Data;

namespace APP_MVC02a.Controllers
{
    public class RPedidoController : Controller
    {
        //
        // GET: /RPedido/

        bdpasteleliasEntities2 storeDB = new bdpasteleliasEntities2();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Pedidoxcliente(int idCliente,string fecha1,string fecha2)
        {
            
            SqlConnection con = new SqlConnection("server=.;database=bdpastelelias;UID=sa;PWD=sql");
            DataTable dt = new DataTable();
            DateTime fec1 = Convert.ToDateTime(fecha1);
            DateTime fec2 = Convert.ToDateTime(fecha2);
            try

                {

                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT pe.idpedido,pro.idproducto,pro.nomProducto,pp.precio,pp.cantidad,pp.total,pe.contacto_nom,pe.contacto_ape,pe.contacto_mail,contacto_movil,pe.fechaPedido,pe.fechaentrega,pe.entrega_dir,pe.subTotal,pe.igv,pe.totalpedido,c.nombre as Cliente,d.descrip as Distrito,tc.descrip as 'Comprobante',tp.descrip as 'Tipo Pago',e.descrip as Estado FROM pedido pe inner join Cliente c on pe.idCliente=c.idCliente inner join distrito d on pe.iddistrito=d.iddistrito inner join tipo_compPago tc on pe.idtipo_compPago=tc.idtipo_compPago inner join TIPO_PAGO tp on pe.idtipopago=tp.idtipopago inner join estado e on pe.idestado=e.idestado inner join pedido_productos pp on pe.idpedido=pp.idpedido inner join producto pro on pp.idproducto=pro.idproducto", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);

                }

                catch (Exception ex)

                {

                }



            ReportDocument rpt = new ReportDocument();
           // ReportClass rpt = new ReportClass();
           // rpt.FileName = Server.MapPath("/Reportes/rptPedidos4.rpt");
            rpt.Load(Path.Combine(Server.MapPath("~/Reportes"), "rptPedidos4.rpt"));
            rpt.SetDatabaseLogon("sa", "sql");
           // rpt.Load(); 
           // rpt.SetDataSource(dt);
           // rpt.SetDataSource(from pe in storeDB.pedido
           //                   join c in storeDB.Cliente on pe.idCliente equals c.idCliente
           //                   join d in storeDB.distrito on pe.iddistrito equals d.iddistrito
           //                   join tc in storeDB.tipo_compPago on pe.idtipo_compPago equals tc.idtipo_compPago
           //                   join tp in storeDB.TIPO_PAGO on pe.idtipopago equals tp.idtipopago
           //                   join e in storeDB.estado on pe.idestado equals e.idestado
           //                   join pp in storeDB.pedido_productos on pe.idpedido equals pp.idpedido
            //                  join pro in storeDB.producto on pp.idproducto equals pro.idproducto
           //                   select new {pe.idpedido,pro.idproducto,pro.nomProducto,pp.precio,pp.cantidad,pp.total,pe.contacto_nom,pe.contacto_ape,pe.contacto_mail,pe.contacto_movil,pe.fechaPedido,pe.fechaentrega,pe.entrega_dir,pe.subTotal,pe.igv,pe.totalpedido,Cliente=c.nombre,Distrito=d.descrip,Comprobante=tc.descrip,Tipo_Pago=tp.descrip,Estado=e.descrip});
           // ParameterDiscreteValue idCli = new ParameterDiscreteValue();
          //  idCli.Value = idCliente;
          //  ParameterDiscreteValue fe1 = new ParameterDiscreteValue();
           // fe1.Value = fecha1;
          //  ParameterDiscreteValue fe2 = new ParameterDiscreteValue();
          //  fe2.Value = fecha2;
            rpt.SetParameterValue("@idCliente", idCliente);
            rpt.SetParameterValue("@fecha1", fecha1);
            rpt.SetParameterValue("@fecha2", fecha2);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();

            Stream stream = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf","ReporteDeClientes.pdf");

        }

    }
}
