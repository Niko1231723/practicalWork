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
    [Route("api/clientdetails")]
    [ApiController]
    public class ClientDetailsApiController : ControllerBase
    {
        // GET: api/ClientDetailsApi
        [HttpGet]
        public  IActionResult GetClientDetails()
        {
            ClientDetailsBLL clientBll = new();

            try
            {
                return Ok(clientBll.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }
        }

        // GET: api/ClientDetailsApi/5
        [HttpGet("{id}")]
        public ActionResult GetClientDetails(int id)
        {
            ClientDetailsBLL clientBll = new();

            if (clientBll == null)
            {
                return NotFound();
            }
            var clientDetails = clientBll.GetById(id);

            return clientDetails == null ? NotFound() : Ok(clientDetails);
        }

        // PUT: api/ClientDetailsApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutClientDetails(int id, ClientDetails clientDetails)
        {
            ClientDetailsBLL clientDetailsBll = new();

            if (id != clientDetails.Id) BadRequest();

            try
            {
                clientDetailsBll.Update(clientDetails);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }

            return NoContent();
        }

        // POST: api/ClientDetailsApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostClientDetails(ClientDetails clientDetails)
        {
            ClientDetailsBLL clientBll = new();

            clientBll.Insert(clientDetails);

            return CreatedAtAction(nameof(GetClientDetails), new { id = clientDetails.Id }, clientDetails);
        }

        // DELETE: api/ClientDetailsApi/5
        [HttpDelete("{id}")]
        public  IActionResult DeleteClientDetails(int id)
        {
            ClientDetailsBLL clientBll = new();

            var clientDetails = clientBll.GetById(id);

            if (clientDetails == null) NotFound();

            clientBll.Delete(id);

            return NoContent();
        }
    }
}
