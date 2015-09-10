using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EAbonos;
using Uricao.Entidades.EPresupuestoFacturas;
using Uricao.AccesoDeDatos.DAOS;


namespace Uricao.LogicaDeNegocios.Clases.LNAbono
{
    public class LogicaAbono
    {
        #region Variables Para: CuentasPorCobrar
            List<Abono> _abonos = new List<Abono>();


        #endregion Variables Para: CuentasPorCobrar


            #region Metodos Para: CuentasPorCobrar

            public double CalcularDeuda() { return 0.0; }


            public bool AgregarAbonoCC(Abono _abono)
            {
                DAOAbono abono = new DAOAbono();
                if (abono.CantidadAbonos(_abono.Factura) == 0)
                {
                    System.Diagnostics.Debug.WriteLine(abono.CantidadAbonos(_abono.Factura));
                    if (abono.AgregarPrimerAbono(_abono))
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
                    if (abono.AgregarAbonoCC(_abono))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }


            }


            public List<Abono> ConsultarAbonos() { return null; }



            public bool ValidarMonto(int miFactura, double monto)
            {
                try
                {
                    DAOAbono abono = new DAOAbono();
                    double deuda = abono.ConsultarDeuda(miFactura);
                    if (deuda == 0)
                    {
                        return true;
                    }
                    else
                    {
                        if (monto < deuda)
                        {
                            return true;
                        }
                        else
                        {
                            if (deuda - monto == 0)
                            {
                                //aqui se llama al procedimiento para settear el estado de la factura en 1
                                return true;
                            }
                            else
                            {
                                return false;
                            }

                            return false;
                        }
                    }

                }

                catch (NullReferenceException e)
                {
                    throw new Exception("No hay deuda", e);
                }
                catch (Exception e)
                {
                    throw new Exception("Error en la consulta de la Deuda", e);
                }

            }

            #endregion Metodos Para: CuentasPorCobrar



        #region Variables Para: CuentasPorPagar

        #endregion Variables Para: CuentasPorPagar


        #region Metodos Para: CuentasPorPagar

           /* public List<Abono> llenarGridAbonos(string nombreProveedor, Int64 codigoCuenta)
            {
                List<Abono> miLogica = new List<Abono>();

                //Creo el objeto de ACCESO A BD de CuentaPorPagar:
                DAOAbono miAbonoBd = new DAOAbono();

                //Ejecuto el STORED PROCEDURE para sacar de la BD las CuentasPorPagar
                miLogica = miAbonoBd.llenarGridAbonos(nombreProveedor, codigoCuenta);

                return miLogica;
            }
        */

           /* public bool agregarAbono(Abono miAbono, Int64 idCuentaPP)
            {
                //Creo el objeto de ACCESO A BD de CuentaPorPagar:
                DAOAbono miDAOSAbonar = new DAOAbono();

                //Ejecuto el STORED PROCEDURE para INSERTAR en la BD las CuentasPorPagar:
                bool fueInsertado = miDAOSAbonar.agregarAbono(miAbono,idCuentaPP);

                //Retorna la variable boolena de confirmacion del exito de la insercion:
                return fueInsertado;
            }*/

        #endregion Metodos Para: CuentasPorPagar



    }
}