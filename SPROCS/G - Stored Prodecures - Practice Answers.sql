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

-- 1. Create a stored procedure called "EnrollFullTimeStudent" that receives a student's name, gender, birthdate and address information along with the starting school year (as an int). The stored procedure must add the new student information and enroll them for the core first-term classes (DMIT101, DMIT103, DMIT104, DMIT108, and DMIT170). As a full-time student, they will be charged $2200 for each term, regardless of the number of courses they are taking; charge them for their first term only (not the entire school year). Semesters are entered as the year followed by a letter for the term ('J' for January, 'M' for May, and 'S' for September, with school years start in September). Your stored procedure should ensure appropriate supplied values are not null and that the year is for an upcoming school year.

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_TYPE = N'PROCEDURE' AND ROUTINE_NAME = 'EnrollFullTimeStudent')
    DROP PROCEDURE EnrollFullTimeStudent
GO
CREATE PROCEDURE EnrollFullTimeStudent
    @FirstName varchar(25),
	@LastName varchar(35),
	@Gender char(1),
	@StreetAddress varchar(35),
	@City varchar(30),
	@Province char(2),
	@PostalCode char(6),
	@Birthdate smalldatetime,  
    @SchoolYear int  
AS
    IF @FirstName IS NULL OR @LastName IS NULL OR @Birthdate IS NULL OR @SchoolYear IS NULL
    BEGIN
        RAISERROR('FirstName, LastName, Birthdate, and SchoolYear are required and cannot be null', 16, 1);
    END
    ELSE
    BEGIN
        BEGIN TRANSACTION
        -- A) Add the student
        INSERT INTO Student(FirstName, LastName, Gender, StreetAddress, City, Province, PostalCode, Birthdate, BalanceOwing)
        VALUES (@FirstName, @LastName, @Gender, @StreetAddress, @City, @Province, @PostalCode, @Birthdate, 2200.00)
        IF @@ERROR <> 0 OR @@ROWCOUNT = 0
        BEGIN
            RAISERROR('Failed to add the new student', 16, 1)
            ROLLBACK TRANSACTION
        END
        ELSE
        BEGIN
            DECLARE @StudentID int = @@IDENTITY
            DECLARE @Semester char(5) = CONVERT(char(4), @SchoolYear) + 'S'
            -- B) Insert into core courses
            --    DMIT101, DMIT103, DMIT104, DMIT108, and DMIT170
            INSERT INTO Registration(CourseId, StudentID, Semester)
            VALUES ('DMIT101', @StudentID, @Semester),
                   ('DMIT103', @StudentID, @Semester),
                   ('DMIT104', @StudentID, @Semester),
                   ('DMIT108', @StudentID, @Semester),
                   ('DMIT170', @StudentID, @Semester)
            IF @@ERROR <> 0 OR @@ROWCOUNT = 0
            BEGIN
                RAISERROR('Failed to add the new student to the core courses', 16, 1)
                ROLLBACK TRANSACTION
            END
            ELSE
            BEGIN
                COMMIT TRANSACTION
            END
        END
    END
RETURN
GO
DECLARE @DOB datetime = DATEFROMPARTS(1980,3,20)
EXEC EnrollFullTimeStudent 'Dan', 'Gilleland', 'M', null, null, null, null, @DOB,2019

-- 2. Create a stored procedure called "CoreFirstTermCourses" which will return the course number and name for the following courses: DMIT101, DMIT103, DMIT104, DMIT108, and DMIT170

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_TYPE = N'PROCEDURE' AND ROUTINE_NAME = 'CoreFirstTermCourses')
    DROP PROCEDURE CoreFirstTermCourses
GO
CREATE PROCEDURE CoreFirstTermCourses
    -- Parameters here
AS
    SELECT  CourseId, CourseName
    FROM    Course
    WHERE   Courseid IN ('DMIT101', 'DMIT103', 'DMIT104', 'DMIT108', 'DMIT170')
RETURN
GO

EXEC CoreFirstTermCourses

-- 3. Create a stored procedure called "EnrollInCourse" that receives a student id, course id and semester. This stored procedure must enroll the student in a course by adding them to the Registration table.

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_TYPE = N'PROCEDURE' AND ROUTINE_NAME = 'EnrollInCourse')
    DROP PROCEDURE EnrollInCourse
