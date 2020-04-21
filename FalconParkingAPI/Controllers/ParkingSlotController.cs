using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FalconParking.Application.Commands;
using FalconParking.Application.Queries;
using FalconParking.Domain.Views;
using FalconParking.Infrastructure.Abstractions;
using FalconParkingAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FalconParkingAPI.Controllers
{
    [ApiController]
    [Route("parkingSlots/")]
    public class ParkingSlotController : Controller
    {
        private readonly ILogger<ParkingSlotController> _logger;
        private readonly IMapper _mapper;
        private readonly IMessageBus _messageBus;

        public ParkingSlotController(
            ILogger<ParkingSlotController> logger
            ,IMapper mapper
            ,IMessageBus messageBus)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _messageBus = messageBus ?? throw new ArgumentNullException(nameof(messageBus));
        }

        [HttpPost("occupy")]
        [Produces("application/json")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> OccupyParkingSlot([FromBody] OccupyParkingSlotRequest request)
        {
            var command = _mapper.Map<OccupyParkingSlotCommand>(request);
            var result = await _messageBus.SendAsync(command);
            return Ok(result);
        }

        [HttpPost("free")]
        [Produces("application/json")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> FreeParkingSlot([FromBody] FreeParkingSlotRequest request)
        {
            var command = _mapper.Map<FreeParkingSlotCommand>(request);
            var result = await _messageBus.SendAsync(command);
            return Ok(result);
        }

        [HttpPost("reserve")]
        [Produces("application/json")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> ReserveParkingSlot([FromBody] ReserveParkingSlotRequest request)
        {
            var command = _mapper.Map<ReserveParkingSlotCommand>(request);
            var result = await _messageBus.SendAsync(command);
            return Ok(result);
        }
    }
}