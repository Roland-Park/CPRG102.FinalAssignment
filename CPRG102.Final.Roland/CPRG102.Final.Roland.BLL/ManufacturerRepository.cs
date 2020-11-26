using CPRG102.Final.Roland.Data;
using CPRG102.Final.Roland.Domain;
using System.Collections.Generic;
using System.Linq;

namespace CPRG102.Final.Roland.BLL
{
    public interface IManufacturerRepository
    {
        List<Manufacturer> GetAll();
    }
    public class ManufacturerRepository : IManufacturerRepository
    {
        private readonly AssetContext assetContext;

        public ManufacturerRepository(AssetContext assetContext)
        {
            this.assetContext = assetContext;
        }
        public List<Manufacturer> GetAll()
        {
            return assetContext.Manufacturers.ToList();
        }
    }
}
