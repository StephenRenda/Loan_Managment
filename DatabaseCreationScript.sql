USE [master]
GO
/****** Object:  Database [SultanLoans]    Script Date: 9/11/2020 5:17:04 PM ******/
CREATE DATABASE [SultanLoans]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LoanApp', FILENAME = N'/var/opt/mssql/data/LoanApp.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'LoanApp_log', FILENAME = N'/var/opt/mssql/data/LoanApp_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [SultanLoans] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SultanLoans].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SultanLoans] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SultanLoans] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SultanLoans] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SultanLoans] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SultanLoans] SET ARITHABORT OFF 
GO
ALTER DATABASE [SultanLoans] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SultanLoans] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SultanLoans] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SultanLoans] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SultanLoans] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SultanLoans] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SultanLoans] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SultanLoans] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SultanLoans] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SultanLoans] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SultanLoans] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SultanLoans] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SultanLoans] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SultanLoans] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SultanLoans] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SultanLoans] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SultanLoans] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SultanLoans] SET RECOVERY FULL 
GO
ALTER DATABASE [SultanLoans] SET  MULTI_USER 
GO
ALTER DATABASE [SultanLoans] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SultanLoans] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SultanLoans] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SultanLoans] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SultanLoans] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'SultanLoans', N'ON'
GO
ALTER DATABASE [SultanLoans] SET QUERY_STORE = OFF
GO
USE [SultanLoans]
GO
/****** Object:  Table [dbo].[Loan]    Script Date: 9/11/2020 5:17:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Loan](
	[id] [uniqueidentifier] NOT NULL,
	[name] [nvarchar](15) NOT NULL,
	[borrower] [uniqueidentifier] NOT NULL,
	[trustee] [uniqueidentifier] NULL,
	[stage] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Loan] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoanStage]    Script Date: 9/11/2020 5:17:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoanStage](
	[id] [uniqueidentifier] NOT NULL,
	[name] [nvarchar](25) NOT NULL,
 CONSTRAINT [PK_LoanStage] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Trustee]    Script Date: 9/11/2020 5:17:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trustee](
	[id] [uniqueidentifier] NOT NULL,
	[name] [nvarchar](75) NOT NULL,
	[mailto] [nvarchar](75) NULL,
 CONSTRAINT [PK_Trustee] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Phone]    Script Date: 9/11/2020 5:17:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Phone](
	[id] [uniqueidentifier] NOT NULL,
	[number] [nvarchar](11) NOT NULL,
	[memo] [nvarchar](max) NULL,
	[owner] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Phone] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 9/11/2020 5:17:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[id] [uniqueidentifier] NOT NULL,
	[street1] [nvarchar](75) NULL,
	[street2] [nvarchar](75) NULL,
	[city] [nvarchar](75) NULL,
	[zip] [nchar](6) NULL,
	[state] [nvarchar](50) NULL,
	[owner] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Email]    Script Date: 9/11/2020 5:17:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Email](
	[id] [uniqueidentifier] NOT NULL,
	[email] [nvarchar](50) NULL,
	[owner] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Email] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Borrower]    Script Date: 9/11/2020 5:17:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Borrower](
	[id] [uniqueidentifier] NOT NULL,
	[name] [nvarchar](75) NOT NULL,
	[title] [nvarchar](50) NULL,
	[company] [nvarchar](75) NULL,
	[companyIsBorrower] [bit] NULL,
	[DateOfBirth] [datetime2](7) NULL,
	[SSN] [nchar](9) NULL,
 CONSTRAINT [PK_Borrower] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[FullLoanView]    Script Date: 9/11/2020 5:17:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[FullLoanView]
AS
SELECT        dbo.Loan.id, dbo.Loan.name, dbo.Loan.borrower, dbo.Loan.stage, dbo.Borrower.name AS borrowerName, dbo.Borrower.title, dbo.Borrower.company, dbo.Borrower.companyIsBorrower, dbo.Borrower.DateOfBirth, 
                         dbo.Borrower.SSN, dbo.Address.street1, dbo.Address.street2, dbo.Address.city, dbo.Address.zip, dbo.Address.state, dbo.Email.email, dbo.LoanStage.name AS LoanStage, dbo.Phone.number, dbo.Phone.memo, 
                         dbo.Phone.owner, dbo.Trustee.name AS Expr1, dbo.Trustee.mailto
FROM            dbo.Address INNER JOIN
                         dbo.Borrower ON dbo.Address.owner = dbo.Borrower.id INNER JOIN
                         dbo.Email ON dbo.Borrower.id = dbo.Email.owner INNER JOIN
                         dbo.Loan ON dbo.Borrower.id = dbo.Loan.borrower INNER JOIN
                         dbo.LoanStage ON dbo.Loan.stage = dbo.LoanStage.id INNER JOIN
                         dbo.Phone ON dbo.Borrower.id = dbo.Phone.owner INNER JOIN
                         dbo.Trustee ON dbo.Loan.trustee = dbo.Trustee.id
GO
/****** Object:  View [dbo].[Full Loan View]    Script Date: 9/11/2020 5:17:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Full Loan View]
AS
SELECT        dbo.Loan.id AS LoanID, dbo.Loan.name AS LoanName, dbo.Borrower.name AS BorrowerName, dbo.Borrower.title AS BorrowerTitle, dbo.Borrower.company AS BorrowerCompany, 
                         dbo.Borrower.companyIsBorrower AS CompanyIsBorrower, dbo.Borrower.DateOfBirth AS BorrowerDateOfBirth, dbo.Borrower.SSN AS BorrowerSSN, dbo.Address.street1 AS BorrowerStreet1, 
                         dbo.Address.street2 AS BorrowerStreet2, dbo.Address.city AS BorrowerCity, dbo.Address.zip AS BorrowerZip, dbo.Address.state AS BorrowerState, dbo.Email.email AS BorrowerEmail, dbo.LoanStage.name AS LoanStage, 
                         dbo.Phone.number AS BorrowerPhone, dbo.Phone.memo AS BorrowerPhoneMemo, dbo.Trustee.name AS TrusteeName, dbo.Trustee.mailto AS TrusteeMailTo
FROM            dbo.Address INNER JOIN
                         dbo.Borrower ON dbo.Address.owner = dbo.Borrower.id INNER JOIN
                         dbo.Email ON dbo.Borrower.id = dbo.Email.owner INNER JOIN
                         dbo.Loan ON dbo.Borrower.id = dbo.Loan.borrower INNER JOIN
                         dbo.LoanStage ON dbo.Loan.stage = dbo.LoanStage.id INNER JOIN
                         dbo.Phone ON dbo.Borrower.id = dbo.Phone.owner INNER JOIN
                         dbo.Trustee ON dbo.Loan.trustee = dbo.Trustee.id
GO
/****** Object:  Table [dbo].[Users]    Script Date: 9/11/2020 5:17:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[_id] [uniqueidentifier] NOT NULL,
	[username] [nvarchar](50) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[email] [nvarchar](50) NULL,
	[hashedPassword] [nchar](40) NULL,
	[salt] [nchar](6) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [FK_Loan]    Script Date: 9/11/2020 5:17:05 PM ******/
