CREATE PROCEDURE res_RestaurantEdit(
	@IdRestaurant INT
	,@Name VARCHAR(250)
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
	,@EditDateTime DATETIME
	,@IdUserEdit VARCHAR(200)
)
AS

SET NOCOUNT ON 

UPDATE 
	Restaurant

SET [Name] = @Name
	,[Description] = @Description
	,Cnpj = @Cnpj
	,MinimumDeliveryValue = @MinimumDeliveryValue
	,DaysOperation = @DaysOperation
	,StartHoursOperation = @StartHoursOperation
	,EndHoursOperation = @EndHoursOperation
	,FreeDelivery = @FreeDelivery
	,IdSegment = @IdSegment
	,[Address] = @Address
	,AddressNumber = @AddressNumber
	,Complement = @Complement
	,Neighborhood = @Neighborhood
	,ZipCode = @ZipCode
	,IdCity = @IdCity
	,IdState = @IdState
	,Active = @Active
	,ImageLogo = @ImageLogo
	,OpenMonday = @OpenMonday
	,OpenTuesday = @OpenTuesday
	,OpenWednesday = @OpenWednesday
	,OpenThursday = @OpenThursday
	,OpenFriday = @OpenFriday
	,OpenSaturday = @OpenSaturday
	,OpenSunday = @OpenSunday
	,EditDateTime = @EditDateTime
	,IdUserEdit = @IdUserEdit

WHERE 
	Restaurant.IdRestaurant = @IdRestaurant

SELECT SCOPE_IDENTITY() AS IdRestaurant
