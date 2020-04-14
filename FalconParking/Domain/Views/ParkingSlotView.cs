﻿using System;

namespace FalconParking.Domain.Views
{
    public class ParkingSlotView
    {
        #region Atributos

        public int AggregateId { get; set; }
        public int Status { get; set; }
        public string OccupantLicensePlate { get; set; }
        public DateTimeOffset UpdatedTime { get; set; }
        public string UpdatedBy { get; set; }

        #endregion

        public ParkingSlotView(
            int aggregateId
            ,int status
            ,DateTimeOffset updatedTime
            ,string updatedBy)
        {
            AggregateId = aggregateId;
            Status = status;
            UpdatedTime = updatedTime;
            UpdatedBy = updatedBy;
        }
    }
}
