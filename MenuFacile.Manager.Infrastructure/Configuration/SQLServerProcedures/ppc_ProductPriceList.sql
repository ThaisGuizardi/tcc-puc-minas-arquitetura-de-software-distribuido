CREATE PROCEDURE ppc_ProductPriceList
AS

SET NOCOUNT ON  

SELECT 
	IdProductPrice,
	ProductPrice.Price,
	Product.[Name] AS ProductName,
	ProductPrice.ValidFrom,
	ProductPrice.ValidUntil,
	ProductPrice.Active
FROM 
	ProductPrice WITH(NOLOCK)
	INNER JOIN Product WITH(NOLOCK) ON ProductPrice.IdProduct = Product.IdProduct
ORDER BY
	Product.[Name]