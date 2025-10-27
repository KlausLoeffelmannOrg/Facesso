CREATE PROCEDURE dbo.Subsidiaries_DoesNameExist

	@SubsidiaryName nvarchar(100),
	@ExcludeIDSubsidiary UNIQUEIDENTIFIER=null,
	@DoesExist bit OUTPUT

	WITH EXECUTE AS CALLER
	AS
	
	if @ExcludeIDSubsidiary IS Null
		BEGIN
			IF EXISTS(SELECT * FROM [Subsidiaries] 
							WHERE [SubsidiaryName]=@SubsidiaryName)
				SET @DoesExist=1
			ELSE
				SET @DoesExist=0
			RETURN
		END
	ELSE
		BEGIN
			IF EXISTS(SELECT * FROM [Subsidiaries] 
							WHERE [SubsidiaryName]=@SubsidiaryName
							AND [IDSubsidiary]<>@ExcludeIDSubsidiary)
				SET @DoesExist=1
			ELSE
				SET @DoesExist=0
			RETURN
		END
	
		
	
