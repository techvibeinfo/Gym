-- MySqlBackup.NET 2.0.2
-- Dump Time: 2016-10-05 23:31:20
-- --------------------------------------
-- Server version 5.6.21 MySQL Community Server (GPL)


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES latin1 */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- 
-- Definition of feerpt
-- 

DROP TABLE IF EXISTS `feerpt`;
CREATE TABLE IF NOT EXISTS `feerpt` (
  `AdmNo` varchar(6) NOT NULL,
  `Jan` varchar(1) NOT NULL,
  `Feb` varchar(1) NOT NULL,
  `Mar` varchar(1) NOT NULL,
  `Apr` varchar(1) NOT NULL,
  `May` varchar(1) NOT NULL,
  `Jun` varchar(1) NOT NULL,
  `Jul` varchar(1) NOT NULL,
  `Aug` varchar(1) NOT NULL,
  `Sep` varchar(1) NOT NULL,
  `Oct` varchar(1) NOT NULL,
  `Nov` varchar(1) NOT NULL,
  `Decm` varchar(1) NOT NULL,
  PRIMARY KEY (`AdmNo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table feerpt
-- 

/*!40000 ALTER TABLE `feerpt` DISABLE KEYS */;

/*!40000 ALTER TABLE `feerpt` ENABLE KEYS */;

-- 
-- Definition of fees
-- 

DROP TABLE IF EXISTS `fees`;
CREATE TABLE IF NOT EXISTS `fees` (
  `BillNo` int(11) NOT NULL,
  `BillDate` date NOT NULL,
  `AdmissionNo` int(11) NOT NULL,
  `Name` varchar(50) NOT NULL,
  `AmountPaid` int(11) NOT NULL,
  `Balance` int(11) NOT NULL,
  PRIMARY KEY (`BillNo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table fees
-- 

/*!40000 ALTER TABLE `fees` DISABLE KEYS */;

/*!40000 ALTER TABLE `fees` ENABLE KEYS */;

-- 
-- Definition of newaddmission
-- 

DROP TABLE IF EXISTS `newaddmission`;
CREATE TABLE IF NOT EXISTS `newaddmission` (
  `AdmissionNo` int(11) NOT NULL,
  `Name` varchar(50) NOT NULL,
  `Address` text NOT NULL,
  `Gender` varchar(10) NOT NULL,
  `Age` int(11) NOT NULL,
  `Mob` varchar(12) NOT NULL,
  `Job` varchar(50) NOT NULL,
  `BloodGroup` varchar(3) NOT NULL,
  `Sugar` varchar(3) NOT NULL,
  `Pressure` varchar(3) NOT NULL,
  `Cholesterol` varchar(3) NOT NULL,
  `OtherDiseases` varchar(3) NOT NULL,
  `Weight` float NOT NULL,
  `Height` float NOT NULL,
  `Chest` float NOT NULL,
  `Abs` float NOT NULL,
  `MatrialArts` varchar(3) NOT NULL,
  `Development` varchar(20) NOT NULL,
  `Time` varchar(10) NOT NULL,
  `JoingDate` date NOT NULL,
  `AdmFee` int(11) NOT NULL,
  PRIMARY KEY (`AdmissionNo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table newaddmission
-- 

/*!40000 ALTER TABLE `newaddmission` DISABLE KEYS */;
INSERT INTO `newaddmission`(`AdmissionNo`,`Name`,`Address`,`Gender`,`Age`,`Mob`,`Job`,`BloodGroup`,`Sugar`,`Pressure`,`Cholesterol`,`OtherDiseases`,`Weight`,`Height`,`Chest`,`Abs`,`MatrialArts`,`Development`,`Time`,`JoingDate`,`AdmFee`) VALUES
(1001,'Vaisakh','pavithram','Male',21,'919037580016','software','A+','1','0','0','0',150,45,24,22,'0','Body Building','Morning','0001-01-01 00:00:00',600),
(1002,'Anagha','adnds','Female',17,'91234234345','dfgg','AB-','120','Sys','Sys','0',150,40,22,33,'1','Fitness Class','Morning','2016-09-14 00:00:00',600),
(1003,'abi','gfdsgds','Male',23,'9132423432','fg','A+','22','Sys','Sys','0',243,43,4,4,'0','Body Building','Morning','2016-09-24 00:00:00',0),
(1004,'afs','dfd','Male',34,'91234','df','A+','33','3','','0',324,234,234,432,'0','Fitness Class','Morning','2016-09-13 00:00:00',0),
(1005,'dfgh','fd','Male',43,'9143','fghd','A+','fg','','','0',45,54,456,64,'0','Fitness Class','Morning','2016-09-25 00:00:00',0),
(1006,'te','dfg','Male',54,'914','fgh','A-','','','','0',43,34,354,5,'0','Body Building','Morning','2016-09-25 00:00:00',0);
/*!40000 ALTER TABLE `newaddmission` ENABLE KEYS */;


/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;


-- Dump completed on 2016-10-05 23:31:20
-- Total time: 0:0:0:0:89 (d:h:m:s:ms)
