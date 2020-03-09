using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FalconParking.Domain.Interfaces;
using FalconParking.Infrastructure.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FalconParkingAPI.Controllers
{
    [ApiController]
    [Route("api/")]
    public class ParkingController : Controller
    {
        private readonly ILogger<ParkingController> _logger;
        //private readonly IParkingEventRepository _eventsRepository;
        //private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ParkingController(
            ILogger<ParkingController> logger,
            //IParkingEventRepository eventsRepository,
            //IMapper mapper,
            IMediator mediator)
        {
            _logger = logger;
            //_eventsRepository = eventsRepository;
            //_mapper = mapper;
            _mediator = mediator;
        }

        // GET: api/<controller>
        [HttpPost("ocupy/{lotId}")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/<controller>
        [HttpGet("{lotId}")]
        public async Task<IActionResult> GetParkingLotInformation()
        {
            var query = new GetLotInformationQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

    }
}
