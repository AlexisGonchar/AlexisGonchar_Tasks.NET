USE universitydb;

/* Subjects */
INSERT INTO subjects (Name) VALUES ('Математика');
INSERT INTO subjects (Name) VALUES ('Философия');
INSERT INTO subjects (Name) VALUES ('Физика');
INSERT INTO subjects (Name) VALUES ('Химия');
INSERT INTO subjects (Name) VALUES ('Политология');
INSERT INTO subjects (Name) VALUES ('Экономика');
INSERT INTO subjects (Name) VALUES ('Основы дизайна');
INSERT INTO subjects (Name) VALUES ('Психология');
INSERT INTO subjects (Name) VALUES ('Социология');

/* Speciality */
INSERT INTO specialty (Name) VALUES ('Информационнные системы и технологии');
INSERT INTO specialty (Name) VALUES ('Промышленная электроника');
INSERT INTO specialty (Name) VALUES ('Информатика и технологии программирования');
INSERT INTO specialty (Name) VALUES ('Игровой дизайн');
INSERT INTO specialty (Name) VALUES ('Промышленные информационные системы');

/* Groups */
INSERT INTO universitydb.`groups` (Name, idSpecialty) VALUES ('ИТ-11', 1);
INSERT INTO universitydb.`groups` (Name, idSpecialty) VALUES ('ИТ-21', 1);
INSERT INTO universitydb.`groups` (Name, idSpecialty) VALUES ('ИТ-31', 1);
INSERT INTO universitydb.`groups` (Name, idSpecialty) VALUES ('ИТ-41', 1);
INSERT INTO universitydb.`groups` (Name, idSpecialty) VALUES ('ПЭ-11', 2);
INSERT INTO universitydb.`groups` (Name, idSpecialty) VALUES ('ПЭ-21', 2);
INSERT INTO universitydb.`groups` (Name, idSpecialty) VALUES ('ПЭ-31', 2);
INSERT INTO universitydb.`groups` (Name, idSpecialty) VALUES ('ПЭ-41', 2);
INSERT INTO universitydb.`groups` (Name, idSpecialty) VALUES ('ИП-11', 3);
INSERT INTO universitydb.`groups` (Name, idSpecialty) VALUES ('ИП-21', 3);
INSERT INTO universitydb.`groups` (Name, idSpecialty) VALUES ('ИП-31', 3);
INSERT INTO universitydb.`groups` (Name, idSpecialty) VALUES ('ИП-41', 3);
INSERT INTO universitydb.`groups` (Name, idSpecialty) VALUES ('ИТИ-11', 4);
INSERT INTO universitydb.`groups` (Name, idSpecialty) VALUES ('ИТИ-21', 4);
INSERT INTO universitydb.`groups` (Name, idSpecialty) VALUES ('ИТИ-31', 4);
INSERT INTO universitydb.`groups` (Name, idSpecialty) VALUES ('ИТИ-41', 4);
INSERT INTO universitydb.`groups` (Name, idSpecialty) VALUES ('ИТП-11', 5);
INSERT INTO universitydb.`groups` (Name, idSpecialty) VALUES ('ИТП-21', 5);
INSERT INTO universitydb.`groups` (Name, idSpecialty) VALUES ('ИТП-31', 5);
INSERT INTO universitydb.`groups` (Name, idSpecialty) VALUES ('ИТП-41', 5);


DECLARE @number INT, @FirstNamePrefix NVARCHAR(40), @MiddleNamePrefix NVARCHAR(40), @LastNamePrefix NVARCHAR(40), @Gender NVARCHAR(20);
DECLARE @year INT, @Month INT, @Day INT, @Date NVARCHAR(12), @GroupId INT;
SET @FirstNamePrefix = 'Fname';
SET @MiddleNamePrefix = 'Mname'
SET @LastNamePrefix = 'Lname';
SET @number = 1;
SET @GroupId = 1;
WHILE @number < 401
	BEGIN
		SET @year = 1985 + ROUND((RAND() * 8), 0);
		SET @Month = ROUND(((RAND() * 11) + 1), 0);
		SET @Day = ROUND(((RAND() * 26) + 1), 0);
		SET @Date = (CONVERT(NVARCHAR, @year) + '-' + CONVERT(NVARCHAR, @Month) + '-' + CONVERT(NVARCHAR, @Day));

			IF (ROUND((RAND() * 10), 0) < 5)
				SET @Gender = 'Male';
			ELSE
				SET @Gender = 'Female';

		INSERT INTO Students (FirstName, MiddleName, LastName, Gender, DateOfBirth, idGroup) 
				VALUES (@FirstNamePrefix + CONVERT(NVARCHAR, @number),
						@SurNamePrefix  + CONVERT(NVARCHAR, @number),
						@PatronymicPrefix + CONVERT(NVARCHAR, @number),
						@Gender, 
						CONVERT(DATETIME, @Date),
						@GroupId);				
		SET @number = @number + 1;
        SET @GroupId = @number DIV 20
	END;