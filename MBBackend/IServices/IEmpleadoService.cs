using MBBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MBBackend.IServices
{
    public interface IEmpleadoService
    {
        Empleado Add(Empleado oEmpleado);
        List<Empleado> Gets();
        Empleado Get(int EmpleadoId);
        string Delete(int EmpleadoId);
        string Update(int EmpleadoId);

    }
}
