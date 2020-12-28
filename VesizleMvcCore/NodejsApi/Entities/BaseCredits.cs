using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VesizleMvcCore.NodejsApi.Entities
{
    public class BaseCredits
    {
        public bool Adult { get; set; }
        public int Gender { get; set; }
        public int Id { get; set; }
        public string Known_For_Department { get; set; }
        public string Name { get; set; }
        public string Original_Name { get; set; }
        public decimal Popularity { get; set; }
        public string Profile_Path { get; set; }
        public string Credit_Id { get; set; }
    }
}
