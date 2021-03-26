namespace ApiToka.Infrastrucure.Repositories
{
    using ApiToka.Core.CustomEntities;
    using ApiToka.Core.Entites;
    using ApiToka.Core.Interfaces.Repositories;
    using ApiToka.Infrastrucure.Data;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using System.Threading.Tasks;
    public class PersonaRepository : IPersonaRepository
    {
        #region Constructor
        public PersonaRepository(TOKAContext contex)
        {
            this.baseDatos = contex;
        }
        #endregion

        #region Propiedades
        private TOKAContext baseDatos;
        #endregion

        #region Métodos
        public async Task<Response<List<TbPersonasFisicas>>> ObtenerPersonasFisicas()
        {
            Response<List<TbPersonasFisicas>> responseUsuarios = new Response<List<TbPersonasFisicas>>();
            try
            {
                await this.baseDatos.Database.OpenConnectionAsync();
                var dbCommand = this.baseDatos.Database.GetDbConnection().CreateCommand();

                dbCommand.CommandText = "sp_ConsultarUsuarios";
                dbCommand.CommandType = CommandType.StoredProcedure;

                DbDataReader resultadoDb = await dbCommand.ExecuteReaderAsync();
                responseUsuarios.Data = new List<TbPersonasFisicas>();
                if (resultadoDb.HasRows)
                {
                    while (resultadoDb.Read())
                    {
                        var Personsa = new TbPersonasFisicas
                        {
                            IdPersonaFisica = resultadoDb.GetInt32(0),
                            FechaRegistro = resultadoDb.GetDateTime(1),
                            Nombre = resultadoDb.GetString(3),
                            ApellidoPaterno = resultadoDb.GetString(4),
                            ApellidoMaterno = resultadoDb.GetString(5),
                            Rfc = resultadoDb.GetString(6),
                            FechaNacimiento = resultadoDb.GetDateTime(7),
                            UsuarioAgrega = resultadoDb.GetInt32(8),
                            Activo = resultadoDb.GetBoolean(9)
                        };
                        if (!resultadoDb.IsDBNull(2))
                        {
                            Personsa.FechaActualizacion = resultadoDb.GetDateTime(2);
                        }

                        responseUsuarios.Data.Add(Personsa);
                    }
                    responseUsuarios.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                responseUsuarios.Mensaje = ex.ToString();
            }
            finally
            {
                await this.baseDatos.Database.CloseConnectionAsync();
            }
            return responseUsuarios;
        }

        public Task<SimpleResponse> ActualizarPersonaFisica(TbPersonasFisicas personasFisicas)
        {
            throw new System.NotImplementedException();
        }

        public async Task<SimpleResponse> BorrarPersonaFisica(int IdPersona)
        {
            SimpleResponse simpleResponseAltaUsuario = new SimpleResponse();
           
            try
            {
                await this.baseDatos.Database.OpenConnectionAsync();
                var dbCommand = this.baseDatos.Database.GetDbConnection().CreateCommand();
                #region Paramethers

                DbParameter idPersonaFisicaParameter = dbCommand.CreateParameter();
                idPersonaFisicaParameter.ParameterName = "IdPersonaFisica";
                idPersonaFisicaParameter.Value = IdPersona;
                dbCommand.Parameters.Add(idPersonaFisicaParameter);
                #endregion

                dbCommand.CommandText = "sp_EliminarPersonaFisica";
                dbCommand.CommandType = CommandType.StoredProcedure;

                DbDataReader resultadoDb = await dbCommand.ExecuteReaderAsync();

                if (resultadoDb.HasRows)
                {
                    if (resultadoDb.Read())
                    {
                        simpleResponseAltaUsuario.Exito = resultadoDb.GetInt32(0);
                        simpleResponseAltaUsuario.Mensaje = resultadoDb.GetString(1);
                    }
                }
                else
                {
                    simpleResponseAltaUsuario.Exito = 1;
                    simpleResponseAltaUsuario.Mensaje = "Borrado exitoso";
                }

            }
            catch (Exception ex)
            {
                simpleResponseAltaUsuario.Exito = 0;
                simpleResponseAltaUsuario.Mensaje = ex.ToString();
            }
            finally
            {
                await this.baseDatos.Database.CloseConnectionAsync();
            }
            return simpleResponseAltaUsuario;
        }

        public async Task<SimpleResponse> RegistrarPersonaFisica(TbPersonasFisicas personasFisicas)
        {
            SimpleResponse simpleResponseAltaUsuario = new SimpleResponse();
            await this.baseDatos.Database.OpenConnectionAsync();
            var dbCommand = this.baseDatos.Database.GetDbConnection().CreateCommand();
            try
            {
                #region Paramethers

                DbParameter nombreParameter = dbCommand.CreateParameter();
                nombreParameter.ParameterName = "Nombre";
                nombreParameter.Value = personasFisicas.Nombre;
                dbCommand.Parameters.Add(nombreParameter);

                DbParameter apellidoPaternoParameter = dbCommand.CreateParameter();
                apellidoPaternoParameter.ParameterName = "ApellidoPaterno";
                apellidoPaternoParameter.Value = personasFisicas.ApellidoPaterno;
                dbCommand.Parameters.Add(apellidoPaternoParameter);

                DbParameter apellidoMaternoParameter = dbCommand.CreateParameter();
                apellidoMaternoParameter.ParameterName = "ApellidoMaterno";
                apellidoMaternoParameter.Value = personasFisicas.ApellidoMaterno;
                dbCommand.Parameters.Add(apellidoMaternoParameter);

                DbParameter rfcParameter = dbCommand.CreateParameter();
                rfcParameter.ParameterName = "RFC";
                rfcParameter.Value = personasFisicas.Rfc;
                dbCommand.Parameters.Add(rfcParameter);

                DbParameter fechaNacimientoParameter = dbCommand.CreateParameter();
                fechaNacimientoParameter.ParameterName = "FechaNacimiento";
                fechaNacimientoParameter.Value = personasFisicas.FechaNacimiento;
                dbCommand.Parameters.Add(fechaNacimientoParameter);

                DbParameter usuarioAgregaParameter = dbCommand.CreateParameter();
                usuarioAgregaParameter.ParameterName = "UsuarioAgrega";
                usuarioAgregaParameter.Value = personasFisicas.UsuarioAgrega;
                dbCommand.Parameters.Add(usuarioAgregaParameter);
                #endregion

                dbCommand.CommandText = "sp_AgregarPersonaFisica";
                dbCommand.CommandType = CommandType.StoredProcedure;

                DbDataReader resultadoDb = await dbCommand.ExecuteReaderAsync();

                if (resultadoDb.HasRows)
                {
                    if (resultadoDb.Read())
                    {
                        simpleResponseAltaUsuario.Exito = resultadoDb.GetInt32(0);
                        simpleResponseAltaUsuario.Mensaje = resultadoDb.GetString(1);
                    }
                }

            }
            catch (Exception ex)
            {
                simpleResponseAltaUsuario.Exito = 0;
                simpleResponseAltaUsuario.Mensaje = ex.ToString();
            }
            finally
            {
                await this.baseDatos.Database.CloseConnectionAsync();
            }
            return simpleResponseAltaUsuario;
        }
        #endregion
    }
}
