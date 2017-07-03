using Achievers.Common.Models;

namespace Achievers.Data.Models
{
    public class Evidence : BaseModel<int>
    {
        public string Title { get; set; }

        public EvidenceType EvidenceType { get; set; }

        public string Url { get; set; }

        public int AchievementId { get; set; }

        public Achievement Achievement { get; set; }

        public string AuthorId { get; set; }

        public User Author { get; set; }
    }
}