using backend.Models;

namespace backend.Repository
{
    public interface IMeetingRepository
    {
        Task<List<MeetingModel>> GetAllMeetings();
        Task AddMeetingAsync(MeetingModel meeting);
        Task EditMeeting(MeetingModel meetingModel, int id);
        Task RemoveMeeting(int id);
    }
}