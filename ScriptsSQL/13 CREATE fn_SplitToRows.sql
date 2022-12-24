--DROP FUNCTION dbo.fn_SplitToRows
CREATE FUNCTION dbo.fn_SplitToRows (@column varchar(max), @separator varchar(1))
RETURNS @rtnTable TABLE
  (
  ID int identity(1,1),
  Columna varchar(max)
  )
 AS
BEGIN
    DECLARE @position int = 0;
    DECLARE @endAt int = 0;
    DECLARE @tempString varchar(100);
    
    set @column = ltrim(rtrim(@column));

    WHILE @position<=len(@column)
    BEGIN       
        set @endAt = CHARINDEX(@separator,@column,@position);
            if(@endAt=0)
            begin
            Insert into @rtnTable(Columna) Select substring(@column,@position,len(@column)-@position);
            break;
            end;
        set @tempString = substring(ltrim(rtrim(@column)),@position,@endAt-@position);

        Insert into @rtnTable(ColumnA) select @tempString;
        set @position=@endAt+1;
    END;
    return;
END;

--select * from dbo.fn_SplitToRows('T14; p226.0001; eee; 3554;', ';');