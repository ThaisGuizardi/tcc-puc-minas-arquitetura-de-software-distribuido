CREATE PROCEDURE ppc_ProductPriceEdit(@IdProductPrice int, @IdProduct int, @Price money, @ValidFrom datetime, @ValidUntil datetime, @Active bit, @EditDateTime datetime, @IdUserEdit varchar(200))
AS

SET NOCOUNT ON 

UPDATE 
	ProductPrice

SET ProductPrice.IdProduct = @IdProduct,
	ProductPrice.Price = @Price,
	ProductPrice.ValidFrom = @ValidFrom,
	ProductPrice.ValidUntil = @ValidUntil,
	ProductPrice.Active = @Active,
	ProductPrice.EditDateTime = @EditDateTime,
	ProductPrice.IdUserEdit = @IdUserEdit

WHERE 
	ProductPrice.IdProductPrice = @IdProductPrice

SELECT SCOPE_IDENTITY() AS IdProductItem
