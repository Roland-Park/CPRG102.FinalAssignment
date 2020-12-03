using CPRG102.Final.Roland.UI.ViewModelFactories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CPRG102.Final.Roland.UI.Controllers
{
    public class AssignmentController : Controller
    {
        private readonly IAssignmentPageViewModelFactory assignmentPageViewModelFactory;
        public AssignmentController(IAssignmentPageViewModelFactory assignmentPageViewModelFactory)
        {
            this.assignmentPageViewModelFactory = assignmentPageViewModelFactory;
        }

        public async Task<IActionResult> Index()
        {
            var assignmentPageViewModel = await assignmentPageViewModelFactory.Create();
            return View(assignmentPageViewModel);
        }
    }
}
