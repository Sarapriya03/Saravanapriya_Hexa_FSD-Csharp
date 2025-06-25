using HttpClientApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace HttpClientApp.Controllers
{
    [Route("Dept")]
    public class DepartmentController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public DepartmentController(IHttpClientFactory httpClientFactory)
        {
            this._httpClientFactory = httpClientFactory;
        }

        public HttpClient GetClient()
        {
            var client=_httpClientFactory.CreateClient("ApiGatewayClient");
            return client;
        }

        //GET:Retrieve all the departments from Department Microservice through API Gateway
        [Route("/")]
        public async Task<IActionResult> DepartmentList()
        {
            var client = GetClient();
            var deptartments = await client.GetFromJsonAsync<List<Department>>("gateway/departments");
            return View(deptartments);
        }

        
    }
}
