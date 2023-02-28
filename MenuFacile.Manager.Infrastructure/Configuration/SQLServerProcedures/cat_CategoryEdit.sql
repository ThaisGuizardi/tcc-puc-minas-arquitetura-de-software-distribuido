CREATE PROCEDURE cat_CategoryEdit(@IdCategory int, @IdRestaurant int, @Name varchar(350), @Description varchar(2000), @Active bit, @EditDateTime datetime, @IdUserEdit varchar(200))
AS

SET NOCOUNT ON 

UPDATE 
	Category

SET Category.IdRestaurant = @IdRestaurant,
	Category.[Name] = @Name,
	Category.[Description] = @Description,
	Category.Active = @Active,
	Category.EditDateTime = @EditDateTime,
	Category.IdUserEdit = @IdUserEdit

WHERE 
	Category.IdCategory = @IdCategory

SELECT SCOPE_IDENTITY() AS IdCategory
