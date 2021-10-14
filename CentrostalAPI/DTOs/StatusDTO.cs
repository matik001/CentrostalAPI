using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentrostalAPI.DTOs {
    public class StatusDTO {
        public string name { get; set; }

        public bool canAnyoneCancel { get; set; }
        public bool canAnyoneChangeStatus { get; set; }
        public bool canAnyoneEdit { get; set; }

        public bool canAdminCancel { get; set; }
        public bool canAdminChangeStatus { get; set; }
        public bool canAdminEdit { get; set; }


        public bool canChairmanCancel { get; set; }
        public bool canChairmanChangeStatus { get; set; }
        public bool canChairmanEdit { get; set; }

        public string color { get; set; }
        public string nextStatusMsg { get; set; }
    }
}
