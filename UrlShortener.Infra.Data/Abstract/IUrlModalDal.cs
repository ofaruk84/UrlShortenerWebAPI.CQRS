using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Domain.Core.DataAccess;
using UrlShortener.Domain.Entities;

namespace UrlShortener.Infra.Data.Abstract
{
    public interface IUrlModalDal : IEntityRepository<UrlModal>
    {

    }
}
