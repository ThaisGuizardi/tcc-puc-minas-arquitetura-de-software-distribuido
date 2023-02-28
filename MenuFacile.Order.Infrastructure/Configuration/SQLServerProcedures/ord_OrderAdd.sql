CREATE PROCEDURE ord_OrderAdd(@IdRestaurant int, @Status varchar(30), @LinkOrder varchar(1000), @CustomerAddress varchar(3000), @IdPaymentMethod int, @ChangeFor money, @CustomerName varchar(500),
@CustomerPhone varchar(30), @TotalOrder money, @Active bit, @CreateDateTime datetime, @EditDateTime datetime, @IdUserCreate varchar(200), @IdUserEdit varchar(200))

AS

SET NOCOUNT ON  

INSERT INTO [Order](IdRestaurant, [Status], LinkOrder, CustomerAddress, IdPaymentMethod, ChangeFor, CustomerName, CustomerPhone, TotalOrder, Active, CreateDateTime, EditDateTime, IdUserCreate, IdUserEdit)
VALUES (@IdRestaurant, @Status, @LinkOrder, @CustomerAddress, @IdPaymentMethod, @ChangeFor, @CustomerName, @CustomerPhone, @TotalOrder, @Active, @CreateDateTime, @EditDateTime, @IdUserCreate, @IdUserEdit)

SELECT SCOPE_IDENTITY() as IdOrder