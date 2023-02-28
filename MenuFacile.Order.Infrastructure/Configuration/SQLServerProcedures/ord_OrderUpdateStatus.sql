CREATE PROCEDURE ord_OrderUpdateStatus(@IdOrder int, @OrderStatus varchar(30))

AS

SET NOCOUNT ON 

UPDATE 
	[Order]

SET 
	[Order].[Status] = @OrderStatus

WHERE 
	[Order].IdOrder = @IdOrder

SELECT SCOPE_IDENTITY() AS IdOrder
