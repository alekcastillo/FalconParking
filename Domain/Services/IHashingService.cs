using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Abstractions.Services
{
    public interface IHashingService
    {
        string HashString(string salt, string password);
        string GenerateSalt(int maxLength);
    }
}
