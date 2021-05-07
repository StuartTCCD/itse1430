--
-- Gets a character.
--
-- PARAMS:
--    id - The ID of the item.
-- 
-- RETURNS: The item, if found.
--
CREATE PROCEDURE [dbo].[GetCharacter]
	@id INT
AS BEGIN
	SET NOCOUNT ON;

    SELECT Id, Name, Description, Profession, Race, Attribute1, Attribute2, Attribute3, Attribute4, Attribute5
    FROM Characters
    WHERE Id = @id
END

	 




