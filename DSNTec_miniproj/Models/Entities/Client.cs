using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DSNTec_miniproj.Models.Entities
{
    public class Client
    {
        public int ClientID { get; set; }

        public string Name { get; set; }

        //public int ProvinceID { get; set; }

        public Province Province { get; set; }
    }
}