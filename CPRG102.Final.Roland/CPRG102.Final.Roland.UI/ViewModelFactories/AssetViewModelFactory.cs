using CPRG102.Final.Roland.BLL;
using CPRG102.Final.Roland.UI.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPRG102.Final.Roland.UI.ViewModelFactories
{
    public interface IAssetViewModelFactory
    {
        AssetViewModel CreateNew();
    }
    public class AssetViewModelFactory : IAssetViewModelFactory
    {
        private readonly IAssetTypeRepository assetTypeRepository;
        private readonly IManufacturerRepository manufacturerRepository;
        private readonly IModelRepository modelRepository;

        public AssetViewModelFactory(IAssetTypeRepository assetTypeRepository, IManufacturerRepository manufacturerRepository, IModelRepository modelRepository)
        {
            this.assetTypeRepository = assetTypeRepository;
            this.manufacturerRepository = manufacturerRepository;
            this.modelRepository = modelRepository;
        }


        public AssetViewModel CreateNew()
        {
            var assetViewModel = new AssetViewModel();

            assetViewModel.AssetTypeList = new SelectList(assetTypeRepository.GetAll(), "Id", "Name");
            assetViewModel.ManufacturerList = new SelectList(manufacturerRepository.GetAll(), "Id", "Name");
            assetViewModel.ModelList = new SelectList(modelRepository.GetAll(), "Id", "Name");

            return assetViewModel;
        }
    }
}
