using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.AccesoDeDatos.DAOS;
using Uricao.Entidades.EPresupuestoFacturas;
using Uricao.Entidades.ETratamientos;
using Uricao.Entidades.ERolesUsuarios;
using System.Data;
using Uricao.LogicaDeNegocios.Excepciones;
using Uricao.Entidades.EEntidad;

namespace Uricao.LogicaDeNegocios.Clases.LNPresupuestoFacturas
{
    public class LogicaFactura
    {
        DAOPresupuestoFactura manejador;

		#region Generar Factura

        public bool insertarFactura(Factura laFactura)
        {
            try
            {
                manejador = new DAOPresupuestoFactura();
                int idUsuario = manejador.RegresarIdUsuario(laFactura.getCedula_Paciente());


                if (manejador.AgregarFactura(laFactura, idUsuario))
                {
                    laFactura.setNro_Factura(manejador.RegresarIdFactura(laFactura, idUsuario));
                    if (manejador.AgregarDetalleFactura(laFactura, idUsuario))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (ExceptionPresupuestoFactura e)
            {
                throw new ExceptionPresupuestoFactura(e.Message);
            }
            catch (Exception e)
            {
                throw new ExceptionPresupuestoFactura(e.Message);
            }

             
        }

        public Boolean GenerarDetalleFactura(Factura laFactura, int id_factura)
        {

            try
            {
                manejador = new DAOPresupuestoFactura();
                manejador.AgregarDetalleFactura(laFactura, id_factura);
                return true;
            }
            catch (ExceptionPresupuestoFactura e)
            {
                throw new ExceptionPresupuestoFactura(e.Message);
            }
            catch (Exception e)
            {
                throw new ExceptionPresupuestoFactura(e.Message);
            }



        }

        #endregion
        
        #region Logica de Consultar Factura
        public Double CostoTodoElDetalleSinIva(List<Detalle_Presupuesto_Factura> listaDetalle)
        {
            try
            {
                Double costo = 0.0;
                foreach (Detalle_Presupuesto_Factura detalle in listaDetalle)
                {
                    costo = costo + detalle.Total_pago_tratamiento * detalle.Cantidad;
                }
                return costo;
            }
            catch (ArithmeticException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Problemas con calculos aritmeticos", e);
            }

            catch (ExceptionPresupuestoFactura e)
            {
                throw new ExceptionPresupuestoFactura(e.Message);
            }
            catch (Exception e)
            {
                throw new ExceptionPresupuestoFactura(e.Message);
            }
        }


        public List<Entidad> ObtenerListaFacturasCompleta()
        {
            try
            {
                DAOPresupuestoFactura servidorSQL = new DAOPresupuestoFactura();
                return servidorSQL.ConsultarFacturasTodas();
            }
            catch (ExceptionPresupuestoFactura e)
            {
                throw new ExceptionPresupuestoFactura(e.Message);
            }
            catch (Exception e)
            {
                throw new ExceptionPresupuestoFactura(e.Message);
            }
             
        }
 


        public List<Entidad> ObtenerListaFacturaFechas(string fechaInicio, string fechaFin)
        {
            try
            {

                DAOPresupuestoFactura servidorSQL = new DAOPresupuestoFactura();
                return servidorSQL.ConsultarFacturasRangoFechas(fechaInicio, fechaFin);
            }
            catch (ExceptionPresupuestoFactura e)
            {
                throw new ExceptionPresupuestoFactura(e.Message);
            }
            catch (Exception e)
            {
                throw new ExceptionPresupuestoFactura(e.Message);
            }
        }


        //NOTA: Entrega2 declaraba: public List<Factura> ObtenerFacturasCI(String ci)
        public List<Entidad> ObtenerFacturasCI(String ci)
        {
            try
            {
                DAOPresupuestoFactura servidorSQL = new DAOPresupuestoFactura();
                return servidorSQL.ConsultarFacturaXCI(ci);
            }
            catch (ExceptionPresupuestoFactura e)
            {
                throw new ExceptionPresupuestoFactura(e.Message);
            }
            catch (Exception e)
            {
                throw new ExceptionPresupuestoFactura(e.Message);
            }
        }

        //Falta prueba
        public Entidad ObtenerFacturaPorNumero(int numeroFactura)
        {
            //parse de numero de presupuesto
            try
            {
                DAOPresupuestoFactura servidorSQL = new DAOPresupuestoFactura();
                return servidorSQL.ConsultarFacturaNumero(numeroFactura);
            }
            catch (ExceptionPresupuestoFactura e)
            {
                throw new ExceptionPresupuestoFactura(e.Message);
            }
            catch (Exception e)
            {
                throw new ExceptionPresupuestoFactura(e.Message);
            }

        }


        public string ObtenerCedulaUsuarioFactura(int nro_factura)
        {
            try
            {
                DAOPresupuestoFactura servidorSQL = new DAOPresupuestoFactura();
                String cedula = servidorSQL.ConsultarCedulaFactura(nro_factura);
                return cedula;
            }
            catch (ExceptionPresupuestoFactura e)
            {
                throw new ExceptionPresupuestoFactura(e.Message);
            }
            catch (Exception e)
            {
                throw new ExceptionPresupuestoFactura(e.Message);
            }
        }



        /// <summary>
        /// No lo usamos
        /// </summary>
        /// <param name="listaFacturas"></param>
        /// <returns></returns>
        public DataSet CreateDataSetFactura(List<Factura> listaFacturas)
        {
            DataSet ds;

            ds = new DataSet();
            DataTable dt = new DataTable("FacturasClientes");
            DataRow dr;
            LogicaFactura logicaFacturas = new LogicaFactura();
            dt.Columns.Add(new DataColumn("NumeroFactura", typeof(string)));
            dt.Columns.Add(new DataColumn("CedulaPaciente", typeof(string)));
            dt.Columns.Add(new DataColumn("FechaEmision", typeof(DateTime)));
            foreach (Factura factura in listaFacturas)
            {
                dr = dt.NewRow();
                dr[0] = factura.Nro_factura;
                dr[1] = logicaFacturas.ObtenerCedulaUsuarioFactura(factura.Nro_factura);
                dr[2] = factura.Fecha_emitida.ToString("dd/MM/yyyy");

                dt.Rows.Add(dr);
            }
            ds.Tables.Add(dt);

            return ds;

        }


        /// <summary>
        /// Método que borra la tabla cada
        /// vez que se selecciona el radiobutton
        /// </summary>
        /// <param name="miTabla"></param>
        /// <returns></returns>
        public DataTable BorrarTabla(DataTable miTabla)
        {
            foreach (DataRow row in miTabla.Rows)
                miTabla.Rows.Remove(row);
            miTabla.AcceptChanges();

            return miTabla;
        }


        //Falta prueba
        //public Usuario ObtenerUsuarioPresupuesto(int nro_presupuesto)
        //{
        //    try
        //    {
        //        DAOPresupuestoFactura servidorSQL = new DAOPresupuestoFactura();

        //        return servidorSQL.ConsultarDatosBasicosUsuarioPresupuesto(nro_presupuesto);
        //    }
        //    catch (ExceptionPresupuestoFactura e)
        //    {
        //        throw new ExceptionPresupuestoFactura(e.Message);
        //    }
        //    catch (Exception e)
        //    {
        //        throw new ExceptionPresupuestoFactura(e.Message);
        //    }
        //}


        //public List<Detalle_Presupuesto_Factura> ObtenerDetalleFactura(int nro_factura)
        public List<Entidad> ObtenerDetalleFactura(int nro_factura)
        {
            try
            {
                DAOPresupuestoFactura servidorSQL = new DAOPresupuestoFactura();

                List<Entidad> listaDetalle = servidorSQL.ConsultarDetalleFactura(nro_factura);
                return servidorSQL.ConsultarTratamientosListaDetalle(listaDetalle);
            }
            catch (ExceptionPresupuestoFactura e)
            {
                throw new ExceptionPresupuestoFactura(e.Message);
            }
            catch (Exception e)
            {
                throw new ExceptionPresupuestoFactura(e.Message);
            }
        }


        public DataSet CreateDataSetTratamientosPresupuesto(List<Detalle_Presupuesto_Factura> listaDetalle)
        {
            try
            {
                DataSet ds;

                ds = new DataSet();
                DataTable dt = new DataTable("DetalleFactura");
                DataRow dr;
                dt.Columns.Add(new DataColumn("nombre_tratamiento", typeof(string)));
                dt.Columns.Add(new DataColumn("cantidad", typeof(Int32)));
                dt.Columns.Add(new DataColumn("monto", typeof(float)));
                foreach (Detalle_Presupuesto_Factura detalle in listaDetalle)
                {
                    dr = dt.NewRow();
                    dr[0] = detalle.El_Tratamiento.Nombre;
                    dr[1] = detalle.Cantidad;
                    dr[2] = detalle.Total_pago_tratamiento;

                    dt.Rows.Add(dr);
                }
                ds.Tables.Add(dt);

            return ds;
            }
            catch (ExceptionPresupuestoFactura e)
            {
                throw new ExceptionPresupuestoFactura(e.Message);
            }
            catch (Exception e)
            {
                throw new ExceptionPresupuestoFactura(e.Message);
            }
            

        }


        public String ObtenerPaisFactura(int idDireccion)
        {
            try
            {

                DAOPresupuestoFactura servidorSQL = new DAOPresupuestoFactura();
                return servidorSQL.ConsultarDireccionPaisFactura(idDireccion);
            }
            catch (ExceptionPresupuestoFactura e)
            {
                throw new ExceptionPresupuestoFactura(e.Message);
            }
            catch (Exception e)
            {
                throw new ExceptionPresupuestoFactura(e.Message);
            }
        }

        //public String ObtenerProvinciaFactura(int idDireccion)
        public String ObtenerProvinciaFactura(int idDireccion)
        {
            try
            {
                DAOPresupuestoFactura servidorSQL = new DAOPresupuestoFactura();
                return servidorSQL.ConsultarDireccionEstadoFactura(idDireccion);
            }
            catch (ExceptionPresupuestoFactura e)
            {
                throw new ExceptionPresupuestoFactura(e.Message);
            }
            catch (Exception e)
            {
                throw new ExceptionPresupuestoFactura(e.Message);
            }
        }

        public String ObtenerCiudadFactura(int idDireccion)
        {
            try
            {
                DAOPresupuestoFactura servidorSQL = new DAOPresupuestoFactura();
                return servidorSQL.ConsultarDireccionCiudadFactura(idDireccion);
            }
            catch (ExceptionPresupuestoFactura e)
            {
                throw new ExceptionPresupuestoFactura(e.Message);
            }
            catch (Exception e)
            {
                throw new ExceptionPresupuestoFactura(e.Message);
            }
        }

        public String ObtenerMunicipioFactura(int idDireccion)
        {
            try
            {
                DAOPresupuestoFactura servidorSQL = new DAOPresupuestoFactura();
                return servidorSQL.ConsultarDireccionMunicipioFactura(idDireccion);
            }
            catch (ExceptionPresupuestoFactura e)
            {
                throw new ExceptionPresupuestoFactura(e.Message);
            }
            catch (Exception e)
            {
                throw new ExceptionPresupuestoFactura(e.Message);
            }
        }

        public String ObtenerCalleFactura(int idDireccion)
        {
            try
            {
                DAOPresupuestoFactura servidorSQL = new DAOPresupuestoFactura();
                return servidorSQL.ConsultarDireccionCalleFactura(idDireccion);
            }
            catch (ExceptionPresupuestoFactura e)
            {
                throw new ExceptionPresupuestoFactura(e.Message);
            }
            catch (Exception e)
            {
                throw new ExceptionPresupuestoFactura(e.Message);
            }
        }

        public String ObtenerEdificioFactura(int idDireccion)
        {
            try
            {
                DAOPresupuestoFactura servidorSQL = new DAOPresupuestoFactura();
                return servidorSQL.ConsultarDireccionEdificioFactura(idDireccion);
            }
            catch (ExceptionPresupuestoFactura e)
            {
                throw new ExceptionPresupuestoFactura(e.Message);
            }
            catch (Exception e)
            {
                throw new ExceptionPresupuestoFactura(e.Message);
            }
        }

        #endregion

        #region Usos Varios
        public bool validarUsuario(string cedulaUsuario, string tipoCi)
        {
            try
            {
                manejador = new DAOPresupuestoFactura();
                return manejador.validarUsuario(cedulaUsuario, tipoCi);
            }
            catch (ExceptionPresupuestoFactura e)
            {
                throw new ExceptionPresupuestoFactura(e.Message);
            }
            catch (Exception e)
            {
                throw new ExceptionPresupuestoFactura(e.Message);
            }

        }



        public Int16 RegresarCostoTratamiento(int id_tratamiento)
        {
            try
            {
                manejador = new DAOPresupuestoFactura();
                return manejador.RegresarCostoTratamiento(id_tratamiento);
            }
            catch (ArithmeticException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Problemas con calculos aritmeticos", e);
            }
            catch (ExceptionPresupuestoFactura e)
            {
                throw new ExceptionPresupuestoFactura(e.Message);
            }
            catch (Exception e)
            {
                throw new ExceptionPresupuestoFactura(e.Message);
            }

        }


        public int RegresarIdFactura(Factura la_factura)
        {
            //manejador = new DAOSPresupuestoFactura();
            //return manejador.RegresarIdFactura(la_factura); ;
            return 0;
        }


        public short CalculoDeCostoTotalTratamiento(List<Tratamiento> listado_tratamiento, int posicion)
        {
            try
            {
                manejador = new DAOPresupuestoFactura();
                return (short)(listado_tratamiento[posicion].Duracion *
                        this.RegresarCostoTratamiento(listado_tratamiento[posicion].Id));
            }
            catch (ArithmeticException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Problemas con calculos aritmeticos", e);
            }

            catch (ExceptionPresupuestoFactura e)
            {
                throw new ExceptionPresupuestoFactura(e.Message);
            }
            catch (Exception e)
            {
                throw new ExceptionPresupuestoFactura(e.Message);
            }
        }

        public double SubtotalFactura(Factura laFactura)
        {
            try
            {
                double subtotal = 0.0;
                foreach (var detalle in laFactura.getListado_Factura())
                {
                    subtotal = (subtotal + detalle.Total_pago_tratamiento);
                }

                return subtotal;
            }
            catch (ArithmeticException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Problemas con calculos aritmeticos", e);
            }

            catch (ExceptionPresupuestoFactura e)
            {
                throw new ExceptionPresupuestoFactura(e.Message);
            }
            catch (Exception e)
            {
                throw new ExceptionPresupuestoFactura(e.Message);
            }
        }

        #endregion


        #region Procedimientos de Tratamiento

        public int RegresarIdUsuario(String cedula)
        {
            try
            {
                manejador = new DAOPresupuestoFactura();
                return manejador.RegresarIdUsuario(cedula);
            }
            catch (ExceptionPresupuestoFactura e)
            {
                throw new ExceptionPresupuestoFactura(e.Message);
            }
            catch (Exception e)
            {
                throw new ExceptionPresupuestoFactura(e.Message);
            }
        }

        public int RegresaIdDireccionUsuario (int idUsuario)
        {
            try
            {
                return manejador.RegresarIdDireccionDeUsuario(idUsuario);
            }
            catch (ExceptionPresupuestoFactura e)
            {
                throw new ExceptionPresupuestoFactura(e.Message);
            }
            catch (Exception e)
            {
                throw new ExceptionPresupuestoFactura(e.Message);
            }
        }

        //Esta vaina no se usa
        public List<Tratamiento> RegresarListadoXID(int idTratamiento)
        {
            try
            {
                List<Tratamiento> regreso = new List<Tratamiento>();
                manejador = new DAOPresupuestoFactura();
                //OJO: ESTO SE CAMBIO, AL PASARLO A COMANDOS, YA QUE NO SE UTILIZA:
                //regreso.Add(manejador.SqlBuscarXIdTratamiento(idTratamiento));
                return regreso;
            }
            catch (ExceptionPresupuestoFactura e)
            {
                throw new ExceptionPresupuestoFactura(e.Message);
            }
            catch (Exception e)
            {
                throw new ExceptionPresupuestoFactura(e.Message);
            }
        }


        public List<Entidad> RegresarListadoXNombre(String nombreTratamiento)
        {
            try
            {
                manejador = new DAOPresupuestoFactura();
                return manejador.SqlBuscarXNombreTramiento(nombreTratamiento);
            }
            catch (ExceptionPresupuestoFactura e)
            {
                throw new ExceptionPresupuestoFactura(e.Message);
            }
            catch (Exception e)
            {
                throw new ExceptionPresupuestoFactura(e.Message);
            }


        }
        #endregion


    }
}