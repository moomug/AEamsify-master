using AEams.Web.Core.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq.Dynamic.Core;
using System.Security.Claims;
 

namespace AEams.Web.Controllers
{
    [Authorize(Roles = AppRoles.HR)]
    public class SchedulesController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public SchedulesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetSchedules()
        {
            var skip = int.Parse(Request.Form["start"]);
            var pageSize = int.Parse(Request.Form["length"]);

            var searchValue = Request.Form["search[value]"];

            var sortColumnIndex = Request.Form["order[0][column]"];
            var sortColumn = Request.Form[$"columns[{sortColumnIndex}][name]"];
            var sortColumnDirection = Request.Form["order[0][dir]"];

            IQueryable<Schedule> Schedules = _context.Schedules
                .Include(b => b.Department)
                .Include(b => b.User)
                .ThenInclude(b => b.User)
                .Include(b => b.ScheduleWeekOff)
                .ThenInclude(c => c.Week);

            if (!string.IsNullOrEmpty(searchValue))
                Schedules = Schedules.Where(b => b.Title.Contains(searchValue) || b.Department!.Name.Contains(searchValue));

            Schedules = Schedules.OrderBy($"{sortColumn} {sortColumnDirection}");

            var data = Schedules.Skip(skip).Take(pageSize).ToList();

            var mappedData = _mapper.Map<IEnumerable<ScheduleViewModel>>(data);

            var recordsTotal = Schedules.Count();

            var jsonData = new { recordsFiltered = recordsTotal, recordsTotal, data = mappedData };

            return Ok(jsonData);
        }

        public IActionResult Details(int id)
        {
            var Schedule = _context.Schedules
                .Include(b => b.Department)
                .Include(b => b.User)
                .ThenInclude(b => b.User)
                .Include(b => b.ScheduleWeekOff)
                .ThenInclude(c => c.Week)
                .SingleOrDefault(b => b.Id == id);

            //Schedule.User = _context.Users.ToList();

            //viewModel.ScheduleWeekOff = _mapper.Map<IEnumerable<SelectListItem>>(week);


            if (Schedule is null)
                return NotFound();

            var viewModel = _mapper.Map<ScheduleViewModel>(Schedule);
            
            return View(viewModel);
        }

        public IActionResult Create()
        {
            return View("Form", PopulateViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ScheduleFormViewModel model)
        {
            if (!ModelState.IsValid)
                return View("Form", PopulateViewModel(model));

            var Schedule = _mapper.Map<Schedule>(model);

            Schedule.CreatedById = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;

            foreach (var week in model.SelectedScheduleWeekOffs)
                Schedule.ScheduleWeekOff.Add(new ScheduleWeekOff { WeekId = week });
            
         

            _context.Add(Schedule);
            _context.SaveChanges();

            return RedirectToAction(nameof(Details), new { id = Schedule.Id });
        }

        public IActionResult Edit(int id)
        {
            var Schedule = _context.Schedules.Include(b => b.ScheduleWeekOff).SingleOrDefault(b => b.Id == id);

            if (Schedule is null)
                return NotFound();

            var model = _mapper.Map<ScheduleFormViewModel>(Schedule);
            var viewModel = PopulateViewModel(model);

            viewModel.SelectedScheduleWeekOffs = Schedule.ScheduleWeekOff.Select(c => c.WeekId).ToList();

            return View("Form", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ScheduleFormViewModel model)
        {
            if (!ModelState.IsValid)
                return View("Form", PopulateViewModel(model));

            var Schedule = _context.Schedules.Include(b => b.ScheduleWeekOff).SingleOrDefault(b => b.Id == model.Id);

            if (Schedule is null)
                return NotFound();
 
            Schedule = _mapper.Map(model, Schedule);
            Schedule.LastUpdatedById = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            Schedule.LastUpdatedOn = DateTime.Now;

            foreach (var week in model.SelectedScheduleWeekOffs)
                Schedule.ScheduleWeekOff.Add(new ScheduleWeekOff { WeekId = week });

            _context.SaveChanges();
                        
            return RedirectToAction(nameof(Details), new { id = Schedule.Id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ToggleStatus(int id)
        {
            var Schedule = _context.Schedules.Find(id);

            if (Schedule is null)
                return NotFound();

            Schedule.IsDeleted = !Schedule.IsDeleted;
            Schedule.LastUpdatedById = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            Schedule.LastUpdatedOn = DateTime.Now;

            _context.SaveChanges();

            return Ok();
        }

        public IActionResult AllowItem(ScheduleFormViewModel model)
        {
            var Schedule = _context.Schedules.SingleOrDefault(b => b.Title == model.Title && b.DepartmentId == model.DepartmentId);
            var isAllowed = Schedule is null || Schedule.Id.Equals(model.Id);

            return Json(isAllowed);
        }

        private ScheduleFormViewModel PopulateViewModel(ScheduleFormViewModel? model = null)
        {
            ScheduleFormViewModel viewModel = model is null ? new ScheduleFormViewModel() : model;

            var department = _context.Departments.Where(a => !a.IsDeleted).OrderBy(a => a.Name).ToList();
            var week = _context.Weeks.OrderBy(a => a.NameAr).ToList();

            viewModel.Department = _mapper.Map<IEnumerable<SelectListItem>>(department);
            viewModel.ScheduleWeekOff = _mapper.Map<IEnumerable<SelectListItem>>(week);

            return viewModel;
        }

        
    }
}