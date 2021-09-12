using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentrostalAPI.DTOs {
    public class ItemTemplateRequestDTO {
        public string name { get; set; }
        public int number { get; set; }

        public ICollection<int> currents { get; set; }
        public ICollection<string> steelTypes { get; set; }
    }
    public class ItemTemplateResponseDTO : ItemTemplateRequestDTO {
        public int id { get; set; }
    }
}
