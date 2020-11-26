using CPRG102.Final.Roland.Data;
using CPRG102.Final.Roland.Domain;
using System.Collections.Generic;
using System.Linq;

namespace CPRG102.Final.Roland.BLL
{
    public interface IAssetTypeRepository
    {
        List<AssetType> GetAll();
    }
    public class AssetTypeRepository : IAssetTypeRepository
    {
        private readonly AssetContext assetContext;

        public AssetTypeRepository(AssetContext assetContext)
        {
            this.assetContext = assetContext;
        }
        public List<AssetType> GetAll()
        {
            return assetContext.AssetTypes.ToList();
        }
    }
}
