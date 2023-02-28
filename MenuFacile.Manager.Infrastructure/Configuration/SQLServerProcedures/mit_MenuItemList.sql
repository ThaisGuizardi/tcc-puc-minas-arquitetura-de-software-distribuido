CREATE PROCEDURE mit_MenuItemList
AS

SET NOCOUNT ON  

SELECT 
	MenuItem.IdMenuItem,
	Menu.[Name] AS MenuName,
	Product.[Name] AS ProductName,
	MenuItem.Active
FROM 
	MenuItem WITH(NOLOCK)
	INNER JOIN Menu WITH(NOLOCK) ON MenuItem.IdMenu = Menu.IdMenu
	INNER JOIN Product WITH(NOLOCK) ON MenuItem.IdProduct = Product.IdProduct
ORDER BY
	Menu.[Name],
	MenuItem.IdMenuItem