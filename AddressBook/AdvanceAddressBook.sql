drop table ownerTable

create procedure AddContactDetails
(
	@firstName varchar(max),
	@lastName varchar(max),
	@address varchar(max),
	@city varchar(max),
	@state varchar(max),
	@zip varchar(max),
	@phonenumber varchar(max),
	@email varchar(max),
	@contact varchar(max),
	@ownerName varchar(max)
)
as
begin
insert Into AddressBookDetails values(@firstname,@lastName,@address,@city,@state,@zip,@phonenumber,@email,@contact,@ownerName)
End


insert Into AddressBookDetails values('a','a','a','a','a','a','a','a','a','a')

drop table AddressBookDetails