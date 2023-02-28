CREATE PROCEDURE men_MenuDelete(@IdMenu int)
AS

SET NOCOUNT ON 

DELETE FROM	Menu WHERE Menu.IdMenu = @IdMenu
