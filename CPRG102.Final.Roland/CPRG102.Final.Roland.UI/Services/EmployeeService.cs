using CPRG102.Final.Roland.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CPRG102.Final.Roland.UI.Services
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetEmployees();
        Task<Employee> GetEmployeeByNumber(string employeeNumber);
    }
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient httpClient;
        private readonly string url = "https://localhost:44310/api/hr";
        public EmployeeService()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(url);
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<Employee>> GetEmployees()
        {
            HttpResponseMessage msg = await httpClient.GetAsync(url);

            if (msg.IsSuccessStatusCode)
            {
                var data = msg.Content.ReadAsStringAsync().Result;
                List<Employee> employees = JsonConvert.DeserializeObject<List<Employee>>(data).ToList();
                return employees;
            }

            return null;
        }

        public async Task<Employee> GetEmployeeByNumber(string employeeNumber)
        {
            HttpResponseMessage msg = await httpClient.GetAsync(url + "/Employee/" + employeeNumber);

            if (msg.IsSuccessStatusCode)
            {
                var data = msg.Content.ReadAsStringAsync().Result;
                var employee = JsonConvert.DeserializeObject<Employee>(data);
                return employee;
            }

            return null;
        }
    }
}
