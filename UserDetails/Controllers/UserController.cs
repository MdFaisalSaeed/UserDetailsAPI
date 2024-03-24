using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace UserDetails.Controllers
{
    [ApiController]
    public class UserController : Controller
    {
        private IValidateUser _validateUser;
        public UserController(IValidateUser validateUser)
        {
            this._validateUser = validateUser;
        }
        [Route("Health")]
        [HttpGet]
        public IActionResult GetHealthCheck()
        {
            return StatusCode(200,"Healthy");
        }

        [Route("RandomUser")]
        [HttpPost]
        public async Task<IActionResult> GetRandomUser([FromBody] UserModel userModel)
        {
            if (_validateUser.ValidateUserDetails(userModel))
            {
                using (var client = new HttpClient())
                {
                        client.BaseAddress = new Uri("https://api.randomuser.me");
                        var response = await client.GetAsync(client.BaseAddress);
                        response.EnsureSuccessStatusCode();

                        var result = await response.Content.ReadAsStringAsync();
                        var userDetails = JsonConvert.DeserializeObject<UserDetails>(result); ;
                        return Ok(userDetails);                  
                }
            }
            else
            {
                return BadRequest("User not found");
            }
        }
    }
}
