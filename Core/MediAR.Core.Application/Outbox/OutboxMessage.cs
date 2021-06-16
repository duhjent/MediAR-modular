using System;

namespace MediAR.Core.Application.Outbox
{
    public class OutboxMessage
    {
        public Guid Id { get; set; }

        public DateTime OccuredAt { get; set; }

        public string Type { get; set; }

        public string Data { get; set; }

        public DateTime? ProcessedDate { get; set; }

        public OutboxMessage(Guid id, DateTime occuredAt, string type, string data)
        {
            Id = id;
            OccuredAt = occuredAt;
            Type = type;
            Data = data;
        }

        private OutboxMessage()
        {

        }
    }
}
