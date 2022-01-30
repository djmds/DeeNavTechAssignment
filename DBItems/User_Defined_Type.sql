USE [ConfigDB]
GO

/****** Object:  UserDefinedTableType [dbo].[BulkInsertUpdateEntityConfigurationType]    Script Date: 31-01-2022 00:44:53 ******/
CREATE TYPE [dbo].[BulkInsertUpdateEntityConfigurationType] AS TABLE(
	[EntityName] [nvarchar](max) NULL,
	[FieldName] [nvarchar](max) NULL,
	[IsRequired] [bit] NOT NULL,
	[MaxLength] [int] NOT NULL,
	[FieldSource] [nvarchar](max) NULL
)
GO


