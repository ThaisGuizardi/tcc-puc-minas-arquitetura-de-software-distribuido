CREATE PROCEDURE pit_ProductItemAdd(@IdProduct int, @Description varchar(350), @Image varchar(3000), @NumberPeopleServing int, @Active bit, @CreateDateTime datetime, @EditDateTime datetime, @IdUserCreate varchar(200), @IdUserEdit varchar(200))
AS

SET NOCOUNT ON  

INSERT INTO ProductItem(IdProduct, [Description], [Image], NumberPeopleServing, Active, CreateDateTime, EditDateTime, IdUserCreate, IdUserEdit)
VALUES (@IdProduct, @Description, @Image, @NumberPeopleServing, @Active, @CreateDateTime, @EditDateTime, @IdUserCreate, @IdUserEdit)

SELECT SCOPE_IDENTITY() as IdProductItem
