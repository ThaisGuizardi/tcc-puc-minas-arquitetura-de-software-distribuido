CREATE PROCEDURE ppc_ProductPriceDelete(@IdProductPrice int)
AS

SET NOCOUNT ON 

DELETE FROM	ProductPrice WHERE ProductPrice.IdProductPrice = @IdProductPrice
