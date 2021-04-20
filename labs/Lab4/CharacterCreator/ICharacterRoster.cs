using System.Collections.Generic;

namespace CharacterCreator
{
    public interface ICharacterRoster
    {
        Character Add ( Character theCharacter, out string error );
        void Delete ( int id, out string error );
        Character Get ( int id, out string error );
        IEnumerable<Character> GetAll ();
        void Update ( int id, Character theCharacter, out string error );
    }
}