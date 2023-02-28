CREATE PROCEDURE pmm_PaymentMethodList
AS

SET NOCOUNT ON  

SELECT 
	IdPaymentMethod,
	PaymentMethod.Change,
	Restaurant.[Name] AS RestaurantName,
	PaymentMethod.Active,
	PaymentMethod.[Name]
FROM 
	PaymentMethod WITH(NOLOCK)
	INNER JOIN Restaurant WITH(NOLOCK) ON PaymentMethod.IdRestaurant = Restaurant.IdRestaurant
ORDER BY
	PaymentMethod.[Name]