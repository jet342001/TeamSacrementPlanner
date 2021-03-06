using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SacramentMeetingPlanner.Data;
using SacramentMeetingPlanner.Models;

namespace SacramentMeetingPlanner.Controllers
{
    public class SpeakersController : Controller
    {
        private readonly MeetingContext _context;

        public SpeakersController(MeetingContext context)
        {
            _context = context;
        }

        // GET: Speakers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Speaker.ToListAsync());
        }

        // GET: Speakers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var speaker = await _context.Speaker
                .FirstOrDefaultAsync(m => m.SpeakerId == id);
            if (speaker == null)
            {
                return NotFound();
            }

            return View(speaker);
        }

        // GET: Speakers/Create
        public IActionResult Create(int meetingId)
        {
            ViewData["MeetingId"] = meetingId;
            return View();
        }

        // POST: Speakers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SpeakerId,MeetingId,Name,Subject,Order")] Speaker speaker)
        {

            var meeting = await _context.Meeting.Include(s => s.Speakers).FirstOrDefaultAsync(m => m.MeetingId == speaker.MeetingId);
            if (meeting.Speakers.Any(s => s.Order == speaker.Order))
            {
                ModelState.AddModelError("Order", "This order number is already taken. Order numbers " + string.Join(", ", meeting.Speakers.Select(s => s.Order.ToString()).ToArray()) + " are used.");
                ViewData["MeetingId"] = speaker.MeetingId;
                return View(speaker);
            }

            if (ModelState.IsValid)
            {
                _context.Add(speaker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Edit), "Meetings", new { id=speaker.MeetingId });
            }
            ViewData["MeetingId"] = speaker.MeetingId;
            return View(speaker);
        }

        // GET: Speakers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var speaker = await _context.Speaker.FindAsync(id);
            if (speaker == null)
            {
                return NotFound();
            }
            return View(speaker);
        }

        // POST: Speakers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SpeakerId,MeetingId,Name,Subject,Order")] Speaker speaker)
        {
            if (id != speaker.SpeakerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var meeting = await _context.Meeting.Include(r => r.Speakers).AsNoTracking().FirstOrDefaultAsync(m => m.MeetingId == speaker.MeetingId);
                if (meeting.Speakers.Any(s => s.Order == speaker.Order && s.SpeakerId != speaker.SpeakerId))
                {
                    ModelState.AddModelError("Order", "This order number is already taken. Order numbers " + string.Join(", ", meeting.Speakers.Select(s => s.Order.ToString()).ToArray()) + " are used.");
                    return View(speaker);
                }
                try
                {
                    _context.Update(speaker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpeakerExists(speaker.SpeakerId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Edit), "Meetings", new { id = speaker.MeetingId });
            }
            return View(speaker);
        }

        // GET: Speakers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var speaker = await _context.Speaker
                .FirstOrDefaultAsync(m => m.SpeakerId == id);
            if (speaker == null)
            {
                return NotFound();
            }

            return View(speaker);
        }

        // POST: Speakers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var speaker = await _context.Speaker.FindAsync(id);
            _context.Speaker.Remove(speaker);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Edit), "Meetings", new { id = speaker.MeetingId });
        }

        private bool SpeakerExists(int id)
        {
            return _context.Speaker.Any(e => e.SpeakerId == id);
        }
    }
}
