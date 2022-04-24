using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using UrlShortener.Application.Abstract;
using UrlShortener.Application.Commands;
using UrlShortener.Application.Constants;
using UrlShortener.Application.Queries;
using UrlShortener.Application.Utilities.Hashing;
using UrlShortener.Application.ValidationRules.FluentValidation;
using UrlShortener.Domain.Core.CrossCuttingConcerns.Validation.FluentValidation;
using UrlShortener.Domain.Core.Utilities.Results;
using UrlShortener.Domain.Dtos;
using UrlShortener.Domain.Entities;
using UrlShortener.Infra.Data.Abstract;

namespace UrlShortener.Application.Concrete
{
    public class UrlModalManager : IUrlModalService
    {

        private readonly IMediator _mediator;

        public UrlModalManager(IUrlModalDal urlModalDal,  IMediator mediator)
        {
           
  
            _mediator = mediator;
        }


        public async Task<IDataResult<List<UrlModal>>> GetAllAsync()
        {
            return await _mediator.Send(new GetAllQuery());
        }

        public async Task<IDataResult<UrlResponseModal>> GetByLongUrlAsync(string longUrl)
        {

            return await _mediator.Send(new GetByLongUrlQuery(longUrl));

        }

        public async Task<IDataResult<UrlResponseModal>> GetByShortUrlAsync(string shortUrl)
        {
            return await _mediator.Send(new GetByShortUrlQuery(shortUrl));

        }

        public async Task<IResult> AddAsync(UrlRequestModal urlRequestModal)
        {
            return await _mediator.Send(new AddUrlModalCommand(urlRequestModal));
        }

        public async Task<IResult> AddCustomAsync(UrlRequestModal urlRequestModal)
        {
            return await _mediator.Send(new AddCustomUrlModalCommand(urlRequestModal));
        }

    }
}