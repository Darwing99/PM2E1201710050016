using PM2E1201710050016.clases;
using PM2E1201710050016.model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PM2E1201710050016.clases
{
    class Crud
    {
        Conexion conn = new Conexion();



        public Task<List<Ubicacion>> getReadUbicacion()
        {
            return conn.GetConnectionAsync().Table<Ubicacion>().ToListAsync();
        }

        public Task<Ubicacion> getUbicacionId(int id)
        {
            return conn
                .GetConnectionAsync()
                .Table<Ubicacion>()
                .Where(item => item.id == id)
                .FirstOrDefaultAsync();
        }

        public Task<int> getUbicacionUpdateId(Ubicacion ubicacion)
        {
            return conn
                .GetConnectionAsync()
                .UpdateAsync(ubicacion);

        }

        public Task<int> Delete(Ubicacion ubicacion)
        {
            return conn
                .GetConnectionAsync()
                .DeleteAsync(ubicacion);
        }
    }
}
