using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FalconParking.Infrastructure.Models
{
    public class ParkingLotEvent
    {
        [Key]
        public Guid EventId { get; private set; }
        public int AggregateId { get; private set; }
        public string EventType { get; private set; }

        [Column(TypeName = "jsonb")]
        public string EventData { get; private set; } 
    }
}
