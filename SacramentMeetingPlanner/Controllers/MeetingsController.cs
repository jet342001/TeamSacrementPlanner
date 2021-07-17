using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SacramentMeetingPlanner.Data;
using SacramentMeetingPlanner.Models;
using SacramentMeetingPlanner.Models.ChurchViewModels;

namespace SacramentMeetingPlanner.Controllers
{
    public class MeetingsController : Controller
    {
        private readonly MeetingContext _context;
        private readonly HymnLibrary _hymnLibrary;

        public MeetingsController(MeetingContext context, HymnLibrary hymnLibrary)
        {
            _context = context;
            _hymnLibrary = hymnLibrary;
        }

        // GET: Meetings
        public async Task<IActionResult> Index(
            string sortOrder,
            string currentFilter,
            string searchString,
            int? pageNumber
        )
        {

            var allMeetings = _context.Meeting
                .Include(i => i.Speakers).Select(m=>m);

            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["CurrentFilter"] = searchString;

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            //var allMeetings = from s in _context.Meeting
            //               select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                allMeetings = allMeetings.Where(s => s.Conductor.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    allMeetings = allMeetings.OrderByDescending(s => s.Conductor);
                    break;
                case "Date":
                    allMeetings = allMeetings.OrderBy(s => s.StartAt);
                    break;
                case "date_desc":
                    allMeetings = allMeetings.OrderByDescending(s => s.StartAt);
                    break;
                default:
                    allMeetings = allMeetings.OrderBy(s => s.StartAt);
                    break;
            }

            int pageSize = 3;

            var meetings =
                await PaginatedList<Meeting>.CreateAsync(allMeetings.AsNoTracking(), pageNumber ?? 1, pageSize);
            //var meetings = await _context.Meeting.ToListAsync();
            meetings.ForEach(LoadAllUsedHymns);
            return View(meetings);
            /*return View(allMeetings);*/
        }

        // GET: Meetings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meeting = await _context.Meeting
                .FirstOrDefaultAsync(m => m.MeetingId == id);
            if (meeting == null)
            {
                return NotFound();
            }

            LoadUsedHymns(meeting);

            return View(meeting);
        }

        public async Task<IActionResult> Print(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meeting = await _context.Meeting
                .FirstOrDefaultAsync(m => m.MeetingId == id);
            if (meeting == null)
            {
                return NotFound();
            }

            LoadAllUsedHymns(meeting);
            return View(meeting);
        }



        // GET: Meetings/Create
        public IActionResult Create()
        {
            ViewBag.HymnSelectionList = _hymnLibrary.GetSelectionList();

            return View();
        }

        // POST: Meetings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MeetingId,StartAt,Conductor,OpeningSongNumber,SacramentSongNumber,ClosingSongNumber,IntermediateSong,IntermediateSongNumber,MusicalNumber,OpeningPrayerBy,ClosingPrayerBy")] Meeting meeting)
        {
            if (ModelState.IsValid)
            {
                _context.Add(meeting);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.HymnSelectionList = _hymnLibrary.GetSelectionList();
            return View(meeting);
        }

        // GET: Meetings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meeting = await _context.Meeting.FindAsync(id);
            if (meeting == null)
            {
                return NotFound();
            }

            ViewBag.HymnSelectionList = _hymnLibrary.GetSelectionList();
            return View(meeting);
        }

        // POST: Meetings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MeetingId,StartAt,Conductor,OpeningSongNumber,SacramentSongNumber,ClosingSongNumber,IntermediateSongNumber,MusicalNumber,OpeningPrayerBy,ClosingPrayerBy")] Meeting meeting)
        {
            if (id != meeting.MeetingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(meeting);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeetingExists(meeting.MeetingId))
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

            ViewBag.HymnSelectionList = _hymnLibrary.GetSelectionList();
            return View(meeting);
        }

        // GET: Meetings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meeting = await _context.Meeting
                .FirstOrDefaultAsync(m => m.MeetingId == id);
            if (meeting == null)
            {
                return NotFound();
            }

            LoadUsedHymns(meeting);
            return View(meeting);
        }

        // POST: Meetings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var meeting = await _context.Meeting.FindAsync(id);
            _context.Meeting.Remove(meeting);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MeetingExists(int id)
        {
            return _context.Meeting.Any(e => e.MeetingId == id);
        }

        private void LoadUsedHymns(Meeting meeting)
        {
            ViewData["OpeningHymn"] = _hymnLibrary.GetHymn(meeting.OpeningSongNumber);
            ViewData["SacramentHymn"] = _hymnLibrary.GetHymn(meeting.SacramentSongNumber);
            ViewData["ClosingHymn"] = _hymnLibrary.GetHymn(meeting.ClosingSongNumber);
            if (meeting.IntermediateSongNumber.HasValue)
                ViewData["IntermediateHymn"] = _hymnLibrary.GetHymn(meeting.IntermediateSongNumber.Value);
        }

        private void LoadAllUsedHymns(Meeting meeting)
        {
            LoadHymn(meeting.OpeningSongNumber);
            LoadHymn(meeting.SacramentSongNumber);
            LoadHymn(meeting.ClosingSongNumber);
            if (meeting.IntermediateSongNumber.HasValue)
                LoadHymn(meeting.IntermediateSongNumber.Value);
        }

        private void LoadHymn(int hymnNumber)
        {
            ViewData[$"Hymn-{hymnNumber}"] ??= _hymnLibrary.GetHymn(hymnNumber);
        }
    }
}