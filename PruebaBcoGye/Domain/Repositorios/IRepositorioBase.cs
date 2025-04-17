using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositorios
{
    public interface IRepositorioBase<T>
    {
        Task<T> ConsultarPorIdAsync(int id);
        Task<IEnumerable<T>> ConsultarTodosAsync();
        Task GrabarAsync(T entity);
        Task GrabarArregloAsync(List<T> entity);
        Task BulkInsertAsync(List<T> entity);

        Task ActualizarAsync(T entity);
        Task ActualizarArregloAsync(List<T> entity);
    }
}
