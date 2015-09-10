using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EPresupuestoFacturas;
using Uricao.Entidades.ERolesUsuarios;
using Uricao.Entidades.ETratamientos;
using Uricao.AccesoDeDatos.DAOS;
using System.Data;
using Uricao.LogicaDeNegocios.Excepciones;

namespace Uricao.LogicaDeNegocios.Clases.LNPresupuestoFacturas
{
    public class LogicaPresupuestos
    {
        private const double iva = 0.12;
        private DAOPresupuestoFactura manejador;

        public LogicaPresupuestos() { }


        #region Usos varios

        public int regresar_presupuesto_numero()
        {
            // el ultimo valor de la lista de presupuestos (el current value) y sumarle 1
            return 0;
        }

        #endregion

        #region Logica de Consultar Presupuesto

        public double regresar_costo_tratamiento(int id_tratamiento)
        {
            try
            {
                manejador = new DAOPresupuestoFactura();
                return manejador.RegresarCostoTratamiento(id_tratamiento);
            }

            catch (ArithmeticException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Problemas con calculos aritmeticos",e);
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

        /*
        public short CalculoDeCostoTotalTratamiento(List<Enti> listado_tratamiento, int posicion)
        {
            try
            {
                manejador = new DAOPresupuestoFactura();
                return (short)(listado_tratamiento[posicion].Duracion *
                        this.regresar_costo_tratamiento(listado_tratamiento[posicion].Id));
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
                
        }*/
            
        //listo
        //public List<Presupuesto> ObtenerListaPresupuestoCompleta()
        //{
        //    try
        //    {
        //        DAOPresupuestoFactura servidorSQL = new DAOPresupuestoFactura();
        //        return servidorSQL.ConsultarPresupuestosTodos();
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

        /*
        //listo
        public List<Presupuesto> ObtenerListaPresupuestoFechas(string fechaInicio, string fechaFin) 
        {
            try
            {
                DAOPresupuestoFactura servidorSQL = new DAOPresupuestoFactura();
                return servidorSQL.ConsultarPresupuestosRangoFechas(fechaInicio, fechaFin);
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
        */

        //listo
        //public Presupuesto ObtenerPresupuestoCI(String ci)
        //{
        //    try
        //    {
        //        DAOPresupuestoFactura servidorSQL = new DAOPresupuestoFactura();
        //        return servidorSQL.ConsultarPresupuestoXCI(ci);
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

        /*
        //listo
        public Presupuesto ObtenerPresupuestoPorNumero(int numeroPresupuesto) 
        {
            try
            {   //parse de numero de presupuesto
                DAOPresupuestoFactura servidorSQL = new DAOPresupuestoFactura();
                return servidorSQL.ConsultarPresupuestoNumero(numeroPresupuesto);
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
        */

        //listo
        /*
        public string ObtenerCedulaUsuarioPresupuesto(int nro_presupuesto)
        {
            try
            {
                DAOPresupuestoFactura servidorSQL = new DAOPresupuestoFactura();
                String cedula = servidorSQL.ConsultarCedulaPresupuesto(nro_presupuesto);
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
        */

        /// <summary>
        /// Método que borra la tabla cada
        /// vez que se selecciona el radiobutton
        /// </summary>
        /// <param name="miTabla"></param>
        /// <returns></returns>
        
        //listo
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


        //listo
        //public List<Detalle_Presupuesto_Factura> ObtenerDetallePresupuesto(int nro_presupuesto)
        //{
        //    try
        //    {
        //        DAOPresupuestoFactura servidorSQL = new DAOPresupuestoFactura();
        //        List<Detalle_Presupuesto_Factura> listaDetalle = servidorSQL.ConsultarDetallePresupuesto(nro_presupuesto);
        //        return servidorSQL.ConsultarTratamientosListaDetalle(listaDetalle);
        //    }
        //    catch (ExceptionPresupuestoFactura e)
        //    {
        //        throw new ExceptionPresupuestoFactura(e.Message);
        //    }
        //    catch (Exception e)
        //    {
        //        throw new ExceptionPresupuestoFactura(e.Message);
        //    }
        //    }
            
        #endregion


        #region Generar presupuesto
           
        

        public int SubtotalFactura(List<Tratamiento> listado_tratamiento)
        {
            try
            {
                int subtotal = 0;
                for (int i = 0; i < listado_tratamiento.Count; i++)
                {
                    subtotal = subtotal + listado_tratamiento[i].Costo;
                }
                return subtotal;
            }
            catch (ArithmeticException e)
            {
                throw new ExceptionPresupuestoFactura("Error: Problemas con calculos aritmeticos",e);
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

        /*
        public bool insertarPresupuesto(Presupuesto presupuesto, string cedulaUsuario)
        {
            try
            {
                manejador = new DAOPresupuestoFactura();
                int idUsuario = manejador.RegresarIdUsuario(cedulaUsuario);
                if (manejador.AgregarPresupuesto(presupuesto, idUsuario))
                {
                    if (manejador.AgregarDetallePresupuesto(presupuesto, idUsuario,
                        manejador.RegresarIdPresupuesto(presupuesto, idUsuario)))
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
        */


        public string retornarDatosUsuario(string cedulaUsuario, string tipoCi)
        {
            try
            {
                DAOPresupuestoFactura servidorSQL = new DAOPresupuestoFactura();
                return servidorSQL.regresarDatosUsuario(cedulaUsuario, tipoCi);
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



        //listo
        //public bool validarUsuario(string cedulaUsuario, string tipoCi)
        //{
        //    try
        //    {
        //        manejador = new DAOPresupuestoFactura();
        //        return manejador.validarUsuario(cedulaUsuario, tipoCi);
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


    }
}