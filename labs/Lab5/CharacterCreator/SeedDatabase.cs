using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator
{
    public class SeedDatabase
    {
        public void Seed ( ICharacterRoster database )
        {
            var character1 = new Character() {
                Name = "Michael",
                Profession = "Wizard",
                Race = "Human",
                Strength = 100,
                Intelligence = 100,
                Agility = 100,
                Constitution = 100,
                Charisma = 100,
                Biography = "A really smart C# Professor!"
            };

            var character2 = new Character() {
                Name = "Bill",
                Profession = "Hunter",
                Race = "Human",
                Strength = 5,
                Intelligence = 5,
                Agility = 5,
                Constitution = 5,
                Charisma = 5
            };

            var character3 = new Character() {
                Name = "Frank",
                Profession = "Hunter",
                Race = "Human",
                Strength = 5,
                Intelligence = 5,
                Agility = 5,
                Constitution = 5,
                Charisma = 5
            };

            database.Add(character1, out var error);
            database.Add(character2, out error);
            database.Add(character3, out error);
        }
    }
}
