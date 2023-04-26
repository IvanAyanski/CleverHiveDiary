using CleverHiveDiary.Core.ViewModels.Note;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleverHiveDiary.Core.Contracts
{
    public interface INoteServicecs
    {
        Task<IEnumerable<NoteViewModel>> GetAllNotesAsync(string userId);
        Task<NoteViewModel> GetNoteByIdAsync(int id);
        Task AddNoteAsync(AddNoteViewModel note, string userId);
        Task UpdateNoteAsync(int id, EditNoteViewModel note);
        Task DeleteNoteAsync(int noteId);
    }
}
