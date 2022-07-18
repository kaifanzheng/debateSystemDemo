using DebateSystem.Data;
using DebateSystem.Models;
using DebateSystem.Services.GeneralServices;
using DebateSystem.Services.TopicServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DebateSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {

        private ITopicValidation _validation;
        private ApiDbContext _dbContext;
        private FileUpload fileUpload_service;
        public record TopicDetilsResponse(int Id, String TopicName, IEnumerable<string> UserNames, IEnumerable<string> TagNames);
        public TopicController(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
            fileUpload_service = new FileUpload();
            _validation = new TopicValidation();
        }

        // GET: api/<TopicController>
        [HttpGet]
        public async Task<IActionResult> GetAllTopics()
        {
            var topics = await (from aTopic in _dbContext.Topics
                                select new
                               {
                                   Id = aTopic.Id,
                                   TopicName = aTopic.TopicName,
                                   Popularity = aTopic.Popularity,
                                   ImgUrl = aTopic.ImgUrl
                               }).ToListAsync();
            return Ok(topics);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetTopicDetailsById(int TopicId)
        {
            try
            {
                var topicDetails = await this._dbContext.Topics.Where(a => a.Id == TopicId).
                    Include(a => a.ApplicationUsers).
                    Include(a => a.topicTags).FirstOrDefaultAsync();
                Argument.NotNull(topicDetails, nameof(topicDetails));

                return Ok(new TopicDetilsResponse(
                        topicDetails.Id,
                        topicDetails.TopicName,
                        topicDetails.ApplicationUsers.Select(x => x.UserName),
                        topicDetails.topicTags.Select(x => x.Name)
                    ));
            }
            catch
            {
                return BadRequest();
            }
        }
        // GET api/<TopicController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTopicById(int id)
        {
            try
            {
                Topic topic = await _dbContext.Topics.FindAsync(id);
                return Ok(Argument.NotNull(topic, nameof(topic)));
            }
            catch
            {
                return NotFound("the user is not found");
            }
        }

        // POST api/<TopicController>
        [HttpPost]
        public async Task<IActionResult> CreateTopic([FromForm] Topic topic)
        {
            try
            {
                topic = this._validation.topicValidation(Argument.NotNull(topic, nameof(topic)));
                var imgURL = await fileUpload_service.UploadFile(topic.TopicImg);
                topic.ImgUrl = imgURL;
                await _dbContext.Topics.AddAsync(topic);
                await _dbContext.SaveChangesAsync();
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message.ToString());
            }
        }

        // PUT api/<TopicController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTopicByIdAsync(int id, [FromForm] Topic topic)
        {
            try
            {
                var atopic = await _dbContext.Topics.FindAsync(id);
                atopic = _validation.topicValidation(Argument.NotNull(atopic, nameof(atopic)));

                var imgURL = await fileUpload_service.UploadFile(atopic.TopicImg);

                atopic.ImgUrl = imgURL;
                atopic.TopicName = topic.TopicName;
                atopic.WrittenArguments = topic.WrittenArguments;
                atopic.Popularity = topic.Popularity;
                await _dbContext.SaveChangesAsync();
                return Ok("topic record update successfully");
            }
            catch
            {
                return BadRequest("update unsuccessful");
            }
        }

        [HttpPut("jointopic")]
        public async Task<IActionResult> AddUserIntoTopicById(int userId, int topicId)//JWT
        {
            try
            {
                var topic = await _dbContext.Topics.Include(x => x.ApplicationUsers).FirstOrDefaultAsync(x => x.Id == topicId);
                topic = Argument.NotNull(topic, nameof(topic));


                var user = await _dbContext.ApplicationUsers.FindAsync(userId);
                user = Argument.NotNull(user, nameof(user));

                topic.ApplicationUsers.Add(user);
                await this._dbContext.SaveChangesAsync();

                return Ok("save change");
            }
            catch
            {
                return BadRequest("update unsuccessful");
            }
        }

        // DELETE api/<TopicController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var topic = await _dbContext.Topics.FindAsync(id);
                topic = Argument.NotNull(topic, nameof(topic));
                _dbContext.Topics.Remove(topic);
                await _dbContext.SaveChangesAsync();
                return Ok("topic record delete successfully");
            }
            catch
            {
                return NotFound("delete unsuccessful");
            }
        }
    }
}
