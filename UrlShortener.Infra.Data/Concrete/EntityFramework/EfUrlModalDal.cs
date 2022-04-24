using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Domain.Core.DataAccess.EntityFramework;
using UrlShortener.Domain.Entities;
using UrlShortener.Infra.Data.Abstract;

namespace UrlShortener.Infra.Data.Concrete.EntityFramework
{
    public class EfUrlModalDal : EfEntityRepositoryBase<UrlModal, UrlContext>, IUrlModalDal
    {

    }
}
