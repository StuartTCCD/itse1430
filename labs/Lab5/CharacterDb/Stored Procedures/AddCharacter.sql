--
-- Adds a character.
--
-- PARAMS:
--    name - The name of the character. Must be unique and cannot be empty.
--    profession - The profession of the character. Cannot be empty.
--    race - The race of the character. Cannot be empty.
--    attribute1 - The attribute1 value. Must be between 1 and 100.
--    attribute2 - The attribute2 value. Must be between 1 and 100.
--    attribute3 - The attribute3 value. Must be between 1 and 100.
--    attribute4 - The attribute4 value. Must be between 1 and 100.
--    attribute5 - The attribute5 value. Must be between 1 and 100.
--    description - Specifies the description of the character.
--
-- RETURNS: The ID of the item.
--
CREATE PROCEDURE [dbo].[AddCharacter]
	@name NVARCHAR(255),
    @profession NVARCHAR(50),
    @race NVARCHAR(50),
    @attribute1 INT,
    @attribute2 INT,
    @attribute3 INT,
    @attribute4 INT,
    @attribute5 INT,
    @description NVARCHAR(MAX) = NULL
AS BEGIN
    SET NOCOUNT ON;

    SET @name = LTRIM(RTRIM(ISNULL(@name, '')))
    SET @profession = LTRIM(RTRIM(ISNULL(@profession, '')))
    SET @race = LTRIM(RTRIM(ISNULL(@race, '')))
    
    SET @description = LTRIM(RTRIM(ISNULL(@description, '')))
    IF LEN(@description) = 0 
        SET @description = NULL

    INSERT INTO Characters (Name, Description, Profession, Race, Attribute1, Attribute2, Attribute3, Attribute4, Attribute5) 
        VALUES (@name, @description, @profession, @race, @attribute1, @attribute2, @attribute3, @attribute4, @attribute5)

    SELECT SCOPE_IDENTITY()
END
