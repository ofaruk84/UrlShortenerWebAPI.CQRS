using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Domain.Core.Utilities.Results;
using UrlShortener.Domain.Dtos;
using UrlShortener.Domain.Entities;

namespace UrlShortener.Application.Abstract
{
    public interface IUrlModalService
    {
        Task<IDataResult<List<UrlModal>>> GetAllAsync();
        Task<IDataResult<UrlResponseModal>> GetByLongUrlAsync(string longUrl);
        Task<IDataResult<UrlResponseModal>> GetByShortUrlAsync(string shortUrl);
        Task<IResult> AddAsync(UrlRequestModal urlRequestModal);
        Task<IResult> AddCustomAsync(UrlRequestModal urlRequestModal);

        //Task<IDataResult<List<UrlModal>>> GetAllViaMediatr();

    }
}
