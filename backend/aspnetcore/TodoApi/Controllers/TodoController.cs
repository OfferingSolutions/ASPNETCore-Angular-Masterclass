using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Repositories;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly ITodoRepository _todoRepository;
        private readonly IMapper _mapper;

        public TodosController(
            ITodoRepository todoRepository,
            IMapper mapper)
        {
            _todoRepository = todoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TodoDto>> Get(bool? done)
        {
            var items = _todoRepository.GetAll(done);
            return Ok(items.Select(x => _mapper.Map<TodoDto>(x)));
        }
        
                
        [HttpGet]
        [Route("{id}", Name = nameof(GetSingle))]
        public ActionResult<TodoDto> GetSingle(Guid id)
        {
            TodoEntity entity = _todoRepository.GetSingle(id);

            if (entity == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<TodoDto>(entity));
        }


        [HttpPost(Name = nameof(AddTodo))]
        public ActionResult AddTodo([FromBody] TodoCreateDto todoCreateDto)
        {
            if (todoCreateDto == null)
            {
                return BadRequest();
            }

            TodoEntity item = _mapper.Map<TodoEntity>(todoCreateDto);
            item.Created = DateTime.UtcNow;
            TodoEntity newTodoEntity = _todoRepository.Add(item);

            if (!_todoRepository.Save())
            {
                throw new Exception("Adding an item failed on save.");
            }

            return CreatedAtRoute(
                nameof(GetSingle),
                new { id = newTodoEntity.Id },
                _mapper.Map<TodoDto>(newTodoEntity));
        }
    }
}