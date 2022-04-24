using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using UrlShortener.Application.Constants;
using UrlShortener.Application.Queries;
using UrlShortener.Domain.Core.Utilities.Results;
using UrlShortener.Domain.Dtos;
using UrlShortener.Domain.Entities;
using UrlShortener.Infra.Data.Abstract;


namespace UrlShortener.Application.QueryHandlers
{
    public class GetByShortUrlQueryHandler : IRequestHandler<GetByShortUrlQuery, IDataResult<UrlResponseModal>>
    {
        private readonly IUrlModalDal _urlModalDal;

        public GetByShortUrlQueryHandler(IUrlModalDal urlModalDal)
        {
            _urlModalDal = urlModalDal;
        }


        public async Task<IDataResult<UrlResponseModal>> Handle(GetByShortUrlQuery request, CancellationToken cancellationToken)
        {
            var url = await _urlModalDal.GetAsync(url => url.ShortUrl == request.ShortUrl);

            if (url == null)
                return new ErrorDataResult<UrlResponseModal>(null, Messages.ThereAreNoRecordsInTheDatabase);

            var response = new UrlResponseModal
            {
                UrlModal = url
            };

            return new SuccessDataResult<UrlResponseModal>(response,
                Messages.AllRecordsSuccessfullyFetchedFromDatabase);
        }
    }
}
