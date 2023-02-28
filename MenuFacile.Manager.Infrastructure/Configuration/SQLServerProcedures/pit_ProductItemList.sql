CREATE PROCEDURE pit_ProductItemList
AS

SET NOCOUNT ON  

SELECT 
	IdProductItem,
	ProductItem.[Description],
	Product.[Name] AS ProductName,
	ProductItem.Active
FROM 
	ProductItem WITH(NOLOCK)
	INNER JOIN Product WITH(NOLOCK) ON ProductItem.IdProduct = Product.IdProduct
ORDER BY
	Product.[Name],
	ProductItem.[Description]