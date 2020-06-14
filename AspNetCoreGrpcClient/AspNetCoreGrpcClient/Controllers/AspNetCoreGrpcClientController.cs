using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GrpcClient;

namespace AspNetCoreGrpcClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AspNetCoreGrpcClientController : ControllerBase
    {
        private readonly GrpcDemo.GrpcDemoClient _client;
        public AspNetCoreGrpcClientController(GrpcDemo.GrpcDemoClient client)
        {
            _client = client;
        }
        [HttpGet]
        public async Task<IActionResult> GetInfo()
        {
            var res = await _client.GetMessgaeAsync(new Request { Info = "1" });
            return new JsonResult(res);
        }
    }
}
