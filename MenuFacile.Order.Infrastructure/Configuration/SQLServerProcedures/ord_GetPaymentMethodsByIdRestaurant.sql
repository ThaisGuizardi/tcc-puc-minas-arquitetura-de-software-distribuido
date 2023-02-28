CREATE PROCEDURE ord_GetPaymentMethodsByIdRestaurant(@IdRestaurant INT)
AS

SET NOCOUNT ON  

SELECT 
	pm.IdPaymentMethod, 
	pm.IdRestaurant, 
	pm.[Name] 
FROM 
	MenuFacileServiceManager..PaymentMethod pm WITH(NOLOCK) 
WHERE 
	pm.IdRestaurant = @IdRestaurant