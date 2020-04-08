using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FalconParking.Domain.Views
{
    public class ParkingSlotView
    {
        #region Atributos

        public int AggregateId { get; private set; }
        public int Id { get; private set; }
        public int Status { get; private set; }

        #endregion

        public ParkingSlotView(
            int id
            ,int status)
        {
            Id = id;
            Status = status;
        }
    }
}
