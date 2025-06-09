using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_API_CRUD_Operation.Data;
using Web_API_CRUD_Operation.Models;

namespace Web_API_CRUD_Operation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public WorkerController(ApplicationDbContext context)
        {
            _context = context;
        }

        //// To Add Worker In Database
        //[HttpPost]
        //public async Task<IActionResult> AddWorker([FromBody] Worker worker)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var addworker = new Worker()
        //    {
        //        First_Name = worker.First_Name,
        //        Last_Name = worker.Last_Name,
        //        Phone = worker.Phone,
        //        Email = worker.Email,
        //        City = worker.City,
        //        Salary = worker.Salary 
        //    };

        //    await _context.worker.AddAsync(addworker);
        //    await _context.SaveChangesAsync();
        //    return Ok(addworker);
        //}


        //// To Show All Records Of Workers
        //[HttpGet]
        //public IActionResult GetAllWorkers()
        //{
        //    var getworkers = _context.worker.ToList();
        //    return Ok(getworkers);
        //}

        //// To Find Worker By ID
        //[HttpGet ("{ID:guid}")]
        //public async Task <IActionResult> GetWorkerById(Guid ID)
        //{
        //    var getworker = await _context.worker.FirstOrDefaultAsync(x => x.ID == ID);
        //    return Ok(getworker);
        //}

        //// To Update Worker
        //[HttpPut]
        //public async Task<IActionResult> UpdateWorker(Guid ID, [FromBody] UpdatedWorker updatedWorker)
        //{
        //    var updatedworker = await _context.worker.FirstOrDefaultAsync(x => x.ID == ID);
        //    if (updatedworker == null)
        //    {
        //        return BadRequest();
        //    }
        //    updatedworker.First_Name = updatedWorker.First_Name;
        //    updatedworker.Last_Name = updatedWorker.Last_Name;
        //    updatedworker.Phone = updatedWorker.Phone;
        //    updatedworker.Email = updatedWorker.Email;
        //    updatedworker.City = updatedWorker.City;
        //    updatedworker.Salary = updatedWorker.Salary;
        //    await _context.SaveChangesAsync();
        //    return Ok(updatedWorker);
        //}
        

        //// To Delete Worker
        //[HttpDelete("{ID:guid}")]
        //public IActionResult DeleteWorker(Guid ID)
        //{
        //    var deleteworker = _context.worker.FirstOrDefault(x => x.ID == ID);
        //    if(deleteworker == null)
        //    {
        //        return BadRequest();
        //    }
        //    _context.Remove(deleteworker);
        //    _context.SaveChangesAsync();
        //    return Ok();
        //}


        [HttpGet]
        public async Task<IActionResult> ShowWorker()
        {
            var w_data = await _context.worker.ToListAsync();
            return Ok(w_data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateWorker(Worker worker)
        {
            var addworker = new Worker
            {
                First_Name = worker.First_Name,
                Last_Name = worker.Last_Name,
                Phone = worker.Phone,
                Email = worker.Email,
                City = worker.City,
                Salary = worker.Salary
            };
            await _context.worker.AddAsync(addworker);
            await _context.SaveChangesAsync();
            return Ok(worker);
        }

        [HttpGet ("{Id:guid}")]
        public async Task<IActionResult> FindByWorkerId(Guid Id)
        {
            var w_data = await _context.worker.FirstOrDefaultAsync(x => x.ID == Id);

            return Ok(w_data);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateWorker(Guid ID, [FromBody] UpdatedWorker updatedWorker)
        {
            var u_worker = await _context.worker.FirstOrDefaultAsync(u => u.ID == ID);
            if (u_worker == null)
            {
                return BadRequest();
            }
            u_worker.First_Name = updatedWorker.First_Name;
            u_worker.Last_Name = updatedWorker.Last_Name;
            u_worker.Phone = updatedWorker.Phone;
            u_worker.Email = updatedWorker.Email;
            u_worker.City = updatedWorker.City;
            u_worker.Salary = updatedWorker.Salary;

            await _context.SaveChangesAsync();
            return Ok(u_worker);
        }

        [HttpDelete ("{ID:guid}")]
        public  IActionResult DeleteWorker(Guid ID)
        {
            var d_worker = _context.worker.FirstOrDefault(x => x.ID == ID);
            _context.worker.Remove(d_worker);
            _context.SaveChanges();
            return Ok();
        }
    }
}
