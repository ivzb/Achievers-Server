namespace Achiever.Data.Models
{
    using Achiever.Data.Common.Models;
    using System.Collections.Generic;

    public class Evidence : BaseModel<int>
    {
        public Evidence()
        {
        }

        public string Title { get; set; }

        public EvidenceType EvidenceType { get; set; }

        public string Url { get; set; }

        public int AchievementId { get; set; }

        public Achievement Achievement { get; set; }

    }
}