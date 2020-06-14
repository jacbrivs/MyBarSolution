using Dapper;
using MBBackend.Common;
using MBBackend.IServices;
using MBBackend.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MBBackend.Services
{
    public class EmpleadoService : IEmpleadoService
    {
        Empleado _oEmpleado = new Empleado();
        List<Empleado> _oEmpleados = new List<Empleado>();

        public Empleado Add(Empleado oEmpleado)
        {
            _oEmpleado = new Empleado();
            
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    //int operationtype = Convert.ToInt32(_oEmpleado.Id == 0 ? OperationType.Add : OperationType.Update);
                    
                    if (con.State == ConnectionState.Closed) con.Open();                    
                    var oEmpleados = con.Query<Empleado>("usp_InsertEmpleado", this.setParameters(oEmpleado),
                        commandType: CommandType.StoredProcedure) ;
                }
            }
            catch (Exception ex)
            {

                _oEmpleado.Error = ex.Message;
            }

            return _oEmpleado;
        }

        public string Delete(int EmpleadoId)
        {
            throw new NotImplementedException();
        }

        public Empleado Get(int EmpleadoId)
        {
            throw new NotImplementedException();
        }

        public List<Empleado> Gets()
        {
            throw new NotImplementedException();
        }

        public string Update(int EmpleadoId)
        {
            throw new NotImplementedException();
        }

        private DynamicParameters setParameters(Empleado oEmpleado)
        {
            DynamicParameters parameters = new DynamicParameters();            
            parameters.Add("@Cedula", oEmpleado.Cedula);
            parameters.Add("@Nombre1", oEmpleado.Nombre1);
            parameters.Add("@Nombre2", oEmpleado.Nombre2);
            parameters.Add("@Apellido1", oEmpleado.Apellido1);
            parameters.Add("@Apellido2", oEmpleado.Apellido2);
            parameters.Add("@Celular", oEmpleado.Celular);
            parameters.Add("@Direccion", oEmpleado.Direccion);
            parameters.Add("@Usuario", oEmpleado.Usuario);
            parameters.Add("@Password", oEmpleado.Password);
            return parameters;
       
        }
    }
}
