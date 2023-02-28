CREATE PROCEDURE rus_RestaurantUserAdd(
	@IdRestaurant INT
	,@IdUser VARCHAR(100)
	,@CreateDateTime DATETIME
	,@EditDateTime DATETIME
	,@IdUserCreate VARCHAR(200)
	,@IdUserEdit VARCHAR(200)
)
AS

SET NOCOUNT ON  

INSERT INTO RestaurantUser(
	IdRestaurant
	,IdUser
	,CreateDateTime
	,EditDateTime
	,IdUserCreate
	,IdUserEdit
)
VALUES (
	@IdRestaurant
	,@IdUser
	,@CreateDateTime
	,@EditDateTime
	,@IdUserCreate
	,@IdUserEdit
)

SELECT SCOPE_IDENTITY() as IdRestaurantUser
