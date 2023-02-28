CREATE PROCEDURE ppc_GetProductPriceById(@IdProductPrice INT)
AS

SET NOCOUNT ON  

SELECT IdProduct, IdProduct, Price, ValidFrom, ValidUntil, Active, EditDateTime, IdUserEdit FROM ProductPrice WITH(NOLOCK) WHERE ProductPrice.IdProductPrice = @IdProductPrice

	