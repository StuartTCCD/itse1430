/*
 * Character Creator - Lab 5
 * ITSE 1430
 * Spring 2021
 * Stuart Beeby
 */

using System.Collections.Generic;

namespace CharacterCreator
{
    /// <summary>Represents a database of RPG characters</summary>
    public interface ICharacterRoster
    {

        /// <summary>
        /// Adds a character to the database.
        /// </summary>
        /// <param name="theCharacter">The character to add</param>
        /// <returns>The added character</returns>
        Character Add ( Character theCharacter);
        /// <summary>
        /// Deletes a character from the database
        /// </summary>
        /// <param name="id">The character to delete</param>
        void Delete ( int id);
        /// <summary>
        /// Gets a character from the database
        /// </summary>
        /// <param name="id">The character name</param>
        /// <returns>Returns a specific character from the database linked to the id number</returns>
        Character Get ( int id);
        /// <summary>
        /// Gets all the characters
        /// </summary>
        /// <returns>All the characters</returns>
        IEnumerable<Character> GetAll ();
        /// <summary>
        /// Updates an existing character linked to the characters id number
        /// </summary>
        /// <param name="id">The characters id number</param>
        /// <param name="theCharacter">The characters name</param>
        void Update ( int id, Character theCharacter);
    }
}