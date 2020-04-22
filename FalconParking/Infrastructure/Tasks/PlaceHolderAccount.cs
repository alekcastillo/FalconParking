using System;
using System.Collections.Generic;
using System.Text;

namespace FalconParking.Infrastructure.Tasks
{
    public class PlaceHolderAccount
    {
        public Guid Id { get; }
        public string Email { get; }
        public string Password { get; }

        public PlaceHolderAccount(
            Guid id
            ,string email
            ,string password)
        {
            Id = id;
            Email = email;
            Password = password;
        }
    }
}
