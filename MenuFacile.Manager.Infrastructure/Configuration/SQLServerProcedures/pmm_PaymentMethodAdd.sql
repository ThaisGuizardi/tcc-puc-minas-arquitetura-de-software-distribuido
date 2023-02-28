CREATE PROCEDURE pmm_PaymentMethodAdd(@IdRestaurant int, @Name varchar(3000), @Change bit, @Active bit, @CreateDateTime datetime, @EditDateTime datetime, @IdUserCreate varchar(200), @IdUserEdit varchar(200))
AS
  
SET NOCOUNT ON  

INSERT INTO PaymentMethod(IdRestaurant, [Name], Change, Active, CreateDateTime, EditDateTime, IdUserCreate, IdUserEdit)
VALUES (@IdRestaurant, @Name, @Change, @Active, @CreateDateTime, @EditDateTime, @IdUserCreate, @IdUserEdit)

SELECT SCOPE_IDENTITY() as IdPaymentMethod
  