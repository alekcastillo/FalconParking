using System;
using System.Collections.Generic;
using System.Text;

namespace FalconParking.Infrastructure.Commands
{
    class DomainCommand
    {
        public enum DomainCommandType
        {
            CREATE,
            UPDATE,
            DELETE
        }

        public DomainCommandType Type;

        public DomainCommand(DomainCommandType type)
        {
            Type = type;
        }
    }
}
