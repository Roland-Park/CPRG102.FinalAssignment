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
            var assetTypes = assetTypeRepository.GetAll();
            var manufacturers = manufacturerRepository.GetAll();
            var models = modelRepository.GetAll();
            var assets = assetRepository.GetAllAssets();
            var unassignedEmployees = await employeeService.GetEmployees();

            var assignmentPageViewModel = new AssignmentPageViewModel()
            {
                AssetTypes = new SelectList(assetTypes, "Id", "Name"),
                Manufacturers = new SelectList(manufacturers, "Id", "Name"),
                Models = new SelectList(models, "Id", "Name"),
                Assets = new SelectList(assets, "Id", "SerialNumber"),
                UnassignedEmployees = new SelectList(unassignedEmployees, "EmployeeNumber", "FullName") //TODO: make this only the unassigned ones
            };

            return assignmentPageViewModel;
        }
    }
}
