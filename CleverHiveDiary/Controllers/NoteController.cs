using CleverHiveDiary.Core.Contracts;
using CleverHiveDiary.Infrastructure.Data.Models;
using CleverHiveDiary.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using CleverHiveDiary.Core.Services;
using CleverHiveDiary.Core.ViewModels.Hive;
using Microsoft.EntityFrameworkCore;
using CleverHiveDiary.Core.ViewModels.Note;

namespace CleverHiveDiary.Controllers
{
    public class NoteController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;

        private readonly ApplicationDbContext context;

        private readonly INoteServicecs noteService;

        public NoteController(INoteServicecs _noteService, ApplicationDbContext _context, UserManager<ApplicationUser> _userManager)
        {
            context = _context;
            userManager = _userManager;
            noteService = _noteService;
        }

        public async Task<IActionResult> All()
        {
            var user = await userManager.GetUserAsync(User);
            var notes = await noteService.GetAllNotesAsync(user.Id);

            return View(notes);

        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var note = new AddNoteViewModel();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddNoteViewModel noteViewModel)
        {
            var user = await userManager.GetUserAsync(User);


            await noteService.AddNoteAsync(noteViewModel, user.Id);
            return RedirectToAction("All");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await noteService.DeleteNoteAsync(id);
            return RedirectToAction("All");

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int noteId)
        {
            var note = await context.Notes.FindAsync(noteId);

            //var status = await context.statusHives.FirstOrDefaultAsync(s => s.Id == hive.StatusId);

            var model = new EditNoteViewModel()
            {
                Id = note.Id,
              Title = note.Title,
              Text = note.Text
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int hiveId, EditNoteViewModel model)
        {
            await noteService.UpdateNoteAsync(hiveId, model);

            return RedirectToAction(nameof(All));
        }

    }
}
