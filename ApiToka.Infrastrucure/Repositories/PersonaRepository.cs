namespace ApiToka.Infrastrucure.Repositories
{
    using ApiToka.Core.CustomEntities;
    using ApiToka.Core.Entites;
    using ApiToka.Core.Interfaces.Repositories;
    using ApiToka.Infrastrucure.Data;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
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
                dbCommand.CommandType = System.Data.CommandType.StoredProcedure;

                DbDataReader resultadoDb = await dbCommand.ExecuteReaderAsync();
                responseUsuarios.Data = new List<TbPersonasFisicas>();
                if (resultadoDb.HasRows)
                {
                    while (resultadoDb.Read())
                    {
                        responseUsuarios.Data.Add(new TbPersonasFisicas
                        {
                            IdPersonaFisica = resultadoDb.GetInt32(0),
                            FechaRegistro = resultadoDb.GetDateTime(1),
                            FechaActualizacion = resultadoDb.GetDateTime(2),
                            Nombre = resultadoDb.GetString(3),
                            ApellidoPaterno = resultadoDb.GetString(4),
                            ApellidoMaterno = resultadoDb.GetString(5),
                            Rfc = resultadoDb.GetString(6),
                            FechaNacimiento = resultadoDb.GetDateTime(7),
                            UsuarioAgrega = resultadoDb.GetInt32(8),
                            Activo = resultadoDb.GetBoolean(9)
                        });
                    }
                    responseUsuarios.Exito = true;
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

        public Task<SimpleResponse> BorrarPersonaFisica(int IdPersona)
        {
            throw new System.NotImplementedException();
        }

        public Task<SimpleResponse> RegistrarPersonaFisica(TbPersonasFisicas personasFisicas)
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}
