CREATE PROCEDURE mit_MenuItemAdd(@IdMenu int, @IdProduct int, @Active bit, @CreateDateTime datetime, @EditDateTime datetime, @IdUserCreate varchar(200), @IdUserEdit varchar(200))
AS

SET NOCOUNT ON  

INSERT INTO MenuItem(IdMenu, IdProduct, Active, CreateDateTime, EditDateTime, IdUserCreate, IdUserEdit)
VALUES (@IdMenu, @IdProduct, @Active, @CreateDateTime, @EditDateTime, @IdUserCreate, @IdUserEdit)

SELECT SCOPE_IDENTITY() as IdMenuItem