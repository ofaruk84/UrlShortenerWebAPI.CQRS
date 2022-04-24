using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using UrlShortener.Domain.Core.Utilities.Results;
using UrlShortener.Domain.Dtos;
using UrlShortener.Domain.Entities;

namespace UrlShortener.Application.Queries
{
    public class GetByShortUrlQuery : IRequest<IDataResult<UrlResponseModal>>
    {
        public GetByShortUrlQuery(string shortUrl)
        {
            ShortUrl = shortUrl;
        }

        public string ShortUrl { get; set; }
    }
}
