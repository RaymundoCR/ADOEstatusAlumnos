using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOEstatusAlumnos
{
    interface ICRUD
    {
        List<Estatus> Consultar();
        Estatus Consultar (int id);
        int Agregar (Estatus estatus);
        void Actualizar (Estatus estatus);
        void Eliminar (Estatus estatus);
    }
}
