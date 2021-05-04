using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FECR.Models
{
    public class DetalleServicio
    {
        private Factura Clave;

        private List<LineaDetalle> LineaDetalleFactura;

        public Factura Clave1 { get => Clave; set => Clave = value; }

        public List<LineaDetalle> LineaDetalleFactura1 { get => LineaDetalleFactura; set => LineaDetalleFactura = value; }


        public String Insert_DetalleServicio()
        {

            ConexionconBD instancia_conexion = new ConexionconBD();

            try
            {
                instancia_conexion.inicializa();
                string CONSULTA;
                System.Data.OleDb.OleDbDataReader CONTENEDOR;

                CONSULTA = "EXEC INSERT_DETALLESERVICIO ?";
                instancia_conexion.annadir_consulta(CONSULTA);
                instancia_conexion.annadir_parametro(Clave1.Clave1, 2);

                CONTENEDOR = instancia_conexion.busca();

                foreach (LineaDetalle item in LineaDetalleFactura1)
                {
                    CONSULTA = "EXEC INSERT_DETALLESERVICIO_LINEADETALLE ?,?";
                    instancia_conexion.annadir_consulta(CONSULTA);
                    instancia_conexion.annadir_parametro(Clave1.Clave1, 2);
                    instancia_conexion.annadir_parametro(item.Consecutivo1, 1);

                    CONTENEDOR = instancia_conexion.busca();
                }

                instancia_conexion.conexion.Close();
                instancia_conexion.conexion.Dispose();
                CONTENEDOR.Close();
                return "Se ha agregado el detalle de servicio de forma correcta.";
            }
            catch (Exception error)
            {
                return error.Message;
            }
        }

        public String Update_DetalleServicio()
        {

            ConexionconBD instancia_conexion = new ConexionconBD();

            try
            {
                instancia_conexion.inicializa();
                string CONSULTA;
                System.Data.OleDb.OleDbDataReader CONTENEDOR;

                CONSULTA = "EXEC UPDATE_DETALLESERVICIO ?";
                instancia_conexion.annadir_consulta(CONSULTA);
                instancia_conexion.annadir_parametro(Clave1.Clave1, 2);

                CONTENEDOR = instancia_conexion.busca();
                instancia_conexion.conexion.Close();
                instancia_conexion.conexion.Dispose();
                CONTENEDOR.Close();
                return "Se ha actualizado el detalle de servicio de forma correcta.";
            }
            catch (Exception error)
            {
                return error.Message;
            }
        }

        public String Delete_DetalleServicio()
        {

            ConexionconBD instancia_conexion = new ConexionconBD();

            try
            {
                instancia_conexion.inicializa();
                string CONSULTA;
                System.Data.OleDb.OleDbDataReader CONTENEDOR;

                CONSULTA = "EXEC DELETE_DETALLESERVICIO ?";
                instancia_conexion.annadir_consulta(CONSULTA);
                instancia_conexion.annadir_parametro(Clave1.Clave1, 2);

                CONTENEDOR = instancia_conexion.busca();
                instancia_conexion.conexion.Close();
                instancia_conexion.conexion.Dispose();
                CONTENEDOR.Close();
                return "Se ha eliminado el detalle de servicio de forma correcta.";
            }
            catch (Exception error)
            {
                return error.Message;
            }
        }

        public DetalleServicio Select_DetalleServicio()
        {
            ConexionconBD instancia_conexion = new ConexionconBD();
            DetalleServicio detalleservicio = new DetalleServicio();
            try
            {
                if (instancia_conexion.inicializa())
                {
                    string CONSULTA;
                    System.Data.OleDb.OleDbDataReader CONTENEDOR;

                    CONSULTA = "EXEC SELECT_OTROSCARGOS ?";
                    instancia_conexion.annadir_consulta(CONSULTA);
                    instancia_conexion.annadir_parametro(Clave1.Clave1.ToString(), 2);
                    CONTENEDOR = instancia_conexion.busca();

                    while (CONTENEDOR.Read())
                    {

                        Factura clave = new Factura();
                        clave.Clave1 = CONTENEDOR["CLAVE"].ToString();
                        detalleservicio.Clave1 = clave;

                    }
                    instancia_conexion.conexion.Close();
                    instancia_conexion.conexion.Dispose();
                    CONTENEDOR.Close();
                    return detalleservicio;
                }
                else
                {
                    return detalleservicio;
                }
            }
            catch (Exception error)
            {
                return detalleservicio;
            }
        }

        public List<DetalleServicio> Select_Todo_DetalleServicio()
        {
            List<DetalleServicio> listadetalleservicio = new List<DetalleServicio>();

            ConexionconBD instancia_conexion = new ConexionconBD();
            DetalleServicio detalleservicio = new DetalleServicio();

            try
            {
                if (instancia_conexion.inicializa())
                {
                    string CONSULTA;
                    System.Data.OleDb.OleDbDataReader CONTENEDOR;

                    CONSULTA = "EXEC SELECT_TODO_DETALLESERVICIO";
                    instancia_conexion.annadir_consulta(CONSULTA);
                    CONTENEDOR = instancia_conexion.busca();

                    while (CONTENEDOR.Read())
                    {

                        Factura clave = new Factura();
                        clave.Clave1 = CONTENEDOR["CLAVE"].ToString();
                        detalleservicio.Clave1 = clave;

                        listadetalleservicio.Add(detalleservicio);
                    }
                    instancia_conexion.conexion.Close();
                    instancia_conexion.conexion.Dispose();
                    CONTENEDOR.Close();
                    return listadetalleservicio;
                }
                else
                {
                    return listadetalleservicio;
                }
            }
            catch (Exception error)
            {
                return listadetalleservicio;
            }
        }

    }
}