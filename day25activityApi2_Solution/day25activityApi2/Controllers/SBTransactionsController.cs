using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using day25activityApi2.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace day25activityApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SBTransactionsController : ControllerBase
    {
        private readonly SBTransactionContext _context;

        public SBTransactionsController(SBTransactionContext context)
        {
            _context = context;
        }

        // GET: api/SBTransactions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SBTransaction>>> GetsBTransactions()
        {
            return await _context.sBTransactions.ToListAsync();
        }

        // GET: api/SBTransactions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SBTransaction>> GetSBTransaction(int id)
        {
            var sBTransaction = await _context.sBTransactions.FindAsync(id);

            if (sBTransaction == null)
            {
                return NotFound();
            }

            return sBTransaction;
        }

        // PUT: api/SBTransactions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSBTransaction(int id, SBTransaction sBTransaction)
        {
            if (id != sBTransaction.TransactionID)
            {
                return BadRequest();
            }

            _context.Entry(sBTransaction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SBTransactionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/SBTransactions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SBTransaction>> PostSBTransaction(SBTransaction sBTransaction)
        {
            _context.sBTransactions.Add(sBTransaction);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSBTransaction", new { id = sBTransaction.TransactionID }, sBTransaction);
        }

        // DELETE: api/SBTransactions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSBTransaction(int id)
        {
            var sBTransaction = await _context.sBTransactions.FindAsync(id);
            if (sBTransaction == null)
            {
                return NotFound();
            }

            _context.sBTransactions.Remove(sBTransaction);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SBTransactionExists(int id)
        {
            return _context.sBTransactions.Any(e => e.TransactionID == id);
        }

        [HttpGet]
        [Route("Account")]
        public async Task<List<SBAccount>> GetAccount()
        {
            string Baseurl = "http://localhost:5866/";
            var ProdInfo = new List<SBAccount>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/SBAccounts");
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var ProdResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list  
                    ProdInfo = JsonConvert.DeserializeObject<List<SBAccount>>(ProdResponse);
                }
                //returning the employee list to view  
                return ProdInfo;
            }
        }

    }
}
