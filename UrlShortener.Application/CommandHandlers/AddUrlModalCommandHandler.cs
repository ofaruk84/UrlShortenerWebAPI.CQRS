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
    public class AddUrlModalCommandHandler : IRequestHandler<AddUrlModalCommand,IResult>
    {
        private readonly IUrlModalDal _urlModalDal;

        public AddUrlModalCommandHandler(IUrlModalDal urlModalDal)
        {
            _urlModalDal = urlModalDal;
        }

        public async Task<IResult> Handle(AddUrlModalCommand request, CancellationToken cancellationToken)
        {
            var record = await _urlModalDal.GetAsync(urlModal => urlModal.LongUrl == request.UrlRequestModal.LongUrl);
            if (record is not null) return new ErrorResult(Messages.TheresARecordWithThisUrl);

            var validationResult =
                ValidationTool<UrlRequestModal>.Validate(new UrlRequestModalValidator(), request.UrlRequestModal);

            if (!validationResult) return new ErrorResult(Messages.InvalidUrl);

            var shortUrl = UrlHasher.CreateShortUrl(request.UrlRequestModal.LongUrl);
            var urlModal = new UrlModal
            {
                LongUrl = request.UrlRequestModal.LongUrl,
                ShortUrl = shortUrl,
                CreatedDate = DateTime.Now
            };

            await _urlModalDal.AddAsync(urlModal);
            return new SuccessResult(Messages.RecordHasBeenSuccessfullyAdded);
        }
    }
}
