CREATE PROCEDURE ppc_ProductPriceAdd(@IdProduct int, @Price money, @ValidFrom datetime, @ValidUntil datetime, @Active bit, @CreateDateTime datetime, @EditDateTime datetime, @IdUserCreate varchar(200), @IdUserEdit varchar(200))
AS

SET NOCOUNT ON  

INSERT INTO ProductPrice(IdProduct, Price, ValidFrom, ValidUntil, Active, CreateDateTime, EditDateTime, IdUserCreate, IdUserEdit)
VALUES (@IdProduct, @Price, @ValidFrom, @ValidUntil, @Active, @CreateDateTime, @EditDateTime, @IdUserCreate, @IdUserEdit)

SELECT SCOPE_IDENTITY() as IdProductPrice
