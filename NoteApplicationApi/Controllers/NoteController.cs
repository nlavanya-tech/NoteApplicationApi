using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoteApplicationApi.BusinessLayer.Interface;
using NoteApplicationApi.Entities;

namespace NoteApplicationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly INoteService _service;
        public NoteController(INoteService service)
        {
            _service = service;
        }        
        // GET: api/Note
        [HttpGet]
        public async Task<IEnumerable<Notes>> GetAllNotes()
        {
            var notes = await _service.ReadAsync();
            return notes;
        }
        // POST: api/Notes
        [HttpPost]
        public async void SubmitNotes([FromBody] Notes notes)
        {
            await _service.CreateAsync(notes);
        }

        // PUT: api/Notes/5
        [HttpPut("{id}")]
        public async void UpdateNotes(int id, [FromBody] Notes notes)
        {
            await _service.UpdateAsync(id, notes);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async void DeleteNotes(int id)
        {
            await _service.DeleteAsync(id);
        }
    }
}
