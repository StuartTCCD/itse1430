CREATE TABLE [dbo].[Characters]
(
	[Id] INT NOT NULL  IDENTITY, 
    [Name] NVARCHAR(255) NOT NULL, 
    [Description] NVARCHAR(MAX) NULL, 
    [Profession] NVARCHAR(50) NOT NULL,
    [Race] NVARCHAR(50) NOT NULL,
    [Attribute1] INT NOT NULL,
    [Attribute2] INT NOT NULL,
    [Attribute3] INT NOT NULL,
    [Attribute4] INT NOT NULL,
    [Attribute5] INT NOT NULL,
    CONSTRAINT [AK_Characters_Name] UNIQUE ([Name]),
    CONSTRAINT [CK_Characters_Name] CHECK (LEN(Name) > 0), 
    CONSTRAINT [CK_Characters_Profession] CHECK (LEN(Profession) > 0),
    CONSTRAINT [CK_Characters_Race] CHECK (LEN(Race) > 0),
    CONSTRAINT [CK_Characters_Attribute1] CHECK (Attribute1 BETWEEN 1 and 100),
    CONSTRAINT [CK_Characters_Attribute2] CHECK (Attribute2 BETWEEN 1 and 100),
    CONSTRAINT [CK_Characters_Attribute3] CHECK (Attribute3 BETWEEN 1 and 100),
    CONSTRAINT [CK_Characters_Attribute4] CHECK (Attribute4 BETWEEN 1 and 100),
    CONSTRAINT [CK_Characters_Attribute5] CHECK (Attribute5 BETWEEN 1 and 100), 
    CONSTRAINT [PK_Characters] PRIMARY KEY ([Id])
)
