using System;
using System.Collections.Generic;
using System.Linq;
using TodoApi.Models;

namespace TodoApi.Repositories 
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoDbContext _todoDbContext;

        public TodoRepository(TodoDbContext dbContext)
        {
            _todoDbContext = dbContext;
        }

        public TodoEntity GetSingle(Guid id)
        {
            return _todoDbContext.TodoItems.FirstOrDefault(x => x.Id == id);
        }

        public TodoEntity Add(TodoEntity item)
        {
            throw new NotImplementedException();
        }

        public void Delete(TodoEntity item)
        {
            throw new NotImplementedException();
        }

        public TodoEntity Update(Guid id, TodoEntity item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TodoEntity> GetAll(bool? done)
        {
            if (done.HasValue)
            {
                return _todoDbContext.TodoItems.Where(x => x.Done == done.Value);
            }
            return _todoDbContext.TodoItems;
        }

        public int Count()
        {
            return _todoDbContext.TodoItems.Count();
        }

        public bool Save()
        {
            return (_todoDbContext.SaveChanges() >= 0);
        }
    }
}