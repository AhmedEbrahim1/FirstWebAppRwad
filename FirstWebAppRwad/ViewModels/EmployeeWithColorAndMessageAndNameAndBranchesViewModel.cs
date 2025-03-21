using FirstWebAppRwad.Models;

namespace FirstWebAppRwad.ViewModels
{
    public class EmployeeWithColorAndMessageAndNameAndBranchesViewModel
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public string Message { get; set; }
        public List<string> Branches { get; set; }
        public Employee Employee  { get; set; }
    }
}
