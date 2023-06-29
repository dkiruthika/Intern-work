select * from users;
CREATE PROC Sp_Login
@username NVARCHAR(20),
@pswd NVARCHAR(20),
@isvalid BIT OUT
AS
BEGIN
SET @isvalid = (SELECT COUNT(1) FROM users WHERE username = @username AND pswd=@pswd)
end