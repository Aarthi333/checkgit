use pubs

--all columns 
select * from authors

--projection --restriction on columns display
select au_fname,au_lname from authors

--giving alias name for column display
select au_fname firstname,au_lname lastname from authors

--selection filter the rows
select * from authors where state='CA'
select * from authors where state !='CA'
--select * from authors where contract='1'
select * from employee where minit is not null
select * from employee where job_id >10
select * from employee where job_id <10
select * from employee where job_id >10 and job_id < 15
select * from employee where job_id between 10 and 15
select * from employee where job_id=11 or job_id=14 or job_id=6 
--same as above
select * from employee where job_id in (11,4,6)
--to print the rest 
select * from employee where job_id not in (11,4,6)

select * from employee where fname='Maria'
--alternate for the above query
select * from employee where fname like 'Mar%'
--prints the names which has the second letter as 'o'
select * from employee where fname like '_o%'

--to select a particular column
 select emp_id from employee where fname like '_o%'

 select emp_id,fname,lname from employee where job_id not in (11,4,6)


 select * from titles
 --aggregation 
 select sum(advance) from titles
  select count(advance) from titles
 select min(advance) from titles
  select max(advance) from titles
 select avg(advance) from titles
   --to include column names in aggregation
 select sum(advance) total from titles
 select count(advance) number_count from titles
 select min(advance) minimum from titles
  select max(advance) maximum from titles
  select avg(advance) average  from titles

select count(*) numcount from titles where pub_id=0877
select count(*) numcount from titles where pub_id= 1389
--to print distinct values
select distinct pub_id from titles 

--group by ("for ever')
select pub_id ,count(*) numberofpublishes from titles group by pub_id

select pub_id,max(advance) advancetotal ,count(*) numberofpublishes from titles group by pub_id

select * from sales
select stor_id,sum(qty) from sales group by stor_id
--to print the sum of quantity for every title
select title_id,sum(qty) from sales group by title_id

select * from titles
select type,avg(royalty) average from titles group by type
--to print the number of orders placed in every store
select * from sales
select stor_id,count(payterms) as ordersplaced from sales group by stor_id
--using having clause (replacing 'where')
select stor_id,count(payterms) as ordersplaced from sales group by stor_id having count(payterms)>2

--select the average royalty for every type is the average is less than 15
select type,avg(royalty) average from titles group by type having avg(royalty)<15

-- sorting 
select * from authors order by au_lname
select * from authors order by city
select * from authors order by state,city
-- sorting in desc
select * from authors order by phone desc

--SUB QUERY:
select * from titles
select * from sales
--print the sales of the title "The Gourmet Microwave"
select * from sales where title_id='MC3021'
select title from titles where title='The Gourmet Microwave'

--instead we can use subquery
select * from sales where title_id=(select title_id from titles where title='The Gourmet Microwave')
select * from publishers

 --using "in" in subquery
select * from sales where title_id in
(select title_id from titles where pub_id=
(select pub_id from publishers where pub_name='New Moon Books'))

select title_id,sum(qty) from sales where title_id in
(select title_id from titles where pub_id=
(select pub_id from publishers where pub_name='New Moon Books')) 
group by title_id
having sum(qty)<=25
order by sum(qty) desc

select title_id,sum(qty) sumofquantity from sales where title_id in
(select title_id from titles where pub_id=
(select pub_id from publishers where pub_name='New Moon Books')) 
group by title_id
having sum(qty)<=25
order by sumofquantity

--JOINTS

--print the title name and sale quantity
--title name is in titles table and sales quantity is in sales table
select title,qty  from titles join sales
on
titles.title_id=sales.title_id
--using instances 
select title,qty  from titles t join sales s
on
t.title_id=s.title_id
--print the title id in the sales table
 select title_id from sales
 --print the unique title id in the sales table
 select distinct title_id from sales

select title_id from titles where title_id not in 
(select distinct title_id from sales)
 --to join with titleid(slternate method)
 --innerjoin
select t.title_id,title,qty  from titles t join sales s
on
t.title_id=s.title_id

--outerjoin
--i want all the records from the left table(left-outer-join)
select t.title_id,title,qty  from titles t left outer join sales s
on
t.title_id=s.title_id

--
select * from publishers
select * from titles
--print all the publishers name and the title names
select pub_name,title from publishers join titles
on 
publishers.pub_id=titles.pub_id

select pub_name,title from publishers left outer join titles
on 
publishers.pub_id=titles.pub_id 

--activity7
--1) Select the author firtname and last name
select * from authors
select au_fname,au_lname from authors
--2) Sort the titles by the title name in descending order and print all teh details
select * from titles order by title desc
--3) Print the number of titlespublished by every author
select count(title) as titlespublished,pub_id from titles group by pub_id 
--4) print the author name and title name
 select au_fname,title from authors cross join titles 
--5) print the publisher name and the average advance for every publisher
select pub_name,avg(advance) as averageadvance from publishers p join titles t
on 
p.pub_id=t.pub_id group by pub_name 
--6) print the publishername, author name, title name and the sale amount(qty*price)
select qty*price as salesamount ,title from sales join titles
on 
sales.title_id=titles.title_id 
select pub_name,au_fname from publishers cross join authors 
--7) print the price of all that titles that have name that ends with s
select title from titles where title like '%s'
--8) print the title names that contain and in it
select title from titles where title like '%and%'
--9) print the employee name and the publisher name
select * from employee
select fname,pub_name from employee e join publishers p
on
e.pub_id=p.pub_id group by pub_name,fname
--10) print the publisher name and number of employees woking in it if the publisher has more than 2 employeesselect pub_name,count(emp_id) as number_of_employees from publishers p join employee e
on
p.pub_id=e.pub_id group by pub_name having count(emp_id)>2
--11) Print the author names who have published using the publisher name 'Algodata Infosystems'
select pub_name,au_fname from publishers join authors
on 
publishers.city=authors.city group by pub_name,au_fname having pub_name='Algodata Infosystems'
--12) Print the employees of the publisher 'Algodata Infosystems'
select pub_name,fname from publishers join employee
on 
publishers.pub_id=employee.pub_id group by pub_name,fname having pub_name='Algodata Infosystems'














