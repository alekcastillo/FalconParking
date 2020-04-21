using System;
using System.Collections.Generic;
using System.Text;

namespace FalconParkingClient
{
    public static class UserRoles
    {

        //Placeholder
        public static Guid CurrentUserId { get; set; }
        public static Guid AdminId = new Guid("7c5c1b66-68f1-4982-8619-82afd8d9039a");
        public static Guid ClientId = new Guid("eafd1dc9-2147-4823-9fa7-130102a802a4");
        public static bool IsAdmin { get { return CurrentUserId == AdminId; } }
    }
}
