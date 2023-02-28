CREATE PROCEDURE seg_GetActiveSegmentsDropdown
AS

SET NOCOUNT ON  

SELECT IdSegment, [Name] FROM Segment WITH(NOLOCK) WHERE Segment.Active = 1

