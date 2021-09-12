using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CentrostalAPI.HttpErrors {
    public class HttpError : Exception {
        public int errorCode { get; } = 500;

        public HttpError(int errorCode) : base(((HttpStatusCode)errorCode).ToString()) {
            this.errorCode = errorCode;
        }
        public HttpError(int errorCode, string msg) : base(msg) {
            this.errorCode = errorCode;
        }
    }
}
