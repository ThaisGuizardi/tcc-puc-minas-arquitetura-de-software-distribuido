CREATE PROCEDURE res_GetRestaurantById(@IdRestaurant INT)
AS

SET NOCOUNT ON  

SELECT 
	IdRestaurant
	,[Name]
	,[Description]
	,Cnpj
	,MinimumDeliveryValue
	,DaysOperation
	,StartHoursOperation
	,EndHoursOperation
	,FreeDelivery
	,IdSegment
	,[Address]
	,AddressNumber
	,Complement
	,Neighborhood
	,ZipCode
	,IdCity
	,IdState
	,Active
	,ImageLogo
	,OpenMonday
	,OpenTuesday
	,OpenWednesday
	,OpenThursday
	,OpenFriday
	,OpenSaturday
	,OpenSunday
	,CreateDateTime
	,EditDateTime
	,IdUserCreate
	,IdUserEdit
FROM 
	Restaurant WITH(NOLOCK) 
WHERE 
	Restaurant.IdRestaurant = @IdRestaurant

