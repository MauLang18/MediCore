CREATE DATABASE MEDICORE;
GO
CREATE TABLE Analysis(
	AnalysisId INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Name VARCHAR(50),
	State INT NOT NULL,
	AuditCreateDate DATETIME2(7) NOT NULL
)
GO
CREATE TABLE Exams(
	ExamId INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Name VARCHAR(100),
	AnalysisId INT NOT NULL,
	State INT NOT NULL,
	AuditCreateDate DATETIME2(7) NOT NULL,
	FOREIGN KEY (AnalysisId) REFERENCES Analysis(AnalysisId)
)
GO
CREATE OR ALTER PROCEDURE uspAnalysisList 
AS 
BEGIN
	SELECT AnalysisId, Name, AuditCreateDate, State FROM Analysis;
END
GO
CREATE OR ALTER PROCEDURE uspAnalysisById
(
	@AnalysisId INT 
)
AS
BEGIN
	SELECT AnalysisId, Name FROM Analysis WHERE AnalysisId = @AnalysisId;
END
GO
CREATE OR ALTER PROCEDURE uspAnalysisRegister
(
	@Name VARCHAR(50)
)
AS
BEGIN
	INSERT INTO Analysis (Name, State, AuditCreateDate) VALUES (@Name, 1, GETDATE());
END
GO
CREATE OR ALTER PROCEDURE uspAnalysisEdit
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
GO
CREATE OR ALTER PROCEDURE uspAnalysisChangeState
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
GO
CREATE OR ALTER PROCEDURE uspExamList
AS
BEGIN
	SELECT
		ex.ExamId,
		ex.Name,
		a.Name Analysis,
		ex.AuditCreateDate,
		CASE ex.State WHEN 1 THEN 'ACTIVO'
		ELSE 'INACTIVO'
		END StateExam
	FROM Exams ex
	INNER JOIN Analysis a
	ON ex.AnalysisId = a.AnalysisId
END
GO
CREATE OR ALTER PROCEDURE uspExamById
(
	@ExamId INT
)
AS
BEGIN
	SELECT
		ex.ExamId,
		ex.Name,
		ex.AnalysisId
	FROM Exams ex
	WHERE ex.ExamId = @ExamId
END
GO
