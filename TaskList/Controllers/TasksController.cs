using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskList.Models;
using TaskList.Queries;
using TaskList.Interfaces;

namespace TaskList.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly IRepository _repo;

        public TasksController(IRepository repo)
        {
            _repo = repo;
        }

        // GET: api/Tasks
        [HttpGet]
        public Task<ActionResult> GetTask()
        {
            return GetAllTasks();
        }

        // GET: api/Tasks/5
        [HttpGet("{id}")]

        public async Task<ActionResult> GetTask(int id)
        {
            return await GetMyTask(id);
        }

        // PUT: api/Tasks/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTask(int id, [FromBody]TaskRequest taskRequest)
        {
            await _repo.UpdateTask(id,taskRequest);
            return Ok();
        }


        // POST: api/Tasks
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult> PostTask([FromBody]TaskRequest taskRequest)
        {
            await _repo.InsertTask(taskRequest);
            return Ok();
        }

        // DELETE: api/Tasks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTask(int id)
        {
 
            await _repo.DeleteTask(id);

            return Ok();
        }

        private async Task<ActionResult> GetAllTasks()
        {
            var taskModel = await _repo.GetAll();

            if (taskModel == null)
            {
                return NotFound();
            }

            return Ok(taskModel);
        }

        private async Task<ActionResult> GetMyTask(int id)
        {
            var taskModel = await _repo.GetMyTask(id);

            if (taskModel == null)
            {
                return NotFound();
            }

            return Ok(taskModel);
        }



    }
}
