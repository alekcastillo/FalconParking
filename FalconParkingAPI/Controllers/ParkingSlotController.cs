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

namespace FalconParkingAPI.Controllers
{
    [ApiController]
    [Route("parkingSlots/")]
    public class ParkingSlotController : Controller
    {
        private readonly ILogger<ParkingSlotController> _logger;
        //private readonly IParkingEventRepository _eventsRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ParkingSlotController(
            ILogger<ParkingSlotController> logger,
            //IParkingEventRepository eventsRepository,
            IMapper mapper,
            IMediator mediator)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            //_eventsRepository = eventsRepository;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("occupy")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<string> OccupyParkingSlot([FromBody] OccupyParkingSlotRequest request)
        {
            var command = _mapper.Map<OccupyParkingSlotCommand>(request);
            var response = await _mediator.Send(command);
            return response.ToString();
        }

        [HttpPost("reserve")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<string> ReserveParkingSlot([FromBody] OccupyParkingSlotRequest request)
        {
            var command = _mapper.Map<ReserveParkingSlotCommand>(request);
            var response = await _mediator.Send(command);
            return response.ToString();
        }

        [HttpPost("reserve")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<string> FreeParkingSlot([FromBody] OccupyParkingSlotRequest request)
        {
            var command = _mapper.Map<FreeParkingSlotCommand>(request);
            var response = await _mediator.Send(command);
            return response.ToString();
        }
    }
}