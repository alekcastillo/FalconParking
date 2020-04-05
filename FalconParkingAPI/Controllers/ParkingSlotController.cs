using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FalconParking.Infrastructure.Abstractions;
using FalconParking.Infrastructure.Commands;
using FalconParkingAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
            ILogger<ParkingSlotController> logger,
            IMapper mapper,
            IMessageBus messageBus)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _messageBus = messageBus ?? throw new ArgumentNullException(nameof(messageBus));
        }

        [HttpPost("occupy")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<string> OccupyParkingSlot([FromBody] OccupyParkingSlotRequest request)
        {
            var command = _mapper.Map<OccupyParkingSlotCommand>(request);
            var response = await _messageBus.SendAsync(command);
            return response.ToString();
        }
    }
}