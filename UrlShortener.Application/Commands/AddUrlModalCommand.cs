using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using UrlShortener.Domain.Core.Utilities.Results;
using UrlShortener.Domain.Dtos;

namespace UrlShortener.Application.Commands
{
    public class AddUrlModalCommand : IRequest<IResult>
    {
        public AddUrlModalCommand(UrlRequestModal urlRequestModal)
        {
            UrlRequestModal = urlRequestModal;
        }

        public UrlRequestModal UrlRequestModal { get; set; }

        
    }
}
