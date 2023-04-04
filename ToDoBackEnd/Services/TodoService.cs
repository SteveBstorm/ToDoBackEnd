using Dapper;
using System.Data.SqlClient;
using ToDoBackEnd.Models;

namespace ToDoBackEnd.Services
{
    public class TodoService
    {
        private SqlConnection _connection;
        public TodoService(SqlConnection connection)
        {
            _connection = connection;
        }

        public void Create(string name)
        {
            string sql = "INSERT INTO Todo (Name) VALUES (@name)";
            var param = new { name = name };
            _connection.Execute(sql, param);
        }

        public void Finish(string name)
        {
            string sql = "Update Todo SET IsFinished = 1 WHERE Name = @name";
            var param = new { name = name };
            _connection?.Execute(sql, param);
        }
        public void Delete(string name)
        {
            string sql = "DELETE FROM Todo WHERE Name = @name";
            var param = new { name = name };
            _connection.Execute(sql, param);
        }

        public IEnumerable<Todo> GetAll()
        {
            string sql = "SELECT * FROM Todo";
            return _connection.Query<Todo>(sql);
        }
    }
}
