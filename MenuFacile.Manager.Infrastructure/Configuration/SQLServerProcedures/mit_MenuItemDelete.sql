CREATE PROCEDURE mit_MenuItemDelete(@IdMenuItem int)
AS

SET NOCOUNT ON 

DELETE FROM	MenuItem WHERE MenuItem.IdMenuItem = @IdMenuItem
