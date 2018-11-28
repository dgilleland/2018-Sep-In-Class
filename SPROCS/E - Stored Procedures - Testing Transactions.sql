USE [A01-School]
GO

-- 1. Testing the TransferCourse stored procedure
-- Exploring of the database to pick a student, & courses from/to
SELECT * FROM Registration
SELECT * FROM Course

-- Good data
EXEC TransferCourse 200578400, '2004M', 'DMIT259', 'DMIT168'
-- Test my error checking
EXEC TransferCourse null     , '2004M', 'DMIT259', 'DMIT168'
EXEC TransferCourse 200578400, null   , 'DMIT259', 'DMIT168'
EXEC TransferCourse 200578400, '2004M', null     , 'DMIT168'
EXEC TransferCourse 200578400, '2004M', 'DMIT259', null
-- Test with student who has already been withdrawn
EXEC TransferCourse 200578400, '2004M', 'DMIT259', 'DMIT168'
-- Test with student who can't be added to a course
EXEC TransferCourse 200578400, '2004M', 'DMIT168', 'DMIT999'
SELECT * FROM Registration WHERE StudentID = 200578400

-- -------------------------------------------------------

-- 2. Testing the AdjustMarks stored procedure
SELECT * FROM Registration WHERE CourseID = 'DMIT172'

EXEC AdjustMarks 'DMIT172'

SELECT * FROM Registration WHERE CourseID = 'DMIT172'














