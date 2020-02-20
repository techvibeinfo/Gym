-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: localhost    Database: gym
-- ------------------------------------------------------
-- Server version	5.6.17

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `feestructure`
--

DROP TABLE IF EXISTS `feestructure`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `feestructure` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `addmissionFee` int(11) NOT NULL,
  `monthlyFee8` int(11) NOT NULL,
  `gender` varchar(10) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `feestructure`
--

LOCK TABLES `feestructure` WRITE;
/*!40000 ALTER TABLE `feestructure` DISABLE KEYS */;
INSERT INTO `feestructure` VALUES (1,1000,600,'male'),(2,1500,1000,'female');
/*!40000 ALTER TABLE `feestructure` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `physic`
--

DROP TABLE IF EXISTS `physic`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `physic` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `AdmissionNo` int(11) NOT NULL,
  `Name` varchar(100) NOT NULL,
  `Height` float NOT NULL,
  `Weight` float NOT NULL,
  `Chest` float NOT NULL,
  `Abs` float NOT NULL,
  `Hamstring` float NOT NULL,
  `Biceps` float NOT NULL,
  `Gludes` float NOT NULL,
  `date` date NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `physic`
--

LOCK TABLES `physic` WRITE;
/*!40000 ALTER TABLE `physic` DISABLE KEYS */;
INSERT INTO `physic` VALUES (1,1001,'vaishakh',168,69,66,55,0,0,0,'2018-06-04'),(2,1001,'vaishakh',78,75,88,65,0,0,0,'2018-06-05'),(3,1001,'vaishakh',70,60,65,65,0,0,0,'2018-06-15'),(4,1001,'vaishakh',176,72,86,56,0,0,0,'2018-06-20'),(5,1001,'vaishakh',170,80,65,60,0,0,0,'2018-06-05');
/*!40000 ALTER TABLE `physic` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-02-21  0:03:22
