CREATE PROCEDURE pro_ProductDelete(@IdProduct int)
AS

SET NOCOUNT ON 

DELETE FROM	Product WHERE Product.IdProduct = @IdProduct
