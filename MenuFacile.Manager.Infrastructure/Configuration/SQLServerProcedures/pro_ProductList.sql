CREATE PROCEDURE pro_ProductList
AS

SET NOCOUNT ON  

SELECT 
	IdProduct,
	Restaurant.[Name] AS RestaurantName,
	Category.[Name] AS CategoryName,
	Product.[Name],
	Product.Active
FROM 
	Product WITH(NOLOCK)
	INNER JOIN Restaurant WITH(NOLOCK) ON Product.IdRestaurant = Restaurant.IdRestaurant
	INNER JOIn Category WITH(NOLOCK) ON Product.IdCategory = Category.IdCategory





