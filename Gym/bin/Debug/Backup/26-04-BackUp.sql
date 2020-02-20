-- MySqlBackup.NET 2.0.2
-- Dump Time: 2018-04-26 23:56:48
-- --------------------------------------
-- Server version 10.1.10-MariaDB mariadb.org binary distribution


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES latin1 */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- 
-- Definition of expenses
-- 

DROP TABLE IF EXISTS `expenses`;
CREATE TABLE IF NOT EXISTS `expenses` (
  `Id` varchar(10) NOT NULL,
  `Date` date NOT NULL,
  `Type` varchar(100) NOT NULL,
  `Amount` int(11) NOT NULL,
  `Description` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table expenses
-- 

/*!40000 ALTER TABLE `expenses` DISABLE KEYS */;
INSERT INTO `expenses`(`Id`,`Date`,`Type`,`Amount`,`Description`) VALUES
('','2018-03-21 00:00:00','Rent',10000,'');
/*!40000 ALTER TABLE `expenses` ENABLE KEYS */;

-- 
-- Definition of expnccategory
-- 

DROP TABLE IF EXISTS `expnccategory`;
CREATE TABLE IF NOT EXISTS `expnccategory` (
  `id` int(11) NOT NULL,
  `Type` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table expnccategory
-- 

/*!40000 ALTER TABLE `expnccategory` DISABLE KEYS */;
INSERT INTO `expnccategory`(`id`,`Type`) VALUES
(0,'salary'),
(0,'Rent');
/*!40000 ALTER TABLE `expnccategory` ENABLE KEYS */;

-- 
-- Definition of feerpt
-- 

DROP TABLE IF EXISTS `feerpt`;
CREATE TABLE IF NOT EXISTS `feerpt` (
  `AdmNo` varchar(6) NOT NULL,
  `Jan` int(11) NOT NULL,
  `Feb` int(11) NOT NULL,
  `Mar` int(11) NOT NULL,
  `Apr` int(11) NOT NULL,
  `May` int(11) NOT NULL,
  `Jun` int(11) NOT NULL,
  `Jul` int(11) NOT NULL,
  `Aug` int(11) NOT NULL,
  `Sep` int(11) NOT NULL,
  `Oct` int(11) NOT NULL,
  `Nov` int(11) NOT NULL,
  `Decm` int(11) NOT NULL
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
  `BillMonth` varchar(12) NOT NULL,
  `AdmissionNo` int(11) NOT NULL,
  `Name` varchar(50) NOT NULL,
  `AmountPaid` int(11) NOT NULL,
  `Balance` int(11) NOT NULL,
  `year` int(11) NOT NULL,
  `feeToPay` float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table fees
-- 

/*!40000 ALTER TABLE `fees` DISABLE KEYS */;
INSERT INTO `fees`(`BillNo`,`BillDate`,`BillMonth`,`AdmissionNo`,`Name`,`AmountPaid`,`Balance`,`year`,`feeToPay`) VALUES
(100,'2018-02-27 00:00:00','February',1001,'vaishakh',300,100,2018,400),
(101,'2018-04-26 00:00:00','April',1001,'vaishakh',600,0,2018,600),
(102,'2018-04-26 00:00:00','May',1001,'vaishakh',400,200,2018,600),
(103,'2018-04-26 00:00:00','April',1002,'gopika',600,400,2018,600),
(104,'2018-04-26 00:00:00','May',1002,'gopika',500,500,2018,1000),
(105,'2018-04-26 00:00:00','May',1002,'gopika',500,0,2018,1000);
/*!40000 ALTER TABLE `fees` ENABLE KEYS */;

-- 
-- Definition of feestructure
-- 

DROP TABLE IF EXISTS `feestructure`;
CREATE TABLE IF NOT EXISTS `feestructure` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `addmissionFee` int(11) NOT NULL,
  `monthlyFee8` int(11) NOT NULL,
  `gender` varchar(10) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table feestructure
-- 

/*!40000 ALTER TABLE `feestructure` DISABLE KEYS */;
INSERT INTO `feestructure`(`id`,`addmissionFee`,`monthlyFee8`,`gender`) VALUES
(1,1000,600,'male'),
(2,1500,1000,'female');
/*!40000 ALTER TABLE `feestructure` ENABLE KEYS */;

-- 
-- Definition of income
-- 

DROP TABLE IF EXISTS `income`;
CREATE TABLE IF NOT EXISTS `income` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Date` date NOT NULL,
  `Type` varchar(100) NOT NULL,
  `Amount` float NOT NULL,
  `Description` text NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table income
-- 

/*!40000 ALTER TABLE `income` DISABLE KEYS */;
INSERT INTO `income`(`Id`,`Date`,`Type`,`Amount`,`Description`) VALUES
(7,'2018-02-27 00:00:00','water',50,''),
(8,'2018-03-20 00:00:00','water',500,''),
(9,'2018-03-21 00:00:00','Proteen Powder',500,''),
(10,'2018-03-21 00:00:00','water',100,'');
/*!40000 ALTER TABLE `income` ENABLE KEYS */;

-- 
-- Definition of incomecategory
-- 

DROP TABLE IF EXISTS `incomecategory`;
CREATE TABLE IF NOT EXISTS `incomecategory` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Type` varchar(110) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table incomecategory
-- 

/*!40000 ALTER TABLE `incomecategory` DISABLE KEYS */;
INSERT INTO `incomecategory`(`id`,`Type`) VALUES
(8,'water'),
(9,'Proteen Powder');
/*!40000 ALTER TABLE `incomecategory` ENABLE KEYS */;

-- 
-- Definition of login
-- 

DROP TABLE IF EXISTS `login`;
CREATE TABLE IF NOT EXISTS `login` (
  `slno` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) NOT NULL,
  `username` varchar(50) NOT NULL,
  `pwd` varchar(50) NOT NULL,
  PRIMARY KEY (`slno`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table login
-- 

/*!40000 ALTER TABLE `login` DISABLE KEYS */;
INSERT INTO `login`(`slno`,`Name`,`username`,`pwd`) VALUES
(1,'Vaishakhkp','vais','123');
/*!40000 ALTER TABLE `login` ENABLE KEYS */;

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
  `Height` float NOT NULL,
  `Weight` float NOT NULL,
  `Chest` float NOT NULL,
  `Abs` float NOT NULL,
  `MatrialArts` varchar(3) NOT NULL,
  `Development` varchar(20) NOT NULL,
  `Time` varchar(10) NOT NULL,
  `JoingDate` date NOT NULL,
  `AdmFee` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table newaddmission
-- 

/*!40000 ALTER TABLE `newaddmission` DISABLE KEYS */;
INSERT INTO `newaddmission`(`AdmissionNo`,`Name`,`Address`,`Gender`,`Age`,`Mob`,`Job`,`BloodGroup`,`Sugar`,`Pressure`,`Cholesterol`,`OtherDiseases`,`Height`,`Weight`,`Chest`,`Abs`,`MatrialArts`,`Development`,`Time`,`JoingDate`,`AdmFee`) VALUES
(1001,'vaishakh','kavumpoyil','Male',24,'918943690506','','AB+','','','','0',168,72,86,86,'0','Body Building','Morning','2018-02-27 00:00:00',1000),
(1002,'gopika','afeff','Female',21,'918943690506','','A+','','','','0',172,45,66,66,'0','Fitness Class','Morning','2018-04-26 00:00:00',1500);
/*!40000 ALTER TABLE `newaddmission` ENABLE KEYS */;


/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;


-- Dump completed on 2018-04-26 23:56:48
-- Total time: 0:0:0:0:508 (d:h:m:s:ms)
