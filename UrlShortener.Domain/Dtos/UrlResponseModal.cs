using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UrlShortener.Domain.Core.Entities;
using UrlShortener.Domain.Entities;

namespace UrlShortener.Domain.Dtos
{
    public class UrlResponseModal : IDto
    {
        public UrlModal UrlModal { get; set; }
    }

    
}
