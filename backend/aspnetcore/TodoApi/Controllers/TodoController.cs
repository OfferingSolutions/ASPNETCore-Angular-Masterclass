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
    }
}