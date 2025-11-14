using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;   // <- BẮT BUỘC để Include hoạt động
using Th14_11.Data;
using Th14_11.Models;

public class LearnerController : Controller
{
    private readonly SchoolContext _context;

    public LearnerController(SchoolContext context)
    {
        _context = context;
    }

    // GET: Learner
    public IActionResult Index()
    {
        var learners = _context.Learners
            .Include(l => l.Major)   // <- Sửa lỗi NullReference khi view gọi item.Major.MajorName
            .ToList();

        return View(learners);
    }

    // GET: Learner/Create
    public IActionResult Create()
    {
        ViewBag.MajorID = new SelectList(_context.Majors, "MajorID", "MajorName");
        return View(new Learner());
    }

    // POST: Learner/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Learner learner)
    {
        if (ModelState.IsValid)
        {
            _context.Learners.Add(learner);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        ViewBag.MajorID = new SelectList(_context.Majors, "MajorID", "MajorName", learner.MajorID);
        return View(learner);
    }

    // GET: Learner/Edit
    public IActionResult Edit(int id)
    {
        var learner = _context.Learners.Find(id);
        if (learner == null) return NotFound();

        ViewBag.MajorID = new SelectList(_context.Majors, "MajorID", "MajorName", learner.MajorID);
        return View(learner);
    }

    // POST: Learner/Edit
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Learner learner)
    {
        if (ModelState.IsValid)
        {
            _context.Learners.Update(learner);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        ViewBag.MajorID = new SelectList(_context.Majors, "MajorID", "MajorName", learner.MajorID);
        return View(learner);
    }

    // GET: Learner/Delete
    public IActionResult Delete(int id)
    {
        var learner = _context.Learners
            .Include(x => x.Major)   // để hiện MajorName trong view Delete
            .FirstOrDefault(x => x.LearnerID == id);

        if (learner == null) return NotFound();

        return View(learner);
    }

    // POST: Learner/Delete
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var learner = _context.Learners.Find(id);
        if (learner != null)
        {
            _context.Learners.Remove(learner);
            _context.SaveChanges();
        }
        return RedirectToAction(nameof(Index));
    }
}
