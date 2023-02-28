CREATE PROCEDURE seg_SegmentList
AS

SET NOCOUNT ON  

SELECT IdSegment, [Name], [Description], Active FROM Segment WITH(NOLOCK)

