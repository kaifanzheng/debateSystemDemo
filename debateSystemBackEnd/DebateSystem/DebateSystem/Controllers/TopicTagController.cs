using DebateSystem.Data;
using DebateSystem.Services.ApplicationUserServices;
using DebateSystem.Services.GeneralServices;
using System.Collections.Generic;

namespace DebateSystem.Controllers
{
    public class TopicTagController
    {
        private readonly IApplicationUserValidation _validation;
        private ApiDbContext _dbContext;
        private FileUpload fileUpload_service;
        public record TopicTagDetailsResponse(int Id, string Name, string Description, IEnumerable<string> TopicName);

        public TopicTagController(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
            fileUpload_service = new FileUpload();
        }
    }
}
