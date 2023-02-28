CREATE PROCEDURE mit_MenuItemEdit(@IdMenuItem int, @IdMenu int, @IdProduct int, @Active bit, @EditDateTime datetime, @IdUserEdit varchar(200))
AS

SET NOCOUNT ON 

UPDATE 
	MenuItem

SET MenuItem.IdMenu = @IdMenu,
	MenuItem.IdProduct = @IdProduct,
	MenuItem.Active = @Active,
	MenuItem.EditDateTime = @EditDateTime,
	MenuItem.IdUserEdit = @IdUserEdit

WHERE 
	MenuItem.IdMenuItem = @IdMenuItem

SELECT SCOPE_IDENTITY() AS IdMenuItem
