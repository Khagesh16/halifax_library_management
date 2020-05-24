-- MySQL dump 10.13  Distrib 8.0.15, for Win64 (x86_64)
--
-- Host: localhost    Database: dbfinalproject
-- ------------------------------------------------------
-- Server version	8.0.15
DROP DATABASE IF EXISTS project;
create database project;
use project;
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

--
-- Table structure for table `p_articles`
--

DROP TABLE IF EXISTS `p_articles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `p_articles` (
  `article_id` int(11) NOT NULL,
  `title` varchar(300) DEFAULT NULL,
  `page_no` varchar(10) DEFAULT NULL,
  `publication_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`article_id`),
  KEY `publication_id` (`publication_id`),
  CONSTRAINT `p_articles_ibfk_1` FOREIGN KEY (`publication_id`) REFERENCES `p_publication` (`publication_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `p_author`
--

DROP TABLE IF EXISTS `p_author`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `p_author` (
  `_id` int(11) NOT NULL,
  `lname` varchar(30) NOT NULL,
  `fname` varchar(30) DEFAULT NULL,
  `email` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `p_author_articles`
--

DROP TABLE IF EXISTS `p_author_articles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `p_author_articles` (
  `author_id` int(20) DEFAULT NULL,
  `article_id` int(20) DEFAULT NULL,
  `_id` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`_id`),
  KEY `author_id` (`author_id`),
  KEY `article_id` (`article_id`),
  CONSTRAINT `p_author_articles_ibfk_1` FOREIGN KEY (`author_id`) REFERENCES `p_author` (`_id`),
  CONSTRAINT `p_author_articles_ibfk_2` FOREIGN KEY (`article_id`) REFERENCES `p_articles` (`article_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `p_customer`
--

DROP TABLE IF EXISTS `p_customer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `p_customer` (
  `cid` int(11) NOT NULL AUTO_INCREMENT,
  `fname` varchar(50) DEFAULT NULL,
  `lname` varchar(50) DEFAULT NULL,
  `telephone` int(10) DEFAULT NULL,
  `streetNo` int(4) DEFAULT NULL,
  `street_name` varchar(50) DEFAULT NULL,
  `apt_no` int(4) DEFAULT NULL,
  `zipcode` varchar(6) DEFAULT NULL,
  PRIMARY KEY (`cid`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `p_emp_expense`
--

DROP TABLE IF EXISTS `p_emp_expense`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `p_emp_expense` (
  `date` date DEFAULT NULL,
  `hours` int(2) DEFAULT NULL,
  `sin` varchar(15) DEFAULT NULL,
  `salary` float DEFAULT NULL,
  `_id` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`_id`),
  KEY `sin` (`sin`),
  CONSTRAINT `p_emp_expense_ibfk_1` FOREIGN KEY (`sin`) REFERENCES `p_employee` (`sin`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` TRIGGER `p_employee_sal` BEFORE INSERT ON `p_emp_expense` FOR EACH ROW BEGIN
 	set @cid := NEW.sin;
 	set @hours :=NEW.hours;
 	set @hour_pay :=(select hourly_pay from p_employee where sin=@cid);
 	set @salary := @hours*@hour_pay;     
     set NEW.salary= @salary;
 END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `p_employee`
--

DROP TABLE IF EXISTS `p_employee`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `p_employee` (
  `sin` varchar(15) NOT NULL,
  `fname` varchar(50) DEFAULT NULL,
  `lname` varchar(50) DEFAULT NULL,
  `hourly_pay` float DEFAULT NULL,
  PRIMARY KEY (`sin`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `p_expense_cat`
--

DROP TABLE IF EXISTS `p_expense_cat`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `p_expense_cat` (
  `_id` int(11) NOT NULL,
  `category_name` varchar(15) DEFAULT NULL,
  PRIMARY KEY (`_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `p_items`
--

DROP TABLE IF EXISTS `p_items`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `p_items` (
  `_id` bigint(20) NOT NULL AUTO_INCREMENT,
  `price` float(8,2) NOT NULL,
  PRIMARY KEY (`_id`)
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `p_magazine`
--

DROP TABLE IF EXISTS `p_magazine`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `p_magazine` (
  `magazine_id` int(11) NOT NULL,
  `magazine_name` varchar(300) NOT NULL,
  PRIMARY KEY (`magazine_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `p_other_expense`
--

DROP TABLE IF EXISTS `p_other_expense`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `p_other_expense` (
  `date` date DEFAULT NULL,
  `cost` float DEFAULT NULL,
  `category_id` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`category_id`),
  KEY `category_id` (`category_id`),
  CONSTRAINT `p_other_expense_ibfk_1` FOREIGN KEY (`category_id`) REFERENCES `p_expense_cat` (`_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `p_publication`
--

DROP TABLE IF EXISTS `p_publication`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `p_publication` (
  `publication_id` int(11) NOT NULL AUTO_INCREMENT,
  `volume_number` int(10) NOT NULL,
  `published_date` date DEFAULT NULL,
  `magazine_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`publication_id`),
  KEY `magazine_id` (`magazine_id`),
  CONSTRAINT `p_publication_ibfk_1` FOREIGN KEY (`magazine_id`) REFERENCES `p_magazine` (`magazine_id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `p_purchase`
--

DROP TABLE IF EXISTS `p_purchase`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `p_purchase` (
  `transaction_id` int(11) DEFAULT NULL,
  `item_id` bigint(20) DEFAULT NULL,
  `_id` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`_id`),
  KEY `transaction_id` (`transaction_id`),
  KEY `item_id` (`item_id`),
  CONSTRAINT `p_purchase_ibfk_1` FOREIGN KEY (`transaction_id`) REFERENCES `p_transaction` (`transaction_id`),
  CONSTRAINT `p_purchase_ibfk_2` FOREIGN KEY (`item_id`) REFERENCES `p_items` (`_id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` TRIGGER `p_transaction_totprice` AFTER INSERT ON `p_purchase` FOR EACH ROW BEGIN
  set @cid = NEW.transaction_id;
  set @discount= (select discount_code from p_transaction where transaction_id=NEW.transaction_id);
  	set @total_sum =(select sum(i.price) from p_purchase p join p_transaction t on (p.transaction_id=t.transaction_id) join p_items i on (i._id=p.item_id) where p.transaction_id=@cid);
  	set @final_tot = @total_sum*(1-2.5*(@discount/100));
 	update p_transaction set total_price=@final_tot where transaction_id=@cid;   
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `p_transaction`
--

DROP TABLE IF EXISTS `p_transaction`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `p_transaction` (
  `transaction_id` int(11) NOT NULL AUTO_INCREMENT,
  `total_price` float DEFAULT NULL,
  `discount_code` int(1) DEFAULT NULL,
  `date` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `cid` int(11) NOT NULL,
  PRIMARY KEY (`transaction_id`),
  KEY `cid` (`cid`),
  CONSTRAINT `p_transaction_ibfk_1` FOREIGN KEY (`cid`) REFERENCES `p_customer` (`cid`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` TRIGGER `p_after_insert_transaction` BEFORE INSERT ON `p_transaction` FOR EACH ROW Begin
 SET @sum = 0;
 SET @sum = (Select sum(total_price) from p_transaction where cid = NEW.cid and `date` >= (DATE_SUB(CURDATE(), INTERVAL 5 YEAR)));
 SET NEW.discount_code = (SELECT CASE 
 			WHEN @sum > 500 THEN 5
             WHEN @sum > 400 and @sum <=500 THEN 4
             WHEN @sum > 300 and @sum <=400 THEN 3
             WHEN @sum > 200 and @sum <=300 THEN 2
             WHEN @sum > 100 and @sum <=200 THEN 1
             ELSE 0
             END);
 End ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` TRIGGER `p_transaction_delete` BEFORE DELETE ON `p_transaction` FOR EACH ROW delete from p_purchase where transaction_id = OLD.transaction_id; ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Dumping events for database 'dbfinalproject'
--

--
-- Dumping routines for database 'dbfinalproject'
--
/*!50003 DROP PROCEDURE IF EXISTS `p_library_expenses_report_sp` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `p_library_expenses_report_sp`(IN queryDate char(20))
begin
select Date ,category_name as Name,null as Hours,cost as Expense from p_other_expense join p_expense_cat on p_other_expense.category_id = p_expense_cat._id where date like queryDate
union
SELECT date,sin,hours,salary FROM m_rankireddi.p_emp_expense where date like queryDate;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-04-13 17:59:18
