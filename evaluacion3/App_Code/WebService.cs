using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Services;

/// <summary>
/// Descripción breve de WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.ComponentModel.ToolboxItem(false)]
public class WebService : System.Web.Services.WebService
{
    [WebMethod]
    public string GenerarLog(DateTime fechaInicio, DateTime fechaTermino)
    {
        AtencionRepository repository = new AtencionRepository();
        List<Atencion> atenciones = repository.Find(fechaInicio, fechaTermino);
        StringBuilder builder = new StringBuilder();
        builder.AppendLine(
                String.Format("'{0}';'{1}';'{2}';'{3}'",
                    "Nombre Completo Doctor", "Box Ocupado", "Fecha de Atencion", "Cantidad de pacientes atendiendo"));

        foreach (Atencion atencion in atenciones)
        {
            builder.AppendLine(
                String.Format("'{0}';'{1}';'{2}';'{3}'",
                    atencion.nombreDoctor, atencion.boxOcupado, atencion.fechaAtencion, atencion.pacientesAtendidos));
        }

        byte[] data = new ASCIIEncoding().GetBytes(builder.ToString());

        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.ContentType = "text/csv;charset=utf-8";
        HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=export.csv");
        HttpContext.Current.Response.OutputStream.Write(data, 0, data.Length);
        HttpContext.Current.Response.End();

        return builder.ToString();
    }

}
