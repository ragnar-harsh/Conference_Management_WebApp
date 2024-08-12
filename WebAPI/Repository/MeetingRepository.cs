using backend.Data;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repository
{
    public class MeetingRepository : IMeetingRepository
    {
        private readonly ContextClass _contextClass;
        public MeetingRepository(ContextClass contextClass)
        {
            _contextClass = contextClass;
        }

        public async Task<List<MeetingModel>> GetAllMeetings()
        {
            var records = await _contextClass.Meetings.Select(m => new MeetingModel(){
                Id = m.Id,
                Title = m.Title,
                Date = m.Date,
                Time = m.Time,
                Description = m.Description,
                Location = m.Location
            }).ToListAsync();
            return records;
        }
        
        public async Task AddMeetingAsync(MeetingModel meeting)
        {
            var NewMeeting = new Meetings()
            {
                Title = meeting.Title,
                Date = meeting.Date,
                Time = meeting.Time,
                Description = meeting.Description,
                Location = meeting.Location
            };
            await _contextClass.Meetings.AddAsync(NewMeeting);
            await _contextClass.SaveChangesAsync();
        }

        public async Task EditMeeting(MeetingModel meetingModel, int id)
        {
            var meeting = await _contextClass.Meetings.FindAsync(id);
            if(meeting != null)
            {
                meeting.Description = meetingModel.Description;
                meeting.Location = meetingModel.Location;
                meeting.Time = meetingModel.Time;
                meeting.Title = meetingModel.Title;
                meeting.Date = meetingModel.Date;
                await _contextClass.SaveChangesAsync();
            }
        }

        public async Task RemoveMeeting(int id)
        {
            var meeting = await _contextClass.Meetings.FindAsync(id);
            _contextClass.Meetings.Remove(meeting);
            await _contextClass.SaveChangesAsync();
            return;
        }
    }
}