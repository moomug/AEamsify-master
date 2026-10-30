using AEams.Web.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AEams.Web.Controllers
{
    public class ScheduleUsersController : Controller
    { 
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ScheduleUsersController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult Create(int scheduleId)
        {
            ScheduleUsersFormViewModel viewModel = new ScheduleUsersFormViewModel() { ScheduleId = scheduleId };
            var users = _context.Users.Where(a => !a.IsDeleted).OrderBy(a => a.FullName).ToList();
    
            viewModel.User = _mapper.Map<IEnumerable<SelectListItem>>(users);

            return PartialView("_Form", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public IActionResult Create(ScheduleUsersFormViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var schedule = _context.Schedules.Find(model.ScheduleId);

            if (schedule is null)
                return NotFound();

            var scheduleUser = _mapper.Map<ScheduleUser>(model);

            _context.Add(scheduleUser);
            _context.SaveChanges();


            var users = _context.Users.SingleOrDefault(a => a.Id == model.UserId);

            var viewModel = _mapper.Map<UserViewModel>(users);

            return PartialView("_ScheduleUserRow", viewModel);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ToggleStatus(string id)
        {
            var scheduleUser = _context.ScheduleUsers.SingleOrDefault(b => b.UserId == id);

            if(scheduleUser is null)
                return NotFound();

            _context.ScheduleUsers.Remove(scheduleUser);
            _context.SaveChanges();

            return Ok();
        }
    }
}
