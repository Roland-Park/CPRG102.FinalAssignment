using CPRG102.Final.Roland.BLL;
using CPRG102.Final.Roland.Domain;
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
        private readonly IAssetTypeRepository assetTypeRepository;
        private readonly IAssetRepository assetRepository;
        private readonly IEmployeeService employeeService;
        public AssignmentPageViewModelFactory(IAssetRepository assetRepository, IAssetTypeRepository assetTypeRepository, IEmployeeService employeeService)
        {
            this.assetRepository = assetRepository;
            this.assetTypeRepository = assetTypeRepository;
            this.employeeService = employeeService;
        }

        public async Task<AssignmentPageViewModel> Create()
        {
            var assetTypes = assetTypeRepository.GetAll();

            var allAssets = assetRepository.GetAllAssets();

            var unassignedEmployees = new List<Employee>();
            try
            {
                var allEmployees = await employeeService.GetEmployees();

                unassignedEmployees = allEmployees.Except(GetAssignedEmployees(allAssets, allEmployees)).ToList();

                if (unassignedEmployees == null || unassignedEmployees.Count < 1)
                {
                    unassignedEmployees.Add(new Employee { EmployeeNumber = "error", FirstName = "No", LastName = "Employees" });
                }
            }
            catch(Exception ex)
            {
                //log ex
                unassignedEmployees.Add(new Employee { EmployeeNumber = "None", FirstName = "HRService", LastName = "Error" });
            }           

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
