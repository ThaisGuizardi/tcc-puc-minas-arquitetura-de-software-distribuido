CREATE PROCEDURE pmm_PaymentMethodEdit(@IdPaymentMethod int, @IdRestaurant int, @Name varchar(3000), @Change bit, @Active bit, @EditDateTime datetime, @IdUserEdit varchar(200))
AS

SET NOCOUNT ON 

UPDATE 
	PaymentMethod

SET PaymentMethod.IdRestaurant = @IdRestaurant,
	PaymentMethod.[Name] = @Name,
	PaymentMethod.Change = @Change,
	PaymentMethod.Active = @Active,
	PaymentMethod.EditDateTime = @EditDateTime,
	PaymentMethod.IdUserEdit = @IdUserEdit

WHERE 
	PaymentMethod.IdPaymentMethod = @IdPaymentMethod

SELECT SCOPE_IDENTITY() AS IdPaymentMethod
