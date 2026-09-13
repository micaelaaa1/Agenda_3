using System;
using MySql.Data.MySqlClient;
using Agenda3.Entidades;

namespace SolucionCapas.Datos
{
    public class ContactoDatos
    {
        private string _conexionString =
            "Server=localhost;Database=agenda;Uid=root;Pwd=;";

        public Contacto BuscarPorDni(string dni)
        {
            string query = @"
                SELECT 
                    c.DNI,
                    c.Apellido,
                    c.Nombres,
                    c.Calle,
                    c.Depto,
                    c.Piso,
                    c.Ciudad,
                    c.Telefono,
                    c.Email,
                    c.CUIL_CUIT,
                    c.FechaAlta,
                    c.EstadoCivil,
                    c.Nacionalidad,
                    c.Provincia,
                    c.CodigoPostal,
                    c.Barrio,
                    c.TelefonoAlternativo,
                    c.Instagram,
                    c.ProfesionOcupacion,
                    c.EmpresaLugarTrabajo,
                    c.NivelEstudios,
                    c.Estado,
                    c.MetodoPagoPreferido,
                    c.Observaciones,

                    cc.Id AS CuentaId,
                    cc.PersonaId,
                    cc.FechaApertura,
                    cc.LimiteCredito,
                    cc.EstadoCredito

                FROM contactos c
                LEFT JOIN CuentaCte cc 
                    ON c.DNI = cc.PersonaId
                WHERE c.DNI = @DNI";

            using (MySqlConnection conexion =
                   new MySqlConnection(_conexionString))
            {
                MySqlCommand comando =
                    new MySqlCommand(query, conexion);

                comando.Parameters.AddWithValue("@DNI", dni);

                conexion.Open();

                using (MySqlDataReader reader =
                       comando.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Contacto contacto = new Contacto();

                        contacto.DNI = reader["DNI"].ToString();
                        contacto.Apellido = reader["Apellido"].ToString();
                        contacto.Nombres = reader["Nombres"].ToString();
                        contacto.Calle = reader["Calle"].ToString();
                        contacto.Depto = reader["Depto"].ToString();
                        contacto.Piso = reader["Piso"].ToString();
                        contacto.Ciudad = reader["Ciudad"].ToString();
                        contacto.Telefono = reader["Telefono"].ToString();
                        contacto.Email = reader["Email"].ToString();
                        contacto.CUIL_CUIT = reader["CUIL_CUIT"].ToString();

                        if (reader["FechaAlta"] != DBNull.Value)
                            contacto.FechaAlta =
                                Convert.ToDateTime(reader["FechaAlta"]);

                        contacto.EstadoCivil =
                            reader["EstadoCivil"].ToString();

                        contacto.Nacionalidad =
                            reader["Nacionalidad"].ToString();

                        contacto.Provincia =
                            reader["Provincia"].ToString();

                        contacto.CodigoPostal =
                            reader["CodigoPostal"].ToString();

                        contacto.Barrio =
                            reader["Barrio"].ToString();

                        contacto.TelefonoAlternativo =
                            reader["TelefonoAlternativo"].ToString();

                        contacto.Instagram =
                            reader["Instagram"].ToString();

                        contacto.ProfesionOcupacion =
                            reader["ProfesionOcupacion"].ToString();

                        contacto.EmpresaLugarTrabajo =
                            reader["EmpresaLugarTrabajo"].ToString();

                        contacto.NivelEstudios =
                            reader["NivelEstudios"].ToString();

                        contacto.Estado =
                            reader["Estado"].ToString();

                        contacto.MetodoPagoPreferido =
                            reader["MetodoPagoPreferido"].ToString();

                        contacto.Observaciones =
                            reader["Observaciones"].ToString();

                        if (reader["CuentaId"] != DBNull.Value)
                        {
                            contacto.CuentaCte = new CuentaCte();

                            contacto.CuentaCte.Id =
                                Convert.ToInt32(reader["CuentaId"]);

                            contacto.CuentaCte.PersonaId =
                                reader["PersonaId"].ToString();

                            if (reader["FechaApertura"] != DBNull.Value)
                                contacto.CuentaCte.FechaApertura =
                                    Convert.ToDateTime(
                                        reader["FechaApertura"]);

                            if (reader["LimiteCredito"] != DBNull.Value)
                                contacto.CuentaCte.LimiteCredito =
                                    Convert.ToDecimal(
                                        reader["LimiteCredito"]);

                            contacto.CuentaCte.EstadoCredito =
                                reader["EstadoCredito"].ToString();
                        }

                        return contacto;
                    }
                }
            }

            return null;
        }


