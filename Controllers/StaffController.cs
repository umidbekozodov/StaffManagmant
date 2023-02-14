using Microsoft.AspNetCore.Mvc;
using StaffManagmant.ViewModels;
using StaffManagment.DataAccess.Models;

namespace StaffManagmant.Controllers;

public class StaffController : Controller
{
    private readonly IStaffRepository _staffRepository;

    public StaffController(IStaffRepository staffRepository)
    {
        _staffRepository = staffRepository;
    }

    public IActionResult Index()
    {
        HomeIndexViewModel viewModels = new()
        {
            Staffs = _staffRepository.GetAll()
        };
        return View(viewModels);
    }

    public IActionResult Details(int? id)
    {
        HomeDetailsViewModel viewModel = new()
        {
            Staff = _staffRepository.Get(id ?? 1),  // ?? is the null-coalescing operator
            PageTitle = "Staff Details"
        };
        return View(viewModel);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Staff staff)
    {
        if (ModelState.IsValid)
        {
            if(_staffRepository.GetAll().Any(e => e.Email.Equals(staff.Email)))
            {
                return View();
            }
            Staff newStaff = _staffRepository.Add(staff);
            return RedirectToAction("details", new { id = newStaff.Id });
        }
        return View();
    }
}
