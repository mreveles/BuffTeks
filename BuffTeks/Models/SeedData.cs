using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace BuffTeks.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MembersContext(serviceProvider.GetRequiredService<DbContextOptions<MembersContext>>()))
            {
                // Look for any movies.
                if (context.Members.Any())
                {
                    return;   // DB has been seeded
                }

                context.Members.AddRange(
                     new Members
                     {
                        StudentID ="123",
                        FName="George",
                        LName ="Patton",
                        Major="CIS",
                        PhoneNumber="123-4567",
                        Email="george@gmail.com"
                     },
                     new Members
                     {
                        StudentID ="456",
                        FName="Ching",
                        LName ="Shih",
                        Major="CIDM",
                        PhoneNumber="456-7891",
                        Email="ching@gmail.com"
                     },
                     new Members
                     {
                        StudentID ="789",
                        FName="Julius",
                        LName ="Caesar",
                        Major="CIS",
                        PhoneNumber="789-1234",
                        Email="ceaser@gmail.com"
                     },
                     new Members
                     {
                        StudentID ="321",
                        FName="Napoleon",
                        LName ="Bonaparte",
                        Major="CS",
                        PhoneNumber="456-7981",
                        Email="napoleon@gmail.com"
                     },
                     new Members
                     {
                        StudentID ="654",
                        FName="James",
                        LName ="Mattis",
                        Major="CIS",
                        PhoneNumber="321-3214",
                        Email="james@gmail.com"
                     },
                     new Members
                     {
                        StudentID ="987",
                        FName="Genghis",
                        LName ="Khan",
                        Major="CIDM",
                        PhoneNumber="654-7891",
                        Email="genghis@gmail.com"
                     }
                );
                context.SaveChanges();
            }
            using (var clientcontext = new ClientContext(serviceProvider.GetRequiredService<DbContextOptions<ClientContext>>()))
            {
                // Look for any movies.
                if (clientcontext.Client.Any())
                {
                    return;   // DB has been seeded
                }

                clientcontext.Client.AddRange(
                    new Client
                    {
                        CompanyName= "Montague Corp",
                        CompanyPhone ="753-1599",
                        CompanyEmail ="help@montague.com",
                        ComapnyLiaison="Romeo",
                        LiaisonNumber="753-7894"
                    },
                    new Client
                    {
                        CompanyName= "Capulet Corp",
                        CompanyPhone ="951-3577",
                        CompanyEmail ="help@capulet.com",
                        ComapnyLiaison="Juliet",
                        LiaisonNumber="951-1234"
                    }
                );
                clientcontext.SaveChanges();
            }
        }
    }
}