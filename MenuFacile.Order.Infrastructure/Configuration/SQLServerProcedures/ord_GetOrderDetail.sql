CREATE PROCEDURE ord_GetOrderDetail(@IdOrder int)
AS

SET NOCOUNT ON  

SELECT 
	o.IdOrder,
	CONVERT(VARCHAR(5), oi.Qty) + 'x ' + p.[Name] + ' R$' + CONVERT(VARCHAR(30), oi.ProductPrice) AS ProductDetail,
	oi.ProductPrice,
	o.TotalOrder,
	0 AS DeliveryTax,
	pm.[Name] AS ProductName,
	o.ChangeFor,
	o.CustomerAddress,
	o.CustomerName,
	o.CustomerPhone
FROM
	[Order] o WITH(NOLOCK)
	INNER JOIN OrderItem oi WITH(NOLOCK) ON o.IdOrder = oi.IdOrder
	INNER JOIN MenuFacileServiceManager..Product p WITH(NOLOCK) ON oi.IdProduct = p.IdProduct
	INNER JOIN MenuFacileServiceManager..Restaurant r WITH(NOLOCK) ON o.IdRestaurant = r.IdRestaurant
	INNER JOIN MenuFacileServiceManager..PaymentMethod pm WITH(NOLOCK) ON o.IdPaymentMethod = pm.IdPaymentMethod
WHERE
	o.IdOrder = @IdOrder

