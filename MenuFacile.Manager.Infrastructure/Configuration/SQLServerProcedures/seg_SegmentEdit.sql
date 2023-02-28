CREATE PROCEDURE seg_SegmentEdit(@IdSegment int, @Name varchar(350), @Description varchar(2000), @Active bit, @EditDateTime datetime, @IdUserEdit varchar(200))
AS

SET NOCOUNT ON 

UPDATE 
	Segment

SET Segment.[Name] = @Name,
	Segment.[Description] = @Description,
	Segment.Active = @Active,
	Segment.EditDateTime = @EditDateTime,
	Segment.IdUserEdit = @IdUserEdit

WHERE 
	Segment.IdSegment = @IdSegment

SELECT SCOPE_IDENTITY() AS IdSegment
