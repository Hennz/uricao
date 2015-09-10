// File: FabricaConexion.cs Company: La Cruz 
// Copyright (c) 01-05-2013 All Right Reserved
// author: Enrique La Cruz
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uricao.AccesoDeDatos.Conexion.InterfazConexion;

namespace Uricao.AccesoDeDatos.Conexion
{
    public class FabricaConexion
    {
        public static IConexionDAOS AccesoConexion()
        {
            return new ConexionDAOS();
        }      
    }
}