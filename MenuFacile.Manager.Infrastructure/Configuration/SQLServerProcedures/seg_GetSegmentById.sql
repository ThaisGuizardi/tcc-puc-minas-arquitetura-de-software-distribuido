CREATE PROCEDURE seg_GetSegmentById(@IdSegment INT)
AS

SET NOCOUNT ON  

SELECT IdSegment, [Name], [Description], Active, EditDateTime, IdUserEdit FROM Segment WITH(NOLOCK) WHERE Segment.IdSegment = @IdSegment

