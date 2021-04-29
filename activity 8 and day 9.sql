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

--just for reference
create table employeesalary1
(transnum int primary key,
emp_id int references employee(id),
salaryid int references salary_(sal_id))
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
--this is a scalar function
create function calsal (@basic float, @hra float,@ded float)
returns float
as 
begin
  declare @netsal float
  set @netsal= @basic+@hra-@ded
  return @netsal
end

select basic_,hra,deduction,dbo.calsal(basic_,hra,deduction) 'net total'  from salary_

--this is a table valued function
create function printcompleteSaldetails(@eid int)
returns @employeesaltax table
(
   ename varchar(20),
   totalsalary float,
   tax float )
as
begin
declare
@tax float,
@total float,
@taxpayable float,
@ename varchar(15)
set @total=(select sum(basic_+hra+pa-deduction) from employee es join salary_ s
on es.id = s.sal_id
where es.id = @eid)
if(@total<100000)
set @tax=0
else if(@total>100000 and @total<200000)
set @tax=5
else if (@total>200000 and @total<350000)
set @tax=7
else
set @tax=7.5
set @taxpayable=@total*@tax/100
set @ename= (select name from employee where id= @eid)
insert into @employeesaltax values(@ename,@total,@taxpayable)
return
end
select * from dbo.printcompleteSaldetails(101)

--triggers
create table tbldummy
(f1 int,
f2 varchar(20))

create trigger triggerdummy
on tbldummy
after insert 
as
begin
    select 'hello there!!!'
end
drop trigger triggerdummy
select * from tbldummy
insert into tbldummy values(01,'ramu')
insert into tbldummy values(02,'somu')

create trigger triggerdummy
on tbldummy
after insert 
as
begin
    select concat ('hello there!!!',f2) from inserted --here "inserted" is used to take hold of the record we insert
end

--trigger number two
create table employeenet
(transnum int,
netsal float)
select * from employeesalary1
select * from salary_
select * from employeenet
create trigger trignetsal
on employeesalary1
after insert
as
begin
 declare
 @totalsal float
 set @totalsal = (select avg(basic_) from salary_ )
 insert into employeenet values ((select transnum from inserted),@totalsal)
end
drop trigger trignetsal 
insert into employeesalary1 values (2011,101,101)

--create a trigger to welcome the employee names in the employee table
create trigger triggeremp
on employee
after insert 
as
begin
    declare @gender varchar(10)
	set @gender = (select gender from inserted)
	if (@gender='male')
    select concat ('WELCOME MR.',name) from inserted 
	else
	select concat ('WELCOME Mrs.',name) from inserted
end
drop trigger triggeremp
insert into employee values('ramu',2345,'male','ramu@',20)
insert into employee values('smithi',3456,'female','smithi@',20)
select * from employee

--transaction
--it does all or it does not do it all
select * from employeesalary
begin transaction 
insert into employee values('smith',4567,'male','smith@',20)
insert into employeesalary1 values(2007,101,101)
if ((select max(transnum) from employeesalary1)=111) 
     commit
else
     rollback
--cursors
	 --declare cursor
	declare @eid int ,@ename varchar(20)
	declare cur_employee cursor for
	select id,name from employee
	open cur_employee
	fetch next from cur_employee
	into @eid,@ename
	print 'employee data'
	while @@FETCH_STATUS=0
	begin
	 print 'employee id'+cast (@eid as varchar(10))
	 print 'employee name'+@ename
	 print'______________'
	 fetch next from cur_employee
	into @eid,@ename
	end
	close cur_employee
	deallocate cur_employee
	--for every customer print the customer name and the salary details
	declare @eid int ,@ename varchar(20)
	declare cur_employee cursor for
	select id,name from employee
	open cur_employee
	fetch next from cur_employee
	into @eid,@ename
	print 'employee data'
	while @@FETCH_STATUS=0
	begin
	 print 'employee id'+cast (@eid as varchar(10))
	 print 'employee name'+@ename
	 print'______________'
	 declare @sid int,@total float
	 declare cur_empsal cursor for
	 select  salaryid  from employeesalary1 where emp_id=@eid
	 open cur_empsal
	 fetch next from cur_empsal into @sid
	 print '_____________________'
	 print 'salary details'
	 while @@FETCH_STATUS = 0
	 begin
	     set @total = (select basic_+hra+pa-deduction  from salary_ where sal_id=@sid)
		 print 'net salary:' +cast(@total as varchar(20))
		 fetch next from cur_empsal into @sid
	end
	print'_________________'
	close cur_empsal
	deallocate cur_empsal
	 fetch next from cur_employee
	into @eid,@ename
	end
	close cur_employee
	deallocate cur_employee

	select * from employeesalary1

