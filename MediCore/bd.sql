CREATE DATABASE MEDICORE;

CREATE TABLE Analysis(
	AnalysisId INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Name VARCHAR(50),
	State INT NOT NULL,
	AuditCreateDate DATETIME2(7) NOT NULL
)
GO

CREATE PROCEDURE uspAnalysisList 
AS 
BEGIN
	SELECT AnalysisId, Name, AuditCreateDate, State FROM Analysis;
END

CREATE PROCEDURE uspAnalysisById
(
	@AnalysisId int 
)
AS
BEGIN
	SELECT AnalysisId, Name FROM Analysis WHERE AnalysisId = @AnalysisId;
END

CREATE PROCEDURE uspAnalysisRegister
(
	@Name VARCHAR(50)
)
AS
BEGIN
	INSERT INTO Analysis (Name, State, AuditCreateDate) VALUES (@Name, 1, GETDATE());
END

CREATE PROCEDURE uspAnalysisEdit
(
	@AnalysisId int,
	@Name VARCHAR(50)
)
AS
BEGIN
	UPDATE Analysis SET Name = @Name WHERE AnalysisId = @AnalysisId;
END

CREATE PROCEDURE uspAnalysisRemove
(
	@AnalysisId int
)
AS
BEGIN
	DELETE FROM Analysis WHERE AnalysisId = @AnalysisId;
END

CREATE PROCEDURE uspAnalysisChangeState
(
	@AnalysisId int,
	@State int
)
AS
BEGIN
	UPDATE Analysis SET State = @State WHERE AnalysisId = @AnalysisId;
END

exec uspAnalysisById 1

insert into Analysis (Name,State,AuditCreateDate) values ('Prueba',1,'2023-08-22');

