using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;
using System.Net.Http;

namespace Ploeh.Samples.RunningJournalApi
{
    public class JournalController : ApiController
    {
        public HttpResponseMessage Get()
        {
            return this.Request.CreateResponse();
        }
    }
}
