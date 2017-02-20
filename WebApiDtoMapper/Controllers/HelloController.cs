namespace WebApiDtoMapper.Controllers
{
    using System.Web.Http;
    using ParameterBinding;
    using WebApiDtoMapper.Filters;
    using WebApiDtoMapper.Models;

    public class HelloController : ApiController
    {
        [HttpGet]
        [MapResponse(typeof(HelloDto))]
        public IHttpActionResult GetHello()
        {
            return Ok(new Hello { Greeting = "Yo" });
        }
        
        [HttpPost]
        public IHttpActionResult SaveHello([MapFromBody(typeof(HelloDto))]Hello hello)
        {
            return Ok();
        }
    }
}