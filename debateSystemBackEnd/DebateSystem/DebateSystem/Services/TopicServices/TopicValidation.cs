using DebateSystem.Models;
using System;

namespace DebateSystem.Services.TopicServices
{
    public class TopicValidation : ITopicValidation
    {
        public Topic topicValidation(Topic topic)
        {
            if (topic == null)
            {
                throw new InvalidOperationException("topic not find");
            }

            if (topic.TopicName == null || topic.TopicName.Equals(""))
            {
                throw new InvalidOperationException("topic name cannot be empty find");
            }
            return topic;
        }
    }
}
