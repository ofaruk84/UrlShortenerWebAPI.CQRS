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
    public class GetAllQueryHandler : IRequestHandler<GetAllQuery, IDataResult<List<UrlModal>>>
    {
        private readonly IUrlModalDal _urlModalDal;

        public GetAllQueryHandler(IUrlModalDal urlModalDal)
        {
            _urlModalDal = urlModalDal;
        }

        public async Task<IDataResult<List<UrlModal>>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {

            var urls = await _urlModalDal.GetAllAsync();

            if (urls.Count > -1)
            {
                return new SuccessDataResult<List<UrlModal>>(urls, Messages.AllRecordsSuccessfullyFetchedFromDatabase);
            }

            return new ErrorDataResult<List<UrlModal>>(null, Messages.ThereAreNoRecordsInTheDatabase);
        }
    }
}
