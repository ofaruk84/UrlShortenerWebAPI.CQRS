using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using UrlShortener.Application.Commands;
using UrlShortener.Application.Constants;
using UrlShortener.Application.Utilities.Hashing;
using UrlShortener.Application.ValidationRules.FluentValidation;
using UrlShortener.Domain.Core.CrossCuttingConcerns.Validation.FluentValidation;
using UrlShortener.Domain.Core.Utilities.Results;
using UrlShortener.Domain.Dtos;
using UrlShortener.Domain.Entities;
using UrlShortener.Infra.Data.Abstract;

namespace UrlShortener.Application.CommandHandlers
{
    public class AddCustomUrlModalCommandHandler : IRequestHandler<AddCustomUrlModalCommand, IResult>
    {
        private readonly IUrlModalDal _urlModalDal;

        public AddCustomUrlModalCommandHandler(IUrlModalDal urlModalDal)
        {
            _urlModalDal = urlModalDal;
        }

        public async Task<IResult> Handle(AddCustomUrlModalCommand request, CancellationToken cancellationToken)
        {
            var record = await _urlModalDal.GetAsync(urlModal => urlModal.LongUrl == request.UrlRequestModal.LongUrl);
            if (record is not null) return new ErrorResult(Messages.TheresARecordWithThisUrl);

            var res = ValidationTool<UrlRequestModal>.Validate(new UrlRequestModalValidator(), request.UrlRequestModal);

            if (!res) return new ErrorResult(Messages.InvalidUrl);

            if (request.UrlRequestModal.CustomName is null) return new ErrorResult(Messages.EmptyCustomName);

            var urlModal = new UrlModal
            {
                LongUrl = request.UrlRequestModal.LongUrl,
                ShortUrl = CreateCustomUrl(request.UrlRequestModal),
                CreatedDate = DateTime.Now
            };

            await _urlModalDal.AddAsync(urlModal);
            return new SuccessResult(Messages.RecordHasBeenSuccessfullyAdded);
        }

        private string CreateCustomUrl(UrlRequestModal urlRequestModal)
        {
            var splittedUrl = urlRequestModal.LongUrl.Split('.')[1];


            var shortUrl = "http://" + splittedUrl + "/" + urlRequestModal.CustomName;

            return shortUrl;
        }
    }
}
