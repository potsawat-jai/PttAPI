using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pttapi.Models
{
    public class OilDetail
    {
        [Key]
        public int detail_id { get; set; }
        public string Description { get; set; }
        public bool IsNotify { get; set; } = false;
        public bool IsChange { get; set; } = false;
        public string ChangeDate { get; set; }
        public string ChangeTime { get; set; }
    }

    public class OilPrice
    {
        [Key]
        public int oil_id { get; set; }
        public int detail_id { get; set; }
        public string MAT_NAME { get; set; }
        public int DIVISION_ID { get; set; }
        public string DIVISION_NAME { get; set; }
        public string MAT_NAME2 { get; set; }
        public int TYPE_NAME { get; set; }
        public string MAT_ID { get; set; }
        public string PRICE0 { get; set; }
        public string PRICE1 { get; set; }
    }

    public class OilPriceResult
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public bool IsNotify { get; set; }
        public bool IsChange { get; set; }
        public string ChangeDate { get; set; }
        public string ChangeTime { get; set; }

        public dynamic ListOfPrice { get; set; }       
    }

}
