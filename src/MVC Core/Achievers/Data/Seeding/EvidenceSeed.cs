using System;
using System.Linq;
using Achievers.Common;
using Achievers.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace Achievers.Data.Seeding
{
    public static class EvidenceSeed
    {
        public static void SeedEvidence(AchieversDbContext dbContext, Achievement achievement, int count)
        {
            GenerateEvidence(dbContext, achievement, count);
        }

        private static void GenerateEvidence(AchieversDbContext dbContext, Achievement achievement, int count) {
            if (count == 0) return;

            GenerateEvidence(dbContext, achievement);

            GenerateEvidence(dbContext, achievement, --count);
        }

        private static Evidence GenerateEvidence(AchieversDbContext dbContext, Achievement achievement)
        {
            Evidence newEvidence = new Evidence
            {
                Title = Faker.Lorem.GetFirstWord(),
                EvidenceType = (EvidenceType) Faker.RandomNumber.Next(1, 4),
                Url = Faker.Internet.DomainName(),
                //CreatedOn = DateTime.UtcNow
            };

            if (achievement != null)
            {
                newEvidence.AchievementId = achievement.Id;
                newEvidence.Achievement = achievement;
            }

            dbContext.Evidence.Add(newEvidence);
            dbContext.SaveChanges();

            return newEvidence;
        }
    }
}