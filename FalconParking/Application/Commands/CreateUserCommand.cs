using FalconParking.Infrastructure.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace FalconParking.Application
{
    public class CreateUserCommand : DomainCommand
    {
        public string Name { get; }
        public string LastName { get; }
        public string Email { get; }
        public string Password { get; }
        public int Type { get; }

        public CreateUserCommand(
            int aggregateId
            , string name
            , string lastName
            , string email
            ,string password
            ,int type) : base(aggregateId)
        {
            Name = name;
            LastName = lastName;
            Email = email;
            Password = password;
            Type = type;
        }

    }
}
