using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BankConfirmations_DTO;
using BankConfirmations_BLL;

namespace BankConfirmations_REST.Controllers
{
    [Route("api/deposit")]
    [ApiController]
    public class DepositsApiController : ControllerBase
    {
        // GET: api/DepositsApi
        [HttpGet]
        public IActionResult GetDeposit()
        {
            DepositBLL depositBll = new();

            return Ok(depositBll.GetAll());
        }

        // GET: api/DepositsApi/5
        [HttpGet("{id}")]
        public  IActionResult GetDeposit(int id)
        {
            DepositBLL depositBll = new();

            var deposit = depositBll.GetById(id);

            if (deposit == null) NotFound();

            return Ok(deposit);
        }

        // PUT: api/DepositsApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public  IActionResult PutDeposit(int id, Deposit deposit)
        {
            DepositBLL depositBll = new();

            if (id != deposit.Id)
            {
                return BadRequest();
            }

            try
            {
                depositBll.Update(deposit);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,"Error");
            }

            return NoContent();
        }

        // POST: api/DepositsApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public  IActionResult PostDeposit(Deposit deposit)
        {
            DepositBLL depositBll = new();

            depositBll.Insert(deposit);

            return CreatedAtAction(nameof(GetDeposit), new { id = deposit.Id }, deposit);
        }

        // DELETE: api/DepositsApi/5
        [HttpDelete("{id}")]
        public  IActionResult DeleteDeposit(int id)
        {
            DepositBLL depositBll = new();

            depositBll.Delete(id);

            return NoContent();
        }
    }
}
