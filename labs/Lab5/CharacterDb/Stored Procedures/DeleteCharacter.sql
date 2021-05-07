--
-- Deletes a character.
--
-- PARAMS:
--    id - The ID of the item to remove.
--
-- RETURNS: None.
--
CREATE PROCEDURE [dbo].[DeleteCharacter]
	@id INT
AS BEGIN
	SET NOCOUNT ON;

    DELETE FROM Characters WHERE Id = @id
END
