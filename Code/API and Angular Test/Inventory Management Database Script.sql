USE [master]
GO
/****** Object:  Database [InventoryManagement]    Script Date: 11-05-2021 11:45:22 ******/
CREATE DATABASE [InventoryManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'InventoryManagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\InventoryManagement.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'InventoryManagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\InventoryManagement_log.ldf' , SIZE = 816KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [InventoryManagement] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [InventoryManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [InventoryManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [InventoryManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [InventoryManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [InventoryManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [InventoryManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [InventoryManagement] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [InventoryManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [InventoryManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [InventoryManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [InventoryManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [InventoryManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [InventoryManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [InventoryManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [InventoryManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [InventoryManagement] SET  ENABLE_BROKER 
GO
ALTER DATABASE [InventoryManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [InventoryManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [InventoryManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [InventoryManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [InventoryManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [InventoryManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [InventoryManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [InventoryManagement] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [InventoryManagement] SET  MULTI_USER 
GO
ALTER DATABASE [InventoryManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [InventoryManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [InventoryManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [InventoryManagement] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [InventoryManagement] SET DELAYED_DURABILITY = DISABLED 
GO
USE [InventoryManagement]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 11-05-2021 11:45:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Phone] [varchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 11-05-2021 11:45:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[OrderTypeID] [int] NULL,
	[OrderDate] [datetime] NULL,
	[CustomerID] [int] NULL,
	[ProductID] [int] NULL,
	[Quantity] [int] NULL,
	[TotalPrice] [decimal](10, 2) NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderType]    Script Date: 11-05-2021 11:45:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[OrderType](
	[OrderTypeID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[Detail] [varchar](2000) NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_OrderType] PRIMARY KEY CLUSTERED 
(
	[OrderTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Product]    Script Date: 11-05-2021 11:45:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Product](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [varchar](50) NULL,
	[Stock] [int] NULL,
	[Price] [decimal](10, 2) NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Customer] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Customer]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_OrderType] FOREIGN KEY([OrderTypeID])
REFERENCES [dbo].[OrderType] ([OrderTypeID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_OrderType]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ProductID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Product]
GO
/****** Object:  StoredProcedure [dbo].[PR_Customer_CountCustomers]    Script Date: 11-05-2021 11:45:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_Customer_CountCustomers]

AS

SELECT COUNT([dbo].[Customer].[CustomerID]) AS TotalRecord FROM [dbo].[Customer]
GO
/****** Object:  StoredProcedure [dbo].[PR_Customer_SearchByCustomerName]    Script Date: 11-05-2021 11:45:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_Customer_SearchByCustomerName]
	@PageNo		int,
	@PageSize	int,
	@SearchText		varchar(100) = ''

AS

BEGIN
	WITH CTE_Customer AS
	(SELECT ROW_NUMBER() OVER(ORDER BY [dbo].[Customer].[CustomerID]) AS RowNumber,
		[dbo].[Customer].[CustomerID],
		[dbo].[Customer].[CustomerName],
		[dbo].[Customer].[Email],
		[dbo].[Customer].[Phone],
		[dbo].[Customer].[CreatedDate],
		[dbo].[Customer].[UpdatedDate]

	FROM [dbo].[Customer]

	WHERE [dbo].[Customer].[CustomerName] LIKE '%' + @SearchText + '%'
	)

	SELECT * FROM CTE_Customer
	WHERE RowNumber > ((@PageNo-1)*@PageSize) AND RowNumber <= (@PageNo*@PageSize)
END

GO
/****** Object:  StoredProcedure [dbo].[PR_Customer_SelectAllPagination]    Script Date: 11-05-2021 11:45:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_Customer_SelectAllPagination]
	@PageNo		int,
	@PageSize	int

AS
BEGIN
	WITH CTE_Customer AS
		(SELECT ROW_NUMBER() OVER(ORDER BY [dbo].[Customer].[CustomerID]) AS RowNumber,
			[dbo].[Customer].[CustomerID],
			[dbo].[Customer].[CustomerName],
			[dbo].[Customer].[Email],
			[dbo].[Customer].[Phone],
			[dbo].[Customer].[CreatedDate],
			[dbo].[Customer].[UpdatedDate]

			FROM [dbo].[Customer]
			WHERE [dbo].[Customer].[Status] = 1
		)

		SELECT * FROM CTE_Customer
		WHERE RowNumber > ((@PageNo-1)*@PageSize) AND RowNumber <= (@PageNo*@PageSize)
END
GO
/****** Object:  StoredProcedure [dbo].[PR_Orders_CountOrders]    Script Date: 11-05-2021 11:45:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_Orders_CountOrders]

AS

SELECT COUNT([dbo].[Orders].[OrderID]) AS TotalRecord FROM [dbo].[Orders]
GO
/****** Object:  StoredProcedure [dbo].[PR_Orders_SelectAll]    Script Date: 11-05-2021 11:45:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_Orders_SelectAll]

AS

SELECT
	[dbo].[Orders].[CustomerID],
	[dbo].[Customer].[CustomerName],
	[dbo].[Product].[ProductName],
	[dbo].[OrderType].[Name],
	[dbo].[Orders].[OrderDate],
	[dbo].[Orders].[Quantity],
	[dbo].[Orders].[TotalPrice],
	[dbo].[Orders].[CreatedDate],
	[dbo].[Orders].[UpdatedDate]

FROM [dbo].[Orders]

INNER JOIN [dbo].[Customer]
ON [dbo].[Customer].[CustomerID] = [dbo].[Orders].[CustomerID]

INNER JOIN [dbo].[Product]
ON [dbo].[Product].[ProductID] = [dbo].[Orders].[ProductID]

INNER JOIN [dbo].[OrderType]
ON [dbo].[OrderType].[OrderTypeID] = [dbo].[Orders].[OrderTypeID]

ORDER BY [dbo].[Orders].[OrderDate] DESC
GO
/****** Object:  StoredProcedure [dbo].[PR_Orders_SelectAllByDate]    Script Date: 11-05-2021 11:45:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_Orders_SelectAllByDate]
	@FromDate	datetime,
	@ToDate		datetime
AS

SELECT
	[dbo].[Orders].[CustomerID],
	[dbo].[Customer].[CustomerName],
	[dbo].[Product].[ProductName],
	[dbo].[OrderType].[Name],
	[dbo].[Orders].[OrderDate],
	[dbo].[Orders].[Quantity],
	[dbo].[Orders].[TotalPrice],
	[dbo].[Orders].[CreatedDate],
	[dbo].[Orders].[UpdatedDate]

FROM [dbo].[Orders]

INNER JOIN [dbo].[Customer]
ON [dbo].[Customer].[CustomerID] = [dbo].[Orders].[CustomerID]

INNER JOIN [dbo].[Product]
ON [dbo].[Product].[ProductID] = [dbo].[Orders].[ProductID]

INNER JOIN [dbo].[OrderType]
ON [dbo].[OrderType].[OrderTypeID] = [dbo].[Orders].[OrderTypeID]

WHERE ([dbo].[Orders].[OrderDate] >= @FromDate AND [dbo].[Orders].[OrderDate] <= @ToDate)

GO
/****** Object:  StoredProcedure [dbo].[PR_Orders_SelectAllPagination]    Script Date: 11-05-2021 11:45:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_Orders_SelectAllPagination]
	@PageNo		int,
	@PageSize	int,
	@Direction	varchar(10)
AS

BEGIN
	
	WITH CTE_Order AS
	(SELECT ROW_NUMBER() OVER
		(ORDER BY 
	
			CASE WHEN (@Direction = 'true')
				THEN [dbo].[Orders].[OrderID]
			END asc,

			CASE WHEN (@Direction = 'false')
				THEN [dbo].[Orders].[OrderID]
			END desc
		) 
		AS RowNumber,
		
		[dbo].[Orders].[OrderID],
		[dbo].[Orders].[CustomerID],
		[dbo].[Customer].[CustomerName],
		[dbo].[Product].[ProductName],
		[dbo].[OrderType].[Name],
		[dbo].[Orders].[OrderDate],
		[dbo].[Orders].[Quantity],
		[dbo].[Orders].[TotalPrice],
		[dbo].[Orders].[CreatedDate],
		[dbo].[Orders].[UpdatedDate]

	FROM [dbo].[Orders]

	INNER JOIN [dbo].[Customer]
	ON [dbo].[Customer].[CustomerID] = [dbo].[Orders].[CustomerID]

	INNER JOIN [dbo].[Product]
	ON [dbo].[Product].[ProductID] = [dbo].[Orders].[ProductID]

	INNER JOIN [dbo].[OrderType]
	ON [dbo].[OrderType].[OrderTypeID] = [dbo].[Orders].[OrderTypeID]
	)

	SELECT * FROM CTE_Order
	WHERE RowNumber > ((@PageNo-1)*@PageSize) AND RowNumber <= (@PageNo*@PageSize)
END
GO
/****** Object:  StoredProcedure [dbo].[PR_Product_CountProducts]    Script Date: 11-05-2021 11:45:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_Product_CountProducts]

AS

SELECT COUNT([dbo].[Product].[ProductID]) AS TotalRecord FROM [dbo].[Product]
GO
/****** Object:  StoredProcedure [dbo].[PR_Product_SearchByProductName]    Script Date: 11-05-2021 11:45:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_Product_SearchByProductName]
	@PageNo		int,
	@PageSize	int,
	@SearchText		varchar(100) = ''

AS

BEGIN
	WITH CTE_Product AS
	(SELECT ROW_NUMBER() OVER(ORDER BY [dbo].[Product].[ProductID]) AS RowNumber,
		[dbo].[Product].[ProductID],
		[dbo].[Product].[ProductName],
		[dbo].[Product].[Stock],
		[dbo].[Product].[Price],
		[dbo].[Product].[CreatedDate],
		[dbo].[Product].[UpdatedDate]

	FROM [dbo].[Product]

	WHERE [dbo].[Product].[ProductName] LIKE '%' + @SearchText + '%'
	)

	SELECT * FROM CTE_Product
	WHERE RowNumber > ((@PageNo-1)*@PageSize) AND RowNumber <= (@PageNo*@PageSize)
END

GO
/****** Object:  StoredProcedure [dbo].[PR_Product_SelectAllPagination]    Script Date: 11-05-2021 11:45:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_Product_SelectAllPagination]
	@PageNo		int,
	@PageSize	int

AS

BEGIN
	WITH CTE_Product AS
		(SELECT ROW_NUMBER() OVER(ORDER BY [dbo].[Product].[ProductID]) AS RowNumber,
			[dbo].[Product].[ProductID],
			[dbo].[Product].[ProductName],
			[dbo].[Product].[Stock],
			[dbo].[Product].[Price],
			[dbo].[Product].[CreatedDate],
			[dbo].[Product].[UpdatedDate]

			FROM [dbo].[Product]
			WHERE [dbo].[Product].[Status] = 1
		)

	SELECT * FROM CTE_Product
	WHERE RowNumber > ((@PageNo-1)*@PageSize) AND RowNumber <= (@PageNo*@PageSize)
END
GO
USE [master]
GO
ALTER DATABASE [InventoryManagement] SET  READ_WRITE 
GO
