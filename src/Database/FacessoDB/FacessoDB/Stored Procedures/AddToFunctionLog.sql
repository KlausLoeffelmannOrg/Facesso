CREATE PROCEDURE dbo.AddToFunctionLog 
	@IDSubsidiary UNIQUEIDENTIFIER,
	@FunctionText nvarchar(4000),
	@CalledByIDUser UNIQUEIDENTIFIER,
	@DateCalled datetime,
	@OnComputer nvarchar(255) = NULL

AS
	INSERT INTO [FunctionLog] ([IDSubsidiary], [FunctionText], 
				[CalledByIDUser], [DateCalled], [OnComputer])
	VALUES
	(@IDSubsidiary, @FunctionText, @CalledByIDUser, @DateCalled,
	 @OnComputer)

