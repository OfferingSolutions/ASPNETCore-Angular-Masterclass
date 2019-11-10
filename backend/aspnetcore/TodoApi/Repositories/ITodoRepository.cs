using System;
using System.Collections.Generic;
using TodoApi.Models;

namespace TodoApi.Repositories 
{
        public interface ITodoRepository
    {
        IEnumerable<TodoEntity> GetAll(bool? done);
        TodoEntity GetSingle(Guid id);
        TodoEntity Add(TodoEntity item);
        TodoEntity Update(Guid id, TodoEntity item);
        void Delete(TodoEntity item);

        bool Save();
    }
}