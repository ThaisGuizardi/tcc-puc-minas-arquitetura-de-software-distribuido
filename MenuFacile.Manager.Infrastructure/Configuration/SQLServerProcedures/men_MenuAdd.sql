CREATE PROCEDURE men_MenuAdd(@IdRestaurant int, @Name varchar(350), @ValidFrom datetime, @ValidTo datetime, @Active bit, @CreateDateTime datetime, @EditDateTime datetime, @IdUserCreate varchar(200), @IdUserEdit varchar(200))
AS

SET NOCOUNT ON  

INSERT INTO Menu(IdRestaurant, [Name], ValidFrom, ValidTo, Active, CreateDateTime, EditDateTime, IdUserCreate, IdUserEdit)
VALUES (@IdRestaurant, @Name, @ValidFrom, @ValidTo, @Active, @CreateDateTime, @EditDateTime, @IdUserCreate, @IdUserEdit)

SELECT SCOPE_IDENTITY() as IdMenu