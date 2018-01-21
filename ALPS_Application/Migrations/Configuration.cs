namespace ALPS_Application.Migrations
{
    using ALPS_Test.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ALPS_Application.Models.DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ALPS_Application.Models.DatabaseContext";
        }

        protected override void Seed(ALPS_Application.Models.DatabaseContext context)
        {

            /*created with Ruby script:
            require 'csv'
            d = CSV.read("Migrations/States.txt")
            d.each_with_index{ |x,i| puts "new USState() { ID = #{i+1}, Name = \"#{x[0]}\", Abbreviation = \"#{x[1]}\" }," }
            */
            context.USStates.AddOrUpdate(x => x.ID,
                new USState() { ID = 1, Name = "Alabama", Abbreviation = "AL" },
                new USState() { ID = 2, Name = "Alaska", Abbreviation = "AK" },
                new USState() { ID = 3, Name = "Arizona", Abbreviation = "AZ" },
                new USState() { ID = 4, Name = "Arkansas", Abbreviation = "AR" },
                new USState() { ID = 5, Name = "California", Abbreviation = "CA" },
                new USState() { ID = 6, Name = "Colorado", Abbreviation = "CO" },
                new USState() { ID = 7, Name = "Connecticut", Abbreviation = "CT" },
                new USState() { ID = 8, Name = "Delaware", Abbreviation = "DE" },
                new USState() { ID = 9, Name = "Florida", Abbreviation = "FL" },
                new USState() { ID = 10, Name = "Georgia", Abbreviation = "GA" },
                new USState() { ID = 11, Name = "Hawaii", Abbreviation = "HI" },
                new USState() { ID = 12, Name = "Idaho", Abbreviation = "ID" },
                new USState() { ID = 13, Name = "Illinois", Abbreviation = "IL" },
                new USState() { ID = 14, Name = "Indiana", Abbreviation = "IN" },
                new USState() { ID = 15, Name = "Iowa", Abbreviation = "IA" },
                new USState() { ID = 16, Name = "Kansas", Abbreviation = "KS" },
                new USState() { ID = 17, Name = "Kentucky", Abbreviation = "KY" },
                new USState() { ID = 18, Name = "Louisiana", Abbreviation = "LA" },
                new USState() { ID = 19, Name = "Maine", Abbreviation = "ME" },
                new USState() { ID = 20, Name = "Maryland", Abbreviation = "MD" },
                new USState() { ID = 21, Name = "Massachusetts", Abbreviation = "MA" },
                new USState() { ID = 22, Name = "Michigan", Abbreviation = "MI" },
                new USState() { ID = 23, Name = "Minnesota", Abbreviation = "MN" },
                new USState() { ID = 24, Name = "Mississippi", Abbreviation = "MS" },
                new USState() { ID = 25, Name = "Missouri", Abbreviation = "MO" },
                new USState() { ID = 26, Name = "Montana", Abbreviation = "MT" },
                new USState() { ID = 27, Name = "Nebraska", Abbreviation = "NE" },
                new USState() { ID = 28, Name = "Nevada", Abbreviation = "NV" },
                new USState() { ID = 29, Name = "New Hampshire", Abbreviation = "NH" },
                new USState() { ID = 30, Name = "New Jersey", Abbreviation = "NJ" },
                new USState() { ID = 31, Name = "New Mexico", Abbreviation = "NM" },
                new USState() { ID = 32, Name = "New York", Abbreviation = "NY" },
                new USState() { ID = 33, Name = "North Carolina", Abbreviation = "NC" },
                new USState() { ID = 34, Name = "North Dakota", Abbreviation = "ND" },
                new USState() { ID = 35, Name = "Ohio", Abbreviation = "OH" },
                new USState() { ID = 36, Name = "Oklahoma", Abbreviation = "OK" },
                new USState() { ID = 37, Name = "Oregon", Abbreviation = "OR" },
                new USState() { ID = 38, Name = "Pennsylvania", Abbreviation = "PA" },
                new USState() { ID = 39, Name = "Rhode Island", Abbreviation = "RI" },
                new USState() { ID = 40, Name = "South Carolina", Abbreviation = "SC" },
                new USState() { ID = 41, Name = "South Dakota", Abbreviation = "SD" },
                new USState() { ID = 42, Name = "Tennessee", Abbreviation = "TN" },
                new USState() { ID = 43, Name = "Texas", Abbreviation = "TX" },
                new USState() { ID = 44, Name = "Utah", Abbreviation = "UT" },
                new USState() { ID = 45, Name = "Vermont", Abbreviation = "VT" },
                new USState() { ID = 46, Name = "Virginia", Abbreviation = "VA" },
                new USState() { ID = 47, Name = "Washington", Abbreviation = "WA" },
                new USState() { ID = 48, Name = "West Virginia", Abbreviation = "WV" },
                new USState() { ID = 49, Name = "Wisconsin", Abbreviation = "WI" },
                new USState() { ID = 50, Name = "Wyoming", Abbreviation = "WY" },
                new USState() { ID = 51, Name = "American Samoa", Abbreviation = "AS" },
                new USState() { ID = 52, Name = "District of Columbia", Abbreviation = "DC" },
                new USState() { ID = 53, Name = "Federated States of Micronesia", Abbreviation = "FM" },
                new USState() { ID = 54, Name = "Guam", Abbreviation = "GU" },
                new USState() { ID = 55, Name = "Marshall Islands", Abbreviation = "MH" },
                new USState() { ID = 56, Name = "Northern Mariana Islands", Abbreviation = "MP" },
                new USState() { ID = 57, Name = "Palau", Abbreviation = "PW" },
                new USState() { ID = 58, Name = "Puerto Rico", Abbreviation = "PR" },
                new USState() { ID = 59, Name = "Virgin Islands", Abbreviation = "VI" }
                );
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
