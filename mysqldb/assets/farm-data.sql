CREATE SCHEMA `farm-data` DEFAULT CHARACTER SET utf8 ;

USE `farm-data`;

CREATE TABLE `Users` (
  `UserId` int NOT NULL AUTO_INCREMENT,
  `Email` varchar(100) DEFAULT NULL,
  `Name` varchar(45) NOT NULL,
  `Password` varchar(45) NOT NULL,
  PRIMARY KEY (`UserId`),
  UNIQUE KEY `username_UNIQUE` (`Email`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

CREATE TABLE `Roles` (
  `RoleId` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) NOT NULL,
  PRIMARY KEY (`RoleId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

CREATE TABLE `UserRole` (
  `UserId` int NOT NULL,
  `RoleId` int NOT NULL,
  PRIMARY KEY (`UserId`,`RoleId`),
  KEY `id_role_idx` (`RoleId`),
  CONSTRAINT `Roles` FOREIGN KEY (`RoleId`) REFERENCES `Roles` (`RoleId`),
  CONSTRAINT `Users` FOREIGN KEY (`UserId`) REFERENCES `Users` (`UserId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

INSERT INTO `Users` (`UserId`,`Email`,`name`,`password`) VALUES (1,'john@test.com','John Dee','123');
INSERT INTO `Users` (`UserId`,`Email`,`name`,`password`) VALUES (2,'jane@test.com','Jane Doe','123');

INSERT INTO `Roles` (`RoleId`,`Name`) VALUES (1,'admin');
INSERT INTO `Roles` (`RoleId`,`Name`) VALUES (2,'tech-lead');
INSERT INTO `Roles` (`RoleId`,`Name`) VALUES (3,'head');

INSERT INTO `UserRole` (`UserId`,`RoleId`) VALUES (2,1);
INSERT INTO `UserRole` (`UserId`,`RoleId`) VALUES (1,2);
INSERT INTO `UserRole` (`UserId`,`RoleId`) VALUES (2,3);