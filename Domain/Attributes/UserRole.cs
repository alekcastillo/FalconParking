using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Domain.Attributes
{
    public enum UserRole
    {
        [Description("Cliente")]
        Client,

        [Description("Guarda")]
        Guard,

        [Description("Administrador")]
        Admin
    }
}
