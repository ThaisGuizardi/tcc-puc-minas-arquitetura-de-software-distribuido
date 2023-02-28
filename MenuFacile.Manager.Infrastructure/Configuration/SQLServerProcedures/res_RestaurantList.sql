CREATE PROCEDURE res_RestaurantList
AS

SET NOCOUNT ON  

SELECT
	IdRestaurant
	,Restaurant.[Name]
	,Cnpj
	,Restaurant.Active
	,Segment.[Name] AS SegmentName
	,City.[Name] AS CityName
	,[State].UF as StateUF
FROM 
	Restaurant WITH(NOLOCK)
	INNER JOIN Segment WITH(NOLOCK) ON Restaurant.IdSegment = Segment.IdSegment
	INNER JOIN City WITH(NOLOCK) ON Restaurant.IdCity = City.Id
	INNER JOIN [State] WITH(NOLOCK) ON Restaurant.IdState = [State].Id 
