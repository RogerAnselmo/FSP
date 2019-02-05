use FSPEngenharia

create table fornecedor
(
  idfornecedor int not null identity(1,1),
  nmrazaosocial varchar(100) not null,
  nocnpj varchar(20) null,
  dsendereco varchar(100) null,
  dsbairro varchar(100) null,
  dscidade varchar(100) null,
  dsuf varchar(10) null,
  nocep varchar(20) null,
  nmresponsavel varchar(100) null,
  nofone varchar(20) null,
  nocelular varchar(20) null,
  nmbanco varchar(60) null,
  noagencia varchar(10) null,
  nocontacorrente varchar(20) null,
  tpcontacorrente varchar(15) null,
  constraint pk_fornecedor primary key(idfornecedor)
)