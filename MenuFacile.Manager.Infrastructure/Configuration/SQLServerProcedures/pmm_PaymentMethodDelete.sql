CREATE PROCEDURE pmm_PaymentMethodDelete(@IdPaymentMethod int)
AS

SET NOCOUNT ON 

DELETE FROM	PaymentMethod WHERE PaymentMethod.IdPaymentMethod = @IdPaymentMethod
