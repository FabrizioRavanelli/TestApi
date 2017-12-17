using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace TestApi.Core.Controllers
{
    [RoutePrefix("api/test")]
    public class TestController : ApiController
    {
        [HttpGet]
        [ResponseType(typeof(bool))]
        [Route("boolean")]
        public async Task<IHttpActionResult> GetTestBoolean()
        {
            return Ok(true);
        }

        [HttpGet]
        [ResponseType(typeof(bool))]
        [Route("boolean_param")]
        public async Task<IHttpActionResult> GetTestBooleanWithParam(int id)
        {
            return Ok(true);
        }

        [HttpPost]
        [ResponseType(typeof(bool))]
        [Route("boolean_post")]
        public async Task<IHttpActionResult> PostTestBoolean()
        {
            return Ok(true);
        }
    }
}
