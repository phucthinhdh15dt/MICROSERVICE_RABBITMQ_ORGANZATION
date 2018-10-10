using PlusTechPlusSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlusTechPlusSystem.Communication
{
    public interface ICommunication
    {
        string Call(string routingKey, string exchange, Ogranzition message);
    }
}
