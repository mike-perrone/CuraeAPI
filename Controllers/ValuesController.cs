using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiralApiReal.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FiralApiReal.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController] // this is new
    // it enforces attribute routing
    // conventional routing is not allowed
    // automatically validates request
    // controllerbase is also new
    // when we create a new controller it inherits the base class
    // so we can use IActions and return http responses from our controller
    // if we use controller on its own it has view support GROSS
    // view support comes from angular app
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _datacontext;

        public ValuesController(DataContext datacontext)
        {
           _datacontext = datacontext;
        }
        // GET api/values
        // what 
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult>  GetValues()
        {
            var values = await _datacontext.Values.ToListAsync();

            return Ok(values);
       
        }
        // GET api/values/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValue(int id)
        {
            var value = await _datacontext.Values.FirstOrDefaultAsync(x => x.Id == id);

            return Ok(value);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
}
