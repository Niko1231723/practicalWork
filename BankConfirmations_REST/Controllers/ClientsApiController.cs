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
    [Route("api/client")]
    [ApiController]
    public class ClientsApiController : ControllerBase
    {
        // GET: api/ClientsApi
        [HttpGet]
        public  IActionResult GetClient()
        {
            ClientBLL clientBll = new();
            return Ok(clientBll.GetAll());
        }

        [HttpGet("search/{search}")]
        public IActionResult GetClientSearch(string search)
        {
            ClientBLL clientBll = new();
            return Ok(clientBll.Search(search));
        }

        // GET: api/ClientsApi/5
        [HttpGet("{id}")]
        public IActionResult GetClient(int id)
        {
            ClientBLL clientBll = new();

            var client = clientBll.GetById(id);

            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        // PUT: api/ClientsApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public  IActionResult PutClient(int id, Client client)
        {
            if (id != client.Id) BadRequest();

            ClientBLL clientBll = new();
            //ClientDetailsBLL clientDetailsBll = new();


            try
            {
                clientBll.Update(client);
                //clientDetailsBll.Update(client.ClientDetails);
            }
            catch (Exception)
            {
                StatusCode(StatusCodes.Status500InternalServerError,"Error");
            }

            return NoContent();
        }

        // POST: api/ClientsApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostClient(Client client)
        {
            ClientBLL clientBll = new();
            //ClientDetailsBLL clientDetailsBll = new();

            clientBll.Insert(client);
            //clientDetailsBll.Insert(client.ClientDetails);

            return CreatedAtAction(nameof(GetClient), new { id = client.Id }, client);
        }

        // DELETE: api/ClientsApi/5
        [HttpDelete("{id}")]
        public IActionResult DeleteClient(int id)
        {
            ClientBLL clientBll = new();

            var client = clientBll.GetById(id);

            if (client == null) NotFound();

            clientBll.Delete(id);

            return NoContent();
        }
    }
}
