using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace authDemo2.Models
{
    public class UserConstants
    {
        public static List<UserModel> Users = new List<UserModel>()
        {
            new UserModel(){UserName="jason_admin",EmailAdress="jason.admin@email.com",Password=
                "MyPass_w0rd",GivenName="Jason",Surname="Bryant",Role="Administrator"},
            new UserModel(){UserName="elyse_seller",EmailAdress="elyse.seller@email.com",Password=
                "MyPass_w0rd",GivenName="Elyse",Surname="Lambert",Role="Seller"}
        };
    }
}
