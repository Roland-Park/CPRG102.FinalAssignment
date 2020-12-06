using CPRG102.Final.Roland.BLL;
using CPRG102.Final.Roland.Domain;
using CPRG102.Final.Roland.UI.HRData;
using CPRG102.Final.Roland.UI.Services;
using CPRG102.Final.Roland.UI.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPRG102.Final.Roland.UI.ViewModelFactories
{
    public interface IAssignmentPageViewModelFactory
    {
        Task<AssignmentPageViewModel> Create();
    }
    public class AssignmentPageViewModelFactory : IAssignmentPageViewModelFactory
    {
        private readonly IModelRepository modelRepository;
        private readonly IAssetTypeRepository assetTypeRepository;
        private readonly IAssetRepository assetRepository;
        private readonly IManufacturerRepository manufacturerRepository;
        private readonly IEmployeeService employeeService;
        public AssignmentPageViewModelFactory(IAssetRepository assetRepository, IModelRepository modelRepository, IAssetTypeRepository assetTypeRepository, IManufacturerRepository manufacturerRepository, IEmployeeService employeeService)
        {
            this.assetRepository = assetRepository;
            this.modelRepository = modelRepository;
            this.assetTypeRepository = assetTypeRepository;
            this.manufacturerRepository = manufacturerRepository;
            this.employeeService = employeeService;
        }

        public async Task<AssignmentPageViewModel> Create()
        {
            var assetTypes = new List<AssetType>() { new AssetType() { Id = 0, Name = "All" } };
            assetTypes.AddRange(assetTypeRepository.GetAll());

            var allAssets = assetRepository.GetAllAssets();
            var allEmployees = await employeeService.GetEmployees();

            var unassignedEmployees = allEmployees.Except(GetAssignedEmployees(allAssets, allEmployees));

            var assignmentPageViewModel = new AssignmentPageViewModel()
            {
                AssetTypes = new SelectList(assetTypes, "Id", "Name"),
                Assets = new SelectList(allAssets, "Id", "AssetDetails"),
                UnassignedEmployees = new SelectList(unassignedEmployees, "EmployeeNumber", "FullName")
            };

            return assignmentPageViewModel;
        }

        private List<Employee> GetAssignedEmployees(List<Asset> allAssets, List<Employee> allEmployees)
        {
            var assignedAssets = allAssets.Where(x => x.AssignedTo != null).ToList();

            var assignedEmployees = new List<Employee>();
            foreach (var assignedAsset in assignedAssets)
            {
                var employeeAssignedToAsset = allEmployees.FirstOrDefault(x => x.EmployeeNumber == assignedAsset.AssignedTo);
                assignedEmployees.Add(employeeAssignedToAsset);
            }

            return assignedEmployees;
        }
    }
}
