CREATE PROCEDURE cit_GetCitiesByIdState(@IdState INT)
AS

SET NOCOUNT ON  

SELECT Id AS IdCity, [Name] FROM City WITH(NOLOCK) WHERE City.[State] = @IdState

