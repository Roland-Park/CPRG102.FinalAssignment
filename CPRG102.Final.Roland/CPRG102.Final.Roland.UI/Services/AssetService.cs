using CPRG102.Final.Roland.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPRG102.Final.Roland.UI.Services
{
    public interface IAssetService
    {
        void CreateAssetFromAssetViewModel(AssetViewModel assetViewModel);
    }
    public class AssetService : IAssetService
    {
        public void CreateAssetFromAssetViewModel(AssetViewModel assetViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
