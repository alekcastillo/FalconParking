using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FalconParking.Application.Commands;
using FalconParking.Application.Queries;
using FalconParking.Domain.Views;
using FalconParking.Infrastructure.Abstractions;
using FalconParkingAPI.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

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

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ParkingLotView>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<string> GetParkingLotsInfo()
        {
            var query = new GetParkingLotsInfoQuery();
            var response = await _messageBus.SendAsync(query);
            //For some reason, the global startup setting for the json loop handling is not working
            return JsonConvert.SerializeObject(response, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }

        [HttpPost("open")]
        [Produces("application/json")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> OpenParkingLot([FromBody] OpenParkingLotRequest request)
        {
            var command = _mapper.Map<OpenParkingLotCommand>(request);
            var response = await _messageBus.SendAsync(command);
            return Ok(response.ToString());
        }

        [HttpPost("close")]
        [Produces("application/json")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> CloseParkingLot([FromBody] CloseParkingLotRequest request)
        {
            var command = _mapper.Map<CloseParkingLotCommand>(request);
            var response = await _messageBus.SendAsync(command);
            return Ok(response.ToString());
        }

        [HttpPut]
        [Produces("application/json")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> AddParkingLot([FromBody] AddParkingLotRequest request)
        {
            var command = _mapper.Map<AddParkingLotCommand>(request);
            var response = await _messageBus.SendAsync(command);
            return Ok(response.ToString());
        }
    }
}
