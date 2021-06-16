using System;

namespace MediAR.Core.Infrastructure.Inbox
{
    class InboxMessage
    {
        public Guid Id { get; set; }

        public DateTime OccuredOn { get; set; }

        public string Type { get; set; }

        public DateTime? ProcessedOn { get; set; }

        public InboxMessage(Guid id, DateTime occuredOn, string type, DateTime processedOn)
        {
            Id = id;
            OccuredOn = occuredOn;
            Type = type;
            ProcessedOn = processedOn;
        }

        private InboxMessage() { }
    }
}
