USE [ConfigDB]
GO

/****** Object:  StoredProcedure [dbo].[spBulkInsertUpdateEntityConfiguration]    Script Date: 31-01-2022 00:43:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spBulkInsertUpdateEntityConfiguration]  
(  
      @tblBulkInsertUpdateEntityType [dbo].[BulkInsertUpdateEntityConfigurationType] READONLY  
)  
AS  
BEGIN  
    MERGE [dbo].[EntityConfigurations]  AS dbEntityConfigurations  
    USING @tblBulkInsertUpdateEntityType AS tblTypeBulkInsertUpdate  
    ON (dbEntityConfigurations.EntityName = tblTypeBulkInsertUpdate.EntityName 
	AND dbEntityConfigurations.FieldName = tblTypeBulkInsertUpdate.FieldName
	AND dbEntityConfigurations.FieldSource =  tblTypeBulkInsertUpdate.FieldSource)  
  
    WHEN  MATCHED THEN  
        UPDATE SET  dbEntityConfigurations.IsRequired = tblTypeBulkInsertUpdate.IsRequired,   
                    dbEntityConfigurations.[MaxLength] = tblTypeBulkInsertUpdate.[MaxLength],  
                    dbEntityConfigurations.ModifiedTime = GETDATE() 
  
    WHEN NOT MATCHED THEN  
        INSERT ([EntityName],[FieldName],[IsRequired],[MaxLength],[FieldSource],[CreatedTime],[ModifiedTime])  
        VALUES (tblTypeBulkInsertUpdate.[EntityName],tblTypeBulkInsertUpdate.[FieldName],
		tblTypeBulkInsertUpdate.[IsRequired],tblTypeBulkInsertUpdate.[MaxLength],tblTypeBulkInsertUpdate.[FieldSource],
		GETDATE(),GETDATE());  
END 
GO