GO
CREATE PROCEDURE EnrollInCourse
    @CourseId  char(7),
    @StudentId int,
    @Semester  char(5)
AS
    IF @CourseId IS NULL OR @StudentId IS NULL OR @Semester IS NULL
        RAISERROR('CourseId, StudentId, and Semester are all required', 16, 1)
    ELSE
        INSERT INTO Registration(CourseId, StudentID, Semester)
        VALUES (@CourseId, @StudentId, @Semester)
RETURN
GO

-- 4. Create an alter procedure for "EnrollFullTimeStudent" that uses the "EnrollInCourse" stored procedure to do the actual enrollment. Remember to check for @@ERROR after each call to the stored procedure.

ALTER PROCEDURE EnrollFullTimeStudent
    @FirstName varchar(25),
	@LastName varchar(35),
	@Gender char(1),
	@StreetAddress varchar(35),
	@City varchar(30),
	@Province char(2),
	@PostalCode char(6),
	@Birthdate smalldatetime,  
    @SchoolYear int  
AS
    IF @FirstName IS NULL OR @LastName IS NULL OR @Birthdate IS NULL OR @SchoolYear IS NULL
    BEGIN
        RAISERROR('FirstName, LastName, Birthdate, and SchoolYear are required and cannot be null', 16, 1);
    END
    ELSE
    BEGIN
        BEGIN TRANSACTION
        -- A) Add the student
        INSERT INTO Student(FirstName, LastName, Gender, StreetAddress, City, Province, PostalCode, Birthdate, BalanceOwing)
        VALUES (@FirstName, @LastName, @Gender, @StreetAddress, @City, @Province, @PostalCode, @Birthdate, 2200.00)
        IF @@ERROR <> 0 OR @@ROWCOUNT = 0
        BEGIN
            RAISERROR('Failed to add the new student', 16, 1)
            ROLLBACK TRANSACTION
        END
        ELSE
        BEGIN
            DECLARE @StudentID int = @@IDENTITY
            DECLARE @Semester char(5) = CONVERT(char(4), @SchoolYear) + 'S'
            -- B) Insert into core courses
            --    DMIT101, DMIT103, DMIT104, DMIT108, and DMIT170
            EXEC EnrollInCourse 'DMIT101', @StudentID, @Semester
            IF @@ERROR <> 0 OR @@ROWCOUNT = 0
            BEGIN
                RAISERROR('Failed to add the new student to DMIT101', 16, 1)
                ROLLBACK TRANSACTION
            END
            ELSE
            BEGIN
                EXEC EnrollInCourse 'DMIT103', @StudentID, @Semester
                IF @@ERROR <> 0 OR @@ROWCOUNT = 0
                BEGIN
                    RAISERROR('Failed to add the new student to DMIT103', 16, 1)
                    ROLLBACK TRANSACTION
                END
                ELSE
                BEGIN
                    EXEC EnrollInCourse 'DMIT104', @StudentID, @Semester
                    IF @@ERROR <> 0 OR @@ROWCOUNT = 0
                    BEGIN
                        RAISERROR('Failed to add the new student to DMIT104', 16, 1)
                        ROLLBACK TRANSACTION
                    END
                    ELSE
                    BEGIN
                        EXEC EnrollInCourse 'DMIT108', @StudentID, @Semester
                        IF @@ERROR <> 0 OR @@ROWCOUNT = 0
                        BEGIN
                            RAISERROR('Failed to add the new student to DMIT108', 16, 1)
                            ROLLBACK TRANSACTION
                        END
                        ELSE
                        BEGIN
                            EXEC EnrollInCourse 'DMIT170', @StudentID, @Semester
                            IF @@ERROR <> 0 OR @@ROWCOUNT = 0
                            BEGIN
                                RAISERROR('Failed to add the new student to DMIT170', 16, 1)
                                ROLLBACK TRANSACTION
                            END
                            ELSE
                            BEGIN
                                COMMIT TRANSACTION
                            END
                        END
                    END
                END
            END
        END
    END
RETURN
GO
