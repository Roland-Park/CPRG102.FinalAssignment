using CPRG102.Final.Roland.Data;
using CPRG102.Final.Roland.Domain;
using System.Collections.Generic;
using System.Linq;

namespace CPRG102.Final.Roland.BLL
{
    public interface IModelRepository
    {
        List<Model> GetAll();
    }
    public class ModelRepository : IModelRepository
    {
        private readonly AssetContext assetContext;

        public ModelRepository(AssetContext assetContext)
        {
            this.assetContext = assetContext;
        }
        public List<Model> GetAll()
        {
            return assetContext.Models.ToList();
        }
    }
}
