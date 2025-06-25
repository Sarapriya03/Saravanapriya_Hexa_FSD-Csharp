using HttpClientApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace HttpClientApp.Controllers
{
    [Route("Employee")]
    public class EmployeeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public EmployeeController(IHttpClientFactory httpClientFactory)
        {
            this._httpClientFactory = httpClientFactory;
        }

        public HttpClient GetClient()
        {
            var client = _httpClientFactory.CreateClient("ApiGatewayClient");
            return client;
        }

        //GET:Retrieve all the departments from Department Microservice through API Gateway
        [Route("/")]
        public async Task<IActionResult> EmployeeList()
        {
            var client = GetClient();
            var employees = await client.GetFromJsonAsync <List<Employee>>("gateway/employees");
            return View(employees);
        }

    }
}
