CREATE PROCEDURE dbo.Employees_DoesPersonnelNumberExist 

	@IDSubsidiary UNIQUEIDENTIFIER,
	@PersonnelNumber int,
	@ExcludeIDEmployee UNIQUEIDENTIFIER=null,
	@DoesExist bit OUTPUT

	WITH EXECUTE AS CALLER
	AS
	
	if @ExcludeIDEmployee IS Null
		BEGIN
			IF EXISTS(SELECT * FROM [Employees] 
							WHERE [IDSubsidiary]=@IDSubsidiary 
							AND [PersonnelNumber]=@PersonnelNumber
							AND [IsCurrent]=1)
				SET @DoesExist=1
			ELSE
				SET @DoesExist=0
			RETURN
		END
	ELSE
		BEGIN
			IF EXISTS(SELECT * FROM [Employees] 
							WHERE [IDSubsidiary]=@IDSubsidiary 
							AND [PersonnelNumber]=@PersonnelNumber
							AND [IsCurrent]=1
							AND [IDEmployee]<>@ExcludeIDEmployee)
				SET @DoesExist=1
			ELSE
				SET @DoesExist=0
			RETURN
		END
	
		
	
