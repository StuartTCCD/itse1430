/*
 * Character Creator
 * ITSE 1430
 * Spring 2021
 * Stuart Beeby
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator
{
    public class CharacterCreator
    {
        public String characterName;
        public String characterProfession;
        public String characterRace;
        public String characterBiography;
        public String[] characterAttributeNames = { "Strength", "Intelligence", "Agility", "Constitution", "Charisma" };
        public int[] characterAttributeValue = { 0, 0, 0, 0, 0 };
    }
}
