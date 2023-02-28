CREATE PROCEDURE rus_GetRestaurantByUserId(@UserId varchar(300))
AS

SET NOCOUNT ON  

SELECT 
	IdRestaurant
	, IdUser
FROM 
	RestaurantUser WITH(NOLOCK) 
WHERE 
	RestaurantUser.IdUser = @UserId

