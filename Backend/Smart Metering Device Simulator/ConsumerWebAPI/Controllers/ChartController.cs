using ConsumerWebAPI.DateStorage;
using ConsumerWebAPI.HubConfig;
using ConsumerWebAPI.TimerFeatures;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace ConsumerWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartController : ControllerBase
    {
        private readonly IHubContext<ChartHub> _hub;
        public ChartController(IHubContext<ChartHub> hub)
        {
            _hub= hub;
        }
        [HttpGet]
        public IActionResult Get()
        {
            //var userId = "a68686a7-df5c-48e3-bda7-41d7782e71f5";
            //var timerManager = new TimerManager(() => _hub.Clients.User(userId).SendAsync("transferchartdata", DataManager.GetData()));
            var timerManager = new TimerManager(() => _hub.Clients.All.SendAsync("transferchartdata", DataManager.GetData()));
            return Ok();
        }
    }
}
