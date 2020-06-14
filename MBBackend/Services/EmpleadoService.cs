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
                    

                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        var oEmpleados = con.Query<Empleado>("usp_InsertEmpleado", this.setParameters(oEmpleado),
                        commandType: CommandType.StoredProcedure);
                    }
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
            
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {                                    

                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        
                        var param = new DynamicParameters();
                        param.Add("@Id", EmpleadoId);
                        con.Query("usp_DeleteEmpleado", param, commandType: CommandType.StoredProcedure).SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {

                _oEmpleado.Error = ex.Message;
            }
            return _oEmpleado.Error;
        }

        public Empleado Get(int EmpleadoId)
        {
            _oEmpleado = new Empleado();

            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {

                    if (con.State == ConnectionState.Closed)con.Open();                                         

                        var param = new DynamicParameters();
                        param.Add("@Id", EmpleadoId);
                        var oEmpleado = con.Query<Empleado>("usp_SelectEmpleado", param, commandType: CommandType.StoredProcedure).ToList();
                    if (oEmpleado != null && oEmpleado.Count() > 0)
                    {
                        _oEmpleado = oEmpleado.SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {

                _oEmpleado.Error = ex.Message;
            }
            return _oEmpleado;

        }

        public List<Empleado> Gets()
        {
            throw new NotImplementedException();
        }

        public Empleado Update(Empleado oEmpleado)
        {
            _oEmpleado = new Empleado();

            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {


                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        var oEmpleados = con.Query<Empleado>("usp_UpdateEmpleado", this.setParameters(oEmpleado),
                        commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception ex)
            {

                _oEmpleado.Error = ex.Message;
            }

            return _oEmpleado;
        }

        private DynamicParameters setParameters(Empleado oEmpleado)
        {
            DynamicParameters parameters = new DynamicParameters();
            if (oEmpleado.Id != 0) parameters.Add("@Id", oEmpleado.Id);            
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
