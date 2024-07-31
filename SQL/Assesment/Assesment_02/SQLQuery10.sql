create database Assesment_07;

use Assesment_07;

--create Books table

create table book(
id int primary key,
title varchar(255),
author varchar(255),
isbn bigint unique,
published_date datetime);

-- insert values into book table

insert into book(id,title,author,isbn,published_date)values
(1,'My First SQL Book','Mary Pariser',981483029127,'2012-02-22 12:08:17'),
(2,'My Second SQL Book','John Mayer',867300923713,'1972-07-03 09:22:48'),
(3,'My Third SQL Book','Cary Flint',523120967812,'2015-10-18 14:06:44');



--Get books by Author ending with "er"

Select * from book where author like '%er';


-- create a Reviewer table

create table reviews(
id int primary key,
book_id int,
reviewer_name varchar(255),
content varchar(255),
rating int,
published_date datetime,
foreign key (book_id) references book(id));

--insert data(values) into reviews table

insert into reviews (id,book_id,reviewer_name,content,rating,published_date) values
(1,1,'John Smith','My first Review',4,'2017-12-10 05:50:11.1'),
(2,2,'John Smith','My Second Review',5,'2017-10-13 15:06:12.6'),
(3,3,'Alice Walker','Another Review',1,'2017-10-22 23:47:10');

--Display Author_name , Title and Reviewer_name

select b.title,b.author,r.reviewer_name from book b join reviews r on b.id= r.book_id;


-- Display the reviewer name who review more than one books

select reviewer_name from reviews group by reviewer_name having COUNT(book_id)>1; 

-- create a customer table

create table customer(
id int primary key,
name varchar(255),
age int ,
Address varchar(255),
salary decimal(10,2)
);

select * from customer

--insert values into customer table 

insert into customer (id, name, age, address, salary) values
(1, 'Ramesh', 32, 'Ahmedabad', 2000.00),
(2, 'Khilan', 25, 'Delhi', 1500.00),
(3, 'Kaushik', 23, 'Kota', 2000.00),
(4, 'Chaitali', 25, 'Mumbai', 6500.00),
(5, 'Hardik', 27, 'Bhopal', 8500.00),
(6, 'Komal', 22, 'MP', 4500.00),
(7, 'Muffy', 24, 'Indore', 10000.00);

--Display the name of the customer who got 'o' in their Address

Select name from customer where Address like '%o%';
 
 -- create employee table 

 create table employee(
 id int primary key,
 name varchar(255),
 age int ,
 address varchar(255),
 salary decimal(10,2)
 );


 --INSERT VALUES INTO EMPLOYEE TABLE

insert into employee (id, name, age, address, salary) values
(1, 'Ramesh', 32, 'Ahmedabad', 2000.00),
(2, 'Khilan', 25, 'Delhi', 1500.00),
(3, 'Kaushik', 23, 'Kota', 2000.00),
(4, 'Chaitali', 25, 'Mumbai', 6500.00),
(5, 'Hardik', 27, 'Bhopal', 8500.00),
(6, 'Komal', 22, 'MP', NULL),
(7, 'Muffy', 24, 'Indore', NULL);

--CREATE ORDERS TABLE

create table Order_ (
oid int primary key,
date datetime,
customer_id int,
amount decimal(10,2));



--INSERT VALUES INTO ORDERS TABLE 

insert into Order_ (oid, date, customer_id, amount) values
(102, '2009-10-08 00:00:00', 3, 3000.00),
(100, '2009-10-08 00:00:00', 3, 1500.00),
(101, '2009-11-20 00:00:00', 2, 1560.00),
(103, '2008-05-20 00:00:08', 4, 2060.00);

-- display the date and total nukber of customer

select date, COUNT(customer_id) as Total_Customers
FROM Order_
group by date
order by date;

-- display name in lower case

select LOWER(name) AS Name
from employee
where SALARY IS NULL;


---create table


CREATE TABLE Studentdetails (
    RegisterNo INT PRIMARY KEY,
    Name VARCHAR(255),
    Age INT,
    Qualification VARCHAR(50),
    MobileNo VARCHAR(15),
    MailID VARCHAR(255),
    Location VARCHAR(255),
    Gender CHAR(1)
);

--insert values

INSERT INTO Studentdetails (RegisterNo, Name, Age, Qualification, MobileNo, MailID, Location, Gender) VALUES
(1, 'Sai', 22, 'B.E', '9952836777', 'Sai@gmail.com', 'Chennai', 'M'),
(2, 'Kumar', 20, 'BSC', '7890125648', 'Kumar@gmail.com', 'Madurai', 'M'),
(3, 'Selvi', 22, 'B.Tech', '8904567342', 'selvi@gmail.com', 'Selam', 'F'),
(4, 'Nisha', 25, 'M.E', '7834672310', 'Nisha@gmail.com', 'Theni', 'F'),
(5, 'SaiSaran', 21, 'B.A', '8901234675', 'saran@gmail.com', 'Madurai', 'F'),
(6, 'Tom', 23, 'BCA', '7890345678', 'Tom@gmail.com', 'Pune', 'M');

--- display gender count

SELECT Gender, COUNT(*) AS Total_No
FROM Studentdetails
GROUP BY Gender;

