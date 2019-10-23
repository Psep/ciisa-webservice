using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Descripción breve de AtencionRepository
/// </summary>
public class AtencionRepository : BaseRepository
{
    public List<Atencion> Find(DateTime fechaInicio, DateTime fechaTermino)
    {
        SqlConnection conn = this.GetConnection();
        SqlCommand cmd = new SqlCommand("sp_findAllAtencion", connection: conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@fechaInicio", SqlDbType.Date).Value = fechaInicio;
        cmd.Parameters.Add("@fechaTermino", SqlDbType.Date).Value = fechaTermino;
        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader();
        List<Atencion> atenciones = new List<Atencion>();

        while (reader.Read())
        {
            Atencion atencion = new Atencion();
            atencion.nombreDoctor = this.GetString(reader, 0);
            atencion.boxOcupado = reader.GetInt32(1);
            atencion.fechaAtencion = reader.GetDateTime(2);
            atencion.pacientesAtendidos = reader.GetInt32(3);
            atenciones.Add(atencion);
        }

        this.CloseAll(conn, reader);

        return atenciones;
    }
}