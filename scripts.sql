create database dsntec_project





create table provinces
(
	province_id int primary key identity(1, 1) not null,
	description nvarchar(50),
)





create table clients
(
	client_id int primary key identity(1, 1) not null,
	name nvarchar(50),
	province_id int foreign key references provinces(province_id)
)





insert into provinces(description)
values('Buenos Aires')

insert into provinces(description)
values('Catamarca')

insert into provinces(description)
values('Chaco')

insert into provinces(description)
values('Chubut')

insert into provinces(description)
values('Córdoba')

insert into provinces(description)
values('Corrientes')

insert into provinces(description)
values('Entre Ríos')

insert into provinces(description)
values('Formosa')

insert into provinces(description)
values('Jujuy')

insert into provinces(description)
values('La Pampa')

insert into provinces(description)
values('La Rioja')

insert into provinces(description)
values('Mendoza')

insert into provinces(description)
values('Misiones')

insert into provinces(description)
values('Neuquén')

insert into provinces(description)
values('Río Negro')

insert into provinces(description)
values('Salta')

insert into provinces(description)
values('San Juan')

insert into provinces(description)
values('San Luis')

insert into provinces(description)
values('Santa Cruz')

insert into provinces(description)
values('Santa Fe')

insert into provinces(description)
values('Santiago del Estero')

insert into provinces(description)
values('Tierra del Fuego')

insert into provinces(description)
values('Tucumán')





create procedure select_provinces
as
begin
	select province_id, description
	from provinces
end





create procedure select_clients
as
begin
	select c.client_id, c.name, p.province_id, p.description
	from clients as c
	left join provinces as p on p.province_id = c.province_id
end





create procedure insert_update_client
(
	@client_id int,
	@name nvarchar(50),
	@province_id int,
	@action nvarchar(10)
)
as
begin
	if @action = 'insert'
	begin
		insert into clients(name, province_id)
		values(@name, @province_id)
	end

	else if @action = 'update'
	begin
		update clients
		set name = @name, province_id = @province_id
		where client_id = @client_id
	end
end





create procedure delete_client
(
	@client_id int
)
as
begin
	delete 
	from clients
	where client_id = @client_id 
end