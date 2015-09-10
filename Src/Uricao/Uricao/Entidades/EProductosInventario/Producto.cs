using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.Entidades.EProveedores;
using Uricao.Entidades.EEntidad;

namespace Uricao.Entidades.EProductosInventario
{
    public class Producto : Entidad
    {
        #region Codigo realizado por Tratamiento
        private Int16 _Id;

        public Int16 Id { get { return _Id; } set { this._Id = value; } }
        #endregion

        private String codigo;
        private String nombre;
        private String tipo;
        private Int16 categoria;
        private String NombreCategoria;
        private Int16 cantidadMinInventario;
        private String marca;
        private String calidad;
        private Decimal precio;
        private String inconvenientes;
        private Proveedor proveedor;

        public Producto() { }

        public Producto(String codigo, String nombre, String tipo, Int16 categoria, Int16 cantMinima, String marca, String calidad,
                                        Decimal precio, String inconvenientes, Proveedor proveedor)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.tipo = tipo;
            this.categoria = categoria;
            this.cantidadMinInventario = cantMinima;
            this.marca = marca;
            this.calidad = calidad;
            this.precio = precio;
            this.inconvenientes = inconvenientes;
            this.proveedor = proveedor;
        }

        /*----------Propiedades----------*/

        public String Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        
        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        
        public String Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
        
        public Int16 Categoria
        {
            get { return categoria; }
            set { categoria = value; }
        }

        public String nombreCategoria
        {
            get { return NombreCategoria; }
            set { NombreCategoria = value; }
        }

        public Int16 CantidadMinInventario
        {
            get { return cantidadMinInventario; }
            set { cantidadMinInventario = value; }
        }
        
        public String Marca
        {
            get { return marca; }
            set { marca = value; }
        }  

        public String Calidad
        {
            get { return calidad; }
            set { calidad = value; }
        }
        
        public Decimal Precio
        {
            get { return precio; }
            set { precio = value; }
        }
        
        public String Inconvenientes
        {
            get { return inconvenientes; }
            set { inconvenientes = value; }
        }

        public Proveedor Proveedor
        {
            get { return proveedor; }
            set { proveedor = value; }
        }

    }
}