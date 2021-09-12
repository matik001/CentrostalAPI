using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CentrostalAPI.DTOs {
    public class ErrorDTO {
        public int statusCode { get; set; }
        public string message { get; set; }
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
