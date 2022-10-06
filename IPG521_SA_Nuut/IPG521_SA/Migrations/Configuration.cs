namespace IPG521_SA.Migrations
{
    using IPG521_SA.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<IPG521_SA.Data.PapersDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(IPG521_SA.Data.PapersDbContext context)
        {
            context.Topics.AddOrUpdate(
                 s => s.TopicID,
                 new Topics { TopicName = "Data Science" },
                 new Topics { TopicName = "Education" },
                 new Topics { TopicName = "Human-Computer Interaction" },
                 new Topics { TopicName = "Internet of Things" });

        }
    }
}
