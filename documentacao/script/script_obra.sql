use FSPEngenharia	;
--drop table obra
create table obra(
 idobra int not null identity(1,1),
 dsobjeto varchar(300) null,
 nmobra varchar(300) null,
 dsendereco varchar(100) null,
 dsbairro  varchar(100) null,
 dscidade  varchar(100) null,
 dsuf varchar(10) null,
 nocep varchar(20) null,
 dsstatus varchar(30) null,
 datainicio datetime,
 datafim datetime,
 constraint pk_obra primary key(idobra)
)

select * from obra