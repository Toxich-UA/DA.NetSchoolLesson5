using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankModel.Mappinds;
using Lesson4.Entity;
using Lesson4.Model;

namespace Lesson4.Services
{
    public class DbServices
    {
        public void InsertInitialData()
        {
            using (var ctx = new BankDbContext())
            {
                var newClient = new Clients
                {
                    FirstName = "Bob",
                    LastName = "Robertson",
                    Birthday = DateTime.Parse("1964-04-04"),
                    PhoneNamber = "+380 (067) 111 11 22"
                };
                var card1 = new Cards { CardId = "5111111111111111", PinCode = "5551" };
                newClient.Cards.Add(card1);
                var card2 = new Cards { CardId = "5111111111111112", PinCode = "5552" }; 
                newClient.Cards.Add(card2);
                newClient.Address = new Addresses { ClientId = 1, Country = "Germany", State = "Mecklenburg-Vorpommern", Address = "544 Harry Place" };

                ctx.Clients.Add(newClient);

                ctx.Operations.Add(new Operations { Amount = 200, InCard = card2, OutCard = card1 });

                ctx.SaveChanges();
            }
        }

        public void RecalculateBallance(string cardNo)
        {
            using (var ctx = new BankDbContext())
            {
                var card = ctx.Cards.SingleOrDefault(c => c.CardId == cardNo);

                ctx.Entry(card).Collection(c => c.InOperations).Load();
                ctx.Entry(card).Collection(c => c.OutOperations).Load();

                card.Ballance = card.InOperations.Sum(o => o.Amount) - card.OutOperations.Sum(o => o.Amount);

                ctx.SaveChanges();
            }
        }
    }
}
