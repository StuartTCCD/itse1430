--
-- Searches for a character given its name.
--
-- PARAMS:
--    name - The name to search for.
--
-- RETURNS: The character, if found.
--
CREATE PROCEDURE [dbo].[FindCharacterByName]
	@name NVARCHAR(255)
AS BEGIN
    SET NOCOUNT ON;

    SET @name = LTRIM(RTRIM(ISNULL(@name, '')))

    SELECT Id, Name, Description, Profession, Race, Attribute1, Attribute2, Attribute3, Attribute4, Attribute5
    FROM Characters
    WHERE Name = @name
END