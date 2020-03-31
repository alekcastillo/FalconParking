using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FalconParking.Infrastructure.Commands;
using FalconParkingAPI.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FalconParkingAPI.Controllers
{
    [ApiController]
    [Route("parkingLots/")]
    public class ParkingLotController : Controller
    {
        private readonly ILogger<ParkingLotController> _logger;
        //private readonly IParkingEventRepository _eventsRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ParkingLotController(
            ILogger<ParkingLotController> logger,
            //IParkingEventRepository eventsRepository,
            IMapper mapper,
            IMediator mediator)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            //_eventsRepository = eventsRepository;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(400)]
        public async Task<string> GetParkingLotView(int id)
        {
            //var command = _mapper.Map<OccupyParkingSlotCommand>();
            //var response = await _mediator.Send(command);
            return ""; //response.ToString();
        }

        [HttpPost("open")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<string> OpenParkingLot([FromBody] OccupyParkingSlotRequest request)
        {
            var command = _mapper.Map<OccupyParkingSlotCommand>(request);
            var response = await _mediator.Send(command);
            return response.ToString();
        }

        [HttpPost("close")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<string> CloseParkingLot([FromBody] OccupyParkingSlotRequest request)
        {
            var command = _mapper.Map<OccupyParkingSlotCommand>(request);
            var response = await _mediator.Send(command);
            return response.ToString();
        }

        //// GET: api/<controller>
        //[HttpGet("{lotId}")]
        //public async Task<IActionResult> GetParkingLotInformation()
        //{
        //    var query = new GetLotInformationQuery();
        //    var result = await _mediator.Send(query);
        //    return Ok(result);
        //}

    }
}
