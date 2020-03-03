using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DSNTec_miniproj.Models.Entities
{
    public class Province
    {
        public int ProvinceID { get; set; }

        public string Description { get; set; }




        public Province() { }

        public Province(int ProvinceID, string Description)
        {
            this.ProvinceID = ProvinceID;
            this.Description = Description;
        }
    }
}