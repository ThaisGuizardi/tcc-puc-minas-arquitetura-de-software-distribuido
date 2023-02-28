CREATE PROCEDURE oit_OrderItemAdd(@IdOrder int, @IdProduct int, @Qty int, @ProductPrice money, @Active bit, @CreateDateTime datetime, @EditDateTime datetime, @IdUserCreate varchar(200), @IdUserEdit varchar(200))

AS

SET NOCOUNT ON  

INSERT INTO OrderItem(IdOrder, IdProduct, Qty, ProductPrice, Active, CreateDateTime, EditDateTime, IdUserCreate, IdUserEdit)
VALUES (@IdOrder, @IdProduct, @Qty, @ProductPrice, @Active, @CreateDateTime, @EditDateTime, @IdUserCreate, @IdUserEdit)

SELECT SCOPE_IDENTITY() as IdOrderItem