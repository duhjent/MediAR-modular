namespace MediAR.Core.Application.Queries
{
    class PageData
    {
        public int Offset { get; }

        public int Next { get; }

        public PageData(int offset, int next)
        {
            Offset = offset;
            Next = next;
        }
    }
}
