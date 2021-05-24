create proc XoaCV
@ma nvarchar(20)
as
begin
update NHANVIEN set NHANVIEN.MaCV = null where NHANVIEN.MaCV = @ma
delete from CHUCVU where MaCV = @ma
end
