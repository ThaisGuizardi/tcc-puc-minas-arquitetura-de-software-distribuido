CREATE PROCEDURE ord_GetListCurrentProductsByIdRestaurant(@IdRestaurant INT, @ValidFrom DATETIME, @ValidUntil DATETIME)
AS

SET NOCOUNT ON  

SELECT 
	p.IdRestaurant,
	c.IdCategory,
	c.[Name] AS CategoryName,
	p.IdProduct,
	p.[Name],
	pit.IdProductItem,
	pit.[Description],
	pp.IdProductPrice,
	pp.Price,
	pit.[Image] +'.svg' AS [Image]
FROM 
	MenuFacileServiceManager..Product p WITH(NOLOCK)
	INNER JOIN MenuFacileServiceManager..Category c WITH(NOLOCK) ON p.IdCategory = c.IdCategory
	INNER JOIN MenuFacileServiceManager..Restaurant r WITH(NOLOCK) ON c.IdRestaurant = r.IdRestaurant
	INNER JOIN MenuFacileServiceManager..ProductItem pit WITH(NOLOCK) ON p.IdProduct = pit.IdProduct
	INNER JOIN MenuFacileServiceManager..ProductPrice pp WITH(NOLOCK) ON p.IdProduct = pp.IdProduct
	INNER JOIN MenuFacileServiceManager..MenuItem mi WITH(NOLOCK) ON p.IdProduct = mi.IdProduct
	INNER JOIN MenuFacileServiceManager..Menu m WITH(NOLOCK) ON mi.IdMenu = m.IdMenu
WHERE
	p.Active = 1
	AND p.IdRestaurant = @IdRestaurant
	AND pp.ValidFrom >= @ValidFrom
	AND pp.ValidUntil <= @ValidUntil
	AND m.ValidFrom >= @ValidFrom
	AND m.ValidTo <= @ValidUntil
ORDER BY
	c.IdCategory
