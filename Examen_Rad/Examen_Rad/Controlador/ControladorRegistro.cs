using Examen_Rad.Modelo;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Examen_Rad.Modelo;

namespace Examen_Rad.Controlador
{
    public class ControladorRegistro
    {
        readonly SQLiteAsyncConnection connection;

        public ControladorRegistro(String dbpath)
        {
            // Crear una nueva conexion hacia la base de datos
            connection = new SQLiteAsyncConnection(dbpath);

            // Crear los objetos de base de datos que vamos a ocupar
            connection.CreateTableAsync<ClaseRegistro>().Wait();
        }

        public Task<int> SaveAlum(ClaseRegistro claseRegistro)
        {
            if (claseRegistro.id != 0)
                return connection.UpdateAsync(claseRegistro);
            else
                return connection.InsertAsync(claseRegistro);
        }

        // Read
        public Task<List<ClaseRegistro>> GetListAlumn()
        {
            return connection.Table<ClaseRegistro>().ToListAsync();
        }

        public Task<ClaseRegistro> GetAlumno(int pid)
        {
            return connection.Table<ClaseRegistro>()
                .Where(i => i.id == pid)
                .FirstOrDefaultAsync();
        }

        // Delete
        public Task<int> DeleteAlumn(ClaseRegistro claseRegistro)
        {
            return connection.DeleteAsync(claseRegistro);
        }
    }
}
