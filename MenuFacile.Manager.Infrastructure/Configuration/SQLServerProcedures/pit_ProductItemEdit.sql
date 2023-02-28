CREATE PROCEDURE pit_ProductItemEdit(@IdProductItem int, @IdProduct int, @Description varchar(2000), @Image varchar(3000), @NumberPeopleServing int, @Active bit, @EditDateTime datetime, @IdUserEdit varchar(200))
AS

SET NOCOUNT ON 

UPDATE 
	ProductItem

SET ProductItem.IdProduct = @IdProduct,
	ProductItem.[Description] = @Description,
	ProductItem.[Image] = @Image,
	ProductItem.NumberPeopleServing = @NumberPeopleServing,
	ProductItem.Active = @Active,
	ProductItem.EditDateTime = @EditDateTime,
	ProductItem.IdUserEdit = @IdUserEdit

WHERE 
	ProductItem.IdProductItem = @IdProductItem

SELECT SCOPE_IDENTITY() AS IdProductItem
