CREATE TABLE Customer_Information (
    Cust_ID        INT   UNIQUE   IDENTITY (1, 1) NOT NULL,
    Cust_Name  VARCHAR (50) NOT NULL,
    Cust_Address VARCHAR (50) NOT NULL,
    Cust_City    VARCHAR(50)  NOT NULL,
	Cust_State    VARCHAR(2)   NOT NULL,
	Cust_Zip    VARCHAR (5)  NOT NULL,
	Cust_Email    VARCHAR (50)  NOT NULL,
	Cust_Phone    VARCHAR (12)  NOT NULL,
	Account_Created_Date DATETIME NOT NULL,
    Cust_Discount          VARCHAR (5)  NULL,
    PRIMARY KEY CLUSTERED (Cust_ID ASC)
);
CREATE TABLE [Payment_Information] (
    [Payment_ID]        INT     UNIQUE     IDENTITY (1, 1) NOT NULL,
    [Cust_ID]  INT FOREIGN KEY REFERENCES Customer_Information(Cust_ID) NOT NULL,
    [Card_Type] VARCHAR (30) NOT NULL,
    [Card_Number]    VARCHAR(16)  NOT NULL,
	[Card_CSV]    VARCHAR(4)   NOT NULL,
	[Billing_Address]    VARCHAR (50)  NOT NULL,
	[Billing_City]    VARCHAR (50)  NOT NULL,
	[Billing_State]    VARCHAR (2)  NOT NULL,
    [Billing_Zip]          VARCHAR (5)  NOT NULL,
    PRIMARY KEY CLUSTERED ([Payment_ID] ASC)
);
CREATE TABLE Work_Orders (
    Order_ID        INT     UNIQUE     IDENTITY (1, 1) NOT NULL,
    Cust_ID  INT FOREIGN KEY REFERENCES Customer_Information(Cust_ID) NOT NULL,
    Employee_ID INT NOT NULL,-- edit this field to link the foreign key
	Date_Created  DATETIME NOT NULL,
	Date_Completed  DATETIME NOT NULL,
    Expedite_Order INT NOT NULL CHECK(Expedite_Order IN (0,1)),
	Results_File_Ascii  NVARCHAR(MAX) NULL,
	Analysis NVARCHAR(MAX) NULL,
	Analysis_Completed INT NOT NULL CHECK(Analysis_Completed IN (0,1)),
    PRIMARY KEY CLUSTERED (Order_ID ASC)
);
CREATE TABLE Compounds (
    LT_Number        INT     UNIQUE     IDENTITY (000001, 1) NOT NULL CHECK(LT_Number < 1000000),
    Compound_Name  VARCHAR  (50) NOT NULL,
    Quantity VARCHAR (6) NOT NULL,
    Date_Arrived  DATETIME  NOT NULL,
	Date_Received    DATETIME  NOT NULL,
	Date_Due    DATETIME  NOT NULL,
	Compound_Appearance    VARCHAR (250)  NOT NULL,
	Compound_Weight    VARCHAR (2)  NOT NULL,
    Actual_Weight          VARCHAR (5)  NOT NULL,
	Molecular_Mass VARCHAR(10)
    PRIMARY KEY CLUSTERED (LT_Number ASC)
);
CREATE TABLE Order_Details (
    Order_ID    INT  FOREIGN KEY REFERENCES Work_Orders(Order_ID) NOT NULL,
    LT_Number  INT FOREIGN KEY REFERENCES Compounds(LT_Number) NOT NULL,
    Quoted_Price VARCHAR(10) NOT NULL,
    PRIMARY KEY CLUSTERED (Order_ID, LT_Number ASC)
);
CREATE TABLE Compound_Assays (
    LT_Number    INT  FOREIGN KEY REFERENCES Work_Orders(Order_ID) NOT NULL,
    Assay_ID  INT FOREIGN KEY REFERENCES Compounds(LT_Number) NOT NULL,
    PRIMARY KEY CLUSTERED (LT_Number, Assay_ID ASC)
);
-- Josh
CREATE TABLE [dbo].[Employee_Roles] (
    [Employee_Role_ID] INT IDENTITY (1,1)  NOT NULL,
    [Role_Desc] VARCHAR (100) NOT NULL,
    [Role_Permissions] NVARCHAR (MAX) NOT NULL
    PRIMARY KEY CLUSTERED ([Employee_Role_ID] ASC)
);
CREATE TABLE [dbo].[Office_Locations] (
    [Office_ID] VARCHAR (3) NOT NULL,
    [Office_Name] VARCHAR (30) NOT NULL,
    [Office_Address] VARCHAR (30) NOT NULL,
    [Employee_Role_ID] INT FOREIGN KEY REFERENCES Employee_Roles(Employee_Role_ID),
    PRIMARY KEY  ([Office_ID] ASC)
);
CREATE TABLE [dbo].[Employees] (
    [Employee_ID] INT IDENTITY (1,1) NOT NULL,
    [Employee_First_Name] VARCHAR (30) NOT NULL,
    [Employee_Last_Name] VARCHAR (30) NOT NULL,
    [Employee_Role_ID] INT FOREIGN KEY REFERENCES Employee_Roles(Employee_Role_ID),
    [Office_ID] VARCHAR (3) FOREIGN KEY REFERENCES Office_Locations(Office_ID)
    PRIMARY KEY CLUSTERED ([Employee_ID] ASC)
);
CREATE TABLE [dbo].[Tests] (
    [Test_ID] VARCHAR(2) NOT NULL,
    [Test_Description] VARCHAR (50) NOT NULL,
    [Test_Details] VARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([Test_ID] ASC)
);
CREATE TABLE [dbo].[Assays] (
    [Assay_ID] INT IDENTITY (1,1) NOT NULL,
    [Assay_Description] VARCHAR (50) NOT NULL,
	Assay_Duration  INT NOT NULL,
    [No_Of_Tests] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Assay_ID] ASC)
);
CREATE TABLE [dbo].[Assay_Details] (
    [Assay_ID] INT FOREIGN KEY REFERENCES Assays(Assay_ID) NOT NULL,
    [Test_ID] VARCHAR(2) FOREIGN KEY REFERENCES Tests(Test_ID) NOT NULL,
    PRIMARY KEY CLUSTERED ([Test_ID] ASC)
);
CREATE TABLE [dbo].[Compound_Samples] (
    [Compound_Sequence_Code]INT IDENTITY (1,1) NOT NULL,
    [Test_ID] VARCHAR (2) FOREIGN KEY REFERENCES Tests(Test_ID) NOT NULL,
    [LT_Number] INT FOREIGN KEY REFERENCES Compounds(LT_Number) NOT NULL,
    PRIMARY KEY CLUSTERED ([Compound_Sequence_Code] ASC)
);