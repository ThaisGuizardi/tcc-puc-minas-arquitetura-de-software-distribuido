CREATE PROCEDURE pro_ProductEdit(@IdProduct int, @IdCategory int, @IdRestaurant int, @Name varchar(350), @Description varchar(2000), @Active bit, @EditDateTime datetime, @IdUserEdit varchar(200))
AS

SET NOCOUNT ON 

UPDATE 
	Product

SET Product.IdRestaurant = @IdRestaurant,
	Product.IdCategory = @IdCategory,
	Product.[Name] = @Name,
	Product.[Description] = @Description,
	Product.Active = @Active,
	Product.EditDateTime = @EditDateTime,
	Product.IdUserEdit = @IdUserEdit

WHERE 
	Product.IdProduct = @IdProduct

SELECT SCOPE_IDENTITY() AS IdProduct
