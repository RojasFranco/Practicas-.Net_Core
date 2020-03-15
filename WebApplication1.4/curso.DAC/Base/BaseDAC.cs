using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace curso.DAC.Base
{
	public interface ITransactionDAC
	{
		IDbTransaction BeginTransaction();
		void BeginTransaction(IDbTransaction oTransaction);
		bool TransactionOpened();
		void Commit();
		void Rollback();
	}

	public class BaseDAC : AbstractBaseDAC, ITransactionDAC, IDisposable
	{
		#region --Attributes--

		private static readonly string _classFullName = MethodBase.GetCurrentMethod().DeclaringType.ToString();
		private string _connectionString;
		private IDbCommand _oDbCommand;
		private IDbConnection _oDbConnection;
		private IDbTransaction _oDbTransaction;

		#endregion --Attributes--

		#region --Properties--

		protected override string ConnectionString
		{
			get { return _connectionString; }
			set { _connectionString = value; }
		}

		#endregion --Properties--

		#region --Constructors & Destructors--

		protected BaseDAC(string connectionString)
		{
			try
			{
				_connectionString = connectionString;
			}
			catch (Exception e)
			{
				throw new Exception(_classFullName + ".BaseDAC() [Constructor]", e);
			}
		}

		#endregion --Constructors & Destructors--

		#region --Methods--

		#region --Transaction ITransactionDAC members--

		public IDbTransaction BeginTransaction()
		{
			_oDbTransaction = GetConnection().BeginTransaction();
			return _oDbTransaction;
		}

		public void BeginTransaction(IDbTransaction oTransaction)
		{
			_oDbTransaction = oTransaction;
			CloseConnection();
			_oDbConnection = oTransaction.Connection;
		}

		public void Commit()
		{
			if (_oDbTransaction != null)
				_oDbTransaction.Commit();
			_oDbTransaction = null;
			CloseCommand();
		}

		public void Rollback()
		{
			if (_oDbTransaction != null)
				_oDbTransaction.Rollback();
			_oDbTransaction = null;
			CloseCommand();
		}

		public void Rollback(string transactionName)
		{
			if (_oDbTransaction != null)
				_oDbTransaction.Rollback();
			_oDbTransaction = null;
			CloseCommand();
		}

		public bool TransactionOpened()
		{
			return _oDbTransaction != null;
		}

		#endregion --Transaction--

		#region --Connection--

		protected override void OpenConnection()
		{
			try
			{
				if (_oDbConnection == null)
					SetConnection();
				else if (_oDbConnection.State == ConnectionState.Closed)
					_oDbConnection.Open();
			}
			catch (Exception e)
			{
				throw new Exception(_classFullName + ".OpenConnection()", e);
			}
		}

		protected override void CloseConnection()
		{
			if (_oDbConnection != null)
			{
				if (_oDbConnection.State != ConnectionState.Closed)
				{
					try
					{
						_oDbConnection.Close();
					}
					catch (Exception e)
					{
						throw new Exception(_classFullName + ".CloseConnection()", e);
					}
				}
			}
		}

		protected override IDbCommand GetCommand()
		{
			try
			{
				OpenCommand();
				_oDbCommand.Parameters.Clear();
				return _oDbCommand;
			}
			catch (Exception e)
			{
				throw new Exception(_classFullName + ".GetCommand()", e);
			}
		}

		protected override void OpenCommand()
		{
			if (_oDbCommand == null)
				_oDbCommand = GetConnection().CreateCommand();
			else
			{
				if (_oDbCommand.Connection.State == ConnectionState.Closed)
				{
					SetConnection();
					_oDbCommand.Connection = _oDbConnection;
				}
			}
			if (_oDbTransaction != null)
				_oDbCommand.Transaction = _oDbTransaction;
		}

		protected override void CloseCommand()
		{
			if (_oDbCommand != null)
			{
				_oDbCommand.Dispose();
				_oDbCommand = null;
				CloseConnection();
			}
		}

		protected override IDbDataAdapter CreateDataAdapter(string sql)
		{
			try
			{
				return new SqlDataAdapter(sql, _connectionString);
			}
			catch (Exception ex)
			{
				throw new Exception(_classFullName + ".CreateDataAdapter(string sql)", ex);
			}
		}

		protected override IDbDataAdapter CreateDataAdapter()
		{
			try
			{
				return new SqlDataAdapter();
			}
			catch (Exception ex)
			{
				throw new Exception(_classFullName + ".CreateDataAdapter()", ex);
			}
		}

		private void SetConnection()
		{
			try
			{
				_oDbConnection = new SqlConnection(_connectionString);
				try
				{
					_oDbConnection.Open();
				}
				catch (Exception ex1)
				{
					throw new Exception(_classFullName + ".SetConnection()", ex1);
				}
			}
			catch (Exception ex2)
			{
				throw new Exception(_classFullName + ".SetConnection()", ex2);
			}
		}

		private IDbConnection GetConnection()
		{
			OpenConnection();
			return _oDbConnection;
		}

		#endregion

		#endregion --Methods--

		public void Dispose()
		{
			this.CloseConnection();
		}
	}
}
