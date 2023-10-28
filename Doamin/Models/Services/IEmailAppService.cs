using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Services
{
    public interface IEmailAppService 
    {
        public Task<string> SendMessage(long fromNumber, long toNumber, string message);
    }
}
