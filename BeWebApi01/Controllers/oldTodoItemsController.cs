using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeWebApi01.Context;
using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Mvc;
using CommonLibrary.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BeWebApi01.Controllers
{
    /*
    [Route("api/[controller]")]
    public class oldTodoItemsController : Controller
    {

        private readonly DatabaseContext _context;
        private readonly TelemetryClient _telemetryClient;

        public oldTodoItemsController(DatabaseContext context, TelemetryClient telemetryClient)
        {
            _context = context;
            _telemetryClient = telemetryClient;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        }

        // POST: api/TodoItems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem todoItem)
        {
            _telemetryClient.TrackTrace(String.Format("Receive Request: todoItem: Name: {0}, IsComplete: {1}", todoItem.Name, todoItem.IsComplete));
            _context.todoItem.Add(todoItem);

            _telemetryClient.TrackTrace(String.Format("Insert Database: todoItem: Name: {0}, IsComplete: {1}", todoItem.Name, todoItem.IsComplete));

            await _context.SaveChangesAsync();

            _telemetryClient.TrackTrace(String.Format("Request Complete: todoItem: Name: {0}, IsComplete: {1}", todoItem.Name, todoItem.IsComplete));

            return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            //return CreatedAtAction(nameof(GetTodoItem), new { id = todoItem.Id }, todoItem);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

    }
    */
}
