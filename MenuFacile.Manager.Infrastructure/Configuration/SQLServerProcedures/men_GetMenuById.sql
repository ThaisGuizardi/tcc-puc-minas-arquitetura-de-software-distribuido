CREATE PROCEDURE men_GetMenuById(@IdMenu INT)
AS

SET NOCOUNT ON  

SELECT 
	IdMenu
	,IdRestaurant
	,[Name] 
	,ValidFrom
	,ValidTo
	,Active
	,CreateDateTime
	,EditDateTime
	,IdUserCreate
	,IdUserEdit
FROM 
	Menu WITH(NOLOCK) 
WHERE 
	Menu.IdMenu = @IdMenu