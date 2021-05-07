--
-- Gets all the characters.
--
-- PARAMS: None.
-- 
-- RETURNS: The characters.
--
CREATE PROCEDURE [dbo].[GetAllCharacters]	
AS BEGIN
    SET NOCOUNT ON;

    SELECT Id, Name, Description, Profession, Race, Attribute1, Attribute2, Attribute3, Attribute4, Attribute5
    FROM Characters
END
