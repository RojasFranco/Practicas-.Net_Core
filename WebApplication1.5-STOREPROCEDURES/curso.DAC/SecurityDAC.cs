using curso.common.DTOs;
using curso.DAC.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace curso.DAC
{
	public class SecurityDAC : BaseDAC
	{
		private static readonly string _classFullName = MethodBase.GetCurrentMethod().DeclaringType?.ToString();
		public SecurityDAC(string connectionString) : base(connectionString)
		{
			try
			{
				base.OpenConnection();
			}
			catch (Exception ex)
			{
				throw new Exception(_classFullName + ".SecurityDAC(string connectionString) (ctor)", ex);
			}
		}

		public LoginResultDTO Login(UserDTO userDTO)
		{
			LoginResultDTO loginResultDTO = new LoginResultDTO(); ;
			IDataReader reader = null;
			using (IDbCommand oCommand = base.GetCommand())
			{
				try
				{
					oCommand.CommandType = CommandType.StoredProcedure;
					oCommand.CommandText = "[dbo].[Logueo]";

					IDbDataParameter oParam = oCommand.CreateParameter();
					oParam.DbType = DbType.AnsiString;
					oParam.Value = userDTO.User;
					oParam.ParameterName = "usuarioProcedure";
					oCommand.Parameters.Add(oParam);

					reader = oCommand.ExecuteReader();
					while (reader.Read())
					{
						loginResultDTO.User = new UserDTO(reader["UsuarioDB"].ToString(), reader["PasswordDB"].ToString());
					}
					return loginResultDTO;
				}
				catch (Exception ex)
				{
					throw new Exception(_classFullName + ".Login(UserDTO userDTO)", ex);
				}
				finally
				{
					if (!reader.IsClosed)
						reader.Close();
					if (!TransactionOpened())
						base.CloseCommand();
				}
			}

		}
		/*
				public LoginResultDTO Login(UserDTO userDTO)
				{
					LoginResultDTO loginResultDTO = new LoginResultDTO();
					loginResultDTO.Status = "ok";
					loginResultDTO.Message = "grilla.html";
					return loginResultDTO;
				}
				*/
		public bool CambioContrania(UserDTO userDTO, string nuevaContrasenia)
		{
			using (IDbCommand oCommand = base.GetCommand())
			{				
				try
				{
					string usuarioCambiar = userDTO.User;
					oCommand.CommandType = CommandType.StoredProcedure;
					oCommand.CommandText = "[dbo].[CambiarContrasenia]";

					IDataParameter oParam = oCommand.CreateParameter();
					oParam.ParameterName = "contraNuevaProcedure";
					oParam.Value = nuevaContrasenia;
					oParam.DbType = DbType.AnsiString;
					oCommand.Parameters.Add(oParam);


					IDataParameter oParamDos = oCommand.CreateParameter();
					oParamDos.ParameterName = "usuarioCambiarProcedure";
					oParamDos.Value = userDTO.User;
					oParamDos.DbType = DbType.AnsiString;
					oCommand.Parameters.Add(oParamDos);

					oCommand.ExecuteNonQuery();

					return true;
				}
				catch (Exception ex)
				{
					throw new Exception(_classFullName + ".CambioContrania(UserDTO userDTO, string nuevaContrasenia)", ex);
				}
				finally
				{
					if (!TransactionOpened())
						base.CloseCommand();
				}
			}

		}
	}
}
