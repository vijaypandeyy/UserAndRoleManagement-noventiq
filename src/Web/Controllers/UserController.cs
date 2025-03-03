using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Application.Models.Response;
using Application.Models.Common;
using Application.Models.Requests;
using Azure.Core;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        // GET: api/<UserController>
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

       /// <summary>
       /// Get USer by ID
       /// </summary>
       /// <param name="id">id for user</param>
       /// <returns></returns>
        [HttpGet("{id}")]
        
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _userService.GetUserByIdAsync(id);
            return StatusCode(result.StatusCode, result);
        }

        // POST api/<UserController>
        /// <summary>
        /// Create a new user
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddUserRequestModel request)
        {
            var result = await _userService.AddUserAsync(request);
            return StatusCode(result.StatusCode, result);
        }

        // PUT api/<UserController>/5
        /// <summary>
        /// Update existing user
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateUserRequestModel request)
        {
            var result = await _userService.UpdateUserAsync(request);
            return StatusCode(result.StatusCode, result);
        }

        // Patch api/<UserController>/5
        /// <summary>
        /// Update existing user password
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdatePasswordRequestModel request)
        {
            request.SetId(id);
           var result = await _userService.UpdateUserAsync(null);
            return StatusCode(result.StatusCode, null);
        }

        // DELETE api/<UserController>/5
        /// <summary>
        /// Delete User
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _userService.DeleteUserAsync(id);
            return StatusCode(result.StatusCode, result);
        }
    }
}
