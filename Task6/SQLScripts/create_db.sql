CREATE SCHEMA `universitydb` ;

CREATE TABLE `universitydb`.`groups` (
  `id` INT NOT NULL,
  `Name` VARCHAR(10) NOT NULL,
  PRIMARY KEY (`id`));

CREATE TABLE `universitydb`.`subjects` (
  `id` INT NOT NULL,
  `name` VARCHAR(15) NOT NULL,
  PRIMARY KEY (`id`));

CREATE TABLE `universitydb`.`students` (
  `id` INT NOT NULL,
  `firstName` VARCHAR(15) NOT NULL,
  `middleName` VARCHAR(15) NOT NULL,
  `lastName` VARCHAR(15) NOT NULL,
  `gender` VARCHAR(15) NOT NULL,
  `dateOfBirth` DATE NOT NULL,
  `idGroups` INT NOT NULL,
  PRIMARY KEY (`id`));
  
ALTER TABLE `universitydb`.`students` 
ADD CONSTRAINT `fk_students_groups`
  FOREIGN KEY (`idGroups`)
  REFERENCES `universitydb`.`groups` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;
  
  CREATE TABLE `universitydb`.`schedule` (
  `id` INT NOT NULL,
  `date` DATETIME NOT NULL,
  `idGroups` INT NOT NULL,
  `idSubjects` INT NOT NULL,
  `type` VARCHAR(10) NOT NULL,
  PRIMARY KEY (`id`),
  CONSTRAINT `fk_schedule_groups`
    FOREIGN KEY (`idGroups`)
    REFERENCES `universitydb`.`groups` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_schedule_subjects`
    FOREIGN KEY (`idSubjects`)
    REFERENCES `universitydb`.`subjects` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);

CREATE TABLE `universitydb`.`marks` (
  `id` INT NOT NULL,
  `idStudents` INT NOT NULL,
  `idSchedule` INT NOT NULL,
  `mark` INT NOT NULL,
  PRIMARY KEY (`id`),
  CONSTRAINT `fk_marks_schedule`
    FOREIGN KEY (`idSchedule`)
    REFERENCES `universitydb`.`schedule` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_mark_students`
    FOREIGN KEY (`idStudents`)
    REFERENCES `universitydb`.`students` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);



