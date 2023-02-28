CREATE PROCEDURE mit_GetMenuItemById(@IdMenuItem INT)
AS

SET NOCOUNT ON  

SELECT 
	IdMenuItem
	,IdMenu
	,IdProduct 
	,Active
	,CreateDateTime
	,EditDateTime
	,IdUserCreate
	,IdUserEdit
FROM 
	MenuItem WITH(NOLOCK) 
WHERE 
	MenuItem.IdMenuItem = @IdMenuItem