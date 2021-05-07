/*
 * Character Creator - Lab 5
 * ITSE 1430
 * Spring 2021
 * Stuart Beeby
 */

namespace CharacterCreator
{
    public static class SeedDatabase
    {
        public static void Seed ( this ICharacterRoster database )
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
                Name = "John",
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

            database.Add(character1);
            database.Add(character2);
            database.Add(character3);
        }
    }
}
