using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace CharacterCreator
{
    public class MemoryCharacterRoster : ICharacterRoster
    {
        public Character Add ( Character theCharacter, out string error )
        {
            if (theCharacter == null)
            {
                error = "Character is null";
                return null;
            };

            var errors = new ObjectValidator().TryValidate(theCharacter);
            if (errors.Count > 0)
            {
                error = errors[0].ErrorMessage;
                return null;
            }

            var existing = FindByName(theCharacter.Name);
            if (existing != null)
            {
                error = "Character name must be unique";
                return null;
            };

            theCharacter.Id = ++_id;
            _characters.Add(CloneCharacter(theCharacter));
            error = null;
            return theCharacter;
        }

        public void Delete ( int id, out string error )
        {
            if (id <=0)
            {
                error = "Invalid ID, must be greater than zero";
                return;
            };
            error = null;

            var existing = FindById(id);
            if (existing != null)
            {
                _characters.Remove(existing);
            }
        }

        public void Update ( int id, Character theCharacter, out string error )
        {
            if (theCharacter == null)
            {
                error = "Character is null";
                return;
            };
            var errors = new ObjectValidator().TryValidate(theCharacter);
            if (errors.Count > 0)
            {
                error = errors[0].ErrorMessage;
                return;
            }
            if (id <=0)
            {
                error = "Invalid ID, must be greater than zero";
                return;
            };

            var existing = FindByName(theCharacter.Name);
            if (existing != null && existing.Id != id)
            {

                error = "Character name must be unique";
                return;
            };

            existing = FindById(id);
            if (existing == null)
            {
                error = "Character does not exist.";
                return;
            }

            error = null;

            CopyCharacter(existing, theCharacter);
        }

        public Character Get ( int id, out string error )
        {
            if (id <=0)
            {
                error = "Invalid ID, must be greater than zero";
                return null;
            };
            error = null;

            var existing = FindById(id);
            if (existing == null)
            {
                return null;
            }

            return CloneCharacter(existing);
        }

        public IEnumerable<Character> GetAll ()
        {
            foreach (Character ch in _characters)
            {
                yield return CloneCharacter(ch);
            }
        }

        private Character CloneCharacter ( Character theCharacter )
        {
            var target = new Character() {
                Id = theCharacter.Id
            };
            CopyCharacter(target, theCharacter);
            return target;
        }

        private void CopyCharacter ( Character target, Character source )
        {
            target.Name = source.Name;
            target.Profession = source.Profession;
            target.Race = source.Race;
            target.Strength = source.Strength;
            target.Intelligence = source.Intelligence;
            target.Agility = source.Agility;
            target.Constitution = source.Constitution;
            target.Charisma = source.Charisma;
            target.Biography = source.Biography;
        }

        private Character FindByName ( string name )
        {
            foreach (var ch in _characters)
            {
                if (String.Compare(ch.Name, name, true) == 0)
                {
                    return ch;
                }
            };
            return null;
        }

        private Character FindById ( int id )
        {
            foreach (var ch in _characters)
            {
                if (ch.Id == id)
                {
                    return ch;
                }
            };
            return null;
        }


        private readonly List<Character> _characters = new List<Character>();

        private int _id;

    }
}
