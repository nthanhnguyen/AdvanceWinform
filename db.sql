USE [master]
GO
/****** Object:  Database [WinFormDb]    Script Date: 09/28/2023 11:14:54 AM ******/
CREATE DATABASE [WinFormDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'WinFormDb', FILENAME = N'C:\Users\Acer\WinFormDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'WinFormDb_log', FILENAME = N'C:\Users\Acer\WinFormDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [WinFormDb] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [WinFormDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [WinFormDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [WinFormDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [WinFormDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [WinFormDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [WinFormDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [WinFormDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [WinFormDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [WinFormDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [WinFormDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [WinFormDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [WinFormDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [WinFormDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [WinFormDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [WinFormDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [WinFormDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [WinFormDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [WinFormDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [WinFormDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [WinFormDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [WinFormDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [WinFormDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [WinFormDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [WinFormDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [WinFormDb] SET  MULTI_USER 
GO
ALTER DATABASE [WinFormDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [WinFormDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [WinFormDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [WinFormDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [WinFormDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [WinFormDb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [WinFormDb] SET QUERY_STORE = OFF
GO
USE [WinFormDb]
GO
/****** Object:  Table [dbo].[user]    Script Date: 09/28/2023 11:14:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user](
	[UserID] [nvarchar](50) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Tel] [nvarchar](max) NULL,
	[Disable] [tinyint] NOT NULL,
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[CheckUserExists]    Script Date: 09/28/2023 11:14:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CheckUserExists]
    @UserID nvarchar(50)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @UserCount INT;

    -- Kiểm tra xem mã người dùng đã tồn tại trong bảng chưa
    SELECT @UserCount = COUNT(*)
    FROM [dbo].[user]
    WHERE [UserID] = @UserID;

    -- Nếu tồn tại, trả về thông báo lỗi
    IF @UserCount > 0
    BEGIN
        THROW 50000, 'Mã người dùng đã tồn tại. Vui lòng chọn mã người dùng khác.', 1;
        RETURN;
    END;
END;
GO
/****** Object:  StoredProcedure [dbo].[CheckValidEmail]    Script Date: 09/28/2023 11:14:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CheckValidEmail]
    @Email NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    -- Kiểm tra xem địa chỉ email có đúng định dạng hợp lệ không
    DECLARE @Pattern NVARCHAR(255) = '^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$';

    IF @Email IS NULL
    BEGIN
        THROW 50000, 'Địa chỉ email là NULL. Vui lòng cung cấp địa chỉ email hợp lệ.', 1;
        RETURN;
    END;

    IF @Email NOT LIKE @Pattern
    BEGIN
        THROW 50000, 'Địa chỉ email không hợp lệ. Vui lòng cung cấp địa chỉ email hợp lệ.', 1;
        RETURN;
    END;

    -- Nếu địa chỉ email hợp lệ, trả về 0 (hoặc một giá trị khác để biểu thị sự thành công)
    RETURN 0;
END;
GO
/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 09/28/2023 11:14:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteUser]
    @UserID nvarchar(50)
AS
BEGIN
    -- Kiểm tra xem người dùng có tồn tại trong bảng "user" không
    IF EXISTS (SELECT 1 FROM [dbo].[user] WHERE [UserID] = @UserID)
    BEGIN
        -- Nếu người dùng tồn tại, thực hiện câu lệnh DELETE để xóa người dùng
        DELETE FROM [dbo].[user] WHERE [UserID] = @UserID;
        PRINT 'Người dùng đã được xóa thành công.';
    END
    ELSE
    BEGIN
        -- Nếu người dùng không tồn tại, in ra thông báo lỗi
        PRINT 'Người dùng không tồn tại.';
    END
END
GO
/****** Object:  StoredProcedure [dbo].[InsertUser]    Script Date: 09/28/2023 11:14:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertUser]
    @UserID nvarchar(50),
    @UserName nvarchar(50),
    @Password nvarchar(50),
    @Email nvarchar(50),
    @Tel nvarchar(max),
    @Disable tinyint
AS
BEGIN
    INSERT INTO [dbo].[user] ([UserID], [UserName], [Password], [Email], [Tel], [Disable])
    VALUES (@UserID, @UserName, @Password, @Email, @Tel, @Disable)
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateUser]    Script Date: 09/28/2023 11:14:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateUser]
    @UserID NVARCHAR(50),
    @UserName NVARCHAR(50),
    @Password NVARCHAR(50),
    @Email NVARCHAR(50),
    @Tel NVARCHAR(MAX),
    @Disable TINYINT
AS
BEGIN
    UPDATE [dbo].[user]
    SET
        UserName = @UserName,
        Password = @Password,
        Email = @Email,
        Tel = @Tel,
        Disable = @Disable
    WHERE UserID = @UserID
END
GO
USE [master]
GO
ALTER DATABASE [WinFormDb] SET  READ_WRITE 
GO
