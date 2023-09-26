using NetCoreWebAPIUnitTest_xUnit.Model;

namespace NetCoreWebAPIUnitTest_xUnit.Services
{
    public interface IEmployeeService
    {
        List<Employee> GetAll();
        Employee GetById(int id);
        Employee Add(Employee employee);
        bool Delete(int id);

    }
  
}
