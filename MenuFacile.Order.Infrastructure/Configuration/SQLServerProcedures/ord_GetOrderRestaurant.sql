CREATE PROCEDURE ord_GetOrderRestaurant(@IdRestaurant INT)
AS

SET NOCOUNT ON  

SELECT
	r.IdRestaurant,
	r.ImageLogo,
	r.[Name] AS RestaurantName,
	s.[Name] AS SegmentName,
	r.IdSegment,
	r.MinimumDeliveryValue,
	-- txEntrega
	r.[Address] + ', ' + r.AddressNumber +', ' + ISNULL(r.Complement, '') + '. ' + r.Neighborhood  + '. ' + c.[Name] + '/' +  st.UF  + '. CEP: ' + r.ZipCode AS RestaurantAddress,
	(CASE WHEN cast(getdate() as time) >= cast(r.StartHoursOperation as time) AND cast(getdate() as time) < cast(r.EndHoursOperation as time) AND (DATEPART(DW, GETDATE())) = 1 AND r.OpenSunday = 1 THEN 'Aberto'
		WHEN cast(getdate() as time) >= cast(r.StartHoursOperation as time) AND cast(getdate() as time) < cast(r.EndHoursOperation as time) AND (DATEPART(DW, GETDATE())) = 2 AND r.OpenMonday = 1 THEN 'Aberto'
		WHEN cast(getdate() as time) >= cast(r.StartHoursOperation as time) AND cast(getdate() as time) < cast(r.EndHoursOperation as time) AND (DATEPART(DW, GETDATE())) = 3 AND r.OpenTuesday = 1 THEN 'Aberto'
		WHEN cast(getdate() as time) >= cast(r.StartHoursOperation as time) AND cast(getdate() as time) < cast(r.EndHoursOperation as time) AND (DATEPART(DW, GETDATE())) = 4 AND r.OpenWednesday = 1 THEN 'Aberto'
		WHEN cast(getdate() as time) >= cast(r.StartHoursOperation as time) AND cast(getdate() as time) < cast(r.EndHoursOperation as time) AND (DATEPART(DW, GETDATE())) = 5 AND r.OpenThursday = 1 THEN 'Aberto'
		WHEN cast(getdate() as time) >= cast(r.StartHoursOperation as time) AND cast(getdate() as time) < cast(r.EndHoursOperation as time) AND (DATEPART(DW, GETDATE())) = 6 AND r.OpenFriday = 1 THEN 'Aberto'
		WHEN cast(getdate() as time) >= cast(r.StartHoursOperation as time) AND cast(getdate() as time) < cast(r.EndHoursOperation as time) AND (DATEPART(DW, GETDATE())) = 7 AND r.OpenSaturday = 1 THEN 'Aberto'
		ELSE 'Fechado'
	END) AS RestaurantOpen
FROM
	MenuFacileServiceManager..Restaurant r WITH(NOLOCK)
	INNER JOIN MenuFacileServiceManager..Segment s WITH(NOLOCK) ON r.IdSegment = s.IdSegment
	INNER JOIN MenuFacileServiceManager..City c WITH(NOLOCK) ON r.IdCity = c.Id
	INNER JOIN MenuFacileServiceManager..[State] st WITH(NOLOCK) ON  r.IdState = st.Id
WHERE
	r.Active = 1
	AND r.IdRestaurant = @IdRestaurant