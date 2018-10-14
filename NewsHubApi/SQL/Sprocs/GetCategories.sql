-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Gilbert
-- Create date: 10/14/2018
-- Description:	Gets all categories to display topics
-- =============================================

-- EXEC dbo.GetCategories

ALTER PROCEDURE dbo.GetCategories

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
		CategoryId, 
		CategoryName
	From dbo.Categories WITH (NOLOCK)
END
GO