        public bool Agregar(Contacto contacto)
        {
            string queryContacto = @"
                INSERT INTO contactos
                (
                    DNI, Apellido, Nombres, Calle, Depto, Piso,
                    Ciudad, Telefono, Email, CUIL_CUIT, FechaAlta,
                    EstadoCivil, Nacionalidad, Provincia, CodigoPostal,
                    Barrio, TelefonoAlternativo, Instagram,
                    ProfesionOcupacion, EmpresaLugarTrabajo,
                    NivelEstudios, Estado, MetodoPagoPreferido,
                    Observaciones
                )
                VALUES
                (
                    @DNI, @Apellido, @Nombres, @Calle, @Depto, @Piso,
                    @Ciudad, @Telefono, @Email, @CUIL_CUIT, @FechaAlta,
                    @EstadoCivil, @Nacionalidad, @Provincia, @CodigoPostal,
                    @Barrio, @TelefonoAlternativo, @Instagram,
                    @ProfesionOcupacion, @EmpresaLugarTrabajo,
                    @NivelEstudios, @Estado, @MetodoPagoPreferido,
                    @Observaciones
                )";

            using (MySqlConnection conexion =
                   new MySqlConnection(_conexionString))
            {
                conexion.Open();

                MySqlTransaction transaccion =
                    conexion.BeginTransaction();

                try
                {
                    MySqlCommand comandoContacto =
                        new MySqlCommand(
                            queryContacto,
                            conexion,
                            transaccion);

                    CargarParametrosContacto(
                        comandoContacto,
                        contacto);

                    comandoContacto.ExecuteNonQuery();

                    if (contacto.CuentaCte != null)
                    {
                        string queryCuenta = @"
                            INSERT INTO CuentaCte
                            (
                                PersonaId,
                                FechaApertura,
                                LimiteCredito,
                                EstadoCredito
                            )
                            VALUES
                            (
                                @PersonaId,
                                @FechaApertura,
                                @LimiteCredito,
                                @EstadoCredito
                            )";

                        MySqlCommand comandoCuenta =
                            new MySqlCommand(
                                queryCuenta,
                                conexion,
                                transaccion);

                        comandoCuenta.Parameters.AddWithValue(
                            "@PersonaId",
                            contacto.DNI);

                        comandoCuenta.Parameters.AddWithValue(
                            "@FechaApertura",
                            contacto.CuentaCte.FechaApertura);

                        comandoCuenta.Parameters.AddWithValue(
                            "@LimiteCredito",
                            contacto.CuentaCte.LimiteCredito);

                        comandoCuenta.Parameters.AddWithValue(
                            "@EstadoCredito",
                            contacto.CuentaCte.EstadoCredito);

                        comandoCuenta.ExecuteNonQuery();
                    }

                    transaccion.Commit();

                    return true;
                }
                catch
                {
                    transaccion.Rollback();
                    return false;
                }
            }
        }


        public bool Modificar(Contacto contacto)
        {
            string query = @"
                UPDATE contactos SET
                    Apellido = @Apellido,
                    Nombres = @Nombres,
                    Calle = @Calle,
                    Depto = @Depto,
                    Piso = @Piso,
                    Ciudad = @Ciudad,
                    Telefono = @Telefono,
                    Email = @Email,
                    CUIL_CUIT = @CUIL_CUIT,
                    FechaAlta = @FechaAlta,
                    EstadoCivil = @EstadoCivil,
                    Nacionalidad = @Nacionalidad,
                    Provincia = @Provincia,
                    CodigoPostal = @CodigoPostal,
                    Barrio = @Barrio,
                    TelefonoAlternativo = @TelefonoAlternativo,
                    Instagram = @Instagram,
                    ProfesionOcupacion = @ProfesionOcupacion,
                    EmpresaLugarTrabajo = @EmpresaLugarTrabajo,
                    NivelEstudios = @NivelEstudios,
                    Estado = @Estado,
                    MetodoPagoPreferido = @MetodoPagoPreferido,
                    Observaciones = @Observaciones
                WHERE DNI = @DNI";

            using (MySqlConnection conexion =
                   new MySqlConnection(_conexionString))
            {
                conexion.Open();

                MySqlTransaction transaccion =
                    conexion.BeginTransaction();

                try
                {
                    MySqlCommand comando =
                        new MySqlCommand(
                            query,
                            conexion,
                            transaccion);

                    CargarParametrosContacto(
                        comando,
                        contacto);

                    int filas =
                        comando.ExecuteNonQuery();

                    if (filas == 0)
                    {
                        transaccion.Rollback();
                        return false;
                    }

                    if (contacto.CuentaCte != null)
                    {
                        string queryCuenta = @"
                            UPDATE CuentaCte SET
                                FechaApertura = @FechaApertura,
                                LimiteCredito = @LimiteCredito,
                                EstadoCredito = @EstadoCredito
                            WHERE PersonaId = @PersonaId";

                        MySqlCommand comandoCuenta =
                            new MySqlCommand(
                                queryCuenta,
                                conexion,
                                transaccion);

                        comandoCuenta.Parameters.AddWithValue(
                            "@FechaApertura",
                            contacto.CuentaCte.FechaApertura);

                        comandoCuenta.Parameters.AddWithValue(
                            "@LimiteCredito",
                            contacto.CuentaCte.LimiteCredito);

                        comandoCuenta.Parameters.AddWithValue(
                            "@EstadoCredito",
                            contacto.CuentaCte.EstadoCredito);

                        comandoCuenta.Parameters.AddWithValue(
                            "@PersonaId",
                            contacto.DNI);

                        comandoCuenta.ExecuteNonQuery();
                    }

                    transaccion.Commit();

                    return true;
                }
                catch
                {
                    transaccion.Rollback();
                    return false;
                }
            }
        }


