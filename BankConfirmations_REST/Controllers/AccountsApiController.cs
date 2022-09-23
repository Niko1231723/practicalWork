using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BankConfirmations_DTO;
using BankConfirmations_BLL;
//using System.Web.Mvc;

namespace BankConfirmations_REST.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountsApiController : ControllerBase
    {
        // GET: api/AccountsApi
        [HttpGet]
        public IActionResult GetAccount()
        {
            AccountBLL accountBll = new();

            try
            {
                return Ok(accountBll.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,"Error");
            }
        }

        // GET: api/AccountsApi/5

        [HttpGet("{id}")]
        public  ActionResult GetAccount(int id)
        {
            AccountBLL accountBll = new();

            var account = accountBll.GetById(id);

            if (account == null)
            {
                return NotFound();
            }

            return Ok(account);
        }

        // PUT: api/AccountsApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public IActionResult PutAccount(int id, Account account)
        {
            AccountBLL accountBll = new();
            //ClientBLL clientBll = new();
            //ClientDetailsBLL clientDetailsBll = new();


            if (id != account.Id)
            {
                return BadRequest("account Id missmatch");
            }

            try
            { 
                accountBll.Update(account);
                //clientBll.Update(account.Client);
                //clientDetailsBll.Update(account.Client.ClientDetails);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }
            return NoContent();
        }

        // POST: api/AccountsApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult PostAccount(Account account)
        {
            AccountBLL accountBll = new();

            accountBll.Insert(account);

            return CreatedAtAction(nameof(GetAccount), new { id = account.Id }, account);
        }

        // DELETE: api/AccountsApi/5
        [HttpDelete("{id}")]
        public  IActionResult DeleteAccount(int id)
        {
            AccountBLL accountBll = new();

            var account = accountBll.GetById(id);

            if (account == null)
            {
                return NotFound();
            }

            accountBll.Delete(id);

            return NoContent();
        }
    }
}
