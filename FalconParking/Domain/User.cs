using FalconParking.Domain.Attributes;
using FalconParking.Domain.Entities;
using FalconParking.Domain.Events;
using FalconParking.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace FalconParking.Domain
{
    public class User : Aggregate
    {
        #region Atributos

        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public UserType Type { get; private set; }
        private List<UserVehicle> _vehicles { get; }

        #endregion

        private User(
            int aggregateId,
            string name,
            string lastName,
            string email,
            string password,
            UserType type) : base(aggregateId)
        {
            Name = name;
            LastName = lastName;
            Email = email;
            Password = password;
            Type = type;
            _vehicles = new List<UserVehicle>();
        }

        #region Metodos privados

        //Nothing yet

        #endregion

        #region Metodos publicos

        #endregion
    }
}
