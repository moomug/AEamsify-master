using System.Security.Claims;

namespace AEams.Web.Controllers
{
    [Authorize(Roles = AppRoles.HR)]
    public class DepartmentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DepartmentsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var departments = _context.Departments.AsNoTracking().ToList();

            var viewModel = _mapper.Map<IEnumerable<DepartmentViewModel>>(departments);

            return View(viewModel);
        }

        [HttpGet]
        [AjaxOnly]
        public IActionResult Create()
        {
            return PartialView("_Form");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DepartmentFormViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var department = _mapper.Map<Department>(model);
            department.CreatedById = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            _context.Add(department);
            _context.SaveChanges();

            var viewModel = _mapper.Map<DepartmentViewModel>(department);

            return PartialView("_DepartmentsRow", viewModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var department = _context.Departments.Find(id);

            if (department is null)
                return NotFound();

            var viewModel = _mapper.Map<DepartmentFormViewModel>(department);

            return PartialView("_Form", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(DepartmentFormViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var department = _context.Departments.Find(model.Id);

            if (department is null)
                return NotFound();

            department = _mapper.Map(model, department);
            department.LastUpdatedById = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            department.LastUpdatedOn = DateTime.Now;

            _context.SaveChanges();

            var viewModel = _mapper.Map<DepartmentViewModel>(department);

            return PartialView("_DepartmentsRow", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ToggleStatus(int id)
        {
            var department = _context.Departments.Find(id);

            if (department is null)
                return NotFound();

            department.IsDeleted = !department.IsDeleted;
            department.LastUpdatedById = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            department.LastUpdatedOn = DateTime.Now;

            _context.SaveChanges();

            return Ok(department.LastUpdatedOn.ToString());
        }

        public IActionResult AllowItem(DepartmentFormViewModel model)
        {
            var department = _context.Departments.SingleOrDefault(c => c.Name == model.Name);
            var isAllowed = department is null || department.Id.Equals(model.Id);

            return Json(isAllowed);
        }
    }
}