DROP DATABASE `universitydb`;
CREATE SCHEMA `universitydb` ;

CREATE TABLE `universitydb`.`specialty`(
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(40) NOT NULL,
  PRIMARY KEY (`id`));

CREATE TABLE `universitydb`.`groups` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(10) NOT NULL,
  `idSpecialty` INT NOT NULL,
  PRIMARY KEY (`id`),
  CONSTRAINT `fk_groups_specialty`
    FOREIGN KEY (`idSpecialty`)
    REFERENCES `universitydb`.`specialty` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);

CREATE TABLE `universitydb`.`subjects` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(40) NOT NULL,
  PRIMARY KEY (`id`));

CREATE TABLE `universitydb`.`examinators`(
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(25) NOT NULL,
  PRIMARY KEY (`id`));
  
CREATE TABLE `universitydb`.`students` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `firstName` VARCHAR(15) NOT NULL,
  `middleName` VARCHAR(15) NOT NULL,
  `lastName` VARCHAR(15) NOT NULL,
  `gender` VARCHAR(15) NOT NULL,
  `dateOfBirth` DATE NOT NULL,
  `idGroup` INT NOT NULL,
  PRIMARY KEY (`id`));
  
ALTER TABLE `universitydb`.`students` 
ADD CONSTRAINT `fk_students_groups`
  FOREIGN KEY (`idGroup`)
  REFERENCES `universitydb`.`groups` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;
  
  CREATE TABLE `universitydb`.`exams` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `date` DATE NOT NULL,
  `idGroup` INT NOT NULL,
  `idSubject` INT NOT NULL,
  `idExaminator` INT NOT NULL,
  `type` VARCHAR(10) NOT NULL,
  `numberOfSession` INT NOT NULL,
  PRIMARY KEY (`id`),
  CONSTRAINT `fk_exams_groups`
    FOREIGN KEY (`idGroup`)
    REFERENCES `universitydb`.`groups` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_exams_subjects`
    FOREIGN KEY (`idSubject`)
    REFERENCES `universitydb`.`subjects` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_exams_examinators`
    FOREIGN KEY (`idExaminator`)
    REFERENCES `universitydb`.`examinators` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);

CREATE TABLE `universitydb`.`results` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `idStudent` INT NOT NULL,
  `idExam` INT NOT NULL,
  `mark` INT NOT NULL,
  PRIMARY KEY (`id`),
  CONSTRAINT `fk_results_exams`
    FOREIGN KEY (`idExam`)
    REFERENCES `universitydb`.`exams` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_results_students`
    FOREIGN KEY (`idStudent`)
    REFERENCES `universitydb`.`students` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);
    
DROP TRIGGER IF EXISTS `universitydb`.`results_BEFORE_INSERT`;

DELIMITER $$
USE `universitydb`$$
CREATE DEFINER = CURRENT_USER TRIGGER `universitydb`.`results_BEFORE_INSERT` BEFORE INSERT ON `results` FOR EACH ROW
BEGIN
	declare amount int;
    set @amount = 0;
    set @amount = (select count(idExam) from results where idStudent = new.idStudent and idExam = new.idExam);
    if(@amount > 0) then
     signal sqlstate '02000' set message_text = 'This student has already passed this exam.';
	end if;
END$$
DELIMITER ;



