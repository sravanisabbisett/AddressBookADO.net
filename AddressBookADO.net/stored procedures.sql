--Stored procedure for delete person
create procedure spDeletePerson
@FirstName varchar(50)
as
begin
delete from Person
Where Firstname=@FirstName
End
Go

--stored pocedure for update person
create procedure spUpdatePerson
@FirsstName varchar(50),
@State varchar(50)
as
begin
update Person
set State=@State
where Firstname=@FirsstName
end
Go

--stored procedure for addPerson in person table
create procedure spAddPerson
@FirstName varchar(50),
@LastName varchar(50),
@Address varchar(50),
@City varchar(50),
@State varchar(50),
@Zip int,
@MobileNumber varchar(10),
@EmailId varchar(50)
as
begin
insert into Person(Firstname,Lastname,Address,City,State,Zip,MobileNumber,EmailId)
values(@FirstName,@LastName,@Address,@City,@State,@Zip,@MobileNumber,@EmailId)
end
go

--stored procedure for Add details in addressBook table
create procedure spAddPersonAddressBook
@PersonId int,
@AddressBookId int
as 
begin
insert into persondAddressBook(PersonId,AddressBookId)
values(@PersonId,@AddressBookId)
end
go

--stored procedure for add data in addressbooktype
create procedure spAddAddressBookType
@PersonType varchar(50),
@AddressBookName varchar(50)
as 
begin
insert into AddressBookType(PersonType,AddressBookName)
values(@PersonType,@AddressBookName)
end
go

--stored procedure fore retrive all data in person table
create procedure spRetriveData
as
Select * from Person;


--stored procedure for retrive all data in Addressbokktype table
create procedure spRetriveAddressBookType
as
Select * from AddressBookType

--stored procedure for get person details by city or state
CREATE PROCEDURE spPersonsCityorState 
@City varchar(50),
@State varchar(50)
AS
SELECT Firstname,City,State FROM Person WHERE City = @City or State=@State

--stored procedure for get person details by city and state
CREATE PROCEDURE spPersonsCityAndState 
@City varchar(50),
@State varchar(50)
AS
SELECT Firstname,City,State FROM Person WHERE City = @City And State=@State
exec spPersonsCityAndState Bantumilli,AndhraPradesh

--stored prpcedure for orderby firstname with city
CREATE PROCEDURE OrderByFirstName 
@City varchar(50)
AS
SELECT Firstname FROM Person 
where City=@City
order by Firstname

--Stored procedure for count by type
create procedure spCountType
as
Select Count(AddressBookId) as Persons,PersonType from  persondAddressBook p
inner join AddressBookType a on p.AddressBookId=a.ABId
Group by PersonType;