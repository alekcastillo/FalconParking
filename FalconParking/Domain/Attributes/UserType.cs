using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FalconParking.Domain.Attributes
{
    public enum UserType
    {
        [Description("Cliente")]
        Client,

        [Description("Guarda")]
        Guard,

        [Description("Administrador")]
        Admin
    }
}
