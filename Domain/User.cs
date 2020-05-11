using Domain.Attributes;
using Domain.Entities;
using Domain.Events;
using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class User : Aggregate
    {
        #region Atributos
        private string password;
        private string passwordSalt;
        public string EmailAddress { get; private set; }
        public string Identification { get; private set; }
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public UserRole Role { get; private set; }

        #endregion

        #region Constructor

        public User(
            Guid aggregateId) : base(aggregateId)
        {}

        #endregion

        #region Metodos publicos

        //public static User New( 
        //    string emailAddress
        //    ,string password
        //    ,string identification
        //    ,string name
        //    ,string lastName
        //    ,int role)
        //{
        //}

        #endregion

        #region Metodos Apply

        #endregion
    }
}
