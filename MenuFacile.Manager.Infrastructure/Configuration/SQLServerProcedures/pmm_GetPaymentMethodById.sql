CREATE PROCEDURE pmm_GetPaymentMethodById(@IdPaymentMethod INT)
AS

SET NOCOUNT ON  

SELECT IdPaymentMethod, IdRestaurant, [Name], Change, Active, EditDateTime, IdUserEdit FROM PaymentMethod WITH(NOLOCK) WHERE PaymentMethod.IdPaymentMethod = @IdPaymentMethod
