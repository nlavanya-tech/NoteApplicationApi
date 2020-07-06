using NoteApplicationApi.BusinessLayer.Interface;
using NoteApplicationApi.BusinessLayer.Services.Repository;
using NoteApplicationApi.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NoteApplicationApi.BusinessLayer.Services
{
   public class NoteService : INoteService
    {
        private readonly INoteRepository _repository;
        public NoteService(INoteRepository repository)
        {
            _repository = repository;
        }
        //Get call from controller to read All Notes Data
        public async Task<IEnumerable<Notes>> ReadAsync()
        {
            var notes = await _repository.ReadAsync();
            return notes;
        }
        public async Task<Notes> ReadIdAsync(int id)
        {
            var notes = await _repository.ReadIdAsync(id);
            return notes;
        }
        //Get call from controller to Create Note 
        public async Task<Notes> CreateAsync(Notes notes)
        {
            await _repository.CreateAsync(notes);
            return notes;
        }
        //Get call from controller to Update Note 
        public async Task<Notes> UpdateAsync(int id ,Notes notes)
        {
            var note = await _repository.UpdateAsync(id ,notes);

            return note;
        }
        //Get call from controller to Delete Note 
        public async Task<bool> DeleteAsync(int id)
        {
            bool result = await _repository.DeleteAsync(id);
            return result;
        }
    }
}
