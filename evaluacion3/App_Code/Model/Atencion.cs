using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Atencion
/// </summary>
public class Atencion
{
    public int idAtencion { set; get; }
    public string nombreDoctor { set; get; }
    public int boxOcupado { set; get; }
    public DateTime fechaAtencion { set; get; }
    public int pacientesAtendidos { set; get; }

    public Atencion()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
}