using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Domain;
using WebApplication1.Interfaces;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class GroupsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IGroupService _groupService;

        public GroupsController(IGroupService groupService, AppDbContext context)
        {
            _groupService = groupService;
            _context = context;
        }

        // GET: Groups
        public async Task<IActionResult> Index()
        {
            return View(await _groupService.GetGroups());
        }

        // GET: Groups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var group = _groupService.GetById(id);
            if (group == null)
            {
                return NotFound();
            }

            return View(group);
        }

        // GET: Groups/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Id");
            ViewData["CuratorId"] = new SelectList(_context.Instructors, "Id", "Id");
            ViewData["SpecialId"] = new SelectList(_context.Specials, "Id", "Id");
            return View();
        }

        // POST: Groups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Group group )
        {
            if (ModelState.IsValid)
            {
                await _groupService.Create(group);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Id", group.CourseId);
            ViewData["CuratorId"] = new SelectList(_context.Instructors, "Id", "Id", group.CuratorId);
            ViewData["SpecialId"] = new SelectList(_context.Specials, "Id", "Id", group.SpecialId);
            return View(group);
        }

        // GET: Groups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var group = _groupService.GetById(id);
            if (group == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Id", group.CourseId);
            ViewData["CuratorId"] = new SelectList(_context.Instructors, "Id", "Id", group.CuratorId);
            ViewData["SpecialId"] = new SelectList(_context.Specials, "Id", "Id", group.SpecialId);
            return View(group);
        }

        // POST: Groups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Group group)
        {
            if (id != group.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _groupService.Update(group);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_groupService.GroupExists(group.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Id", group.CourseId);
            ViewData["CuratorId"] = new SelectList(_context.Instructors, "Id", "Id", group.CuratorId);
            ViewData["SpecialId"] = new SelectList(_context.Specials, "Id", "Id", group.SpecialId);
            return View(group);
        }

        // GET: Groups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var group = _groupService.GetById(id);
            if (group == null)
            {
                return NotFound();
            }

            return View(group);
        }

        // POST: Groups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _groupService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool GroupExists(int id)
        {
            return _groupService.GroupExists(id);
        }
    }
}
