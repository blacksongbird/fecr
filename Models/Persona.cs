using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FECR.Models
{
    public class Persona
    {
        private String Nombre;
        private Identificacion IdentificacionNumero;
        private String NombreComercial;
        private Ubicacion UbicacionID;
        private TelefonoFax TelefonoNumero;
        private TelefonoFax FaxNumero;
        private String CorreoElectronico;

        public string Nombre1 { get => Nombre; set => Nombre = value; }
        public Identificacion IdentificacionNumero1 { get => IdentificacionNumero; set => IdentificacionNumero = value; }
        public string NombreComercial1 { get => NombreComercial; set => NombreComercial = value; }
        public Ubicacion UbicacionID1 { get => UbicacionID; set => UbicacionID = value; }
        public TelefonoFax TelefonoNumero1 { get => TelefonoNumero; set => TelefonoNumero = value; }
        public TelefonoFax FaxNumero1 { get => FaxNumero; set => FaxNumero = value; }
        public string CorreoElectronico1 { get => CorreoElectronico; set => CorreoElectronico = value; }


        public String Insert_Persona()
        {

            ConexionconBD instancia_conexion = new ConexionconBD();

            try
            {
                instancia_conexion.inicializa();
                string CONSULTA;
                System.Data.OleDb.OleDbDataReader CONTENEDOR;

                CONSULTA = "EXEC INSERT_PERSONA ?,?,?,?,?,?,?";
                instancia_conexion.annadir_consulta(CONSULTA);
                instancia_conexion.annadir_parametro(Nombre1, 2);
                instancia_conexion.annadir_parametro(IdentificacionNumero1.Numero1, 2);
                instancia_conexion.annadir_parametro(NombreComercial1, 2);
                instancia_conexion.annadir_parametro(UbicacionID1.ID1, 1);
                instancia_conexion.annadir_parametro(TelefonoNumero1.NumTelefono1, 1);
                instancia_conexion.annadir_parametro(FaxNumero1.NumTelefono1, 1);
                instancia_conexion.annadir_parametro(CorreoElectronico1, 2);

                CONTENEDOR = instancia_conexion.busca();
                instancia_conexion.conexion.Close();
                instancia_conexion.conexion.Dispose();
                CONTENEDOR.Close();
                return "Se ha agregado la persona de forma correcta.";
            }
            catch (Exception error)
            {
                return error.Message;
            }
        }

        public String Update_Persona()
        {

            ConexionconBD instancia_conexion = new ConexionconBD();

            try
            {
                instancia_conexion.inicializa();
                string CONSULTA;
                System.Data.OleDb.OleDbDataReader CONTENEDOR;

                CONSULTA = "EXEC UPDATE_PERSONA ?,?,?,?,?,?,?";
                instancia_conexion.annadir_consulta(CONSULTA);
                instancia_conexion.annadir_parametro(Nombre1, 2);
                instancia_conexion.annadir_parametro(IdentificacionNumero1.Numero1, 2);
                instancia_conexion.annadir_parametro(NombreComercial1, 2);
                instancia_conexion.annadir_parametro(UbicacionID1.ID1, 1);
                instancia_conexion.annadir_parametro(TelefonoNumero1.NumTelefono1, 1);
                instancia_conexion.annadir_parametro(FaxNumero1.NumTelefono1, 1);
                instancia_conexion.annadir_parametro(CorreoElectronico1, 2);

                CONTENEDOR = instancia_conexion.busca();
                instancia_conexion.conexion.Close();
                instancia_conexion.conexion.Dispose();
                CONTENEDOR.Close();
                return "Se ha actualizado la persona de forma correcta.";
            }
            catch (Exception error)
            {
                return error.Message;
            }
        }

        public String Delete_Persona()
        {

            ConexionconBD instancia_conexion = new ConexionconBD();

            try
            {
                instancia_conexion.inicializa();
                string CONSULTA;
                System.Data.OleDb.OleDbDataReader CONTENEDOR;

                CONSULTA = "EXEC DELETE_PERSONA ?";
                instancia_conexion.annadir_consulta(CONSULTA);
                instancia_conexion.annadir_parametro(IdentificacionNumero1.Numero1, 2);

                CONTENEDOR = instancia_conexion.busca();
                instancia_conexion.conexion.Close();
                instancia_conexion.conexion.Dispose();
                CONTENEDOR.Close();
                return "Se ha eliminado la persona de forma correcta.";
            }
            catch (Exception error)
            {
                return error.Message;
            }
        }

        public Persona Select_Persona()
        {
            ConexionconBD instancia_conexion = new ConexionconBD();
            Persona persona = new Persona();
            persona.Nombre1 = "No Existe";

            try
            {
                if (instancia_conexion.inicializa())
                {
                    string CONSULTA;
                    System.Data.OleDb.OleDbDataReader CONTENEDOR;

                    CONSULTA = "EXEC SELECT_PERSONA ?";
                    instancia_conexion.annadir_consulta(CONSULTA);
                    instancia_conexion.annadir_parametro(IdentificacionNumero1.Numero1.ToString(), 2);
                    CONTENEDOR = instancia_conexion.busca();

                    while (CONTENEDOR.Read())
                    {
                        persona.Nombre1 = CONTENEDOR["NOMBRE"].ToString();

                        Identificacion identificacion = new Identificacion();
                        identificacion.Numero1 = CONTENEDOR["IDENTIFICACIONNUMERO"].ToString();
                        persona.IdentificacionNumero1 = identificacion;

                        persona.NombreComercial1 = CONTENEDOR["NOMBRECOMERCIAL"].ToString();

                        Ubicacion ubicacion = new Ubicacion();
                        ubicacion.ID1 = Convert.ToInt32(CONTENEDOR["UBICACIONID"].ToString());
                        persona.UbicacionID1 = ubicacion;

                        TelefonoFax telefono = new TelefonoFax();
                        telefono.NumTelefono1 = Convert.ToInt32(CONTENEDOR["TELEFONONUMERO"].ToString());
                        persona.TelefonoNumero1 = telefono;

                        TelefonoFax fax = new TelefonoFax();
                        fax.NumTelefono1 = Convert.ToInt32(CONTENEDOR["FAXNUMERO"].ToString());
                        persona.FaxNumero = fax;

                        persona.CorreoElectronico1 = CONTENEDOR["CORREOELECTRONICO"].ToString();

                    }
                    instancia_conexion.conexion.Close();
                    instancia_conexion.conexion.Dispose();
                    CONTENEDOR.Close();
                    return persona;
                }
                else
                {
                    return persona;
                }
            }
            catch (Exception error)
            {
                persona.Nombre1 = "Error";
                return persona;
            }
        }

        public List<Persona> Select_Todo_Persona()
        {
            List<Persona> listapersona = new List<Persona>();

            ConexionconBD instancia_conexion = new ConexionconBD();
            

            try
            {
                if (instancia_conexion.inicializa())
                {
                    string CONSULTA;
                    System.Data.OleDb.OleDbDataReader CONTENEDOR;

                    CONSULTA = "EXEC SELECT_TODO_PERSONA";
                    instancia_conexion.annadir_consulta(CONSULTA);
                    CONTENEDOR = instancia_conexion.busca();

                    while (CONTENEDOR.Read())
                    {
                        Persona persona = new Persona();

                        persona.Nombre1 = CONTENEDOR["NOMBRE"].ToString();

                        Identificacion identificacion = new Identificacion();
                        identificacion.Numero1 = CONTENEDOR["IDENTIFICACIONNUMERO"].ToString();
                        persona.IdentificacionNumero1 = identificacion;

                        persona.NombreComercial1 = CONTENEDOR["NOMBRECOMERCIAL"].ToString();

                        Ubicacion ubicacion = new Ubicacion();
                        ubicacion.ID1 = Convert.ToInt32(CONTENEDOR["UBICACIONID"].ToString());
                        persona.UbicacionID1 = ubicacion;

                        TelefonoFax telefono = new TelefonoFax();
                        telefono.NumTelefono1 = Convert.ToInt32(CONTENEDOR["TELEFONONUMERO"].ToString());
                        persona.TelefonoNumero1 = telefono;

                        TelefonoFax fax = new TelefonoFax();
                        fax.NumTelefono1 = Convert.ToInt32(CONTENEDOR["FAXNUMERO"].ToString());
                        persona.FaxNumero = fax;

                        persona.CorreoElectronico1 = CONTENEDOR["CORREOELECTRONICO"].ToString();

                        persona.UbicacionID1 = ubicacion.Select_Ubicacion();

                        persona.TelefonoNumero1 = telefono.Select_TelefonoFax();

                        persona.FaxNumero1 = fax.Select_TelefonoFax();

                        listapersona.Add(persona);
                    }
                    instancia_conexion.conexion.Close();
                    instancia_conexion.conexion.Dispose();
                    CONTENEDOR.Close();
                    return listapersona;
                }
                else
                {
                    return listapersona;
                }
            }
            catch (Exception error)
            {
                return listapersona;
            }
        }

    }
}