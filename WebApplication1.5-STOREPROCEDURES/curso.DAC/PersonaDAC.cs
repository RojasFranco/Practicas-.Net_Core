using curso.common.DTOs;
using curso.DAC.Base;
using System;
using System.Data;
using System.Reflection;

namespace curso.DAC
{
	public class PersonaDAC : BaseDAC
	{
		private static readonly string _classFullName = MethodBase.GetCurrentMethod().DeclaringType?.ToString();
		public PersonaDAC(string connectionString) : base(connectionString)
		{
			try
			{
				base.OpenConnection();
			}
			catch (Exception ex)
			{
				throw new Exception(_classFullName + ".PersonaDAC(string connectionString) (ctor)", ex);
			}
		}
		public TableJSONv4<PersonaV3> ObtenerPersonas()
		{
			//TableJSONv4<PersonaV3> tableJSON = new TableJSONv4<PersonaV3>();
			//for (int i = 0; i < 100; i++)
			//{
			//	PersonaV3 persona = new PersonaV3("Jose-" + i.ToString(), "Perez-" + i.ToString());
			//	tableJSON.Data.Add(persona);
			//}
			//return tableJSON;
			TableJSONv4<PersonaV3> tableJSON = null;
			IDataReader reader = null;
			using (IDbCommand oCommand = base.GetCommand())
			{
				try
				{
					oCommand.CommandType = CommandType.Text;
					oCommand.CommandText = @"SELECT * 
                                            FROM [dbo].[Persona] as T";
                                            //where user = @user;";


					//oCommand.AddParameter("user", DbType.AnsiString, "sdfdsf");

					tableJSON = new TableJSONv4<PersonaV3>();
					reader = oCommand.ExecuteReader();
					while (reader.Read())
					{
						tableJSON.Data.Add(new PersonaV3(reader["Nombre"].ToString(), reader["Apellido"].ToString()));
					}
					return tableJSON;
				}
				catch (Exception ex)
				{
					throw new Exception(_classFullName + ".ObtenerPersonas()", ex);
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
	}
}
