CREATE PROCEDURE cat_CategoryList
AS

SET NOCOUNT ON  

SELECT 
	IdCategory, 
	Category.[Name], 
	Category.Active,
	Restaurant.[Name] AS RestaurantName
FROM 
	Category WITH(NOLOCK)
	INNER JOIN Restaurant WITH(NOLOCK) ON Category.IdRestaurant = Restaurant.IdRestaurant


