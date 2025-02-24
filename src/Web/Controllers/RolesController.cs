using Application.Models.Requests;
using Application.Services;
using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _roleService.GetByIdAsync(id);
            return StatusCode(result.StatusCode, result);
        }

        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddRoleRequestModel request)
        {
            var result = await _roleService.AddAsync(request);
            return StatusCode(result.StatusCode, result);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateRoleRequestModel request)
        {
            var result = await _roleService.UpdateAsync(request);
            return StatusCode(result.StatusCode, result);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _roleService.DeleteAsync(id);
            return StatusCode(result.StatusCode, result);
        }
    }
}
