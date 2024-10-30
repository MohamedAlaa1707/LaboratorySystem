
--1
CREATE FUNCTION dbo.fn_GetAllMainGroupNames()
RETURNS TABLE
AS
RETURN 
(
    SELECT GroupName  
    FROM Main_Test_Group
);
-----------------------------------------------------------
--2
CREATE FUNCTION dbo.fn_GetAllSubTestNames(@GroupName VARCHAR(50))
RETURNS TABLE
AS
RETURN 
(
    SELECT s.SubTestName  
    FROM Main_Test_Group M
    INNER JOIN Sub_Test S ON s.GroupID = M.GroupID
    WHERE M.GroupName = @GroupName
);

--------------------------------------------------------
 exec  get_AllNameSubTests @GroupName='Kidney Function'
 --3
 
CREATE FUNCTION dbo.fn_GetNormalValue(
    @TestName VARCHAR(50),
    @Age_gender_cat VARCHAR(50)
)
RETURNS TABLE
AS
RETURN 
(
    SELECT [MinValue], [MaxValue]
    FROM [dbo].[Test_Normal_Value] N
    INNER JOIN [dbo].[Sub_Test] S ON S.SubTestID = N.SubTestID
    WHERE S.SubTestName = @TestName AND N.[Age_gender_cat] = @Age_gender_cat
);
 
 -- 4
 CREATE FUNCTION dbo.fn_GetNormalValueForTest(
    @TestName VARCHAR(50),
    @Age INT,
    @Gender VARCHAR(50)
)
RETURNS @Result TABLE 
(
    MinValue VARCHAR(50),
    MaxValue VARCHAR(50)
)
AS
BEGIN
    IF @Gender = 'male'
    BEGIN
        IF @Age >= 16
        BEGIN
            INSERT INTO @Result
            SELECT * FROM dbo.fn_GetNormalValue(@TestName, 'AdultMale');
        END
        ELSE
        BEGIN
            INSERT INTO @Result
            SELECT * FROM dbo.fn_GetNormalValue(@TestName, 'ChildMale');
        END
    END
    ELSE
    BEGIN
        IF @Age >= 16
			BEGIN
				INSERT INTO @Result
				 SELECT * FROM dbo.fn_GetNormalValue(@TestName, 'Adultfemale');
			END
        ELSE
        BEGIN
            INSERT INTO @Result
            SELECT * FROM dbo.fn_GetNormalValue(@TestName, 'Childfemale');
        END
    END

    RETURN;
END;



CREATE FUNCTION dbo.fn_ReturnPrice(@TestName VARCHAR(50))
RETURNS DECIMAL(18,2) 
AS
BEGIN    
    DECLARE @Price DECIMAL(18,2); 

    SELECT @Price = Price 
    FROM Sub_Test 
    WHERE SubTestName = @TestName;

    RETURN @Price;
END;



