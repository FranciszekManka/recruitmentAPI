using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Threading.Tasks;



namespace recruitmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatabaseController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public DatabaseController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet("GetToDo")]
        public async Task<IActionResult> GetToDo()
        {
            var result = await _context.ToDoTable.Select(x => new ToDoTable
            {
                id = x.id,
                tytul_zadania = x.tytul_zadania,
                opis = x.opis,
                expiry_date = x.expiry_date,
                completion = x.completion,
                IsCompleted = x.IsCompleted,
            }).ToListAsync();

            return Ok(result);  
        }
        [HttpPost("CreateTask")]
        public async Task<IActionResult> CreateTask([FromBody] ToDoTableDomain todotable)//wykorzystanie drugiego modelu ktory nie posiada id 
        {
            var x = new ToDoTable
            {
                tytul_zadania = todotable.tytul_zadania,
                opis = todotable.opis,
                expiry_date = todotable.expiry_date,
                completion = todotable.completion,
                IsCompleted = todotable.IsCompleted,
            };
            _context.ToDoTable.Add(x);
            await _context.SaveChangesAsync();

            return Ok();
        }
        [HttpDelete("DeleteTask")]
        public async Task<IActionResult> DeleteTask(int TaskId)
        {
            var rows = await _context.ToDoTable.Where(x => x.id == TaskId).ExecuteDeleteAsync();


            return Ok(true);

        }
        [HttpPost("UpdateTask")]
        public async Task<IActionResult> UpdateTask([FromBody] ToDoTableDomain todotable, int TaskId)
        {
            var x = new ToDoTable
            {
                tytul_zadania = todotable.tytul_zadania,
                opis = todotable.opis,
                expiry_date = todotable.expiry_date,
                completion = todotable.completion,
                
            };
            _context.ToDoTable.Update(x);
            await _context.ToDoTable.Where(x => x.id == TaskId).ExecuteUpdateAsync(setters => setters.SetProperty(t => t.IsCompleted, t => true));
            



            return Ok();
        }
    }
}
