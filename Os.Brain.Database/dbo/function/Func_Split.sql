-- ================================================
-- <copyright file="[dbo].[Fn_Split].sql" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
-- Author:      Craze
-- Create date: 2016/1/18 10:53:47
-- Description: 
-- Modify [1]:  Name,Time,Description
-- Modify [2]:  
-- Eg [1]:		SELECT * FROM dbo.Func_Split('a,b,c,d',DEFAULT)
-- Eg [2]:		SELECT * FROM dbo.Func_Split('a,b,c,d',',')
-- ================================================

CREATE FUNCTION [dbo].[Func_Split]
(
	@source VARCHAR(8000),
	@separator VARCHAR(512)=','
)
RETURNS @returntable TABLE
(
	item VARCHAR(8000)
)
AS
BEGIN
	SET @source=RTRIM(LTRIM(@source))

	DECLARE @begin INT,@end INT,@item VARCHAR(8000)
	SET @begin = 1
	SET @end=CHARINDEX(@separator,@source,@begin)

	WHILE(@end<>0)
	BEGIN
		SET @item = SUBSTRING(@source,@begin,@end-@begin)

		INSERT INTO @returntable(item) VALUES(@item)

		SET @begin = @end+1
		SET @end=CHARINDEX(@separator,@source,@begin)
	END

	SET @item = SUBSTRING(@source,@begin,LEN(@source)+1-@begin)
	IF (LEN(@item)>0)
	INSERT INTO @returntable(item) VALUES(SUBSTRING(@source,@begin,LEN(@source)+1-@begin))
	RETURN
END
