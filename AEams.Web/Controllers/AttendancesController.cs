using Microsoft.AspNetCore.Mvc;

namespace AEams.Web.Controllers
{
    public class AttendancesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AttendancesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var Attendances = _context.Attendances.ToList();    
            return View(Attendances);
        }
    }
}
