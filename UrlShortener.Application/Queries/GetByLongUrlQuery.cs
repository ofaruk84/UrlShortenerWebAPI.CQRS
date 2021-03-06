using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using UrlShortener.Domain.Core.Utilities.Results;
using UrlShortener.Domain.Dtos;
using UrlShortener.Domain.Entities;

namespace UrlShortener.Application.Queries
{
    public class GetByLongUrlQuery : IRequest<IDataResult<UrlResponseModal>>
    {
        public GetByLongUrlQuery(string longUrl)
        {
            LongUrl = longUrl;
        }

        public string LongUrl { get; set; }
    }
}
