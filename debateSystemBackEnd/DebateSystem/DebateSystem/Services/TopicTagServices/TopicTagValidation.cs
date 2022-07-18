using DebateSystem.Models;
using System;

namespace DebateSystem.Services.TopicTagServices
{
    public class TopicTagValidation : ITopicTagValidation
    {
        public TopicTag topicTagValidation(TopicTag topicTag)
        {
            if(topicTag == null)
            {
                throw new InvalidOperationException("topicTag cannot be find find");
            }

            if(topicTag.Name == null || topicTag.Name.Equals(""))
            {
                throw new InvalidOperationException("topicTag name cannot be empty");
            }

            if(topicTag.Description == null || topicTag.Description.Equals(""))
            {
                throw new InvalidOperationException("Description cannot be empty");
            }

            return topicTag;
        }
    }
}
