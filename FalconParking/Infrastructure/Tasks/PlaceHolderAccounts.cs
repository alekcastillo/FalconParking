using System;
using System.Collections.Generic;
using System.Text;

namespace FalconParking.Infrastructure.Tasks
{
    public static class PlaceHolderAccounts
    {
        public static PlaceHolderAccount Admin = new PlaceHolderAccount(
            new Guid("7c5c1b66-68f1-4982-8619-82afd8d9039a")
            ,"admin@ulacit.ed.cr"
            ,"123");

        public static PlaceHolderAccount Client = new PlaceHolderAccount(
            new Guid("eafd1dc9-2147-4823-9fa7-130102a802a4")
            ,"client@ulacit.ed.cr"
            ,"123");
    }
}
