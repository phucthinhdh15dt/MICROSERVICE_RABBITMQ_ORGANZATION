using IdentityServerWithAspIdAndEF.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServerWithAspIdAndEF.Communication
{
    public interface ICommunication
    {
        string Call(string routingKey, string exchange, ProfileIdentityServer message);
    }
}
