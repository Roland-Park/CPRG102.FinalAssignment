using CPRG102.Final.Roland.BLL;
using CPRG102.Final.Roland.Domain;
using CPRG102.Final.Roland.UI.ViewModelFactories;
using CPRG102.Final.Roland.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPRG102.Final.Roland.UI.Controllers
{
    public class AssetController : Controller
    {
        private readonly IAssetRepository assetRepository;
        private readonly IAssetViewModelFactory assetViewModelFactory;
        private readonly IAssetTypeRepository assetTypeRepository;

        public AssetController(IAssetRepository assetRepository, IAssetViewModelFactory assetViewModelFactory, IAssetTypeRepository assetTypeRepository)
        {
            this.assetRepository = assetRepository;
            this.assetViewModelFactory = assetViewModelFactory;
            this.assetTypeRepository = assetTypeRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var assetTypes = new List<AssetType>() { new AssetType() { Id = 0, Name = "All Asset Types" } };
            assetTypes.AddRange(assetTypeRepository.GetAll());
            ViewBag.AssetTypes = new SelectList(assetTypes, "Id", "Name");
            return View();
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

        public IActionResult GetFilteredAssets(int assignedOrUnassigned, string employeeNumber, int assetTypeId)
        {
            var assetList = assetRepository.GetAllAssets();
            if (assignedOrUnassigned == 1)
            {
                assetList = assetList.Where(x => !string.IsNullOrWhiteSpace(x.AssignedTo)).ToList();
            }

            if (assignedOrUnassigned == 2)
            {
                assetList = assetList.Where(x => string.IsNullOrWhiteSpace(x.AssignedTo)).ToList();
            }

            if (!string.IsNullOrWhiteSpace(employeeNumber))
            {
                assetList = assetList.Where(x => x.AssignedTo != null && x.AssignedTo.ToUpper().Contains(employeeNumber.ToUpper())).ToList();
            }

            if (assetTypeId > 0)
            {
                assetList = assetList.Where(x => x.AssetTypeId == assetTypeId).ToList();
            }

            return PartialView("_GetFilteredAssets", assetList.ToList());
        }
    }
}
