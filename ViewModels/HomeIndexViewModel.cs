
using StaffManagment.DataAccess.Models;

namespace StaffManagmant.ViewModels;

public class HomeIndexViewModel
{
    public IEnumerable<Staff> Staffs { get; set; }
}