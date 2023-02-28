CREATE PROCEDURE res_RestaurantDelete(@IdRestaurant int)
AS

SET NOCOUNT ON 

DELETE FROM	Restaurant WHERE Restaurant.IdRestaurant = @IdRestaurant
