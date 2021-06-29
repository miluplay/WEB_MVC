using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class TeachingPlansController : Controller
    {
        private readonly SSMContext1Context _context;

        public TeachingPlansController(SSMContext1Context context)
        {
            _context = context;
        }

        // GET: TeachingPlans
        public async Task<IActionResult> Index()
        {
            var sSMContext1Context = _context.TeachingPlans.Include(t => t.Course).Include(t => t.Major);
            return View(await sSMContext1Context.ToListAsync());
        }

        // GET: TeachingPlans/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teachingPlan = await _context.TeachingPlans
                .Include(t => t.Course)
                .Include(t => t.Major)
                .FirstOrDefaultAsync(m => m.TeachingPlanId == id);
            if (teachingPlan == null)
            {
                return NotFound();
            }

            return View(teachingPlan);
        }

        // GET: TeachingPlans/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId");
            ViewData["MajorId"] = new SelectList(_context.Majors, "MajorId", "CollageName");
            return View();
        }

        // POST: TeachingPlans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Semester,MajorId,CourseId,TeachingPlanId")] TeachingPlan teachingPlan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teachingPlan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", teachingPlan.CourseId);
            ViewData["MajorId"] = new SelectList(_context.Majors, "MajorId", "CollageName", teachingPlan.MajorId);
            return View(teachingPlan);
        }

        // GET: TeachingPlans/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teachingPlan = await _context.TeachingPlans.FindAsync(id);
            if (teachingPlan == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", teachingPlan.CourseId);
            ViewData["MajorId"] = new SelectList(_context.Majors, "MajorId", "CollageName", teachingPlan.MajorId);
            return View(teachingPlan);
        }

        // POST: TeachingPlans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Semester,MajorId,CourseId,TeachingPlanId")] TeachingPlan teachingPlan)
        {
            if (id != teachingPlan.TeachingPlanId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teachingPlan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeachingPlanExists(teachingPlan.TeachingPlanId))
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
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", teachingPlan.CourseId);
            ViewData["MajorId"] = new SelectList(_context.Majors, "MajorId", "CollageName", teachingPlan.MajorId);
            return View(teachingPlan);
        }

        // GET: TeachingPlans/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teachingPlan = await _context.TeachingPlans
                .Include(t => t.Course)
                .Include(t => t.Major)
                .FirstOrDefaultAsync(m => m.TeachingPlanId == id);
            if (teachingPlan == null)
            {
                return NotFound();
            }

            return View(teachingPlan);
        }

        // POST: TeachingPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var teachingPlan = await _context.TeachingPlans.FindAsync(id);
            _context.TeachingPlans.Remove(teachingPlan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeachingPlanExists(string id)
        {
            return _context.TeachingPlans.Any(e => e.TeachingPlanId == id);
        }
    }
}
