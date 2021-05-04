using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FECR.Models
{
    public class InformacionReferencia
    {
        private String TipoDoc;
        private String Numero;
        private DateTime FechaEmision;
        private String Codigo;
        private String Razon;
        private Factura Clave;

        public string TipoDoc1 { get => TipoDoc; set => TipoDoc = value; }
        public string Numero1 { get => Numero; set => Numero = value; }
        public DateTime FechaEmision1 { get => FechaEmision; set => FechaEmision = value; }
        public string Codigo1 { get => Codigo; set => Codigo = value; }
        public string Razon1 { get => Razon; set => Razon = value; }
        public Factura Clave1 { get => Clave; set => Clave = value; }


        public String Insert_InformacionReferencia()
        {

            ConexionconBD instancia_conexion = new ConexionconBD();

            try
            {
                instancia_conexion.inicializa();
                string CONSULTA;
                System.Data.OleDb.OleDbDataReader CONTENEDOR;

                CONSULTA = "EXEC INSERT_INFORMACIONREFERENCIA ?,?,?,?,?,?";
                instancia_conexion.annadir_consulta(CONSULTA);
                instancia_conexion.annadir_parametro(TipoDoc, 2);
                instancia_conexion.annadir_parametro(Numero1, 2);
                instancia_conexion.annadir_parametro(FechaEmision1, 4);
                instancia_conexion.annadir_parametro(Codigo1, 2);
                instancia_conexion.annadir_parametro(Razon1, 2);
                instancia_conexion.annadir_parametro(Clave1.Clave1, 2);

                CONTENEDOR = instancia_conexion.busca();
                instancia_conexion.conexion.Close();
                instancia_conexion.conexion.Dispose();
                CONTENEDOR.Close();
                return "Se ha agregado la información de referencia de forma correcta.";
            }
            catch (Exception error)
            {
                return error.Message;
            }
        }

        public String Update_InformacionReferencia()
        {

            ConexionconBD instancia_conexion = new ConexionconBD();

            try
            {
                instancia_conexion.inicializa();
                string CONSULTA;
                System.Data.OleDb.OleDbDataReader CONTENEDOR;

                CONSULTA = "EXEC UPDATE_INFORMACIONREFERENCIA ?,?,?,?,?,?";
                instancia_conexion.annadir_consulta(CONSULTA);
                instancia_conexion.annadir_parametro(TipoDoc, 2);
                instancia_conexion.annadir_parametro(Numero1, 2);
                instancia_conexion.annadir_parametro(FechaEmision1, 4);
                instancia_conexion.annadir_parametro(Codigo1, 2);
                instancia_conexion.annadir_parametro(Razon1, 2);
                instancia_conexion.annadir_parametro(Clave1.Clave1, 2);

                CONTENEDOR = instancia_conexion.busca();
                instancia_conexion.conexion.Close();
                instancia_conexion.conexion.Dispose();
                CONTENEDOR.Close();
                return "Se ha actualizado la información de referencia de forma correcta.";
            }
            catch (Exception error)
            {
                return error.Message;
            }
        }

        public String Delete_InformacionReferencia()
        {

            ConexionconBD instancia_conexion = new ConexionconBD();

            try
            {
                instancia_conexion.inicializa();
                string CONSULTA;
                System.Data.OleDb.OleDbDataReader CONTENEDOR;

                CONSULTA = "EXEC DELETE_INFORMACIONREFERENCIA ?";
                instancia_conexion.annadir_consulta(CONSULTA);
                instancia_conexion.annadir_parametro(Clave1.Clave1, 2);

                CONTENEDOR = instancia_conexion.busca();
                instancia_conexion.conexion.Close();
                instancia_conexion.conexion.Dispose();
                CONTENEDOR.Close();
                return "Se ha eliminado la información de referencia de forma correcta.";
            }
            catch (Exception error)
            {
                return error.Message;
            }
        }

        public InformacionReferencia Select_InformacionReferencia()
        {
            ConexionconBD instancia_conexion = new ConexionconBD();
            InformacionReferencia informacionreferencia = new InformacionReferencia();
            informacionreferencia.TipoDoc1 = "No Existe";

            try
            {
                if (instancia_conexion.inicializa())
                {
                    string CONSULTA;
                    System.Data.OleDb.OleDbDataReader CONTENEDOR;

                    CONSULTA = "EXEC SELECT_INFORMACIONREFERENCIA ?";
                    instancia_conexion.annadir_consulta(CONSULTA);
                    instancia_conexion.annadir_parametro(Clave1.Clave1.ToString(), 2);
                    CONTENEDOR = instancia_conexion.busca();

                    while (CONTENEDOR.Read())
                    {
                        informacionreferencia.TipoDoc1 = CONTENEDOR["TIPODOC"].ToString();

                        informacionreferencia.Numero1 = CONTENEDOR["NUMERO"].ToString();

                        informacionreferencia.FechaEmision1 = Convert.ToDateTime(CONTENEDOR["FECHAEMISION"].ToString());

                        informacionreferencia.Codigo1 = CONTENEDOR["CODIGO"].ToString();

                        informacionreferencia.Razon1 = CONTENEDOR["RAZON"].ToString();

                        Factura clave = new Factura();
                        clave.Clave1 = CONTENEDOR["CLAVE"].ToString();
                        informacionreferencia.Clave1 = clave;

                    }
                    instancia_conexion.conexion.Close();
                    instancia_conexion.conexion.Dispose();
                    CONTENEDOR.Close();
                    return informacionreferencia;
                }
                else
                {
                    return informacionreferencia;
                }
            }
            catch (Exception error)
            {
                informacionreferencia.TipoDoc1 = "Error";
                return informacionreferencia;
            }
        }

        public List<InformacionReferencia> Select_Todo_InformacionReferencia()
        {
            List<InformacionReferencia> listainformacionreferencia = new List<InformacionReferencia>();

            ConexionconBD instancia_conexion = new ConexionconBD();
            

            try
            {
                if (instancia_conexion.inicializa())
                {
                    string CONSULTA;
                    System.Data.OleDb.OleDbDataReader CONTENEDOR;

                    CONSULTA = "EXEC SELECT_TODO_INFORMACIONREFERENCIA";
                    instancia_conexion.annadir_consulta(CONSULTA);
                    CONTENEDOR = instancia_conexion.busca();

                    while (CONTENEDOR.Read())
                    {

                        InformacionReferencia informacionreferencia = new InformacionReferencia();

                        informacionreferencia.TipoDoc1 = CONTENEDOR["TIPODOC"].ToString();

                        informacionreferencia.Numero1 = CONTENEDOR["NUMERO"].ToString();

                        informacionreferencia.FechaEmision1 = Convert.ToDateTime(CONTENEDOR["FECHAEMISION"].ToString());

                        informacionreferencia.Codigo1 = CONTENEDOR["CODIGO"].ToString();

                        informacionreferencia.Razon1 = CONTENEDOR["RAZON"].ToString();

                        Factura clave = new Factura();
                        clave.Clave1 = CONTENEDOR["CLAVE"].ToString();
                        informacionreferencia.Clave1 = clave;

                        listainformacionreferencia.Add(informacionreferencia);
                    }
                    instancia_conexion.conexion.Close();
                    instancia_conexion.conexion.Dispose();
                    CONTENEDOR.Close();
                    return listainformacionreferencia;
                }
                else
                {
                    return listainformacionreferencia;
                }
            }
            catch (Exception error)
            {
                return listainformacionreferencia;
            }
        }

    }
}