CREATE PROCEDURE pit_GetProductItemById(@IdProductItem INT)
AS

SET NOCOUNT ON  

SELECT IdProduct, IdProduct, [Description], [Image], NumberPeopleServing, Active, EditDateTime, IdUserEdit FROM ProductItem WITH(NOLOCK) WHERE ProductItem.IdProductItem = @IdProductItem

