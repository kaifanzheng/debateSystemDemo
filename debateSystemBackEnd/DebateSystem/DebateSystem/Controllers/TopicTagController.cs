using DebateSystem.Data;
using DebateSystem.Services.GeneralServices;
using DebateSystem.Services.TopicTagServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DebateSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicTagController
    {
        private readonly ITopicTagValidation _validation;
        private ApiDbContext _dbContext;
        private FileUpload fileUpload_service;
        public record TopicTagDetailsResponse(int Id, string Name, string Description, IEnumerable<string> TopicName);

        public TopicTagController(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
            fileUpload_service = new FileUpload();
            this._validation = new TopicTagValidation();
        }
    }
}
