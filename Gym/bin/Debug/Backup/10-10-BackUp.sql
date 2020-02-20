-- MySqlBackup.NET 2.0.2
-- Dump Time: 2016-10-10 01:05:06
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
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Date` date NOT NULL,
  `Type` varchar(100) NOT NULL,
  `Amount` int(11) NOT NULL,
  `Description` varchar(100) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table expenses
-- 

/*!40000 ALTER TABLE `expenses` DISABLE KEYS */;
INSERT INTO `expenses`(`Id`,`Date`,`Type`,`Amount`,`Description`) VALUES
(3,'2016-10-09 00:00:00','Salary',5000,''),
(4,'2016-10-09 00:00:00','Salary',2000,''),
(5,'2016-10-09 00:00:00','Salary',10000,''),
(6,'2016-10-12 00:00:00','Salary',300,'');
/*!40000 ALTER TABLE `expenses` ENABLE KEYS */;

-- 
-- Definition of expnccategory
-- 

DROP TABLE IF EXISTS `expnccategory`;
CREATE TABLE IF NOT EXISTS `expnccategory` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Type` varchar(100) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table expnccategory
-- 

/*!40000 ALTER TABLE `expnccategory` DISABLE KEYS */;
INSERT INTO `expnccategory`(`id`,`Type`) VALUES
(1,'Salary');
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
  `Decm` int(11) NOT NULL,
  PRIMARY KEY (`AdmNo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table feerpt
-- 

/*!40000 ALTER TABLE `feerpt` DISABLE KEYS */;
INSERT INTO `feerpt`(`AdmNo`,`Jan`,`Feb`,`Mar`,`Apr`,`May`,`Jun`,`Jul`,`Aug`,`Sep`,`Oct`,`Nov`,`Decm`) VALUES
('1001',0,0,0,0,0,0,0,0,0,0,0,0),
('1002',0,0,0,0,0,0,0,350,350,0,0,0),
('1003',0,0,0,0,0,0,0,0,0,0,0,0),
('1004',0,0,0,0,0,0,0,0,0,0,0,0),
('1005',0,0,0,0,0,0,0,0,0,0,0,0),
('1006',0,0,0,0,0,0,0,0,0,0,0,0),
('1007',0,0,0,0,0,0,0,0,0,0,0,0),
('1008',0,0,0,0,0,0,0,0,0,0,0,0),
('1009',0,0,0,0,0,0,0,0,0,0,0,0),
('1010',0,0,0,0,0,0,0,0,0,0,0,0),
('1011',0,0,0,0,0,0,0,0,0,0,0,0),
('1012',0,0,0,0,0,0,0,0,0,0,0,0),
('1013',0,0,0,0,0,0,0,0,0,0,0,0),
('1014',0,0,0,0,0,0,0,0,0,0,0,0),
('1015',0,0,0,0,0,0,0,0,0,0,0,0),
('1016',0,0,0,0,0,0,0,0,0,0,0,0),
('1017',0,0,0,0,0,0,0,0,0,0,0,0),
('1018',0,0,0,0,0,0,0,0,0,0,0,0),
('1019',0,0,0,0,0,0,0,0,0,0,0,0),
('1020',0,0,0,0,0,0,0,0,0,0,0,0),
('1021',0,0,0,0,0,0,0,0,0,0,0,0),
('1022',0,0,0,0,0,0,0,0,0,0,0,0),
('1023',0,0,0,0,0,0,0,0,0,0,0,0),
('1024',0,0,0,0,0,0,0,0,0,0,0,0),
('1025',0,0,0,0,0,0,0,0,0,0,0,0),
('1026',0,0,0,0,0,0,0,0,0,0,0,0),
('1027',0,0,0,0,0,0,0,0,0,0,0,0),
('1028',0,0,0,0,0,0,0,0,0,0,0,0),
('1029',0,0,0,0,0,0,0,0,0,0,0,0),
('1030',0,0,0,0,0,0,0,0,0,0,0,0),
('1031',0,0,0,0,0,0,0,0,0,0,0,0),
('1032',0,0,0,0,0,0,0,0,0,0,0,0),
('1033',0,0,0,0,0,0,0,0,0,0,0,0),
('1034',0,0,0,0,0,0,0,0,0,0,0,0),
('1035',0,0,0,0,0,0,0,0,0,0,0,0),
('1036',0,0,0,0,0,0,0,0,0,0,0,0),
('1037',0,0,0,0,0,0,0,0,0,0,0,0),
('1038',0,0,0,0,0,0,0,0,0,0,0,0),
('1039',0,0,0,0,0,0,0,0,0,0,0,0),
('1040',0,0,0,0,0,0,0,0,0,0,0,0),
('1041',0,0,0,0,0,0,0,0,0,0,0,0),
('1042',0,0,0,0,0,0,0,0,0,0,0,0),
('1043',0,0,0,0,0,0,0,0,0,0,0,0),
('1044',0,0,0,0,0,0,0,0,0,0,0,0),
('1045',0,0,0,0,0,0,0,0,0,0,0,0),
('1046',0,0,0,0,0,0,0,0,0,0,0,0),
('1047',0,0,0,0,0,0,0,0,0,0,0,0),
('1048',0,0,0,0,0,0,0,0,0,0,0,0),
('1049',0,0,0,0,0,0,0,0,0,0,0,0),
('1050',0,0,0,0,0,0,0,0,0,0,0,0),
('1051',0,0,0,0,0,0,0,0,0,0,0,0),
('1052',0,0,0,0,0,0,0,0,0,0,0,0),
('1053',0,0,0,0,0,0,0,0,0,0,0,0),
('1054',0,0,0,0,0,0,0,0,0,0,0,0),
('1055',0,0,0,0,0,0,0,0,0,0,0,0),
('1056',0,0,0,0,0,0,0,0,0,0,0,0),
('1057',0,0,0,0,0,0,0,0,0,0,0,0),
('1058',0,0,0,0,0,0,0,0,0,0,0,0),
('1059',0,0,0,0,0,0,0,0,0,0,0,0),
('1060',0,0,0,0,0,0,0,0,0,0,0,0),
('1061',0,0,0,0,0,0,0,0,0,0,0,0),
('1062',0,0,0,0,0,0,0,0,0,0,0,0),
('1063',0,0,0,0,0,0,0,0,0,0,0,0),
('1064',0,0,0,0,0,0,0,0,0,0,0,0),
('1065',0,0,0,0,0,0,0,0,0,0,0,0),
('1066',0,0,0,0,0,0,0,0,0,0,0,0),
('1067',0,0,0,0,0,0,0,0,0,0,0,0),
('1068',0,0,0,0,0,0,0,0,0,0,0,0),
('1069',0,0,0,0,0,0,0,0,0,0,0,0),
('1070',0,0,0,0,0,0,0,0,0,0,0,0),
('1071',0,0,0,0,0,0,0,0,0,0,0,0),
('1072',0,0,0,0,0,0,0,0,0,0,0,0),
('1073',0,0,0,0,0,0,0,0,0,0,0,0),
('1074',0,0,0,0,0,0,0,0,0,0,0,0),
('1075',0,0,0,0,0,0,0,0,0,0,0,0),
('1076',0,0,0,0,0,0,0,0,0,0,0,0),
('1077',0,0,0,0,0,0,0,0,0,0,0,0),
('1078',0,0,0,0,0,0,0,0,0,0,0,0),
('1079',0,0,0,0,0,0,0,0,0,0,0,0),
('1080',0,0,0,0,0,0,0,0,0,0,0,0),
('1081',0,0,0,0,0,0,0,0,0,0,0,0),
('1082',0,0,0,0,0,0,0,0,0,0,0,0),
('1083',0,0,0,0,0,0,0,0,0,0,0,0),
('1084',0,0,0,0,0,0,0,0,0,0,0,0),
('1085',0,0,0,0,0,0,0,0,0,0,0,0),
('1086',0,0,0,0,0,0,0,0,0,0,0,0),
('1087',0,0,0,0,0,0,0,0,0,0,0,0),
('1088',0,0,0,0,0,0,0,0,0,0,0,0),
('1089',0,0,0,0,0,0,0,0,0,0,0,0),
('1090',0,0,0,0,0,0,0,0,0,0,0,0),
('1091',0,0,0,0,0,0,0,0,0,0,0,0),
('1092',0,0,0,0,0,0,0,0,0,0,0,0),
('1093',0,0,0,0,0,0,0,0,0,0,0,0),
('1094',0,0,0,0,0,0,0,0,0,0,0,0),
('1095',0,0,0,0,0,0,0,0,0,0,0,0),
('1096',0,0,0,0,0,0,0,0,0,0,0,0),
('1097',0,0,0,0,0,0,0,0,0,0,0,0),
('1098',0,0,0,0,0,0,0,0,0,0,0,0),
('1099',0,0,0,0,0,0,0,0,0,0,0,0),
('1100',0,0,0,0,0,0,0,0,0,0,0,0),
('1101',0,0,0,0,0,0,0,0,0,0,0,0),
('1102',0,0,0,0,0,0,0,0,0,0,0,0),
('1103',0,0,0,0,0,0,0,0,0,0,0,0),
('1104',0,0,0,0,0,0,0,0,0,0,0,0),
('1105',0,0,0,0,0,0,0,0,0,0,0,0),
('1106',0,0,0,0,0,0,0,0,0,0,0,0),
('1107',0,0,0,0,0,0,0,0,0,0,0,0),
('1108',0,0,0,0,0,0,0,0,0,0,0,0),
('1109',0,0,0,0,0,0,0,0,0,0,0,0),
('1110',0,0,0,0,0,0,0,0,0,0,0,0),
('1111',0,0,0,0,0,0,0,0,0,0,0,0),
('1112',0,0,0,0,0,0,0,0,0,0,0,0),
('1113',0,0,0,0,0,0,0,0,0,0,0,0),
('1114',0,0,0,0,0,0,0,0,0,0,0,0),
('1115',0,0,0,0,0,0,0,0,0,0,0,0),
('1116',0,0,0,0,0,0,0,0,0,0,0,0),
('1117',0,0,0,0,0,0,0,0,0,0,0,0),
('1118',0,0,0,0,0,0,0,0,0,0,0,0),
('1119',0,0,0,0,0,0,0,0,0,0,0,0),
('1120',0,0,0,0,0,0,0,0,0,0,0,0),
('1121',0,0,0,0,0,0,0,0,0,0,0,0),
('1122',0,0,0,0,0,0,0,0,0,0,0,0),
('1123',0,0,0,0,0,0,0,0,0,0,0,0),
('1124',0,0,0,0,0,0,0,0,0,0,0,0),
('1125',0,0,0,0,0,0,0,0,0,0,0,0),
('1126',0,0,0,0,0,0,0,0,0,0,0,0),
('1127',0,0,0,0,0,0,0,0,0,0,0,0),
('1128',0,0,0,0,0,0,0,0,0,0,0,0),
('1129',0,0,0,0,0,0,0,0,0,0,0,0),
('1130',0,0,0,0,0,0,0,0,0,0,0,0),
('1131',0,0,0,0,0,0,0,0,0,0,0,0),
('1132',0,0,0,0,0,0,0,0,0,0,0,0),
('1133',0,0,0,0,0,0,0,0,0,0,0,0),
('1134',0,0,0,0,0,0,0,0,0,0,0,0),
('1135',0,0,0,0,0,0,0,0,0,0,0,0),
('1136',0,0,0,0,0,0,0,0,0,0,0,0);
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
  PRIMARY KEY (`BillNo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table fees
-- 

/*!40000 ALTER TABLE `fees` DISABLE KEYS */;
INSERT INTO `fees`(`BillNo`,`BillDate`,`BillMonth`,`AdmissionNo`,`Name`,`AmountPaid`,`Balance`) VALUES
(100,'2016-10-06 00:00:00','',1120,'ASHOK KUMAR',300,50),
(101,'2016-10-09 00:00:00','September',1001,'ARUN KP',100,250),
(102,'2016-10-09 00:00:00','September',1001,'ARUN KP',200,50),
(103,'2016-10-09 00:00:00','September',1001,'ARUN KP',50,0),
(104,'2016-10-09 00:00:00','October',1001,'ARUN KP',350,0),
(105,'2016-10-10 00:00:00','Auguest',1002,'SUJIN DAS KP',350,0),
(106,'2016-10-10 00:00:00','September',1002,'SUJIN DAS KP',200,150),
(107,'2016-10-10 00:00:00','September',1002,'SUJIN DAS KP',150,0);
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
  `Height` float NOT NULL,
  `Weight` float NOT NULL,
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
INSERT INTO `newaddmission`(`AdmissionNo`,`Name`,`Address`,`Gender`,`Age`,`Mob`,`Job`,`BloodGroup`,`Sugar`,`Pressure`,`Cholesterol`,`OtherDiseases`,`Height`,`Weight`,`Chest`,`Abs`,`MatrialArts`,`Development`,`Time`,`JoingDate`,`AdmFee`) VALUES
(1001,'ARUN KP','kinarullaparambath\r\nadukath po\r\nkuttiady\r\n\r\n','Male',19,'918111189265','student','B+','','','0','0',74,166,90,90,'0','Body Building','Morning','2016-08-04 00:00:00',600),
(1002,'SUJIN DAS KP','Kunjiparambath\r\nadukath\r\nkuttiadi\r\n','Male',16,'919072074334','student plus two','O+','','0','0','0',170,98,113,115,'0','Fitness Class','Morning','2016-01-04 00:00:00',600),
(1003,'ABID K','Kmmarani\r\nvelom\r\nsanthinagar','Male',22,'918086112508','gulf','','','0','0','0',174,56,84,0,'0','Body Building','Morning','2016-04-01 00:00:00',600),
(1004,'ASLAM T','THURAKKAL\r\nVELOM\r\nSANTHINAGAR\r\n','Male',18,'919745344020','STUDENT','','','0','0','0',175,68,88,0,'0','Body Building','Morning','2016-01-04 00:00:00',600),
(1005,'ROBE SK','KALKKATHA\r\nSIRAJULHUDA KUTTIADY\r\n\r\n','Male',22,'918086517256','MEASON','','','0','0','0',164,56,89,0,'0','Body Building','Morning','2016-02-04 00:00:00',600),
(1006,'FAISAL EK','KUNNOTH\r\nVELOM\r\nPERUVAYAL\r\n','Male',21,'919747439405','SALES MEN PERAMBRA','B+','','0','0','0',169,53,81.85,0,'0','Body Building','Morning','2016-04-04 00:00:00',600),
(1007,'RUN KK','KATTANKODUMMAL PALERI KUTTIADY','Male',24,'919048872946','BANK SAHAKRANA','','','0','0','0',170,83,97.99,104,'0','Body Building','Morning','2016-04-04 00:00:00',600),
(1008,'SABINESH KM','KUNNOTHMEETHAL\r\nPOOLAKKOOL KAKKTTIL','Male',23,'919847512261','BELDING AYENCHERI','B+','','0','0','0',165,54,85.82,0,'0','Body Building','Morning','2016-04-04 00:00:00',600),
(1009,'SAMMYAKADAS','KARAMKOT \r\nMOILOTHARA \r\nMARUTHOMKARA','Male',16,'919633302302','STUDENT','','','0','0','0',162,50,75.78,0,'0','Fitness Class','Morning','2016-04-04 00:00:00',600),
(1010,'FAVAS CV','CV HOUSE\r\nMOKERI\r\n','Male',27,'919495493612','GULF','','','0','0','0',176,95,102,109,'0','Fitness Class','Morning','2016-05-04 00:00:00',600),
(1011,'AGIL KK','KNNOTHKAVIL\r\nVADAYAM\r\nKAKKATIL','Male',16,'917034420093','STUDENT PLUS TWO','','','0','0','0',172,52,79.81,0,'0','Body Building','Morning','2016-06-04 00:00:00',600),
(1012,'ASHAD CP','CHEELIPARAMBATH\r\nPALERI\r\nKUTTIDY\r\n','Male',24,'919995792388','GULF','','','0','0','0',172,75,90.92,0,'0','Body Building','Morning','2016-06-04 00:00:00',600),
(1013,'NIVED PRADEEP','NELIULLAPARAMBATH\r\nCHATHANKOTTUNADA\r\nKAVILUMPARA\r\n','Male',16,'919526003881','STUDENT','','','0','0','0',170,77,90,100,'0','Fitness Class','Morning','2016-06-04 00:00:00',600),
(1014,'REBEEH E','ELLIYATTUMAL\r\nVELOM\r\nSANTHINAGAR\r\n','Male',18,'9195','STUDENT','','','0','0','0',160,46,76.79,0,'0','Body Building','Morning','2016-08-04 00:00:00',600),
(1015,'AMALGITH VP','VELLAPOTTIL\r\nPOOLKOOL\r\nKAKKAT','Male',18,'918281211060','STUDENT','','','0','0','0',166,54,80.83,0,'0','Body Building','Morning','2016-08-04 00:00:00',600),
(1016,'RENJISH KP','KARIKKADANPOYIL\r\nMOILOTHARA\r\nKAVILUMPARA','Male',37,'919746514383','SALES MEN','','','0','0','0',171,71,94.96,0,'0','Fitness Class','Morning','2016-09-04 00:00:00',600),
(1017,'FASIL PP','PUTHIYOTTILPARAMBIL\r\nPALERI\r\nPARAKADAV\r\n','Male',22,'919048295617','STUDENT','O+','','0','0','0',173,45,73.79,0,'0','Body Building','Morning','2016-11-04 00:00:00',600),
(1018,'MUHAMMED ASHIFAG','PUTHIYOTTIL\r\nPALERY\r\nPARAKADAV','Male',18,'919745176810','STUDENT PLUS TWO','','','0','0','0',175,57,75.78,0,'0','Body Building','Morning','2016-11-04 00:00:00',600),
(1019,'MUHAMMED RUSTHU','VALLIL\r\nKAVILUMPARA\r\nTHOTTILPALAM','Male',18,'919544181881','STUDENT PLUS TWO','B+','','0','0','0',176,58,0,0,'0','Body Building','Morning','2016-11-04 00:00:00',600),
(1020,'JASEEM K','KUNIYIL\r\nKAYAKODI\r\nKUTTIDY','Male',24,'919539210767','GULF','O+','','0','0','0',181,77,94.97,92,'0','Body Building','Morning','2016-11-04 00:00:00',600),
(1021,'NAJMAL KP','KANIYANTEPARAMBATH\r\nKUTTIADY\r\nVADAKARA','Male',25,'919846856701','STUDENT','','','0','0','0',176,87,103.105,106,'0','Fitness Class','Morning','2016-11-04 00:00:00',600),
(1022,'KATHIR SET','KALKATHA\r\nKUTTIDY\r\nKKH ROOM','Male',20,'918136988572','NO','','','0','0','0',168,57,89,0,'0','Body Building','Morning','2016-11-04 00:00:00',600),
(1023,'JEMSHID V','VAZHAYIL\r\nKAVILUMPARA\r\nAASWASI\r\n\r\n','Male',20,'919995959816','NO','O+','','0','0','0',178,57,81.88,0,'0','Body Building','Morning','2016-11-04 00:00:00',600),
(1024,'AJMAL KC','KAPPUMCHLIL\r\nKAYAKODI\r\n','Male',22,'919846072445','NO','','','0','0','0',180,75,84.89,0,'0','Body Building','Morning','2016-12-04 00:00:00',600),
(1025,'HAIDARMUHUSIN KE','KANDOTHELLATH\r\nKUTTIADY\r\n','Male',17,'919747046161','STUDANT','O+','','0','0','0',189,64,85.9,0,'0','Body Building','Morning','2016-12-04 00:00:00',600),
(1026,'SEFEER PV','THERUVATH\r\nKUTTIDY\r\n\r\n','Male',17,'919605012639','STUDENT','A+','','0','0','0',178,60,85.88,0,'0','Body Building','Morning','2016-12-04 00:00:00',600),
(1027,'NIHALSHA ','KOTTOLAKKAL\r\nKAYAKODI\r\n','Male',17,'919048188589','STUDENT','','','0','0','0',172,60,85.9,0,'0','Body Building','Morning','2016-12-04 00:00:00',600),
(1028,'AKIL TK','THEEYARKANDY\r\nADUKATH\r\nKUTTIADY\r\n','Male',21,'918086157212','WAIRING','O+','','0','0','0',168,44,73.75,0,'0','Body Building','Morning','2016-12-04 00:00:00',600),
(1029,'SHAKKIFUL','KALKATTA\r\nMOOSHIDABATH','Male',20,'918136988510','CONCREAT','','','0','0','0',160,55,87.9,0,'0','Body Building','Morning','2016-12-04 00:00:00',600),
(1030,'SADAM ','KALKATTA','Male',22,'918136988510','CONCREAT','','','0','0','0',169,61,87.89,0,'0','Body Building','Morning','2016-12-04 00:00:00',600),
(1031,'HEMANTH C','CHAMBOTTUMMAL\r\nKUNDUTHODE\r\nKAVILUMPARA','Male',21,'919947234726','STUDENT','O+','','0','0','0',169,59,87.92,0,'0','Body Building','Morning','2016-12-04 00:00:00',600),
(1032,'SAJITH PP','POOVULLAPARAMBIL\r\nPOOLAKOOL\r\nKATTIL\r\n\r\n\r\n','Male',31,'919745935783','TILS WORK','O+','','0','0','0',172,63,88.89,0,'0','Body Building','Morning','2016-12-04 00:00:00',600),
(1033,'ALFAS P','PUTHALATH\r\nTHALIYIL\r\nKUTTIADY','Male',19,'919633819867','STUDENT','B+','','0','0','0',161,67,87.9,0,'0','Fitness Class','Morning','2016-12-04 00:00:00',600),
(1034,'MUBASHHER VP','VATTAPOYIL\r\nAAKAL\r\nKAVILUMPARA','Male',20,'919747390084','STUDENT GRAFIC DISINGER','A+','','0','0','0',171,47,78.82,0,'0','Body Building','Morning','2016-12-04 00:00:00',600),
(1035,'SUBINKUMR','CHERUKUNNUMMAL\r\nKAVILUMPARA\r\nTHOTTILPALAM','Male',21,'918129228805','STUDENT','O+','','0','0','0',170,53,80.83,0,'0','Body Building','Morning','2016-12-04 00:00:00',600),
(1036,'ATHUL  AS','VADAKKANVILLA\r\nKAVILUMPARA\r\nTHOTTILPALAM\r\n','Male',20,'919539575030','TUDENT','O+','','0','0','0',169,53,79.83,0,'0','Body Building','Morning','2016-12-04 00:00:00',600),
(1037,'MUHAMMENOUSHAD KK','KK HOUSE\r\nKAVILUMPARA\r\nTHOTTILPALAM\r\n','Male',18,'919747865938','STUDENT','','','0','0','0',176,57,78.81,0,'0','Body Building','Morning','2016-12-04 00:00:00',600),
(1038,'VAISHAK EK','ADAKOTTUMMAL\r\nADUKKATH\r\nKUTTIADY','Male',24,'918943612640','STUDENT','B+','','0','0','0',179,77,104.106,100,'0','Fitness Class','Morning','2016-12-04 00:00:00',600),
(1039,'MOIDU ','PALLITHAZHA\r\nMRUTHOMKARA\r\nKAVILUMPARA\r\n','Male',46,'91908812090','POLICE','B+','','0','0','0',175,96,109,107,'0','Fitness Class','Morning','2016-12-04 00:00:00',600),
(1040,'RISWANMUHAMMED','MYSOOR\r\n','Male',23,'919744221397','BELDING WORK','O+','','0','0','0',163,49,81.82,0,'0','Body Building','Morning','2016-12-04 00:00:00',600),
(1041,'BADUSHA PK','PALLIYARAKANDI\r\nADUKKATH\r\nKALLAD\r\n','Male',18,'918547100154','STUDENT','O+','','0','0','0',183,63,87.89,0,'0','Body Building','Morning','2016-12-04 00:00:00',600),
(1042,'MANOJ ','MYSOOR\r\nBAMBOO HOTEL','Male',28,'919740504389','HOTEL','','','0','0','0',160,61,90.91,84,'0','Body Building','Morning','2016-12-04 00:00:00',600),
(1043,'AANAD ','MYSOR\r\nBABOO HOTEL','Male',25,'917356438019','HOTEL','','','0','0','0',163,59,87.88,0,'0','Weight Reduce ','Morning','2016-12-04 00:00:00',600),
(1044,'HAREESH KUMAR','KAPPIPARAMBATH\r\nMARUTHOMKARA\r\nKAVILUMPARA\r\n','Male',29,'919995507557','ENGINEARING','O+','','0','0','0',178,79.6,98.101,98,'0','Fitness Class','Morning','2016-12-04 00:00:00',600),
(1045,'MEHABOOB','BEEHAR\r\nURATH\r\n','Male',25,'919633942973','TILE WORK','','','0','0','0',170,61,81.83,0,'0','Fitness Class','Morning','2016-12-04 00:00:00',600),
(1046,'AASHIR A','AAYANOLI\r\nVELOM\r\nKUTTIADY','Male',23,'919048164163','WAIRING','A+','','0','0','0',170,74,94.96,0,'0','Fitness Class','Morning','2016-12-04 00:00:00',600),
(1047,'SHAMSHAD CM','CHERIYAMUNDIYODI\r\nVELOM\r\nKUTTIADY\r\n','Male',24,'919048068011','CIVIL ENGINEARING','A+','','0','0','0',164,63,91.93,85,'0','Fitness Class','Morning','2016-12-04 00:00:00',600),
(1048,'ASHINJITH','MEETHALECHERUVATHIRA\r\nKURIVHIKAM\r\nKUTTIADI','Male',19,'919946462257','BELDDING WORK','B+','','0','0','0',170,66.3,87.88,0,'0','Fitness Class','Morning','2016-12-04 00:00:00',600),
(1049,'SOORAJ TK','KALLULLAKANDI\r\nAROOR\r\nKAKKATTIL','Male',23,'919946094635','OFFICE WORK','B+','','0','0','0',170,68,87.9,88,'0','Fitness Class','Morning','2016-12-04 00:00:00',600),
(1050,'SHAMSEER A','AAYADATHIL\r\nKAMMOM\r\nWYANAD\r\n','Male',24,'919539109983','SALESMAN','O+','','0','0','0',166,72.8,97.98,95,'0','Fitness Class','Morning','2016-12-04 00:00:00',600),
(1051,'DASHID MM','MOLORMANNIL\r\nKUTTIADY\r\nVADAKARA','Male',23,'918129681812','DEGREE','A+','','0','0','0',160,49,81.84,0,'0','Fitness Class','Morning','2016-12-04 00:00:00',600),
(1052,'ARUNGITH T','POOLAKANDI\r\nAKKAL\r\nKAVILUMPARA','Male',22,'919539554143','PAINTING','B+','','0','0','0',68,168,89.93,85,'0','Fitness Class','Morning','2016-12-04 00:00:00',600),
(1053,'SUDEESH C','CHELLADACHERI\r\nADUKATH\r\nKUTTIADY\r\n\r\n','Male',21,'918592007471','PAITING','','','0','0','0',164,59,85.86,78,'0','Fitness Class','Morning','2016-12-04 00:00:00',600),
(1054,'SABITH TK','THALAMKUNNATH\r\nKALLACHI\r\nNADAPURAM','Male',17,'919800552444','STUDENT PLUS TWO','','','0','0','0',175,78,97.99,99,'0','Fitness Class','Morning','2016-12-04 00:00:00',600),
(1055,'JUNAID K','KOGOTTUMMAL\r\nKADIYAGAD\r\nPERAMBRA','Male',15,'919605339323','STUDENT','O+','','0','0','0',172,65,87.89,0,'0','Weight Reduce ','Morning','2016-12-04 00:00:00',600),
(1056,'HARI ABDUNASAR ','KANDIYIL\r\nKUTTIADY\r\nNEAR GHSS','Male',23,'918129997162','SPORTS MAN','B+','','0','0','0',175,58,86.88,0,'0','Body Building','Morning','2016-12-04 00:00:00',600),
(1057,'BASIMALI','MUNDABATH\r\nURATH\r\nKUTTIADY','Male',19,'919846049498','STUDENT ELECRICAL ENGINEARING','','','0','0','0',168,56,82.85,0,'0','Body Building','Morning','2016-12-04 00:00:00',600),
(1058,'TOIS ET','ELASSERY\r\nCHATHANKOTTUNADA\r\nKAVLUMPARA\r\n','Male',22,'919645524909','STUDENT','O+','','','','0',171,66,84.88,0,'0','Weight Reduce ','Morning','2016-05-02 00:00:00',600),
(1059,'JIJO KM','KADUTHALAKUNNEL\r\nCHATHANKOTTUNADA\r\nKAVILUMPARA','Male',23,'919744734851','STUDENT','AB+','','','','0',166,49,83.88,0,'0','Weight Reduce ','Morning','2016-05-02 00:00:00',600),
(1060,'JIJIN PK','POOTHAKANDY\r\nADUKATH\r\nKUTTIADY\r\n','Male',24,'919961893014','MEASON','O+','','','','0',163,49,78.81,0,'0','Weight Reduce ','Morning','2016-05-02 00:00:00',600),
(1061,'SIYAD ','AKKAVALAPPIL\r\nAKKAL','Male',26,'91974599313','GULF','','','','','0',178,70,90.91,0,'0','Weight Reduce ','Morning','2016-05-02 00:00:00',600),
(1062,'VAISHAK C','KANJIRAKUNNUMMAL\r\nADUKKATH\r\nKUTTIADY','Male',24,'919567916056','STUDENT','B+','','','','0',167,55,84.86,0,'0','Weight Reduce ','Morning','2016-05-02 00:00:00',600),
(1063,'AGIL VK','VALAYAMKOTTUMMAL\r\nPUNATHIL\r\nADUKATH\r\n','Male',20,'91984731180','PAITTING','B+','','','','0',158,62,85.87,87,'0','Weight Reduce ','Morning','2016-05-02 00:00:00',600),
(1064,'SWAMI','BAMBO HOTEL','Male',30,'919048155038','HOTTEL','','','','','0',0,63,90.91,90,'0','Weight Reduce ','Morning','2016-05-02 00:00:00',600),
(1065,'SARANG K','VANATH\r\nKADIYAGAD\r\nPERAMBRA','Male',17,'919947002956','STUDENT','O+','','','','0',163,48,80.84,0,'0','Weight Reduce ','Morning','2016-05-02 00:00:00',600),
(1066,'FAFIS K','KALATHIL\r\nKUTTIADY','Male',19,'918086497592','STUDENT','B+','','','','0',170,48,75.77,0,'0','Weight Reduce ','Morning','2016-05-03 00:00:00',600),
(1067,'SOORAJ VK','VELLAKOLLIYIL\r\nCHAGAROTH\r\nPERUVANNAMUZHI','Male',20,'919746308615','STUDENT','O+','','','','0',179,72,93.95,0,'0','Weight Reduce ','Morning','2016-05-03 00:00:00',600),
(1068,'ADARSH ASHOK','KANJIRAKKANDI\r\nKUNDUTHODE\r\nKAVILUMPARA','Male',20,'91963347677','STUDENT','B+','','','','0',170,76,97.1,0,'0','Fitness Class','Morning','2016-05-03 00:00:00',600),
(1069,'SHIBIN BABU','SASIPURAM\r\nKAVILUMPARA\r\nKUNDUTHODE\r\n','Male',26,'91960583916','EXEQUTIVE','A+','','','','0',174,82,97,94,'0','Weight Reduce ','Morning','2016-05-03 00:00:00',600),
(1070,'DEEPAK CHANDRAN','OTTAPLVULLATHI\r\nKUNDUTHODE\r\nTHOTTILPALAM','Male',21,'919656761853','STUDENT','O+','','','','0',180,77,80.84,0,'0','Weight Reduce ','Morning','2016-05-03 00:00:00',600),
(1071,'ASWIN N','ODANKANDY\r\nCHAGAROTH\r\nTHOTTATHAMKADY','Male',20,'919946873453','TILE WORK','','','','','0',163,50,81.84,0,'0','Weight Reduce ','Morning','2016-05-03 00:00:00',600),
(1072,'RAHUL VP','VALIYAPARAMBIL\r\nPALERI\r\nKUTTIADY','Male',21,'918086273797','STUDENT','O+','','','','0',174,72,90.92,0,'0','Weight Reduce ','Morning','2016-05-03 00:00:00',600),
(1073,'RAGIL M','MATHUKKATHUT\r\nPALERI\r\n','Male',22,'919656757696','TILE WORK','','','','','0',163,51,81.83,0,'0','Weight Reduce ','Morning','2016-05-03 00:00:00',600),
(1074,'AJMAL','KAKKUDUMBIL\r\nADUKATH\r\nKUTTIADY','Male',27,'919061306837','GULF','O+','','','','0',182,84,0,0,'0','Weight Reduce ','Morning','2016-05-04 00:00:00',600),
(1075,'SHUHED MT','MAVULLATHARA\r\nAAKKAL\r\nKAVILUMPARA','Male',17,'918111961173','STUDENT','','','','','0',162,59,86.88,86,'0','Weight Reduce ','Morning','2016-05-04 00:00:00',600),
(1076,'MUHAMMED RAMSHAD','THOTTARMAYANGIYIL\r\nCHATHANKOTTUNADA\r\nKAVILUMPARA\r\n','Male',18,'919544631543','STUDENT','','','','','0',171,54,80.84,0,'0','Weight Reduce ','Morning','2016-05-05 00:00:00',600),
(1077,'SAYOOJ RAJ','PUTHIYAMADATHIL\r\nPOOTHAMPARA\r\nKAVILUMPARA','Male',18,'919539307163','STUDENT','','','','','0',169,97,97.98,102,'0','Weight Reduce ','Morning','2016-05-05 00:00:00',600),
(1078,'SAYOOJ RAJ','PUTHIYAMADATHIL\r\nPOOTHAMPARA\r\nKAVILUMPARA','Male',18,'919539307163','STUDENT','','','','','0',169,87,97.98,102,'0','Weight Reduce ','Morning','2016-05-05 00:00:00',600),
(1079,'ANSHID','KANDOTHILLTH\r\nADUKKATH\r\nKUTTIADY','Male',18,'919946697048','STUDENT','O+','','','','0',178,65,84.87,0,'0','Weight Reduce ','Morning','2016-05-05 00:00:00',600),
(1080,'SHABEER','PALONKAVIL\r\nADUKKATH\r\nKUTTIADY\r\n','Male',19,'919497653867','STUDENT','','','','','0',174,61,85.88,0,'0','Weight Reduce ','Morning','2016-05-05 00:00:00',600),
(1081,'ELLIYAS','PALONKAVL\r\nKUTTIADY\r\nADUKKATH','Male',22,'919665763867','STUDENT','B+','','','','0',162,50,85.87,0,'0','Weight Reduce ','Morning','2016-05-05 00:00:00',600),
(1082,'SANISH MAJEED',' VP HOUSE\r\nKUTTIADY\r\n','Male',23,'919645027353','STUDENT','B+','','','','0',176,77,95.97,96,'0','Weight Reduce ','Morning','2016-05-05 00:00:00',600),
(1083,'ANAS','MENOKKIMANNIL\r\nSHANTHINAGAR\r\nKUTTIADY','Male',22,'919846440609','AIRPORT STAFF','AB+','','','','0',160,56,0,0,'0','Weight Reduce ','Morning','2016-05-06 00:00:00',600),
(1084,'VENGDESH','SWADESHI HOTTEL\r\nMYSORE','Male',18,'917034335103','HOTEL','','','','','0',169,60,83.86,0,'0','Weight Reduce ','Morning','2016-05-06 00:00:00',600),
(1085,'SAVAD K','PERUMPAREMMAL\r\nMOKERI\r\nKAKKATTIL','Male',17,'919745141354','STUDENT','B+','','','','0',173,72,92.94,94,'0','Weight Reduce ','Morning','2016-05-06 00:00:00',600),
(1086,'MUHAMMEDFARIS K','KALLULLATHIL\r\nCHANGARAMKULAM\r\nKAYAKKODI\r\nKUTTIADI\r\n','Male',17,'917025346336','STUDENT','O+','','','','0',170,61,88.91,85,'0','Weight Reduce ','Morning','2016-05-06 00:00:00',600),
(1087,'CHOTTU RAJ','UTHRAPRADESH\r\nMARUTHOMKARA ROAD\r\nNEAR FLAIR HOTEL','Male',20,'919745686628','BELDING','','','','','0',175,58,83.87,0,'0','Weight Reduce ','Morning','2016-05-09 00:00:00',600),
(1088,'ADARSH BABU','VALAKKAZHAM\r\nKAVILUMPARA\r\nTHOTTILPALAM','Male',19,'919048163208','STUDENT','A+','','','','0',173,52,79.82,0,'0','Weight Reduce ','Morning','2016-05-09 00:00:00',600),
(1089,'SHAMEEL K','KONNAKKAL\r\nMUTHUVANNACHA\r\nKUTTIADY','Male',15,'919072704809','STUDENT','B+','','','','0',183,73,95.98,92,'0','Weight Reduce ','Morning','2016-05-09 00:00:00',600),
(1090,'MUHAMMED FAYIS','KAKKOT\r\nMUTHUVANNACHA\r\nKUTTIADY','Male',16,'919048897927','STUDENT','','','','','0',0,62,0,0,'0','Weight Reduce ','Morning','2016-05-09 00:00:00',600),
(1091,'NARENDRAN','MARUTHOMKARA\r\n','Male',21,'919645914707','BELDING','','','','','0',160,59,90.91,0,'0','Weight Reduce ','Morning','2016-05-09 00:00:00',600),
(1092,'MAHAMUDEEN ANSARI','MARUTHOMKARA ROAD\r\nKUTTIADY','Male',20,'918893689526','BELDING','','','','','0',152,49,81.84,0,'0','Weight Reduce ','Morning','2016-05-09 00:00:00',600),
(1093,'ABDUL ANSARI','MARUTHOMKARA ROAD\r\nKUTTIADY','Male',21,'91889325920','BELDING','','','','','0',154,59,87.9,87,'0','Weight Reduce ','Morning','2016-05-09 00:00:00',600),
(1094,'SAMEER ANSARI','MRUTHOMKARA ROAD\r\nUTHARPRADESH','Male',26,'919745140551','BELDING','','','','','0',165,54,89.92,0,'0','Body Building','Morning','2016-05-09 00:00:00',600),
(1095,'SOORAJ EK','EDAKKOTTUMMAL\r\nADUKKATH\r\nKUTTIADY','Male',22,'918943724471','NO','O+','','','','0',178,69,92.94,0,'0','Body Building','Morning','2016-05-09 00:00:00',600),
(1096,'SAFEER C','CHARUMMAL\r\nKUTTIADY\r\nVADAKARA ROAD','Male',23,'918086804900','STUDENT','','','','','0',171,51,82.85,0,'0','Body Building','Morning','2016-05-09 00:00:00',600),
(1097,'SEJEER TM','THOTTARMAYANGI\r\nTHALIYIL\r\nKUTTIADY\r\n\r\n','Male',28,'919847543132','PHYSICL TRAINING','A+','','','','0',180,86,98,98,'0','Body Building','Morning','2016-05-09 00:00:00',600),
(1098,'MUHAMMED SALIH','KOYAMBRATH\r\nADUKKATH\r\nKUTTIADY','Male',27,'919746810927','ACCOUNTANT','A+','','','','0',166,55,0,0,'0','Weight Reduce ','Morning','2016-05-05 00:00:00',600),
(1099,'MUHAMMED KHALEEL','VANNATHANVEETTL\r\nKARANDODE\r\nKUTTIADY','Male',18,'918157091262','STUDENT','','','','','0',0,54,0,0,'0','Weight Reduce ','Morning','2016-05-05 00:00:00',600),
(1100,'NASEEM HINDI','LULU BARBER SHOP\r\nKUTTIADY','Male',23,'919946757862','BARBER','','','','','0',174,66,0,0,'0','Weight Reduce ','Morning','2016-05-05 00:00:00',600),
(1101,'ASWIN ','KAVIL\r\nVELOM\r\nKUTTIADY','Male',18,'919746273369','STUDENT','','','','','0',170,48,79.81,0,'0','Weight Reduce ','Morning','2016-05-05 00:00:00',600),
(1102,'IBRAHIM','KAKKATHA\r\nKMC HOSPITAL SIDE\r\nKOZHIKODE ROAD','Male',18,'919846015893','MEASON','B+','','','','0',165,48,81.85,0,'0','Weight Reduce ','Morning','2016-05-10 00:00:00',600),
(1103,'NASARUDEEN ALI','NATTUGRAM DURBAPARA\r\nKARUVI KATWA','Male',20,'919746715282','MEASON','','','','','0',157,48,87.9,0,'0','Weight Reduce ','Morning','2016-05-10 00:00:00',600),
(1104,'ALIMUSTHAFA A','THUVVOTTE\r\nKUTTIADY\r\nKOZHIKODE','Male',19,'919846957523','STUDENT','O+','','','','0',166,78.5,98.99,0,'0','Fitness Class','Morning','2016-05-10 00:00:00',600),
(1105,'MIDUN K','MAPPILANDI\r\nKUTTIADY\r\nVADAKARA','Male',24,'919645911580','NO','AB+','','','','0',174,65,83.89,0,'0','Fitness Class','Morning','2016-05-11 00:00:00',600),
(1106,'NIJIN LAL','PALLIYARAKANDY\r\nMOILOTHARA\r\nKAVILUMPARA','Male',22,'919995317720','PET','','','','','0',172,77,88.91,99,'0','Fitness Class','Morning','2016-05-13 00:00:00',600),
(1107,'JITHIN K','VADAKKAL\r\nKAVILUMPARA\r\nTHOTTILPALAM','Male',22,'918129228766','STUDENT','','','','','0',157,53,85.87,84,'0','Fitness Class','Morning','2016-05-13 00:00:00',600),
(1108,'ASHIF ALI','VAZHAYIL\r\nADUKKATH\r\nKUTTIADY\r\n','Male',22,'919745513851','NO','B+','','','','0',178,73,90.93,93,'0','Weight Reduce ','Morning','2016-05-13 00:00:00',600),
(1109,'SAFWAN','CHERIYAKUMBALAM\r\nKUTTIADY','Male',18,'919745938617','STUDENT','','','','','0',169,69,90.92,92,'0','Weight Reduce ','Morning','2016-05-17 00:00:00',600),
(1110,'SEKEER K','KOTTOTHUMMAL\r\nMARUTHOMKARA\r\nKAVILUMPARA','Male',24,'919744451813','NO','B+','','','','0',172,61,89.88,0,'0','Weight Reduce ','Morning','2016-05-17 00:00:00',600),
(1111,'VISHAK','VALIYAKANDATHIL\r\nMARUTHOMKARA\r\nKAVILUMPARA','Male',21,'919539560919','NO','A+','','','','0',162,59,90.92,0,'0','Weight Reduce ','Morning','2016-05-17 00:00:00',600),
(1112,' ABDUL MAJEED E.P','VADAKKEPRAMBATH\r\nKULAGARATHAZHA','Male',18,'918592009536','STUDENT','','','','','0',178,55,83.88,0,'0','Weight Reduce ','Morning','2016-05-18 00:00:00',600),
(1113,'SHYAM','RAJASTHAN','Male',21,'918696612301','TILE WORK','','','','','0',186,80,92.96,86,'0','Weight Reduce ','Morning','2016-05-18 00:00:00',600),
(1114,'SIRAJ PP','PALLIPARAMBATH\r\nNITTOOR\r\nKAKKATTIL','Male',22,'919656965560','STUDENT','B+','','','','0',172,57,87.91,0,'0','Weight Reduce ','Morning','2016-05-18 00:00:00',600),
(1115,'MAANJID','VADAKKOTTUMPARAMBATH\r\nKUTTIADY\r\nPERAMBRA','Male',18,'91964577892','STUDENT','B+','','','','0',175,71,85.87,0,'0','Weight Reduce ','Morning','2016-05-19 00:00:00',600),
(1116,'NIDHIN T','THAYYULLATHIL\r\nKAYAKODI\r\nKUTTIADY','Male',26,'919847021100','ACCOUNTANT','A+','','','','0',172,70,90.93,88,'0','Weight Reduce ','Morning','2016-05-20 00:00:00',600),
(1117,'RAM VIJAY','MARUTHOMKARA ROAD\r\nNEAR PETROLPUMP     ','Male',18,'918058820591','TILEWORK','','','','','0',165,52,77.8,0,'0','Weight Reduce ','Morning','2016-05-20 00:00:00',600),
(1118,'SAROJ YADAV','VADAKARA ROAD\r\nKUTTIADY\r\nMANNA QURTES','Male',25,'918804601120','SALES EXECUTIVE','','','','','0',171,81,98.101,103,'0','Weight Reduce ','Morning','2016-05-21 00:00:00',600),
(1119,'RAVIKUMAR','VADAKARA ROAD\r\nKUTTIADY\r\n','Male',20,'919632739726','SALES EXECUTIVE','','','','','0',160,58,90.94,0,'0','Weight Reduce ','Morning','2016-05-21 00:00:00',600),
(1120,'ASHOK KUMAR','VADAKARA ROAD\r\nMANNA QUATERS','Male',24,'919633364885','SALES EXECUTIVE','','','','','0',178,80,100.102,103,'0','Weight Reduce ','Morning','2016-05-21 00:00:00',600),
(1121,'MUHAMMED JISNAS','MANAKATH\r\nTHALIYIL\r\nDEVARKOVIL','Male',19,'919995331395','STUDENT','','','','','0',180,79,97.98,90,'0','Weight Reduce ','Morning','2016-05-23 00:00:00',600),
(1122,'MUHAMMED JISNAS','MANAKKATH\r\nTHALIYIL\r\nDEVORKOVIL','Male',19,'91999531395','STUDENT','','','','','0',180,79,97.98,90,'0','Weight Reduce ','Morning','2016-05-23 00:00:00',600),
(1123,'SANJAY JITH','CHAPPAYIL\r\nCHOMPALA\r\nKOROTH','Male',21,'919744445043','HOLOBRICKS WORK','AB+','','','','0',172,85,102.103,0,'0','Fitness Class','Morning','2016-05-23 00:00:00',600),
(1124,'UNNIKRISHNAN K.V','CHILAKKATHAZHEKUNIYIL\r\nKUTTIADY\r\nVADAARA','Male',23,'919995488186','STUDENT','AB+','','','','0',176,76,90.92,0,'0','Weight Reduce ','Morning','2016-05-23 00:00:00',600),
(1125,'SNJAY JITH','CHAPPAYIL\r\nCHOMPALA\r\nKOROTH\r\n','Male',21,'919744445043','HOLOBRICKES','','','','','0',172,85,102.103,102,'0','Fitness Class','Morning','2016-05-23 00:00:00',600),
(1126,'MIDUN.PK','POOLAKANDY\r\nCHATHANKOTTUNADA\r\nKAVILUMPARA\r\n','Male',25,'919048099230','VAIRING','','','','','0',167,50,82.85,0,'0','Weight Reduce ','Morning','2016-05-23 00:00:00',600),
(1127,'RATHEESH D.T','JYOTHI NIVAS\r\nKAVILUMPAR\r\nTHOTTILPALAM','Male',37,'919048862920','TEACHING','O+','','','','0',170,83,100.102,99,'0','Fitness Class','Morning','2016-05-24 00:00:00',600),
(1128,'NITHYALAL P','PUTHUKKUDI\r\nPALERI\r\nKUTTIADY','Male',27,'919946426809','OPTISION','AB+','','','','0',167,47,78.83,0,'0','Weight Reduce ','Morning','2016-05-25 00:00:00',600),
(1129,'NIDINRAJ KK','PARAULLAPRAMBATH\r\nKAVILUMPARA\r\nTHOTTILPALAM','Male',21,'919605636575','PAITING','O+','','','','0',185,59,83.86,0,'0','','Morning','2016-05-26 00:00:00',600),
(1130,'NEJEEB KV','KODAKKAL\r\nKAYAKKODI\r\nKUTTIADY','Male',31,'919745182363','GULF','O+','','','','0',71,173,93.96,0,'0','Weight Reduce ','Morning','2016-05-26 00:00:00',600),
(1131,'ANAS PP','PUTHANPURAYIL\r\nAAVUKKADA\r\nPERUVANNAMUZHI','Male',22,'919605693693','TEECHISION','','','','','0',177,85,97.1,102,'0','Weight Reduce ','Morning','2016-05-26 00:00:00',600),
(1132,'SHARATH LAL','KAPPILUMAMKOOTTATHIL\r\nTHOTTILPALAM\r\n','Male',22,'919961360071','STUDENT','A+','','','','0',161,43,71.73,0,'0','Weight Reduce ','Morning','2016-05-26 00:00:00',600),
(1133,'ASIF KP','KELAMPOYIL\r\nPALERI\r\nKUTTIADY','Male',20,'919946479526','DEGRE','O+','','','','0',183,71,85.88,0,'0','Weight Reduce ','Morning','2016-05-28 00:00:00',600),
(1134,'VIPIN MATHEW','PUTHANPURAYIL\r\nKUNDUTHODE\r\nKAVILUMPARA','Male',22,'919961336524','SALS','B+','','','','0',164,57,85.87,0,'0','Weight Reduce ','Morning','2016-05-28 00:00:00',600),
(1135,'ARSHAD PK','PARAVANDEKANDY\r\nPALERY\r\nKUTTIADY','Male',21,'919633244136','DRIWING','O+','','','','0',172,67,89.91,86,'0','Weight Reduce ','Morning','2016-05-28 00:00:00',600),
(1136,'SAGAR','MANNUPUTHIYAVEETTIL\r\nTHALIYIL\r\nKUTTIADY','Male',24,'919539284408','ALUMINNIUM FABRICATION','A+','','','','0',172,68,91.93,88,'1','Weight Reduce ','Morning','2016-05-29 00:00:00',600);
/*!40000 ALTER TABLE `newaddmission` ENABLE KEYS */;


/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;


-- Dump completed on 2016-10-10 01:05:06
-- Total time: 0:0:0:0:286 (d:h:m:s:ms)
