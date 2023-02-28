CREATE PROCEDURE pro_GetProductById(@IdProduct INT)
AS

SET NOCOUNT ON  

SELECT IdProduct, IdCategory, IdRestaurant, [Name], [Description], Active, EditDateTime, IdUserEdit FROM Product WITH(NOLOCK) WHERE Product.IdProduct = @IdProduct

