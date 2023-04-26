using CleverHiveDiary.Core.Contracts;
using CleverHiveDiary.Core.ViewModels.Note;
using CleverHiveDiary.Infrastructure.Data;
using CleverHiveDiary.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleverHiveDiary.Core.Services
{
    public class NoteService : INoteServicecs
    {
        private readonly ApplicationDbContext context;

        public NoteService(ApplicationDbContext _context)
        {
            context = _context;
        }

        public async Task AddNoteAsync(AddNoteViewModel note, string userId)
        {
            var newNote = new Note()
            {
                Text = note.Text,
                Title = note.Title,
                UserId = userId
            };

            context.Notes.Add(newNote);
            await context.SaveChangesAsync();

        }

        public async Task DeleteNoteAsync(int noteId)
        {
            var note = await context.Notes.FirstOrDefaultAsync(x => x.Id == noteId);
            context.Notes.Remove(note);
            await context.SaveChangesAsync();


        }

        public async Task<IEnumerable<NoteViewModel>> GetAllNotesAsync(string userId)
        {
            var user = await context.Users.Include(u => u.Notes)
                .FirstOrDefaultAsync(u => u.Id == userId);

            var notes = user.Notes.Select(n => new NoteViewModel
            {
                Id = n.Id,
                Title = n.Title,
                Text = n.Text,
                UserId = userId
            }).ToList();

            return notes;
        }

        public async Task<NoteViewModel> GetNoteByIdAsync(int noteId)
        {
            var note = await context.Notes.FindAsync(noteId);


            return new NoteViewModel
            {
                Id = note.Id,
                Text = note.Text,
                UserId = note.UserId,
                Title = note.Title

            };
        }

        public async Task UpdateNoteAsync(int id, EditNoteViewModel note)
        {
            var existingNote = await context.Notes.FindAsync(note.Id);

            if (existingNote != null)
            {
                existingNote.Title = note.Title;
                existingNote.Text = note.Text;

                await context.SaveChangesAsync();
            }
        }
    }

}

