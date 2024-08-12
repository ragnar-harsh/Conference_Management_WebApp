using backend.Models;
using backend.Repository;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class MeetingController : ControllerBase
    {
        private readonly IMeetingRepository _meetings;
        public MeetingController(IMeetingRepository meetingRepository)
        {
            _meetings = meetingRepository;
        }
        [HttpGet("")]
        public async Task<IActionResult> GetAllMeetings()
        {
            var meetings = await _meetings.GetAllMeetings();
            return Ok(meetings);
        }

        [HttpPost("AddMeeting")]
        public async Task<IActionResult> AddMeetings([FromForm]MeetingModel meetingModel)
        {
            await _meetings.AddMeetingAsync(meetingModel);
            return Ok(new { message = "Meeting Scheduled Successfully"});
        }

        [HttpPost("EditMeeting")]
        public async Task<IActionResult> EditMeetings([FromForm]MeetingModel meetingModel)
        {
            await _meetings.EditMeeting(meetingModel, meetingModel.Id);
            return Ok(new { message = "Meeting Edited Successfully"});
        }
        [HttpDelete("removeMeeting/{id}")]
        public async Task<IActionResult> EditMeetings([FromRoute]int id)
        {
            await _meetings.RemoveMeeting(id);
            return Ok(new { Message = "Meeting Removed Successfully"});
        }

    }
}