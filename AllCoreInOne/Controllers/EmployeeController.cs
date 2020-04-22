using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AllCoreInOne.Data;
using AllCoreInOne.Services.AuthorizationPolicy;
using AllCoreInOne.Services.CurrentUser;
using AllCoreInOne.Services.Employee;
using AllCoreInOne.ViewModels.Employee;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AllCoreInOne.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private IEmployeeService EmployeeService { get; }
        private ApplicationDbContext DbContext { get; }
        private ICurrentUser CurrentUser { get; }
        private IMapper Mapper { get; }
        private IAuthorizationPolicy Policies { get; }
        public EmployeeController(IEmployeeService employeeService, ApplicationDbContext dbContext,
            IMapper mapper, ICurrentUser currentUser, IAuthorizationPolicy authorizationPolicy)
        {
            EmployeeService = employeeService;
            DbContext = dbContext;
            Mapper = mapper;
            CurrentUser = currentUser;
            Policies = authorizationPolicy;
        }
        public async Task<IActionResult> Index(CancellationToken ct)
        {
            var employees = await DbContext.Employees.Include(x => x.Department).Where(a=>a.CreatedBy == CurrentUser.Id).ToListAsync();
            return View(Mapper.Map<List<EmployeeViewModel>>(employees));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeViewModel model, CancellationToken ct = default)
        {
            if (ModelState.IsValid)
            {
                await EmployeeService.CreateEmployee(model, ct);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public async  Task<IActionResult> Edit(Guid id, CancellationToken ct)
        {
            var accessGranted = await Policies.GrantsEmployeeAccess(id);
            if (!accessGranted) return StatusCode(403);
            var employee = await DbContext.Employees.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
            if (employee == null)
                return NotFound($"Employee with Id {id} does not exist");
            return View(Mapper.Map<EmployeeViewModel>(employee));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, EmployeeViewModel model, CancellationToken ct)
        {
            if (ModelState.IsValid)
            {
                var employee = await DbContext.Employees.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
                if (employee == null)
                    return NotFound($"Employee with Id {id} does not exist");
                await EmployeeService.UpdateEmployee(id, model, ct);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
    }
}