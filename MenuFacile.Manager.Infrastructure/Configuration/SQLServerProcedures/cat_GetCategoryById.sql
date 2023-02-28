CREATE PROCEDURE cat_GetCategoryById(@IdCategory INT)
AS

SET NOCOUNT ON  

SELECT IdCategory, IdRestaurant, [Name], [Description], Active, EditDateTime, IdUserEdit FROM Category WITH(NOLOCK) WHERE Category.IdCategory = @IdCategory

