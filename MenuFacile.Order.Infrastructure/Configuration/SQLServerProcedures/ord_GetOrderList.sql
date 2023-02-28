CREATE PROCEDURE ord_GetOrderList(@IdRestaurant INT, @DateFrom DATETIME, @DateTo DATETIME, @OrderStatus VARCHAR(30))
AS

SET NOCOUNT ON  

SELECT
	o.IdOrder,
	o.IdRestaurant,
	os.CurrentStatus,
	os.CurrentStatusView,
	os.NextStatus,
	os.NextStatusView,
	ISNULL(OrderProduct.OrderProductsDetails, 'Nenhum Produto Confirmado') AS OrderProductsDetails
FROM 
	[Order] o WITH (NOLOCK) 
	INNER JOIN OrderStatus os WITH (NOLOCK) ON o.[Status] = os.CurrentStatus
	LEFT OUTER JOIN (
		SELECT 
			STRING_AGG(CONVERT(VARCHAR(5), oi.Qty) + ' ' + p.[Name], '. ') AS OrderProductsDetails,
			o.IdOrder
		FROM 
			[Order] o WITH(NOLOCK)
			INNER JOIN OrderItem oi WITH(NOLOCK) ON o.IdOrder = oi.IdOrder
			INNER JOIN MenuFacileServiceManager..Product p WITH(NOLOCK) ON oi.IdProduct = p.IdProduct
		WHERE
			o.IdRestaurant = @IdRestaurant
		GROUP BY 
			o.IdOrder
	) OrderProduct ON o.IdOrder = OrderProduct.IdOrder
WHERE
	o.Active = 1
	AND o.IdRestaurant = @IdRestaurant
	AND o.[Status] = @OrderStatus OR @OrderStatus IS NULL
	AND  o.CreateDateTime >= @DateFrom 
	AND  o.CreateDateTime <= @DateTo
ORDER BY 
	o.CreateDateTime DESC