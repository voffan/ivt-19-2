-- MySQL dump 10.13  Distrib 8.0.11, for Win64 (x86_64)
--
-- Host: achievenow.crtrvtxtpali.ap-northeast-2.rds.amazonaws.com    Database: AchieveNowDB
-- ------------------------------------------------------
-- Server version	8.0.27

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
 SET NAMES utf8 ;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
SET @MYSQLDUMP_TEMP_LOG_BIN = @@SESSION.SQL_LOG_BIN;

--
-- GTID state at the beginning of the backup 
--


--
-- Table structure for table `AchievementSportsman`
--

DROP TABLE IF EXISTS `AchievementSportsman`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `AchievementSportsman` (
  `AchievementsId` int NOT NULL,
  `SportsmenId` int NOT NULL,
  PRIMARY KEY (`AchievementsId`,`SportsmenId`),
  KEY `IX_AchievementSportsman_SportsmenId` (`SportsmenId`),
  CONSTRAINT `FK_AchievementSportsman_Achievements_AchievementsId` FOREIGN KEY (`AchievementsId`) REFERENCES `Achievements` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_AchievementSportsman_Sportsmen_SportsmenId` FOREIGN KEY (`SportsmenId`) REFERENCES `Sportsmen` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `AchievementSportsman`
--

LOCK TABLES `AchievementSportsman` WRITE;
/*!40000 ALTER TABLE `AchievementSportsman` DISABLE KEYS */;
/*!40000 ALTER TABLE `AchievementSportsman` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Achievements`
--

DROP TABLE IF EXISTS `Achievements`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `Achievements` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `DateOfIssue` date NOT NULL,
  `Results` tinyint unsigned NOT NULL,
  `CompetitionId` int NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Achievements_CompetitionId` (`CompetitionId`),
  CONSTRAINT `FK_Achievements_Competitions_CompetitionId` FOREIGN KEY (`CompetitionId`) REFERENCES `Competitions` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Achievements`
--

LOCK TABLES `Achievements` WRITE;
/*!40000 ALTER TABLE `Achievements` DISABLE KEYS */;
INSERT INTO `Achievements` VALUES (1,'Победитель по стрельбе','2022-05-28',1,3),(2,'Призер по стрельбе','2022-05-28',2,3),(3,'Призер по стрельбе','2022-05-28',3,3),(4,'Победитель по конькобежному спорту','2022-02-18',1,1),(5,'Призер по конькобежному спорту','2022-02-18',2,1),(6,'Призер по конькобежному спорту','2022-02-18',3,1),(7,'Победитель по фигурному катанию','2022-04-09',1,2),(8,'Призер по фигурному катанию','2022-04-09',2,2),(9,'Призер по фигурному катанию','2022-04-09',3,2);
/*!40000 ALTER TABLE `Achievements` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `CompetitionEmployee`
--

DROP TABLE IF EXISTS `CompetitionEmployee`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `CompetitionEmployee` (
  `CompetitionsId` int NOT NULL,
  `EmployeesId` int NOT NULL,
  PRIMARY KEY (`CompetitionsId`,`EmployeesId`),
  KEY `IX_CompetitionEmployee_EmployeesId` (`EmployeesId`),
  CONSTRAINT `FK_CompetitionEmployee_Competitions_CompetitionsId` FOREIGN KEY (`CompetitionsId`) REFERENCES `Competitions` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_CompetitionEmployee_Employees_EmployeesId` FOREIGN KEY (`EmployeesId`) REFERENCES `Employees` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `CompetitionEmployee`
--

LOCK TABLES `CompetitionEmployee` WRITE;
/*!40000 ALTER TABLE `CompetitionEmployee` DISABLE KEYS */;
/*!40000 ALTER TABLE `CompetitionEmployee` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Competitions`
--

DROP TABLE IF EXISTS `Competitions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `Competitions` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Level` int NOT NULL,
  `LocationId` int NOT NULL,
  `SportKindId` int NOT NULL,
  `DateOfExecution` date NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Competitions_LocationId` (`LocationId`),
  KEY `IX_Competitions_SportKindId` (`SportKindId`),
  CONSTRAINT `FK_Competitions_Locations_LocationId` FOREIGN KEY (`LocationId`) REFERENCES `Locations` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_Competitions_SportKinds_SportKindId` FOREIGN KEY (`SportKindId`) REFERENCES `SportKinds` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Competitions`
--

LOCK TABLES `Competitions` WRITE;
/*!40000 ALTER TABLE `Competitions` DISABLE KEYS */;
INSERT INTO `Competitions` VALUES (1,'Соревнование по коньобежному спорту',4,1,1,'2022-02-16'),(2,'Соревнование по фигурному катанию',3,3,1,'2022-04-08'),(3,'Соревнование по стрельбе',1,5,3,'2022-05-25'),(4,'Соревнование по лыжному спорту 2022',2,4,2,'2022-04-10');
/*!40000 ALTER TABLE `Competitions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Employees`
--

DROP TABLE IF EXISTS `Employees`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `Employees` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `PositionId` int NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Employees_PositionId` (`PositionId`),
  CONSTRAINT `FK_Employees_Positions_PositionId` FOREIGN KEY (`PositionId`) REFERENCES `Positions` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Employees`
--

LOCK TABLES `Employees` WRITE;
/*!40000 ALTER TABLE `Employees` DISABLE KEYS */;
/*!40000 ALTER TABLE `Employees` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Locations`
--

DROP TABLE IF EXISTS `Locations`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `Locations` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Locations`
--

LOCK TABLES `Locations` WRITE;
/*!40000 ALTER TABLE `Locations` DISABLE KEYS */;
INSERT INTO `Locations` VALUES (1,'Санкт-Петербург'),(2,'Москва'),(3,'Якутск'),(4,'Екатеринбург'),(5,'Казань');
/*!40000 ALTER TABLE `Locations` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Positions`
--

DROP TABLE IF EXISTS `Positions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `Positions` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Positions`
--

LOCK TABLES `Positions` WRITE;
/*!40000 ALTER TABLE `Positions` DISABLE KEYS */;
/*!40000 ALTER TABLE `Positions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `SportKinds`
--

DROP TABLE IF EXISTS `SportKinds`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `SportKinds` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `SportKinds`
--

LOCK TABLES `SportKinds` WRITE;
/*!40000 ALTER TABLE `SportKinds` DISABLE KEYS */;
INSERT INTO `SportKinds` VALUES (1,'Коньковой спорт'),(2,'Лыжный спорт'),(3,'Стрельба'),(4, 'Бокс'),(5, 'Футбол');
/*!40000 ALTER TABLE `SportKinds` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Sportsmen`
--

DROP TABLE IF EXISTS `Sportsmen`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `Sportsmen` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `DateOfBirth` date NOT NULL,
  `Height` int NOT NULL,
  `Weight` int NOT NULL,
  `Gender` int NOT NULL,
  `SportKindId` int NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Sportsmen_SportKindId` (`SportKindId`),
  CONSTRAINT `FK_Sportsmen_SportKinds_SportKindId` FOREIGN KEY (`SportKindId`) REFERENCES `SportKinds` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Sportsmen`
--

LOCK TABLES `Sportsmen` WRITE;
/*!40000 ALTER TABLE `Sportsmen` DISABLE KEYS */;
INSERT INTO `Sportsmen` VALUES (1, 'Хабиб Макрегор', '1989-06-26', 182, 90, 0, 4),(2, 'Дзюба Криштиану Роналду', '1987-07-21', 196, 86, 0, 5),(3, 'Непряева Наталья Михайловна', '1996-10-07', 169, 63, 1, 2),(4, 'Тимоти Ледюк', '1991-06-05', 185, 78, 2, 1);
/*!40000 ALTER TABLE `Sportsmen` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-03-29  0:46:23
