using CPRG102.Final.Roland.BLL;
using CPRG102.Final.Roland.Domain;
using CPRG102.Final.Roland.UI.ViewModelFactories;
using CPRG102.Final.Roland.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Create()
        {
            var assetViewModel = await assetViewModelFactory.CreateNew();
            return View(assetViewModel);
        }

        [HttpPost]
        public IActionResult Create(Asset asset)
        {
            assetRepository.CreateAsset(asset);
            return RedirectToAction("Index");
        }
    }
}
