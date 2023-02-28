CREATE PROCEDURE ord_OrderEdit(@IdOrder int, @IdRestaurant int, @Status varchar(30), @LinkOrder varchar(1000), @CustomerAddress varchar(3000), @IdPaymentMethod int, @ChangeFor money, @CustomerName varchar(500),
@CustomerPhone varchar(30), @TotalOrder money, @Active bit, @EditDateTime datetime, @IdUserEdit varchar(200) )

AS

SET NOCOUNT ON 

UPDATE 
	[Order]

SET 
	[Order].IdRestaurant = @IdRestaurant
	,[Order].[Status] = @Status
	,[Order].LinkOrder = @LinkOrder
	,[Order].CustomerAddress = @CustomerAddress
	,[Order].IdPaymentMethod = @IdPaymentMethod
	,[Order].ChangeFor = @ChangeFor
	,[Order].CustomerName = @CustomerName
	,[Order].CustomerPhone = @CustomerPhone
	,[Order].TotalOrder = @TotalOrder
	,[Order].Active = @Active
	,[Order].EditDateTime = @EditDateTime
	,[Order].IdUserEdit = @IdUserEdit

WHERE 
	[Order].IdOrder = @IdOrder

SELECT SCOPE_IDENTITY() AS IdOrder
