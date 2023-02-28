CREATE PROCEDURE men_MenuList
AS

SET NOCOUNT ON  

SELECT 
	IdMenu,
	Menu.[Name],
	Menu.ValidFrom,
	Menu.ValidTo,
	Restaurant.[Name] AS RestaurantName,
	Menu.Active
FROM 
	Menu WITH(NOLOCK)
	INNER JOIN Restaurant WITH(NOLOCK) ON Menu.IdRestaurant = Restaurant.IdRestaurant
ORDER BY
	Menu.ValidFrom