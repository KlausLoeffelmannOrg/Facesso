CREATE PROCEDURE dbo.LabourValues_DoesNumberExist 

	@IDSubsidiary UNIQUEIDENTIFIER,
	@LabourValueNumber int,
	@ExcludeIDLabourValue UNIQUEIDENTIFIER=null,
	@DoesExist bit OUTPUT

	WITH EXECUTE AS CALLER
	AS
	
	if @ExcludeIDLabourValue IS Null
		BEGIN
			IF EXISTS(SELECT * FROM [LabourValues] 
							WHERE [IDSubsidiary]=@IDSubsidiary 
							AND [LabourValueNumber]=@LabourValueNumber
							AND [IsCurrent]=1)
				SET @DoesExist=1
			ELSE
				SET @DoesExist=0
			RETURN
		END
	ELSE
		BEGIN
			IF EXISTS(SELECT * FROM [LabourValues] 
							WHERE [IDSubsidiary]=@IDSubsidiary 
							AND [LabourValueNumber]=@LabourValueNumber
							AND [IsCurrent]=1
							AND [IDLabourValue]<>@ExcludeIDLabourValue)
				SET @DoesExist=1
			ELSE
				SET @DoesExist=0
			RETURN
		END
	
		
	
