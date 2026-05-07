using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using ST_CPS_Backend.Models;

namespace ST_CPS_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private DBMethods DbMeth;
        public ValuesController(DBMethods DbMeth)
        {
            this.DbMeth = DbMeth;
        }
        
        [HttpGet("weather")]
        public async Task<ActionResult<List<WeatherValues>>> GetWeather()
        {
            var data = await DbMeth.FetchData();
            return Ok(data);
        }
    }
}
