namespace Achiever.Services.Models
{
    public class ServicePage : IServicePage
    {
        public ServicePage(int index, int size, int offset)
        {
            this.Index = index;
            this.Size = size;
            this.Offset = offset;
        }

        public int Index { get; set; }
        public int Size { get; set; }
        public int Offset { get; set; }

        public int LinqSkip
        {
            get
            {
                return this.Size * (this.Index - this.Offset);
            }
        }

        public int LinqTake
        {
            get
            {
                return this.Size;
            }
        }
    }
}