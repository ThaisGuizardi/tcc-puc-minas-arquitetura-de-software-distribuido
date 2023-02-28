CREATE PROCEDURE res_RestaurantAdd(
	@Name VARCHAR(250)
	,@Description VARCHAR(2000)
	,@Cnpj VARCHAR(20)
	,@MinimumDeliveryValue DECIMAL(18,3)
	,@DaysOperation INT
	,@StartHoursOperation TIME(7)
	,@EndHoursOperation TIME(7)
	,@FreeDelivery BIT
	,@IdSegment INT
	,@Address VARCHAR(2000)
	,@AddressNumber VARCHAR(20)
	,@Complement VARCHAR(1000)
	,@Neighborhood VARCHAR(1000)
	,@ZipCode VARCHAR(50)
	,@IdCity INT
	,@IdState INT
	,@Active BIT
	,@ImageLogo VARCHAR(3000)
	,@OpenMonday BIT
	,@OpenTuesday BIT
	,@OpenWednesday BIT
	,@OpenThursday BIT
	,@OpenFriday BIT
	,@OpenSaturday BIT
	,@OpenSunday BIT
	,@CreateDateTime DATETIME
	,@EditDateTime DATETIME
	,@IdUserCreate VARCHAR(200)
	,@IdUserEdit VARCHAR(200)
)
AS

SET NOCOUNT ON  

INSERT INTO Restaurant(
	[Name]
	,[Description]
	,Cnpj
	,MinimumDeliveryValue
	,DaysOperation
	,StartHoursOperation
	,EndHoursOperation
	,FreeDelivery
	,IdSegment
	,[Address]
	,AddressNumber
	,Complement
	,Neighborhood
	,ZipCode
	,IdCity
	,IdState
	,Active
	,ImageLogo
	,OpenMonday
	,OpenTuesday
	,OpenWednesday
	,OpenThursday
	,OpenFriday
	,OpenSaturday
	,OpenSunday
	,CreateDateTime
	,EditDateTime
	,IdUserCreate
	,IdUserEdit
)
VALUES (
	@Name
	,@Description
	,@Cnpj
	,@MinimumDeliveryValue
	,@DaysOperation
	,@StartHoursOperation
	,@EndHoursOperation
	,@FreeDelivery
	,@IdSegment
	,@Address
	,@AddressNumber
	,@Complement
	,@Neighborhood
	,@ZipCode
	,@IdCity
	,@IdState
	,@Active
	,@ImageLogo
	,@OpenMonday
	,@OpenTuesday
	,@OpenWednesday
	,@OpenThursday
	,@OpenFriday
	,@OpenSaturday
	,@OpenSunday
	,@CreateDateTime
	,@EditDateTime
	,@IdUserCreate
	,@IdUserEdit
)

SELECT SCOPE_IDENTITY() as IdRestaurant
