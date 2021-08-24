using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using C_Datos;
using C_Entidad;

namespace C_Negocio
{
    public class ClassNegocio
    {
        ClassDatos objd = new ClassDatos();

        public DataTable N_listar_clientes()
        {
            return objd.D_listar_clientes();
        }

        public DataTable N_buscar_clientes_nombre(ClassEntidad obje)
        {
            return objd.D_buscar_clientes_nombre(obje);
        }

        public DataTable N_buscar_clientes_codigo(ClassEntidad obje)
        {
            return objd.D_buscar_clientes_codigo(obje);
        }

        public string N_mantenimiento_cliente(ClassEntidad obje)
        {
            return objd.D_mantenimiento_clientes(obje);
        }
    }
}
