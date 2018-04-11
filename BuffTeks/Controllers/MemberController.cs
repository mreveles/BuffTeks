using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BuffTeks.Models;

namespace BuffTeks.Controllers
{
    public class MemberController : Controller
    {
        private readonly MembersContext _context;

        public MemberController(MembersContext context)
        {
            _context = context;
        }

        // GET: Member
       // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public async Task<IActionResult> Index(string memberMajor, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> majorQuery = from m in _context.Members
                                            orderby m.Major
                                            select m.Major;

            var members = from m in _context.Members
                        select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                members = members.Where(s => s.FName.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(memberMajor))
            {
                members = members.Where(x => x.Major == memberMajor);
            }

            var memberMajorVM = new MemberMajorViewModel();
            memberMajorVM.major = new SelectList(await majorQuery.Distinct().ToListAsync());
            memberMajorVM.members = await members.ToListAsync();

            return View(memberMajorVM);
        } 

        // GET: Member/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var members = await _context.Members
                .SingleOrDefaultAsync(m => m.ID == id);
            if (members == null)
            {
                return NotFound();
            }

            return View(members);
        }

        // GET: Member/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Member/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,StudentID,FName,LName,Major,PhoneNumber,Email")] Members members)
        {
            if (ModelState.IsValid)
            {
                _context.Add(members);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(members);
        }

        // GET: Member/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var members = await _context.Members.SingleOrDefaultAsync(m => m.ID == id);
            if (members == null)
            {
                return NotFound();
            }
            return View(members);
        }

        // POST: Member/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,StudentID,FName,LName,Major,PhoneNumber,Email")] Members members)
        {
            if (id != members.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(members);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MembersExists(members.ID))
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
            return View(members);
        }

        // GET: Member/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var members = await _context.Members
                .SingleOrDefaultAsync(m => m.ID == id);
            if (members == null)
            {
                return NotFound();
            }

            return View(members);
        }

        // POST: Member/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var members = await _context.Members.SingleOrDefaultAsync(m => m.ID == id);
            _context.Members.Remove(members);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MembersExists(int id)
        {
            return _context.Members.Any(e => e.ID == id);
        }
    }
}
