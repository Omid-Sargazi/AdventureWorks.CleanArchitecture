using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdventureWorks.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [Authorize(Roles = "Administrator")]
        [HttpGet("secured-data")]
        public IActionResult SecuredData()
        {
            return Ok("🔐 This data is protected by JWT and only accessible to Administrators.");
        }

        [AllowAnonymous]
        [HttpGet("public-data")]
        public IActionResult PublicData()
        {
            return Ok("🌐 This is public and does not need authentication.");
        }
    }
}