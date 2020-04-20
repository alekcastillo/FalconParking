using System;
using System.Threading.Tasks;
using AutoMapper;
using FalconParking.Application.Commands;
using FalconParking.Infrastructure.Abstractions;
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
        private readonly IMapper _mapper;
        private readonly IMessageBus _messageBus;

        public ParkingLotController(
            ILogger<ParkingLotController> logger
            ,IMapper mapper
            ,IMessageBus messageBus)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _messageBus = messageBus ?? throw new ArgumentNullException(nameof(messageBus));
        }

        [HttpPost("open")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<string> OpenParkingLot([FromBody] OpenParkingLotRequest request)
        {
            var command = _mapper.Map<OpenParkingLotCommand>(request);
            var response = await _messageBus.SendAsync(command);
            return response.ToString();
        }

        [HttpPut]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<string> AddParkingLot([FromBody] AddParkingLotRequest request)
        {
            var command = _mapper.Map<AddParkingLotCommand>(request);
            var response = await _messageBus.SendAsync(command);
            return response.ToString();
        }
    }
}
