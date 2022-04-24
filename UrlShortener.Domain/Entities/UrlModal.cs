using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Domain.Core.Entities;


namespace UrlShortener.Domain.Entities
{
    public class UrlModal : IEntity
    {
        public int Id { get; set; }
        public string LongUrl { get; set; }
        public string ShortUrl { get; set; }
        public DateTime CreatedDate { get; set; }


    }
}
