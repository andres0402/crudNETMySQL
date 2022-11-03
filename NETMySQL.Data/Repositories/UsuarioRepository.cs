using Dapper;
using MySql.Data.MySqlClient;
using NETMySQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NETMySQL.Data.Repositories
{
    public class UsuarioRepository : IUsuariosRepository
    {
        private MySQLConfiguration _connectionString;

        public UsuarioRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        async Task<bool> IUsuariosRepository.DeleteUsuario(Usuario usuario)
        {
            

            var db = dbConnection();

            var sql = @"DELETE FROM netmysql.usuario WHERE id_usuario = @Id";

            var result = await db.ExecuteAsync(sql, new { Id = usuario.id_usuario });
            return result > 0;
        }

        async Task<IEnumerable<Usuario>> IUsuariosRepository.GetAllUsuarios()
        {
            var db = dbConnection();

            var sql = @"SELECT * FROM netmysql.usuario";

            return await db.QueryAsync<Usuario>(sql, new { });
        }

        async Task<Usuario> IUsuariosRepository.GetUsuarioDetails(int id)
        {
            var db = dbConnection();

            var sql = @"SELECT * FROM netmysql.usuario WHERE id_usuario = @Id";

            return await db.QueryFirstOrDefaultAsync<Usuario>(sql, new { Id = id });
        }

        async Task<bool> IUsuariosRepository.InsertUsuario(Usuario usuario)
        {
            var db = dbConnection();

            var sql = @"INSERT INTO netmysql.usuario (id_usuario, nombres, apellidos, username, pass) VALUES  (@id_usuario, @nombres, @apellidos, @username, @pass)";

            var result = await db.ExecuteAsync(sql, new { usuario.id_usuario, usuario.nombres, usuario.apellidos, usuario.username, usuario.pass });
            return result > 0;
        }

        async Task<bool> IUsuariosRepository.UpdateUsuario(Usuario usuario)
        {
            var db = dbConnection();

            var sql = @"UPDATE netmysql.usuario SET nombres = @nombres, apellidos = @apellidos, username = @username, pass = @pass WHERE id_usuario = @id_usuario";

            var result = await db.ExecuteAsync(sql, new { usuario.nombres, usuario.apellidos, usuario.username, usuario.pass, usuario.id_usuario });
            return result > 0;
        }
    }
}
