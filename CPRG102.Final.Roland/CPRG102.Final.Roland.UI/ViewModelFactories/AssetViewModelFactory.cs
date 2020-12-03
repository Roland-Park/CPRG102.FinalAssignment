using CPRG102.Final.Roland.BLL;
using CPRG102.Final.Roland.UI.HRData;
using CPRG102.Final.Roland.UI.Services;
using CPRG102.Final.Roland.UI.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CPRG102.Final.Roland.UI.ViewModelFactories
{
    public interface IAssetViewModelFactory
    {
        Task<AssetViewModel> CreateNew();
    }
    public class AssetViewModelFactory : IAssetViewModelFactory
    {
        private readonly IEmployeeService employeeService;
        private readonly IAssetTypeRepository assetTypeRepository;
        private readonly IManufacturerRepository manufacturerRepository;
        private readonly IModelRepository modelRepository;

        public AssetViewModelFactory(IEmployeeService employeeService, IAssetTypeRepository assetTypeRepository, IManufacturerRepository manufacturerRepository, IModelRepository modelRepository)
        {
            this.employeeService = employeeService;
            this.assetTypeRepository = assetTypeRepository;
            this.manufacturerRepository = manufacturerRepository;
            this.modelRepository = modelRepository;
        }

        public async Task<AssetViewModel> CreateNew()
        {
            var employees = new List<Employee>() { new Employee() { EmployeeNumber = null, FirstName = "(None)" } };
            employees.AddRange(await employeeService.GetEmployees());
            var assetViewModel = new AssetViewModel()
            {
                AssetTypeList = new SelectList(assetTypeRepository.GetAll(), "Id", "Name"),
                ManufacturerList = new SelectList(manufacturerRepository.GetAll(), "Id", "Name"),
                ModelList = new SelectList(modelRepository.GetAll(), "Id", "Name"),
                EmployeeList = new SelectList(employees, "EmployeeNumber", "FullName")
            };

        return assetViewModel;
        }
    }
}
