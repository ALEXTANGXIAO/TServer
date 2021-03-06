using System;
using System.Collections.Generic;
using System.Text;
using SocketGameProtocol;

namespace SocketServer
{
    class BaseController
    {
        protected RequestCode requestCode = RequestCode.RequestNone;

        protected ActionCode actionCode;

        protected ReturnCode returnCode;

        public RequestCode GetRequestCode
        {
            get { return requestCode; }
        }
    }
}
