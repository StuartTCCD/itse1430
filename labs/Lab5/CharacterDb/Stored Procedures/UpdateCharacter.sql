--
-- Updates an existing character.
--
-- PARAMS:
--    id - The ID of the existing character.
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
-- RETURNS: None.
--
CREATE PROCEDURE [dbo].[UpdateCharacter]
    @id INT,
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

    IF NOT EXISTS (SELECT * FROM Characters WHERE Id = @id)
        THROW 51000, 'Character does not exist.', 1

    SET @name = LTRIM(RTRIM(ISNULL(@name, '')))
    SET @profession = LTRIM(RTRIM(ISNULL(@profession, '')))
    SET @race = LTRIM(RTRIM(ISNULL(@race, '')))
    
    SET @description = LTRIM(RTRIM(ISNULL(@description, '')))
    IF LEN(@description) = 0 
        SET @description = NULL

    UPDATE Characters
    SET
        Name = @name, 
        Description = @description, 
        Profession = @profession,
        Race = @race,
        Attribute1 = @attribute1,
        Attribute2 = @attribute2,
        Attribute3 = @attribute3,
        Attribute4 = @attribute4,
        Attribute5 = @attribute5
    WHERE Id = @id
END