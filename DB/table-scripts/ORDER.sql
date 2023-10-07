CREATE TABLE TBL_ORDER_TYPE(
	ORDERTYPEID UNIQUEIDENTIFIER NOT NULL PRIMARY KEY NONCLUSTERED DEFAULT NEWID(),
	ORDERNAME NVARCHAR(50) NOT NULL,
	ORDERCODE NVARCHAR(50) NOT NULL,
	ORDERDESCRIPTION NVARCHAR(50) NULL,
	CREATEDDATE DATETIME NOT NULL DEFAULT GETDATE(),
	CREATEDBY NVARCHAR(50) NULL,
	UPDATEDDATE DATETIME NULL,
	UDATEDBY NVARCHAR(50) NULL
)ON [PRIMARY]

CREATE TABLE TBL_ORDER(
	ORDERID UNIQUEIDENTIFIER NOT NULL PRIMARY KEY NONCLUSTERED DEFAULT NEWID(),
	ORDERTYPEID UNIQUEIDENTIFIER NOT NULL FOREIGN KEY REFERENCES TBL_ORDER_TYPE(ORDERTYPEID),
	CUSTOMERNAME NVARCHAR(50) NOT NULL,
	CUSTOMEREMAIL NVARCHAR(50) NOT NULL,
	CUSTOMERCONTACTNUMVER NVARCHAR(50) NOT NULL,
	PACKAGEID UNIQUEIDENTIFIER NULL,
	CUSTOMERADDRESS NVARCHAR(50) NOT NULL,
	[EVENTDATE] DATETIME NOT NULL,
	ORDERSTATUSID UNIQUEIDENTIFIER NOT NULL CONSTRAINT TBL_ORDER_ORDERSTATUSID_ORDERSTATUSID FOREIGN KEY REFERENCES TBL_ORDER_STATUS(ORDERSTATUSID),
	SLOTID UNIQUEIDENTIFIER NOT NULL CONSTRAINT TBL_ORDER_SLOTID_SLOTID FOREIGN KEY REFERENCES TBL_SLOT(SLOTID),
	APPOINTMENTDATE DATETIME NOT NULL,
	CREATEDDATE DATETIME NOT NULL DEFAULT GETDATE(),
	CREATEDBY NVARCHAR(50) NULL,
	UPDATEDDATE DATETIME NULL,
	UDATEDBY NVARCHAR(50) NULL
)ON [PRIMARY]

CREATE TABLE TBL_ORDERS(
	ORDERSID UNIQUEIDENTIFIER NOT NULL PRIMARY KEY NONCLUSTERED DEFAULT NEWID(),
	ORDERID UNIQUEIDENTIFIER NOT NULL FOREIGN KEY REFERENCES TBL_ORDER(ORDERID),
	PACKAGEID UNIQUEIDENTIFIER NULL FOREIGN KEY REFERENCES TBL_PACKAGE(PACKAGEID),
	MENUID UNIQUEIDENTIFIER NULL FOREIGN KEY REFERENCES TBL_MENU(MENUID),
	CREATEDDATE DATETIME NOT NULL DEFAULT GETDATE(),
	CREATEDBY NVARCHAR(50) NULL,
	UPDATEDDATE DATETIME NULL,
	UDATEDBY NVARCHAR(50) NULL
)ON [PRIMARY]