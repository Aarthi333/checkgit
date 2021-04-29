use dbsoft
--creating tables
create table employee
(id int identity(100,1) primary key,
name varchar(20),
phone char(9) not null,
gender varchar(10))
create table salary_
(sal_id int identity (1,100) primary key,
basic_ int,
hra int,
pa int,
deduction int)
create table employeesalary
(transnum int primary key,
emp_id int references employee(id),
salaryid int references salary_(sal_id),
dateandtime date)
--altering tables
alter table employee
add email varchar(20)
select * from employee
alter table employee
add age int

select * from employee
select * from salary_
select * from employeesalary
--inserting records
insert into employee(name,phone,gender,age,email) values('shree',1234,'male',10,'shree@')
insert into employee(name,phone,gender,age,email) values('hari',1234,'male',11,'hari@')
insert into salary_(basic_,hra,pa,deduction) values(10,20,30,40)
insert into salary_(basic_,hra,pa,deduction) values(20,30,40,50)
insert into salary_(basic_,hra,pa,deduction) values(30,40,50,60)
insert into salary_(basic_,hra,pa,deduction) values(20000,30000,50000,0)
insert into salary_(basic_,hra,pa,deduction) values(20000,50000,50000,0)
insert into salary_(basic_,hra,pa,deduction) values(200000,50000,50000,0)
insert into salary_(basic_,hra,pa,deduction) values(300000,50000,50000,0)
insert into employeesalary(transnum,salaryid,emp_id) values(1000,1,100)
insert into employeesalary(transnum,salaryid,emp_id) values(2000,101,101)

create procedure totalout_ (@empid int)
as
begin
  select (basic_+hra+pa-deduction) as total,id from salary_ cross join employee where sal_id in
  (select sal_id from salary_ where salary_.sal_id = employee.id  and @empid = salary_.sal_id)
end
--drop proc totalout_
exec totalout_ 101

create procedure averagecal (@empid int)
as
begin
  select avg(basic_) as averagesalary,id from salary_ cross join employee where sal_id in
  (select sal_id from salary_ where salary_.sal_id = employee.id  and @empid = salary_.sal_id) group by id
end
drop proc averagecal
exec averagecal 101

create procedure taxpay (@empid int)
as
begin 
declare 
@total int
set @total = (select (basic_+hra+pa-deduction) as total from salary_ where @empid = salary_.sal_id)
if(@total = 100000)
select 'tax payable=0%'
else if (@total < 200000)
select 'tax payable=5%'
else if (@total<350000 and @total>200000)
select 'tax payable=6%'
else
select 'tax payable=7%'
end
--drop proc taxpay
exec taxpay 301
exec taxpay 401
exec taxpay 501
exec taxpay 601


--day 9 
--functions
create function calsal (@basic float, @hra float,@ded float)
returns float
as 
begin
  declare @netsal float
  set @netsal= @basic+@hra-@ded
  return @netsal
end

select basic_,hra,deduction,dbo.calsal(basic_,hra,deduction) 'net total'  from salary_