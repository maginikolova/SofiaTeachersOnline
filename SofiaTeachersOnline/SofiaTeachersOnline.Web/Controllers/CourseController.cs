using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SofiaTeachersOnline.Database;
using SofiaTeachersOnline.Database.Models;
using SofiaTeachersOnline.Services.DTOs;
using SofiaTeachersOnline.Services.Services.Contracts;

namespace SofiaTeachersOnline.Web.Controllers
{
    public class CourseController : Controller
    {
        private readonly SofiaTeachersOnlineDbContext _context;
        private readonly IEntityService<Course, CourseDTO> _courseService;

        public CourseController(SofiaTeachersOnlineDbContext context, IEntityService<Course, CourseDTO> courseService)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));
            this._courseService = courseService ?? throw new ArgumentNullException(nameof(courseService));
        }

        // GET: Courses
        public async Task<IActionResult> Index()
        {
            var sofiaTeachersOnlineDbContext = _context.Courses.Include(c => c.ModifiedByUser).Include(c => c.Teacher);
            return View(await sofiaTeachersOnlineDbContext.ToListAsync());
        }

        // GET: Courses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await this._courseService.GetEntityByIdAsync(id.Value);

            var course2 = this._courseService.GetAllEntities()
                .Include(x => x.CourseProgress);


            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // GET: Courses/Create
        public IActionResult Create()
        {
            ViewData["ModifiedByUserId"] = new SelectList(_context.Users, "Id", "Discriminator");
            ViewData["TeacherId"] = new SelectList(_context.Set<Teacher>(), "Id", "Discriminator");
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,TeacherId,ModifiedOn,ModifiedByUserId,Id,CreatedOn,DeletedOn,IsDeleted")] Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Add(course);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ModifiedByUserId"] = new SelectList(_context.Users, "Id", "Discriminator", course.ModifiedByUserId);
            ViewData["TeacherId"] = new SelectList(_context.Set<Teacher>(), "Id", "Discriminator", course.TeacherId);
            return View(course);
        }

        // GET: Courses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            ViewData["ModifiedByUserId"] = new SelectList(_context.Users, "Id", "Discriminator", course.ModifiedByUserId);
            ViewData["TeacherId"] = new SelectList(_context.Set<Teacher>(), "Id", "Discriminator", course.TeacherId);
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title,TeacherId,ModifiedOn,ModifiedByUserId,Id,CreatedOn,DeletedOn,IsDeleted")] Course course)
        {
            if (id != course.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(course);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(course.Id))
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
            ViewData["ModifiedByUserId"] = new SelectList(_context.Users, "Id", "Discriminator", course.ModifiedByUserId);
            ViewData["TeacherId"] = new SelectList(_context.Set<Teacher>(), "Id", "Discriminator", course.TeacherId);
            return View(course);
        }

        // GET: Courses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .Include(c => c.ModifiedByUser)
                .Include(c => c.Teacher)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseExists(int id)
        {
            return _context.Courses.Any(e => e.Id == id);
        }
    }
}


/*
    // NOTE: Original scaffolded code

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using SofiaTeachersOnline.Database;
    using SofiaTeachersOnline.Database.Models;
    
    namespace SofiaTeachersOnline.Web.Controllers
    {
        public class CoursesController : Controller
        {
            private readonly SofiaTeachersOnlineDbContext _context;
    
            public CoursesController(SofiaTeachersOnlineDbContext context)
            {
                _context = context;
            }
    
            // GET: Courses
            public async Task<IActionResult> Index()
            {
                var sofiaTeachersOnlineDbContext = _context.Courses.Include(c => c.ModifiedByUser).Include(c => c.Teacher);
                return View(await sofiaTeachersOnlineDbContext.ToListAsync());
            }
    
            // GET: Courses/Details/5
            public async Task<IActionResult> Details(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }
    
                var course = await _context.Courses
                    .Include(c => c.ModifiedByUser)
                    .Include(c => c.Teacher)
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (course == null)
                {
                    return NotFound();
                }
    
                return View(course);
            }
    
            // GET: Courses/Create
            public IActionResult Create()
            {
                ViewData["ModifiedByUserId"] = new SelectList(_context.Users, "Id", "Discriminator");
                ViewData["TeacherId"] = new SelectList(_context.Set<Teacher>(), "Id", "Discriminator");
                return View();
            }
    
            // POST: Courses/Create
            // To protect from overposting attacks, enable the specific properties you want to bind to, for 
            // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create([Bind("Title,TeacherId,ModifiedOn,ModifiedByUserId,Id,CreatedOn,DeletedOn,IsDeleted")] Course course)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(course);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["ModifiedByUserId"] = new SelectList(_context.Users, "Id", "Discriminator", course.ModifiedByUserId);
                ViewData["TeacherId"] = new SelectList(_context.Set<Teacher>(), "Id", "Discriminator", course.TeacherId);
                return View(course);
            }
    
            // GET: Courses/Edit/5
            public async Task<IActionResult> Edit(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }
    
                var course = await _context.Courses.FindAsync(id);
                if (course == null)
                {
                    return NotFound();
                }
                ViewData["ModifiedByUserId"] = new SelectList(_context.Users, "Id", "Discriminator", course.ModifiedByUserId);
                ViewData["TeacherId"] = new SelectList(_context.Set<Teacher>(), "Id", "Discriminator", course.TeacherId);
                return View(course);
            }
    
            // POST: Courses/Edit/5
            // To protect from overposting attacks, enable the specific properties you want to bind to, for 
            // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, [Bind("Title,TeacherId,ModifiedOn,ModifiedByUserId,Id,CreatedOn,DeletedOn,IsDeleted")] Course course)
            {
                if (id != course.Id)
                {
                    return NotFound();
                }
    
                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(course);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!CourseExists(course.Id))
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
                ViewData["ModifiedByUserId"] = new SelectList(_context.Users, "Id", "Discriminator", course.ModifiedByUserId);
                ViewData["TeacherId"] = new SelectList(_context.Set<Teacher>(), "Id", "Discriminator", course.TeacherId);
                return View(course);
            }
    
            // GET: Courses/Delete/5
            public async Task<IActionResult> Delete(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }
    
                var course = await _context.Courses
                    .Include(c => c.ModifiedByUser)
                    .Include(c => c.Teacher)
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (course == null)
                {
                    return NotFound();
                }
    
                return View(course);
            }
    
            // POST: Courses/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                var course = await _context.Courses.FindAsync(id);
                _context.Courses.Remove(course);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
    
            private bool CourseExists(int id)
            {
                return _context.Courses.Any(e => e.Id == id);
            }
        }
    }
*/