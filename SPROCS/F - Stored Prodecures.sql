--Stored Procedures (Sprocs)

USE [A01-School]
GO

/*
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_TYPE = N'PROCEDURE' AND ROUTINE_NAME = 'SprocName')
    DROP PROCEDURE SprocName
GO
CREATE PROCEDURE SprocName
    -- Parameters here
AS
    -- Body of procedure here
RETURN
GO
*/

-- 1. Create a stored procedure called "EnrollFullTimeStudent" that receives a student's name, gender, birthdate and address information along with the starting school year (as an int). The stored procedure must add the new student information and enroll them for the core first-term classes (DMIT101, DMIT103, DMIT104, DMIT108, and DMIT170). As a full-time student, they will be charged $2200 for each term, regardless of the number of courses they are taking; charge them for their first term only (not the entire school year). Semesters are entered as the year followed by a letter for the term ('J' for January, 'M' for May, and 'S' for September, with school years start in September). Your stored procedure should ensure all supplied values are not null and that the year is for an upcoming school year.

-- 2. 

-- 3. 
