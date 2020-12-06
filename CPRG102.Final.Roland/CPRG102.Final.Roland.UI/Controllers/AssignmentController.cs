using CPRG102.Final.Roland.BLL;
using CPRG102.Final.Roland.Domain;
using CPRG102.Final.Roland.UI.ViewModelFactories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CPRG102.Final.Roland.UI.Controllers
{
    public class AssignmentController : Controller
    {
        private readonly IAssignmentPageViewModelFactory assignmentPageViewModelFactory;
        private readonly IAssetRepository assetRepository;

        public AssignmentController(IAssignmentPageViewModelFactory assignmentPageViewModelFactory, IAssetRepository assetRepository)
        {
            this.assignmentPageViewModelFactory = assignmentPageViewModelFactory;
            this.assetRepository = assetRepository;
        }

        public async Task<IActionResult> Index()
        {
            var assignmentPageViewModel = await assignmentPageViewModelFactory.Create();
            return View(assignmentPageViewModel);
        }

        [HttpGet]
        public IActionResult GetAssetSelectList(int assetTypeId)
        {
            var assetsOfType = assetTypeId == 0? assetRepository.GetAllAssets() : assetRepository.GetAssetsByType(assetTypeId);
            if(assetsOfType.Count < 1)
            {
                assetsOfType.Add(new Asset()
                {
                    Id = 0,
                    Manufacturer = new Manufacturer(),
                    Model = new Model(),
                    AssignedTo = "No Assets To Display"
                });
            }
            return PartialView("_GetAssetSelectList", assetsOfType);
        }

        [HttpGet]
        public IActionResult AssignAsset(string employeeNumber, int assetId)
        {
            var success = false;
            var asset = assetRepository.GetAssetById(assetId);
            
            if(asset != null && employeeNumber != null)
            {
                asset.AssignedTo = employeeNumber;
                success = assetRepository.UpdateAsset(asset);
            }            

            return PartialView("_ConfirmAssetAssignment", success);
        }
    }
}