CREATE NONCLUSTERED INDEX [FK_Loan] ON [dbo].[Loan]
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Address] ADD  CONSTRAINT [DF_Address_id]  DEFAULT (newid()) FOR [id]
GO
ALTER TABLE [dbo].[Borrower] ADD  CONSTRAINT [DF_Borrower_id]  DEFAULT (newid()) FOR [id]
GO
ALTER TABLE [dbo].[Email] ADD  CONSTRAINT [DF_Email_id]  DEFAULT (newid()) FOR [id]
GO
ALTER TABLE [dbo].[Loan] ADD  CONSTRAINT [DF_Loan_id]  DEFAULT (newid()) FOR [id]
GO
ALTER TABLE [dbo].[LoanStage] ADD  CONSTRAINT [DF_LoanStage_id]  DEFAULT (newid()) FOR [id]
GO
ALTER TABLE [dbo].[Phone] ADD  CONSTRAINT [DF_Phone_id]  DEFAULT (newid()) FOR [id]
GO
ALTER TABLE [dbo].[Trustee] ADD  CONSTRAINT [DF_Trustee_id]  DEFAULT (newid()) FOR [id]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_id]  DEFAULT (newid()) FOR [_id]
GO
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Address_Borrower] FOREIGN KEY([owner])
REFERENCES [dbo].[Borrower] ([id])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Address_Borrower]
GO
ALTER TABLE [dbo].[Email]  WITH CHECK ADD  CONSTRAINT [FK_Email_Borrower] FOREIGN KEY([owner])
REFERENCES [dbo].[Borrower] ([id])
GO
ALTER TABLE [dbo].[Email] CHECK CONSTRAINT [FK_Email_Borrower]
GO
ALTER TABLE [dbo].[Loan]  WITH CHECK ADD  CONSTRAINT [FK_Loan_Borrower] FOREIGN KEY([borrower])
REFERENCES [dbo].[Borrower] ([id])
GO
ALTER TABLE [dbo].[Loan] CHECK CONSTRAINT [FK_Loan_Borrower]
GO
ALTER TABLE [dbo].[Loan]  WITH CHECK ADD  CONSTRAINT [FK_Loan_LoanStage] FOREIGN KEY([stage])
REFERENCES [dbo].[LoanStage] ([id])
GO
ALTER TABLE [dbo].[Loan] CHECK CONSTRAINT [FK_Loan_LoanStage]
GO
ALTER TABLE [dbo].[Loan]  WITH CHECK ADD  CONSTRAINT [FK_Loan_Trustee] FOREIGN KEY([trustee])
REFERENCES [dbo].[Trustee] ([id])
GO
ALTER TABLE [dbo].[Loan] CHECK CONSTRAINT [FK_Loan_Trustee]
GO
ALTER TABLE [dbo].[Phone]  WITH CHECK ADD  CONSTRAINT [FK_Phone_Borrower] FOREIGN KEY([owner])
REFERENCES [dbo].[Borrower] ([id])
GO
ALTER TABLE [dbo].[Phone] CHECK CONSTRAINT [FK_Phone_Borrower]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Borrower"
            Begin Extent = 
               Top = 31
               Left = 257
               Bottom = 253
               Right = 452
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Email"
            Begin Extent = 
               Top = 6
               Left = 479
               Bottom = 245
               Right = 649
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Loan"
            Begin Extent = 
               Top = 6
               Left = 687
               Bottom = 235
               Right = 857
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "LoanStage"
            Begin Extent = 
               Top = 6
               Left = 895
               Bottom = 102
               Right = 1065
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Phone"
            Begin Extent = 
               Top = 6
               Left = 1106
               Bottom = 196
               Right = 1273
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Address"
            Begin Extent = 
               Top = 36
               Left = 42
               Bottom = 256
               Right = 212
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Trustee"
            Begin Extent = 
               Top = 6
               Left = 1311
               Bottom = 205
               Right = 1481
            End
            DisplayFlags = 280
    ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Full Loan View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'        TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 22
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 2100
         Alias = 3705
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Full Loan View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Full Loan View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Address"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 226
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 3
         End
         Begin Table = "Borrower"
            Begin Extent = 
               Top = 31
               Left = 257
               Bottom = 253
               Right = 452
            End
            DisplayFlags = 280
            TopColumn = 3
         End
         Begin Table = "Email"
            Begin Extent = 
               Top = 6
               Left = 479
               Bottom = 245
               Right = 649
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Loan"
            Begin Extent = 
               Top = 6
               Left = 687
               Bottom = 235
               Right = 857
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "LoanStage"
            Begin Extent = 
               Top = 6
               Left = 895
               Bottom = 102
               Right = 1065
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Phone"
            Begin Extent = 
               Top = 6
               Left = 1106
               Bottom = 196
               Right = 1273
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Trustee"
            Begin Extent = 
               Top = 6
               Left = 1311
               Bottom = 205
               Right = 1481
            End
            DisplayFlags = 280
     ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'FullLoanView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'       TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 2100
         Alias = 3705
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'FullLoanView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'FullLoanView'
GO
USE [master]
GO
ALTER DATABASE [SultanLoans] SET  READ_WRITE 
GO