        public bool Eliminar(string dni)
        {
            using (MySqlConnection conexion =
                   new MySqlConnection(_conexionString))
            {
                conexion.Open();

                MySqlTransaction transaccion =
                    conexion.BeginTransaction();

                try
                {
                    string queryCuenta =
                        "DELETE FROM CuentaCte WHERE PersonaId = @DNI";

                    MySqlCommand comandoCuenta =
                        new MySqlCommand(
                            queryCuenta,
                            conexion,
                            transaccion);

                    comandoCuenta.Parameters.AddWithValue(
                        "@DNI",
                        dni);

                    comandoCuenta.ExecuteNonQuery();

                    string queryContacto =
                        "DELETE FROM contactos WHERE DNI = @DNI";

                    MySqlCommand comandoContacto =
                        new MySqlCommand(
                            queryContacto,
                            conexion,
                            transaccion);

                    comandoContacto.Parameters.AddWithValue(
                        "@DNI",
                        dni);

                    int filas =
                        comandoContacto.ExecuteNonQuery();

                    transaccion.Commit();

                    return filas > 0;
                }
                catch
                {
                    transaccion.Rollback();
                    return false;
                }
            }
        }
        private void CargarParametrosContacto(
            MySqlCommand comando,
            Contacto contacto)
        {
            comando.Parameters.AddWithValue("@DNI", contacto.DNI);
            comando.Parameters.AddWithValue("@Apellido", contacto.Apellido);
            comando.Parameters.AddWithValue("@Nombres", contacto.Nombres);
            comando.Parameters.AddWithValue("@Calle", contacto.Calle);
            comando.Parameters.AddWithValue("@Depto", contacto.Depto);
            comando.Parameters.AddWithValue("@Piso", contacto.Piso);
            comando.Parameters.AddWithValue("@Ciudad", contacto.Ciudad);
            comando.Parameters.AddWithValue("@Telefono", contacto.Telefono);
            comando.Parameters.AddWithValue("@Email", contacto.Email);
            comando.Parameters.AddWithValue("@CUIL_CUIT", contacto.CUIL_CUIT);
            comando.Parameters.AddWithValue("@FechaAlta", contacto.FechaAlta);
            comando.Parameters.AddWithValue("@EstadoCivil", contacto.EstadoCivil);
            comando.Parameters.AddWithValue("@Nacionalidad", contacto.Nacionalidad);
            comando.Parameters.AddWithValue("@Provincia", contacto.Provincia);
            comando.Parameters.AddWithValue("@CodigoPostal", contacto.CodigoPostal);
            comando.Parameters.AddWithValue("@Barrio", contacto.Barrio);
            comando.Parameters.AddWithValue("@TelefonoAlternativo", contacto.TelefonoAlternativo);
            comando.Parameters.AddWithValue("@Instagram", contacto.Instagram);
            comando.Parameters.AddWithValue("@ProfesionOcupacion", contacto.ProfesionOcupacion);
            comando.Parameters.AddWithValue("@EmpresaLugarTrabajo", contacto.EmpresaLugarTrabajo);
            comando.Parameters.AddWithValue("@NivelEstudios", contacto.NivelEstudios);
            comando.Parameters.AddWithValue("@Estado", contacto.Estado);
            comando.Parameters.AddWithValue("@MetodoPagoPreferido", contacto.MetodoPagoPreferido);
            comando.Parameters.AddWithValue("@Observaciones", contacto.Observaciones);
        }
    }
}