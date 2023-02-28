CREATE PROCEDURE seg_SegmentDelete(@IdSegment int)
AS

SET NOCOUNT ON 

DELETE FROM	Segment WHERE Segment.IdSegment = @IdSegment
