﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Uricao.Entidades.EEntidad;

namespace Uricao.Presentacion.Contrato.CTratamientos
{
    public interface IContratoModificarTratamiento
    {
        GridView GridTratamiento { get; set; }
    }
}