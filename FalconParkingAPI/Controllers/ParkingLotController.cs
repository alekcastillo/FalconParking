using System;
using AutoMapper;
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
        private readonly IMediator _mediator;

        public ParkingLotController(
            ILogger<ParkingLotController> logger
            ,IMapper mapper
            ,IMediator mediator)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            //_eventsRepository = eventsRepository;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
    }
}
