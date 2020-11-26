using CPRG102.Final.Roland.BLL;
using CPRG102.Final.Roland.UI.ViewModelFactories;
using CPRG102.Final.Roland.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CPRG102.Final.Roland.UI.Controllers
{
    public class AssetController : Controller
    {
        private readonly IAssetRepository assetRepository;
        private readonly IAssetViewModelFactory assetViewModelFactory;

        public AssetController(IAssetRepository assetRepository, IAssetViewModelFactory assetViewModelFactory)
        {
            this.assetRepository = assetRepository;
            this.assetViewModelFactory = assetViewModelFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var assets = assetRepository.GetAllAssets();
            return View(assets);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var assetViewModel = assetViewModelFactory.CreateNew();
            return View(assetViewModel);
        }

        [HttpPost]
        public IActionResult Create(AssetViewModel asset)
        {
            return RedirectToAction("Index");
        }
    }
}
