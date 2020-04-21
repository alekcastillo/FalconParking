using System;
using System.Collections.Generic;
using System.Text;

namespace FalconParkingClient
{
    /// <summary>
    /// Se encarga de guardar el id del usuario actual,
    /// asi como validar si corresponde al de la cuenta
    /// de admin
    /// </summary>
    public static class UserRoles
    {
        public static Guid CurrentUserId { get; set; }
        public static Guid AdminId = new Guid("7c5c1b66-68f1-4982-8619-82afd8d9039a");
        public static bool IsAdmin { get { return CurrentUserId == AdminId; } }
    }
}
