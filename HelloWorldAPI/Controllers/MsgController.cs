using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using HelloWorldAPI.Models;

namespace HelloWorldAPI.Controllers
{
    public class MsgController : ApiController
    {
        // GET: api/Msg
        public string Get()
        {
            MsgModel msg = new MsgModel();

            return msg.RetrieveMessage();
        }
    }
}
