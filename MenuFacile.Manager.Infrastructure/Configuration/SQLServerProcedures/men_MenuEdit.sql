CREATE PROCEDURE men_MenuEdit(@IdMenu int, @IdRestaurant int, @Name varchar(350), @ValidFrom datetime, @ValidTo datetime, @Active bit, @EditDateTime datetime, @IdUserEdit varchar(200))
AS

SET NOCOUNT ON 

UPDATE 
	Menu

SET Menu.IdRestaurant = @IdRestaurant,
	Menu.[Name] = @Name,
	Menu.ValidFrom = @ValidFrom,
	Menu.ValidTo = @ValidTo,
	Menu.Active = @Active,
	Menu.EditDateTime = @EditDateTime,
	Menu.IdUserEdit = @IdUserEdit

WHERE 
	Menu.IdMenu = @IdMenu

SELECT SCOPE_IDENTITY() AS IdMenu
