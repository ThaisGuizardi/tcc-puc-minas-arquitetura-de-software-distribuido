CREATE PROCEDURE pit_ProductItemDelete(@IdProductItem int)
AS

SET NOCOUNT ON 

DELETE FROM	ProductItem WHERE ProductItem.IdProductItem = @IdProductItem
