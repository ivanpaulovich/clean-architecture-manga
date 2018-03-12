namespace Manga.Infrastructure.DataAccess.EntityFramework
{
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class DapperReadOnlyRepository : IDisposable
    {

        public IDbConnection Connection
        {
            private set;
            get;
        }

        public DapperReadOnlyRepository(string connectionString)
        {
            Connection = new SqlConnection(connectionString);
        }

        public DapperReadOnlyRepository(IDbConnection connection)
        {
            Connection = connection ?? throw new ArgumentNullException(nameof(connection));
        }

        public void Dispose()
        {
            if (Connection == null)
            {
                return;
            }

            Connection.Close();
            GC.SuppressFinalize(this);
        }
    }
}
