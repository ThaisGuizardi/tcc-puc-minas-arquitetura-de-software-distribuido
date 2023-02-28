CREATE PROCEDURE cat_CategoryDelete(@IdCategory int)
AS

SET NOCOUNT ON 

DELETE FROM	Category WHERE Category.IdCategory = @IdCategory
