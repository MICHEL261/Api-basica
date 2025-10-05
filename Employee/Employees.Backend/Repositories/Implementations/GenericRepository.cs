using Employees.Backend.Data;
using Employees.Backend.Helpers;
using Employees.Shared.DTOs;
using Microsoft.EntityFrameworkCore;
using Orders.Backend.Repositories.Interfaces;
using Orders.Shared.Responses;

namespace Employees.Backend.Repositories.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DataContext _Context;
        private readonly DbSet<T> _entity;

        public GenericRepository(DataContext Context) {
            _Context = Context;
            _entity = _Context.Set<T>();

        }

        

        public virtual async Task<ActionResponse<T>> AddAsync(T entity)
        {
            _Context.Add(entity);

            try
            {
                
                await _Context.SaveChangesAsync();
                return new ActionResponse<T>
                {
                    WasSuccess = true,
                    Result = entity
                };
            }
            catch(Exception ex)
            {
                return new ActionResponse<T>
                {
                    WasSuccess = false,
                    Message = ex.Message
                };

            }
            
        }



        public virtual async Task<ActionResponse<T>> DeleteAsync(int id)
        {
            var row = await _entity.FindAsync(id);

         
            if (row == null)
            {
                new ActionResponse<T>
                {
                    Message = "No se encontró el registro"
                };

            }
            _entity.Remove(row);
            try
            {
                await _Context.SaveChangesAsync();
                return new ActionResponse<T>
                {
                    WasSuccess = true,
                };
            }
            catch 
            {
                return new ActionResponse<T>
                { 
                    Message = "tiene relaciones con otros registros, no se puede eliminar",
                };

            }
      

        }

        public virtual async Task<ActionResponse<T>> GetAsync(int id)
        {
            var row = await _entity.FindAsync(id);
            if (row ==null)
            {
                new ActionResponse<T>
                {
                    Message = "No se encontró el registro"
                };

            }
            return new ActionResponse<T>
            {
                WasSuccess = true,
                Result = row
            };
        }

        public virtual async Task<ActionResponse<IEnumerable<T>>> GetAsync()
        {
            return new ActionResponse<IEnumerable<T>>
            {
                WasSuccess = true,
                Result = await _entity.ToListAsync()
            };
        }

        public virtual async Task<ActionResponse<T>> UpdateAsync(T entity)
        {
            _Context.Update(entity);

            try
            {

                await _Context.SaveChangesAsync();
                return new ActionResponse<T>
                {
                    WasSuccess = true,
                    Result = entity
                };
            }
            catch (Exception ex)
            {
                return new ActionResponse<T>
                {
                    WasSuccess = false,
                    Message = ex.Message
                };

            }
        }

        public virtual async Task<ActionResponse<IEnumerable<T>>> GetAsync(PaginationDTO pagination)
        {
            var queryable = _entity.AsQueryable();

            return new ActionResponse<IEnumerable<T>>
            {
                WasSuccess = true,
                Result = await queryable
                    .Paginate(pagination)
                    .ToListAsync()
            };
        }

        public virtual async Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination)
        {
            var queryable = _entity.AsQueryable();
            double count = await queryable.CountAsync();
            return new ActionResponse<int>
            {
                WasSuccess = true,
                Result = (int)count
            };
        }





    }
}
