using AppMobileMoto.Models;
using ServiceReferenceMoto;
using System;
using System.Linq;

namespace AppMobileMoto.Services
{
    class BrandDataStore : AbstractDataStore<Brand>
    {
        public BrandDataStore() : base()
        {
            items = MotoService.GetBrands(new GetBrandsRequest()).GetBrandsResult.Select(b => new Brand(b)).ToList();
        }

        public override Brand Find(Brand item)
        {
            return items.Where((Brand arg) => arg.IdBrand == item.IdBrand).FirstOrDefault();
        }

        public override Brand Find(int id)
        {
            return items.Where((Brand arg) => arg.IdBrand == id).FirstOrDefault();
        }
    }
}
