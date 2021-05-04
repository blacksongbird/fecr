using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FECR.Models
{
    public class Factura
    {
        private String CodigoActividad;
        private String Clave;
        private String NumeroConsecutivo;
        private DateTime FechaEmision;
        private Persona EmisorPersona;
        private Persona ReceptorPersona;
        private String CondicionVenta;
        private String PlazoCredito;
        private String MedioPago;

        public string CodigoActividad1 { get => CodigoActividad; set => CodigoActividad = value; }
        public string Clave1 { get => Clave; set => Clave = value; }
        public string NumeroConsecutivo1 { get => NumeroConsecutivo; set => NumeroConsecutivo = value; }
        public DateTime FechaEmision1 { get => FechaEmision; set => FechaEmision = value; }
        public Persona EmisorPersona1 { get => EmisorPersona; set => EmisorPersona = value; }
        public Persona ReceptorPersona1 { get => ReceptorPersona; set => ReceptorPersona = value; }
        public string CondicionVenta1 { get => CondicionVenta; set => CondicionVenta = value; }
        public string PlazoCredito1 { get => PlazoCredito; set => PlazoCredito = value; }
        public string MedioPago1 { get => MedioPago; set => MedioPago = value; }


        public String Insert_Factura()
        {

            ConexionconBD instancia_conexion = new ConexionconBD();

            try
            {
                instancia_conexion.inicializa();
                string CONSULTA;
                System.Data.OleDb.OleDbDataReader CONTENEDOR;

                CONSULTA = "EXEC INSERT_FACTURA ?,?,?,?,?,?,?,?,?";
                instancia_conexion.annadir_consulta(CONSULTA);
                instancia_conexion.annadir_parametro(CodigoActividad1, 2);
                instancia_conexion.annadir_parametro(Clave1, 2);
                instancia_conexion.annadir_parametro(NumeroConsecutivo1, 2);
                instancia_conexion.annadir_parametro(FechaEmision1, 4);
                instancia_conexion.annadir_parametro(EmisorPersona1.IdentificacionNumero1.Numero1, 2);
                instancia_conexion.annadir_parametro(ReceptorPersona1.IdentificacionNumero1.Numero1, 2);
                instancia_conexion.annadir_parametro(CondicionVenta1, 2);
                instancia_conexion.annadir_parametro(PlazoCredito1, 2);
                instancia_conexion.annadir_parametro(MedioPago1, 2);

                CONTENEDOR = instancia_conexion.busca();
                instancia_conexion.conexion.Close();
                instancia_conexion.conexion.Dispose();
                CONTENEDOR.Close();
                return "Se ha agregado la factura de forma correcta.";
            }
            catch (Exception error)
            {
                return error.Message;
            }
        }

        public String Update_Factura()
        {

            ConexionconBD instancia_conexion = new ConexionconBD();

            try
            {
                instancia_conexion.inicializa();
                string CONSULTA;
                System.Data.OleDb.OleDbDataReader CONTENEDOR;

                CONSULTA = "EXEC UPDATE_FACTURA ?,?,?,?,?,?,?,?,?";
                instancia_conexion.annadir_consulta(CONSULTA);
                instancia_conexion.annadir_parametro(CodigoActividad1, 2);
                instancia_conexion.annadir_parametro(Clave1, 2);
                instancia_conexion.annadir_parametro(NumeroConsecutivo1, 2);
                instancia_conexion.annadir_parametro(FechaEmision1, 4);
                instancia_conexion.annadir_parametro(EmisorPersona1.IdentificacionNumero1.Numero1, 2);
                instancia_conexion.annadir_parametro(ReceptorPersona1.IdentificacionNumero1.Numero1, 2);
                instancia_conexion.annadir_parametro(CondicionVenta1, 2);
                instancia_conexion.annadir_parametro(PlazoCredito1, 2);
                instancia_conexion.annadir_parametro(MedioPago1, 2);

                CONTENEDOR = instancia_conexion.busca();
                instancia_conexion.conexion.Close();
                instancia_conexion.conexion.Dispose();
                CONTENEDOR.Close();
                return "Se ha actualizado la factura de forma correcta.";
            }
            catch (Exception error)
            {
                return error.Message;
            }
        }

        public String Delete_Factura()
        {

            ConexionconBD instancia_conexion = new ConexionconBD();

            try
            {
                instancia_conexion.inicializa();
                string CONSULTA;
                System.Data.OleDb.OleDbDataReader CONTENEDOR;

                CONSULTA = "EXEC DELETE_FACTURA ?";
                instancia_conexion.annadir_consulta(CONSULTA);
                instancia_conexion.annadir_parametro(Clave1, 2);

                CONTENEDOR = instancia_conexion.busca();
                instancia_conexion.conexion.Close();
                instancia_conexion.conexion.Dispose();
                CONTENEDOR.Close();
                return "Se ha eliminado la factura de forma correcta.";
            }
            catch (Exception error)
            {
                return error.Message;
            }
        }

        public Factura Select_Factura()
        {
            ConexionconBD instancia_conexion = new ConexionconBD();
            Factura factura = new Factura();
            factura.CodigoActividad1 = "No Existe";

            try
            {
                if (instancia_conexion.inicializa())
                {
                    string CONSULTA;
                    System.Data.OleDb.OleDbDataReader CONTENEDOR;

                    CONSULTA = "EXEC SELECT_FACTURA ?";
                    instancia_conexion.annadir_consulta(CONSULTA);
                    instancia_conexion.annadir_parametro(Clave1.ToString(), 2);
                    CONTENEDOR = instancia_conexion.busca();

                    while (CONTENEDOR.Read())
                    {
                        factura.CodigoActividad1 = CONTENEDOR["CODIGOACTIVIDAD"].ToString();

                        factura.Clave1 = CONTENEDOR["CLAVE"].ToString();

                        factura.NumeroConsecutivo1 = CONTENEDOR["NUMEROCONSECUTIVO"].ToString();

                        factura.FechaEmision1 = Convert.ToDateTime(CONTENEDOR["FECHAEMISION"].ToString());

                        Identificacion idemisor = new Identificacion();
                        idemisor.Numero1 = CONTENEDOR["EMISORPERSONA"].ToString();
                        Persona emisor = new Persona();
                        emisor.IdentificacionNumero1 = idemisor;
                        factura.EmisorPersona1 = emisor;

                        Identificacion idreceptor = new Identificacion();
                        idreceptor.Numero1 = CONTENEDOR["RECEPTORPERSONA"].ToString();
                        Persona receptor = new Persona();
                        receptor.IdentificacionNumero1 = idreceptor;
                        factura.ReceptorPersona1 = receptor;

                        factura.CondicionVenta1 = CONTENEDOR["CONDICIONVENTA"].ToString();

                        factura.PlazoCredito1 = CONTENEDOR["PLAZOCREDITO"].ToString();

                        factura.MedioPago1 = CONTENEDOR["MEDIOPAGO"].ToString();

                    }
                    instancia_conexion.conexion.Close();
                    instancia_conexion.conexion.Dispose();
                    CONTENEDOR.Close();
                    return factura;
                }
                else
                {
                    return factura;
                }
            }
            catch (Exception error)
            {
                factura.CodigoActividad1 = "Error";
                return factura;
            }
        }

        public List<Factura> Select_Todo_Factura()
        {
            List<Factura> listafactura = new List<Factura>();

            ConexionconBD instancia_conexion = new ConexionconBD();
            

            try
            {
                if (instancia_conexion.inicializa())
                {
                    string CONSULTA;
                    System.Data.OleDb.OleDbDataReader CONTENEDOR;

                    CONSULTA = "EXEC SELECT_TODO_FACTURA";
                    instancia_conexion.annadir_consulta(CONSULTA);
                    CONTENEDOR = instancia_conexion.busca();

                    while (CONTENEDOR.Read())
                    {
                        Factura factura = new Factura();

                        factura.CodigoActividad1 = CONTENEDOR["CODIGOACTIVIDAD"].ToString();

                        factura.Clave1 = CONTENEDOR["CLAVE"].ToString();

                        factura.NumeroConsecutivo1 = CONTENEDOR["NUMEROCONSECUTIVO"].ToString();

                        factura.FechaEmision1 = Convert.ToDateTime(CONTENEDOR["FECHAEMISION"].ToString());

                        Identificacion idemisor = new Identificacion();
                        idemisor.Numero1 = CONTENEDOR["EMISORPERSONA"].ToString();
                        Persona emisor = new Persona();
                        emisor.IdentificacionNumero1 = idemisor;
                        factura.EmisorPersona1 = emisor;

                        Identificacion idreceptor = new Identificacion();
                        idreceptor.Numero1 = CONTENEDOR["RECEPTORPERSONA"].ToString();
                        Persona receptor = new Persona();
                        receptor.IdentificacionNumero1 = idreceptor;
                        factura.ReceptorPersona1 = receptor;

                        factura.CondicionVenta1 = CONTENEDOR["CONDICIONVENTA"].ToString();

                        factura.PlazoCredito1 = CONTENEDOR["PLAZOCREDITO"].ToString();

                        factura.MedioPago1 = CONTENEDOR["MEDIOPAGO"].ToString();

                        factura.EmisorPersona1 = emisor.Select_Persona();

                        factura.ReceptorPersona1 = receptor.Select_Persona();

                        listafactura.Add(factura);
                    }
                    instancia_conexion.conexion.Close();
                    instancia_conexion.conexion.Dispose();
                    CONTENEDOR.Close();
                    return listafactura;
                }
                else
                {
                    return listafactura;
                }
            }
            catch (Exception error)
            {
                return listafactura;
            }
        }

    }
}