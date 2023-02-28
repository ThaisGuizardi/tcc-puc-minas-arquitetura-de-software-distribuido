CREATE PROCEDURE pro_ProductAdd(@IdCategory int, @IdRestaurant int, @Name varchar(350), @Description varchar(2000), @Active bit, @CreateDateTime datetime, @EditDateTime datetime, @IdUserCreate varchar(200), @IdUserEdit varchar(200))
AS

SET NOCOUNT ON  

INSERT INTO Product(IdCategory, IdRestaurant, [Name], [Description], Active, CreateDateTime, EditDateTime, IdUserCreate, IdUserEdit)
VALUES (@IdCategory, @IdRestaurant, @Name, @Description, @Active, @CreateDateTime, @EditDateTime, @IdUserCreate, @IdUserEdit)

SELECT SCOPE_IDENTITY() as IdProduct
