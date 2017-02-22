namespace WebApiDtoMapper.Sample.Controllers
{
    using Filters;
    using ParameterBinding;
    using Models;
    using System.Web.Http;

    public class HelloController : ApiController
    {
        [HttpGet]
        [MapResponseTo(typeof(HelloDto))]
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