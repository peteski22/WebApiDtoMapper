namespace WebApiDtoMapper.Controllers
{
    using System.Web.Http;
    using WebApiDtoMapper.Filters;
    using WebApiDtoMapper.Models;
    using WebApi.ParameterBinding;

    public class HelloController : ApiController
    {
        [HttpGet]
        [AutoMap(typeof(HelloDto))]
        public IHttpActionResult GetHello()
        {
            return Ok(new Hello { Greeting = "Yo" });
        }

        [HttpPost]
        public IHttpActionResult SaveHello([FromBodyMap(typeof(HelloDto))]Hello hello)
        {
            return Ok();
        }
    }
}