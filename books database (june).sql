create database BooksDb
go

use BooksDb

create table tbl_author
(
AuthorID int identity(1,1),
AuthorName varchar(20),
constraint PK_auth primary key (AuthorID)
)
create table tbl_Books
( 
BookId int identity (1000,1),
Title varchar(50),
AuthorID int,
Price money,
constraint PK_book primary key(BookId),
constraint FK_auth foreign key(AuthorID) 
references tbl_author(AuthorID)
)
select AuthorID,AuthorName from tbl_author
select BookId,Title,AuthorID,Price from tbl_Books

create proc sp_InsBook
@Title varchar(20),
@AuthorID int,
@Price money 
as
begin
insert into tbl_Books (Title,AuthorID,Price) values(@Title,@AuthorID,@Price)
end

create proc sp_UpdBook
@Title varchar(20),
@Price money
as
begin
update tbl_Books set Price=@Price where Title=@Title
end

exec sp_UpdBook 'mindmaster',650

create proc sp_DelBook
@BookId int
as
begin
delete from tbl_Books where BookId=@BookId 
end

exec sp_DelBook 1007

create proc sp_InsAuthor
@AuthorName varchar(20)
as
begin
insert into tbl_author(AuthorName) values(@AuthorName)
end

exec sp_InsAuthor 'Kambar'

create proc sp_UpdAuthor
@AuthorId int,
@authorname varchar(20)
as
begin
update tbl_author set AuthorName=@authorname where AuthorID=@AuthorId
end

exec sp_UpdAuthor 8,'Denny'
--displaying author name in books table
select BookId,Title,AuthorName,Price  from tbl_Books b join tbl_author a
on b.AuthorID = a.AuthorID 