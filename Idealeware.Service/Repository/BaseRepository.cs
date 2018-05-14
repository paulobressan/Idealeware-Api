using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace Idealeware.Service.Repository
{
    public class BaseRepository : IDisposable
    {
        protected IDbConnection context { get; set; }
        public BaseRepository()
        {
            context = new MySqlConnection("server=localhost; database=idealeware; user id=root; password=2cnbrf4642;");
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
