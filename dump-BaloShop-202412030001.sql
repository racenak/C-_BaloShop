-- MySQL dump 10.13  Distrib 8.0.19, for Win64 (x86_64)
--
-- Host: localhost    Database: BaloShop
-- ------------------------------------------------------
-- Server version	9.0.1

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `Password`
--

DROP TABLE IF EXISTS `Password`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Password` (
  `PersonID` int NOT NULL,
  `Password` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ModifiedDate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  KEY `Password_Person_FK` (`PersonID`),
  CONSTRAINT `Password_Person_FK` FOREIGN KEY (`PersonID`) REFERENCES `Person` (`PersonID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Password`
--

LOCK TABLES `Password` WRITE;
/*!40000 ALTER TABLE `Password` DISABLE KEYS */;
INSERT INTO `Password` VALUES (1,'12345','2024-10-31 08:41:36');
/*!40000 ALTER TABLE `Password` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Person`
--

DROP TABLE IF EXISTS `Person`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Person` (
  `PersonID` int NOT NULL AUTO_INCREMENT,
  `PersonType` varchar(50) NOT NULL,
  `FirstName` varchar(50) NOT NULL,
  `LastName` varchar(50) NOT NULL,
  `ModifiedDate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`PersonID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Person`
--

LOCK TABLES `Person` WRITE;
/*!40000 ALTER TABLE `Person` DISABLE KEYS */;
INSERT INTO `Person` VALUES (1,'Emp','Emma','Clark','2024-10-24 14:57:02'),(2,'Master','Brian','Barnes','2024-10-24 14:57:02'),(3,'Emp','Kevin','Rose','2024-10-24 14:57:02'),(4,'Master','Megan','Barnes','2024-10-24 14:57:02'),(5,'Master','Isaac','Mack','2024-10-24 14:57:02');
/*!40000 ALTER TABLE `Person` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Product`
--

DROP TABLE IF EXISTS `Product`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Product` (
  `ProductID` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Color` varchar(50) DEFAULT NULL,
  `SafetyStockLevel` smallint NOT NULL,
  `StandardCost` double NOT NULL,
  `ListPrice` double NOT NULL,
  `Size` varchar(5) NOT NULL,
  `ProductSubCategoryID` int NOT NULL,
  `Status` bit(1) NOT NULL,
  `ModifiedDate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ProductID`),
  KEY `Product_ProductSubCategory_FK` (`ProductSubCategoryID`),
  CONSTRAINT `Product_ProductSubCategory_FK` FOREIGN KEY (`ProductSubCategoryID`) REFERENCES `ProductSubCategory` (`ProductSubCategoryID`)
) ENGINE=InnoDB AUTO_INCREMENT=32 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Product`
--

LOCK TABLES `Product` WRITE;
/*!40000 ALTER TABLE `Product` DISABLE KEYS */;
INSERT INTO `Product` VALUES (1,'Balo laptop du lịch, thể thao cao cấp - Tangcool TC736','IndianRed',19,930141.93,1105013.52,'L',1,_binary '','2024-10-24 14:11:58'),(2,'Balo phượt, du lịch bằng vải canvas – ROLLER II','Peru',64,914997.18,1179560.13,'M',1,_binary '','2024-10-24 14:11:58'),(3,'Balo laptop du lịch, phượt đa năng, chống thấm nước 17 inch – OZUKO 9588','Teal',41,815494.13,1042892.86,'M',1,_binary '','2024-10-24 14:11:58'),(4,'Balo laptop du lịch, phượt, thể thao đa năng chống thấm nước 17 inch – OZUKO 9587','Aqua',73,504215.69,1130790.53,'L',1,_binary '','2024-10-24 14:11:58'),(5,'Balo laptop du lịch phượt, chống thấm nước – OZUKO 9631','DarkCyan',49,613729.69,865439.04,'M',1,_binary '','2024-10-24 14:11:58'),(6,'Balo du lịch cỡ lớn 80L, phong cách quân đội, rằn ri – SUR80 V2','CornflowerBlue',67,655957.57,918800.03,'L',2,_binary '','2024-10-24 14:27:51'),(7,'Balo du lịch, phượt, kiểu rằn ri, có công suất lớn 100 lít – SUR100','MediumSlateBlue',38,865726.62,1018173.52,'L',2,_binary '','2024-10-24 14:27:51'),(8,'Balo du lịch, phượt phong cách quân đội – SUR50 – 3688','CornflowerBlue',50,760711.23,1020137.46,'L',2,_binary '','2024-10-24 14:27:51'),(9,'Balo vải quân đội đi du lịch, phượt – 40 lít – SUR 40','Ivory',82,748052.82,1032023.66,'L',2,_binary '','2024-10-24 14:27:51'),(10,'Balo du lịch, phượt, quân đội cỡ lớn 80 lít – SUR80','Orchid',9,846440.85,948742.11,'M',2,_binary '','2024-10-24 14:27:51'),(11,'Ba lô du lịch phượt phong cách vintage rằn ri – COOLBELL 8008','OliveDrab',28,956301.17,1145440.55,'M',2,_binary '','2024-10-24 14:27:51'),(12,'Balo thể thao đạp xe, leo núi, du lịch siêu nhẹ – NEVO RHINO XBIKE','DarkOliveGreen',15,809526.08,1135425.13,'S',3,_binary '','2024-10-24 14:31:16'),(13,'Balo du lịch, leo núi, trekking cỡ lớn – 65 lít – NEVO RHINO V65','Pink',8,605446.65,1017712.11,'L',3,_binary '','2024-10-24 14:31:16'),(14,'Balo du lịch phượt, leo núi đa năng 40 lít – NEVO RHINO 9033','Moccasin',70,740660.92,867516.52,'S',3,_binary '','2024-10-24 14:31:16'),(15,'Balo du lịch cỡ lớn, phượt, leo núi 60 lít – NEVO RHINO 9032','Turquoise',91,676917.26,1020180.44,'L',3,_binary '','2024-10-24 14:31:16'),(16,'Balo du lịch, phượt, leo núi đa năng 30 lít – NEVO RHINO 9071','HotPink',80,521192.04,737703.53,'S',3,_binary '','2024-10-24 14:31:16'),(17,'Balo du lịch, phượt, leo núi chống thấm nước – 25 lít – NEVO RHINO – 8824','DeepPink',82,611300.14,943619.25,'M',3,_binary '','2024-10-24 14:31:16'),(18,'Balo phượt, leo núi, du lịch chống nước – 55L – KAKA 2010','SaddleBrown',62,774685.18,1067315.45,'M',3,_binary '','2024-10-24 14:31:16'),(19,'Balo du lịch, phượt, leo núi đa năng có túi giày – KAKA WANDER','Black',95,780914.78,1100601.65,'S',3,_binary '','2024-10-24 14:31:16'),(20,'[Xả kho] Balo laptop du lịch, thể thao cao cấp – Tangcool TC736','MediumAquaMarine',58,905336.06,1121906.68,'S',12,_binary '','2024-10-24 14:36:39'),(21,'Balo/ túi dây rút thể thao tập gym, chạy bộ – WEROCKER Urban','Plum',69,590318.19,1039918.52,'M',12,_binary '','2024-10-24 14:36:39'),(22,'Túi trống kiêm balo thể thao đa năng – MOYYI SPORTY','Yellow',51,883920.72,1164071.77,'L',12,_binary '','2024-10-24 14:36:39'),(23,'Balo laptop du lịch, thể thao đựng vợt cầu lông 17.3 inch – TANGCOOL TC725','YellowGreen',28,567813.32,975339.14,'M',12,_binary '','2024-10-24 14:36:39'),(24,'Balo thể thao, dã ngoại mini – ENDSTART 2090','Ivory',36,953175.43,1054602.29,'L',12,_binary '','2024-10-24 14:36:39'),(25,'Balo mini thể thao phong cách – ES2776','MediumPurple',12,743290.91,1123592.86,'M',12,_binary '','2024-10-24 14:36:39'),(26,'Balo thể thao dây rút – WR690','PapayaWhip',53,506465.88,1139411.76,'S',12,_binary '','2024-10-24 14:36:39'),(27,'Balo thể thao dây rút siêu nhẹ – NEVO RHINO 8927','Chartreuse',16,732929.14,804652.27,'S',12,_binary '','2024-10-24 14:36:39'),(28,'Balo thể thao đạp xe, leo núi, du lịch siêu nhẹ – NEVO RHINO XBIKE','Silver',3,503159.88,1005409.28,'L',12,_binary '','2024-10-24 14:36:39'),(29,'Túi trống/balo phượt du lịch, thể thao có ngăn đựng giày, vợt cầu lông – BANGE – BG7088','MediumPurple',88,962771.28,1072736.14,'M',12,_binary '','2024-10-24 14:36:39'),(30,'Balo dây rút, thể thao nữ – LEISURE x SWIMMING BAG','Thistle',72,970247.75,1180395.57,'L',12,_binary '','2024-10-24 14:36:39'),(31,'Ba lô mini siêu nhẹ du lịch, đi bộ thể thao, dã ngoại – Minipack','Orchid',3,600627.21,922336.9,'L',12,_binary '','2024-10-24 14:36:39');
/*!40000 ALTER TABLE `Product` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ProductCategory`
--

DROP TABLE IF EXISTS `ProductCategory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ProductCategory` (
  `ProductCategoryID` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) NOT NULL,
  `ModifiedDate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ProductCategoryID`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ProductCategory`
--

LOCK TABLES `ProductCategory` WRITE;
/*!40000 ALTER TABLE `ProductCategory` DISABLE KEYS */;
INSERT INTO `ProductCategory` VALUES (1,'BALO DU LỊCH','2024-10-24 07:11:58'),(2,'BALO LAPTOP','2024-10-24 07:12:01');
/*!40000 ALTER TABLE `ProductCategory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ProductInventory`
--

DROP TABLE IF EXISTS `ProductInventory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ProductInventory` (
  `ProductID` int NOT NULL,
  `Shelf` varchar(10) NOT NULL,
  `Bin` tinyint NOT NULL,
  `Quantity` smallint NOT NULL,
  `ModifiedDate` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  KEY `ProductInventory_Product_FK` (`ProductID`),
  CONSTRAINT `ProductInventory_Product_FK` FOREIGN KEY (`ProductID`) REFERENCES `Product` (`ProductID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ProductInventory`
--

LOCK TABLES `ProductInventory` WRITE;
/*!40000 ALTER TABLE `ProductInventory` DISABLE KEYS */;
INSERT INTO `ProductInventory` VALUES (1,'Bac',45,21,'2024-11-28 07:34:34'),(2,'Tay',51,44,'2024-10-24 15:10:05'),(3,'Tay',79,26,'2024-10-24 15:10:05'),(4,'Bac',82,34,'2024-10-24 15:10:05'),(5,'Tay',25,50,'2024-10-24 15:10:05'),(6,'Tay',76,27,'2024-10-24 15:10:05'),(7,'Dong',29,25,'2024-10-24 15:10:05'),(8,'Bac',33,40,'2024-10-24 15:10:05'),(9,'Nam',26,33,'2024-10-24 15:10:05'),(10,'Dong',13,41,'2024-10-24 15:10:05'),(11,'Dong',22,12,'2024-10-24 15:10:05'),(12,'Dong',12,24,'2024-10-24 15:10:05'),(13,'Dong',13,41,'2024-10-24 15:10:05'),(14,'Tay',15,39,'2024-10-24 15:10:05'),(15,'Bac',9,41,'2024-10-24 15:10:05'),(16,'Nam',22,39,'2024-10-24 15:10:05'),(17,'Dong',64,14,'2024-10-24 15:10:05'),(18,'Dong',37,36,'2024-10-24 15:10:05'),(19,'Dong',67,20,'2024-10-24 15:10:05'),(20,'Bac',89,10,'2024-10-24 15:10:05'),(21,'Tay',89,40,'2024-10-24 15:10:05'),(22,'Dong',81,20,'2024-10-24 15:10:05'),(23,'Nam',58,18,'2024-10-24 15:10:05'),(24,'Tay',22,24,'2024-10-24 15:10:05'),(25,'Bac',74,19,'2024-10-24 15:10:05'),(26,'Bac',97,48,'2024-10-24 15:10:05'),(27,'Bac',20,6,'2024-10-24 15:10:05'),(28,'Nam',62,27,'2024-10-24 15:10:05'),(29,'Dong',94,33,'2024-10-24 15:10:05'),(30,'Bac',74,27,'2024-10-24 15:10:05'),(31,'Tay',75,24,'2024-10-24 15:10:05');
/*!40000 ALTER TABLE `ProductInventory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ProductSubCategory`
--

DROP TABLE IF EXISTS `ProductSubCategory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ProductSubCategory` (
  `ProductSubCategoryID` int NOT NULL AUTO_INCREMENT,
  `ProductCategoryID` int DEFAULT NULL,
  `Name` varchar(150) NOT NULL,
  `ModifiedDate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ProductSubCategoryID`),
  KEY `ProductSubCategory_ProductCategory_FK` (`ProductCategoryID`),
  CONSTRAINT `ProductSubCategory_ProductCategory_FK` FOREIGN KEY (`ProductCategoryID`) REFERENCES `ProductCategory` (`ProductCategoryID`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ProductSubCategory`
--

LOCK TABLES `ProductSubCategory` WRITE;
/*!40000 ALTER TABLE `ProductSubCategory` DISABLE KEYS */;
INSERT INTO `ProductSubCategory` VALUES (1,1,'BALO PHƯỢT ','2024-10-24 07:30:26'),(2,1,'BALO QUÂN ĐỘI','2024-10-24 07:30:26'),(3,1,'BALO LEO NÚI','2024-10-24 07:30:26'),(4,1,'BALO CHỐNG NƯỚC','2024-10-24 07:30:26'),(5,1,'BALO DU LỊCH CỠ LỚN','2024-10-24 07:30:26'),(6,1,'BALO LAPTOP DU LỊCH','2024-10-24 07:30:26'),(7,1,'BALO DU LỊCH NỮ','2024-10-24 07:30:26'),(8,1,'BALO KÉO','2024-10-24 07:30:26'),(9,2,'BALO CÔNG SỞ','2024-10-24 07:33:34'),(10,2,'BALO LAPTOP DU LỊCH','2024-10-24 07:33:47'),(11,2,'BALO GAMING','2024-10-24 07:34:01'),(12,NULL,'BALO THỂ THAO','2024-10-24 07:37:09'),(13,NULL,'BALO VẢI','2024-10-24 07:38:10'),(14,NULL,'BALO DA','2024-10-24 07:38:23'),(15,NULL,'BALO MÁY ẢNH','2024-10-24 07:38:37'),(16,NULL,'BALO ĐEO CHÉO','2024-10-24 07:38:59'),(17,NULL,'BALO CHỐNG NƯỚC','2024-10-24 07:39:12');
/*!40000 ALTER TABLE `ProductSubCategory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ProductVendor`
--

DROP TABLE IF EXISTS `ProductVendor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ProductVendor` (
  `ProductVendorID` int NOT NULL AUTO_INCREMENT,
  `ProductID` int NOT NULL,
  `VendorID` int NOT NULL,
  `StandardPrice` double NOT NULL,
  `LastReceiptPrice` double DEFAULT NULL,
  `LastReceiptDate` datetime DEFAULT NULL,
  `ModifiedDate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ProductVendorID`),
  KEY `ProductVendor_Product_FK` (`ProductID`),
  KEY `ProductVendor_Vendor_FK` (`VendorID`),
  CONSTRAINT `ProductVendor_Product_FK` FOREIGN KEY (`ProductID`) REFERENCES `Product` (`ProductID`),
  CONSTRAINT `ProductVendor_Vendor_FK` FOREIGN KEY (`VendorID`) REFERENCES `Vendor` (`VendorID`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ProductVendor`
--

LOCK TABLES `ProductVendor` WRITE;
/*!40000 ALTER TABLE `ProductVendor` DISABLE KEYS */;
INSERT INTO `ProductVendor` VALUES (1,22,3,525573.77,807827.05,'2024-03-28 20:19:47','2024-10-24 16:18:22'),(2,26,1,971371.89,771917.71,'2024-07-04 08:43:13','2024-10-24 16:18:22'),(3,16,2,836623.95,767410.35,'2024-06-30 20:29:16','2024-10-24 16:18:22'),(4,9,5,614200.99,700758.71,'2024-07-07 02:44:54','2024-10-24 16:18:22'),(5,13,5,762200.46,522895.93,'2024-02-07 05:06:19','2024-10-24 16:18:22'),(6,22,4,953072.73,903315.48,'2024-08-10 04:11:50','2024-10-24 16:18:22'),(7,9,1,599464.55,900736.12,'2024-06-21 03:19:43','2024-10-24 16:18:22'),(8,24,1,838213.5,608810.43,'2024-05-25 00:05:27','2024-10-24 16:18:22'),(9,9,4,702817.61,681788.34,'2024-01-11 10:26:22','2024-10-24 16:18:22'),(10,26,1,509247.35,605399.92,'2024-09-07 03:51:34','2024-10-24 16:18:22');
/*!40000 ALTER TABLE `ProductVendor` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `PurchaseOrderDetail`
--

DROP TABLE IF EXISTS `PurchaseOrderDetail`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `PurchaseOrderDetail` (
  `PurchaseOrderID` int NOT NULL,
  `PurchaseOrderDetailID` int NOT NULL AUTO_INCREMENT,
  `ProductID` int NOT NULL,
  `OrderQty` smallint NOT NULL,
  `ReceivedQty` double NOT NULL,
  `UnitPrice` double NOT NULL,
  `LineTotal` double NOT NULL,
  `RejectedQty` smallint NOT NULL,
  `StockedQty` smallint NOT NULL,
  `ModifedDate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`PurchaseOrderDetailID`),
  KEY `PurchaseOrderDetail_PurchaseOrderHeader_FK` (`PurchaseOrderID`),
  KEY `PurchaseOrderDetail_Product_FK` (`ProductID`),
  CONSTRAINT `PurchaseOrderDetail_Product_FK` FOREIGN KEY (`ProductID`) REFERENCES `Product` (`ProductID`),
  CONSTRAINT `PurchaseOrderDetail_PurchaseOrderHeader_FK` FOREIGN KEY (`PurchaseOrderID`) REFERENCES `PurchaseOrderHeader` (`PurchaseOrderID`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `PurchaseOrderDetail`
--

LOCK TABLES `PurchaseOrderDetail` WRITE;
/*!40000 ALTER TABLE `PurchaseOrderDetail` DISABLE KEYS */;
INSERT INTO `PurchaseOrderDetail` VALUES (5,1,5,4,1.4821051834800754,549141.32,2196565.28,1,3,'2024-10-21 19:29:33'),(6,2,28,11,3.488598910939928,606026.04,6666286.44,5,6,'2024-05-14 03:37:17'),(15,3,4,15,10.671406247102881,576768.37,8651525.55,4,11,'2024-01-31 11:38:50'),(4,4,23,10,0.8466398811360409,929755.59,9297555.9,2,8,'2024-02-21 02:47:46'),(12,5,11,17,0.3251087741942539,959534.02,16312078.34,1,16,'2024-03-27 09:03:18'),(22,6,6,17,15.481194398881438,591085.64,10048455.88,2,15,'2024-06-01 09:54:37'),(11,7,11,13,7.9808248557082395,690078.69,8971022.97,0,13,'2024-04-17 04:33:17'),(2,8,25,5,2.0844824157668107,504117.76,2520588.8,3,2,'2024-02-26 06:01:20'),(2,9,26,3,1.774578967081832,880691.01,2642073.03,5,-2,'2024-04-26 04:47:23'),(25,10,21,20,15.377446492716576,683539.27,13670785.4,0,20,'2024-01-06 22:32:32');
/*!40000 ALTER TABLE `PurchaseOrderDetail` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `PurchaseOrderHeader`
--

DROP TABLE IF EXISTS `PurchaseOrderHeader`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `PurchaseOrderHeader` (
  `PurchaseOrderID` int NOT NULL AUTO_INCREMENT,
  `Status` smallint NOT NULL,
  `EmployeeID` int NOT NULL,
  `VendorID` int NOT NULL,
  `OrderDate` datetime NOT NULL,
  `SubTotal` double NOT NULL,
  `Tax` double NOT NULL,
  `TotalDue` double NOT NULL,
  `ModifiedDate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`PurchaseOrderID`),
  KEY `PurchaseOrderHeader_Person_FK` (`EmployeeID`),
  KEY `PurchaseOrderHeader_Vendor_FK` (`VendorID`),
  CONSTRAINT `PurchaseOrderHeader_Person_FK` FOREIGN KEY (`EmployeeID`) REFERENCES `Person` (`PersonID`),
  CONSTRAINT `PurchaseOrderHeader_Vendor_FK` FOREIGN KEY (`VendorID`) REFERENCES `Vendor` (`VendorID`)
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `PurchaseOrderHeader`
--

LOCK TABLES `PurchaseOrderHeader` WRITE;
/*!40000 ALTER TABLE `PurchaseOrderHeader` DISABLE KEYS */;
INSERT INTO `PurchaseOrderHeader` VALUES (1,4,1,3,'2024-08-17 06:01:40',663647.81,66364.78,730012.59,'2024-10-24 16:28:09'),(2,4,4,3,'2024-03-20 19:06:12',801239.36,80123.94,881363.3,'2024-10-24 16:28:09'),(3,2,5,2,'2024-08-22 00:03:59',733421.16,73342.12,806763.28,'2024-10-24 16:28:09'),(4,4,4,5,'2024-08-19 01:06:53',992823.2,99282.32,1092105.52,'2024-10-24 16:28:09'),(5,3,5,2,'2024-04-05 18:32:52',671145.51,67114.55,738260.06,'2024-10-24 16:28:09'),(6,2,2,3,'2024-06-29 17:13:12',669124.59,66912.46,736037.05,'2024-10-24 16:28:09'),(7,2,5,5,'2024-02-05 08:18:49',913420.38,91342.04,1004762.42,'2024-10-24 16:28:09'),(8,4,4,3,'2024-03-18 02:35:34',622906.76,62290.68,685197.44,'2024-10-24 16:28:09'),(9,1,5,3,'2024-02-08 15:53:07',554587.82,55458.78,610046.6,'2024-10-24 16:28:09'),(10,1,2,4,'2024-01-15 19:40:51',808476.79,80847.68,889324.47,'2024-10-24 16:28:09'),(11,4,5,5,'2024-05-05 20:36:58',648379.05,64837.91,713216.96,'2024-10-24 16:29:01'),(12,4,4,1,'2024-07-27 22:39:55',686600.87,68660.09,755260.96,'2024-10-24 16:29:01'),(13,2,5,5,'2024-05-22 19:48:44',916699.56,91669.96,1008369.52,'2024-10-24 16:29:01'),(14,3,3,4,'2024-06-15 22:54:16',672972.1,67297.21,740269.31,'2024-10-24 16:29:01'),(15,4,2,2,'2024-07-27 01:31:52',843349.21,84334.92,927684.13,'2024-10-24 16:29:01'),(16,3,5,4,'2024-05-02 04:45:30',522355.99,52235.6,574591.59,'2024-10-24 16:29:01'),(17,1,2,3,'2024-05-11 05:01:17',928211.69,92821.17,1021032.86,'2024-10-24 16:29:01'),(18,2,2,3,'2024-04-11 23:07:45',950747.95,95074.79,1045822.74,'2024-10-24 16:29:01'),(19,3,3,5,'2024-07-08 07:06:18',970027.55,97002.76,1067030.31,'2024-10-24 16:29:01'),(20,3,3,3,'2024-08-09 08:27:26',619840.63,61984.06,681824.69,'2024-10-24 16:29:01'),(21,3,5,4,'2024-07-05 22:43:50',722927.11,72292.71,795219.82,'2024-10-24 16:29:01'),(22,2,1,4,'2024-01-11 10:22:14',842071.52,84207.15,926278.67,'2024-10-24 16:29:01'),(23,3,2,3,'2024-04-16 22:08:12',550736.61,55073.66,605810.27,'2024-10-24 16:29:01'),(24,4,5,4,'2024-06-02 16:00:38',812097.85,81209.79,893307.64,'2024-10-24 16:29:01'),(25,1,2,5,'2024-04-03 10:00:04',628171.1,62817.11,690988.21,'2024-10-24 16:29:01'),(26,3,4,4,'2024-02-11 18:57:06',836901.75,83690.18,920591.93,'2024-10-24 16:29:01'),(27,1,2,3,'2024-02-05 15:17:43',822533.15,82253.32,904786.47,'2024-10-24 16:29:01'),(28,4,1,2,'2024-09-09 12:17:36',688933.8,68893.38,757827.18,'2024-10-24 16:29:01'),(29,4,1,3,'2024-10-02 19:43:50',648574.05,64857.41,713431.46,'2024-10-24 16:29:01'),(30,3,2,3,'2024-04-19 07:50:55',897596.25,89759.62,987355.87,'2024-10-24 16:29:01');
/*!40000 ALTER TABLE `PurchaseOrderHeader` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `SalesOrderDetail`
--

DROP TABLE IF EXISTS `SalesOrderDetail`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `SalesOrderDetail` (
  `SaleOrderID` int NOT NULL,
  `SaleOrderDetailID` int NOT NULL AUTO_INCREMENT,
  `OrderQty` smallint NOT NULL,
  `ProductID` int NOT NULL,
  `SpecialOfferID` int NOT NULL DEFAULT '1',
  `UnitPrice` double NOT NULL,
  `UnitPriceDiscount` double NOT NULL DEFAULT '0',
  `LineTotal` decimal(10,2) GENERATED ALWAYS AS ((`UnitPrice` - (`UnitPrice` * `OrderQty`))) STORED,
  `ModifiedDate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`SaleOrderDetailID`),
  KEY `SalesOrderDetail_SpecialOfferProduct_FK` (`SpecialOfferID`),
  KEY `SalesOrderDetail_SalesOrderHeader_FK` (`SaleOrderID`),
  KEY `SalesOrderDetail_Product_FK` (`ProductID`),
  CONSTRAINT `SalesOrderDetail_Product_FK` FOREIGN KEY (`ProductID`) REFERENCES `Product` (`ProductID`),
  CONSTRAINT `SalesOrderDetail_SalesOrderHeader_FK` FOREIGN KEY (`SaleOrderID`) REFERENCES `SalesOrderHeader` (`SalesOrderID`),
  CONSTRAINT `SalesOrderDetail_SpecialOffer_FK` FOREIGN KEY (`SpecialOfferID`) REFERENCES `SpecialOffer` (`SpecialOfferID`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `SalesOrderDetail`
--

LOCK TABLES `SalesOrderDetail` WRITE;
/*!40000 ALTER TABLE `SalesOrderDetail` DISABLE KEYS */;
INSERT INTO `SalesOrderDetail` (`SaleOrderID`, `SaleOrderDetailID`, `OrderQty`, `ProductID`, `SpecialOfferID`, `UnitPrice`, `UnitPriceDiscount`, `ModifiedDate`) VALUES (8,1,4,28,1,20.6,9.55,'2024-10-24 16:59:33'),(10,2,5,12,1,11.8,3.67,'2024-10-24 16:59:33'),(2,3,2,16,1,30.33,11.55,'2024-10-24 16:59:33'),(9,4,6,18,1,86.29,4.66,'2024-10-24 16:59:33'),(9,5,10,16,1,56.63,25.89,'2024-10-24 16:59:33'),(9,6,1,16,1,16.08,7.35,'2024-10-24 16:59:33'),(5,7,3,4,1,80.85,37,'2024-10-24 16:59:33'),(1,8,5,14,1,33.58,6.7,'2024-10-24 16:59:33'),(5,9,6,8,1,13.75,2.77,'2024-10-24 16:59:33'),(3,10,7,20,1,81.88,25.46,'2024-10-24 16:59:33'),(18,11,1,1,1,1105013.52,0,'2024-11-28 07:12:05'),(19,12,1,1,1,1105013.52,0,'2024-11-28 07:14:30'),(20,13,1,1,1,1105013.52,0,'2024-11-28 07:17:09'),(21,14,1,1,1,1105013.52,0,'2024-11-28 07:18:03'),(22,15,1,1,1,1105013.52,0,'2024-11-28 07:23:26'),(23,16,1,1,1,1105013.52,0,'2024-11-28 07:34:34');
/*!40000 ALTER TABLE `SalesOrderDetail` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `SalesOrderHeader`
--

DROP TABLE IF EXISTS `SalesOrderHeader`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `SalesOrderHeader` (
  `SalesOrderID` int NOT NULL AUTO_INCREMENT,
  `OrderDare` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `SalePersonID` int NOT NULL,
  `Status` tinyint NOT NULL,
  `SubTotal` double NOT NULL,
  `Tax` double NOT NULL,
  `TotalDue` double NOT NULL,
  `ModifiedDate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`SalesOrderID`),
  KEY `SalesOrderHeader_Person_FK` (`SalePersonID`),
  CONSTRAINT `SalesOrderHeader_Person_FK` FOREIGN KEY (`SalePersonID`) REFERENCES `Person` (`PersonID`)
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `SalesOrderHeader`
--

LOCK TABLES `SalesOrderHeader` WRITE;
/*!40000 ALTER TABLE `SalesOrderHeader` DISABLE KEYS */;
INSERT INTO `SalesOrderHeader` VALUES (1,'2024-03-20 14:17:49',5,1,341.1,34.11,11634.921,'2024-10-24 16:37:42'),(2,'2024-04-17 02:03:05',3,2,130.3,13.03,1697.809,'2024-10-24 16:37:42'),(3,'2024-04-16 01:20:08',4,2,407.71,40.77,16622.3367,'2024-10-24 16:37:42'),(4,'2024-03-04 03:17:09',4,4,551.57,55.16,30424.6012,'2024-10-24 16:37:42'),(5,'2024-06-17 18:33:33',3,1,707.79,70.78,50097.3762,'2024-10-24 16:37:42'),(6,'2024-04-25 07:03:43',5,1,304.54,30.45,9273.243,'2024-10-24 16:37:42'),(7,'2024-02-24 02:53:11',3,2,948.52,94.85,89967.12199999999,'2024-10-24 16:37:42'),(8,'2024-07-04 01:11:23',3,1,436.44,43.64,19046.2416,'2024-10-24 16:37:42'),(9,'2024-07-14 22:19:46',4,4,641.16,64.12,41111.1792,'2024-10-24 16:37:42'),(10,'2024-10-20 20:47:03',3,1,557.39,55.74,31068.9186,'2024-10-24 16:37:42'),(11,'2024-11-28 06:54:55',2,1,1105013.52,110501.352,122105487938.27904,'2024-11-28 06:54:55'),(12,'2024-11-28 06:56:46',2,1,1105013.52,110501.352,122105487938.27904,'2024-11-28 06:56:46'),(13,'2024-11-28 06:57:07',2,1,1105013.52,110501.352,122105487938.27904,'2024-11-28 06:57:07'),(14,'2024-11-28 06:58:00',2,1,1105013.52,110501.352,122105487938.27904,'2024-11-28 06:58:00'),(15,'2024-11-28 06:58:48',2,1,1105013.52,110501.352,122105487938.27904,'2024-11-28 06:58:48'),(16,'2024-11-28 06:59:20',2,1,1105013.52,110501.352,122105487938.27904,'2024-11-28 06:59:20'),(17,'2024-11-28 07:06:44',2,1,1105013.52,110501.352,122105487938.27904,'2024-11-28 07:06:44'),(18,'2024-11-28 07:12:05',2,1,1105013.52,110501.352,122105487938.27904,'2024-11-28 07:12:05'),(19,'2024-11-28 07:14:30',2,1,1105013.52,110501.352,122105487938.27904,'2024-11-28 07:14:30'),(20,'2024-11-28 07:17:09',2,1,1105013.52,110501.352,122105487938.27904,'2024-11-28 07:17:09'),(21,'2024-11-28 07:18:03',2,1,1105013.52,110501.352,122105487938.27904,'2024-11-28 07:18:03'),(22,'2024-11-28 07:23:26',2,1,1105013.52,110501.352,122105487938.27904,'2024-11-28 07:23:26'),(23,'2024-11-28 07:34:34',2,1,1105013.52,110501.352,122105487938.27904,'2024-11-28 07:34:34');
/*!40000 ALTER TABLE `SalesOrderHeader` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`%`*/ /*!50003 TRIGGER `CalculateTotalDue` BEFORE INSERT ON `SalesOrderHeader` FOR EACH ROW BEGIN 
	SET NEW.TotalDue = NEW.SubTotal * NEW.Tax;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `SpecialOffer`
--

DROP TABLE IF EXISTS `SpecialOffer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `SpecialOffer` (
  `SpecialOfferID` int NOT NULL AUTO_INCREMENT,
  `Description` varchar(255) NOT NULL,
  `DiscountPct` double NOT NULL,
  `Name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `StartDate` datetime NOT NULL,
  `EndDate` datetime NOT NULL,
  `ModifiedDate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`SpecialOfferID`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `SpecialOffer`
--

LOCK TABLES `SpecialOffer` WRITE;
/*!40000 ALTER TABLE `SpecialOffer` DISABLE KEYS */;
INSERT INTO `SpecialOffer` VALUES (1,'Both more off involve thus position you.',41.97,'three','2024-10-15 03:28:53','2024-10-26 03:28:53','2024-10-24 16:48:20'),(2,'Season somebody fire treatment that blue several.',3.28,'nearly','2024-03-28 09:50:26','2024-04-19 09:50:26','2024-10-24 16:48:20'),(3,'Her leader seek campaign.',30.61,'process','2024-09-27 07:04:09','2024-10-08 07:04:09','2024-10-24 16:48:20'),(4,'General reflect best peace.',37.29,'inside','2024-09-06 18:36:39','2024-09-12 18:36:39','2024-10-24 16:48:20'),(5,'Data production least sometimes.',47.81,'decide','2024-01-20 19:04:11','2024-02-04 19:04:11','2024-10-24 16:48:20'),(6,'Require box sit economic break.',9.15,'prevent','2024-02-06 02:34:52','2024-02-25 02:34:52','2024-10-24 16:48:20'),(7,'Own off safe perform hear example.',36.27,'service','2024-01-07 01:51:07','2024-01-24 01:51:07','2024-10-24 16:48:20'),(8,'And nature democratic.',34.93,'spend','2024-04-03 06:17:39','2024-04-19 06:17:39','2024-10-24 16:48:20'),(9,'Final recently mouth late human.',41.98,'detail','2024-02-22 17:17:40','2024-03-17 17:17:40','2024-10-24 16:48:20'),(10,'Admit debate school build help thought first involve.',29.21,'president','2024-03-09 21:58:14','2024-04-01 21:58:14','2024-10-24 16:48:20');
/*!40000 ALTER TABLE `SpecialOffer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Vendor`
--

DROP TABLE IF EXISTS `Vendor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Vendor` (
  `VendorID` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) NOT NULL,
  `ModifiedDate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`VendorID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Vendor`
--

LOCK TABLES `Vendor` WRITE;
/*!40000 ALTER TABLE `Vendor` DISABLE KEYS */;
INSERT INTO `Vendor` VALUES (1,'King, Holloway and Hernandez','2024-10-24 15:23:34'),(2,'Holland-Rivera','2024-10-24 15:23:34'),(3,'Mason, Hawkins and Campbell','2024-10-24 15:23:34'),(4,'Forbes-Pena','2024-10-24 15:23:34'),(5,'Hicks PLC','2024-10-24 15:23:34');
/*!40000 ALTER TABLE `Vendor` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'BaloShop'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-12-03  0:01:51
