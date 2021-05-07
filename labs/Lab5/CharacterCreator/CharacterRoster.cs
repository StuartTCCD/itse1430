/*
 * Character Creator - Lab 5
 * ITSE 1430
 * Spring 2021
 * Stuart Beeby
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace CharacterCreator 
{
    public abstract class CharacterRoster : ICharacterRoster
    { 
        public Character Add ( Character theCharacter )
        {
            if (theCharacter == null)
            {
                throw new ArgumentNullException(nameof(Character));
            };

            ObjectValidator.Validate(theCharacter);

            var existing = FindByName(theCharacter.Name);
            if (existing != null)
            {
                throw new InvalidOperationException("Character name must be unique");
            };

            return AddCore(theCharacter);
        }

        protected abstract Character AddCore ( Character theCharacter );

        public void Delete ( int id )
        {
            if (id <=0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than 0.");
            };

            DeleteCore(id);
        }

        protected abstract void DeleteCore ( int id );

        public void Update ( int id, Character theCharacter)
        {
            if (id <=0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than 0.");
            };

            if (theCharacter == null)
            {
                throw new ArgumentNullException(nameof(Character));
            };

            ObjectValidator.Validate(theCharacter);

            var existing = FindByName(theCharacter.Name);
            if (existing != null)
            {
                throw new InvalidOperationException("Character name must be unique");
            };
            try
            {
                UpdateCore(id, theCharacter);
            }
            catch(ArgumentException e)
            {
                throw;
            }
            catch (InvalidOperationException e)
            {
                throw;
            }
            catch(Exception e)
            {
                throw new Exception("Update failed", e);
            }
            
        }

        protected abstract void UpdateCore (int id, Character theCharacter );

        public Character Get ( int id)
        {
            if (id <=0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than 0.");
            };

            return GetCore(id);
        }

        protected abstract Character GetCore ( int id );

        public IEnumerable<Character> GetAll ()
        {
            return GetAllCore() ?? Enumerable.Empty<Character>();
        }

        protected abstract IEnumerable<Character> GetAllCore ();

        protected virtual Character FindByName ( string name )
        {
            foreach (var ch in GetAllCore())
            {
                if (String.Compare(ch.Name, name, true) == 0)
                {
                    return ch;
                }
            };
            return null;
        }
    }
}
