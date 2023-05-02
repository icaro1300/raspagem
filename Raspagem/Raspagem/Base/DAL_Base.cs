using Raspagem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Raspagem.Base
{
    public class DAL_Base
    {
        private readonly string _link;
        public DAL_Base(string link) => _link = link;
        protected async Task<string> Pegar_Html() => await HttpRequestService.ConfiguringHttp(_link).Pegar_Html();
    }
}
