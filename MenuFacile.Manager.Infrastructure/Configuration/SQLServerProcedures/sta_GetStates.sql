CREATE PROCEDURE sta_GetStates
AS

SET NOCOUNT ON  

SELECT Id AS IdState, [Name] FROM [State] WITH(NOLOCK)

