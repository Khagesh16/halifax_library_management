#DROP DATABASE IF EXISTS Project;
#CREATE DATABASE IF NOT EXISTS Project;
use k_pandya;
drop table if exists p_author_articles;
drop table if exists p_articles;
drop table if exists p_publication;
drop table if exists p_magazine;
drop table if exists p_author;
drop table if exists p_purchase;
drop table if exists p_transaction;
drop table if exists p_items;
drop table if exists p_customer;

CREATE TABLE  `p_author`(
    `_id` int(11) NOT NULL,
   `lname` varchar(30) NOT NULL,
   `fname` varchar(30) DEFAULT NULL,
   `email` varchar(50) DEFAULT NULL,
   PRIMARY KEY (`_id`)
 ) ENGINE=InnoDB DEFAULT CHARSET=latin1;




CREATE TABLE `p_magazine` (
   `magazine_id` int(11) NOT NULL ,
   `magazine_name` varchar(300) NOT NULL,
   PRIMARY KEY (`magazine_id`)
   ) ENGINE=InnoDB  DEFAULT CHARSET=latin1;



CREATE TABLE `p_publication` (
		`publication_id` int auto_increment,
       `volume_number` int(10) NOT NULL,
      `published_date` date DEFAULT NULL,
      `magazine_id` int(11) DEFAULT NULL,
      PRIMARY KEY (`publication_id`),
       KEY `magazine_id` (`magazine_id`),
   CONSTRAINT `p_publication_ibfk_1` FOREIGN KEY (`magazine_id`) REFERENCES `p_magazine`        
   (`magazine_id`)
       ) ENGINE=InnoDB DEFAULT CHARSET=latin1;




CREATE TABLE `p_articles` (
   	`article_id` int(11) NOT NULL,
   	`title` varchar(300) DEFAULT NULL,
   	`page_no` varchar(10) DEFAULT NULL,
  	 `publication_id` int ,
  	 PRIMARY KEY (`article_id`),
   	KEY `publication_id` (`publication_id`),
CONSTRAINT `p_articles_ibfk_1` FOREIGN KEY (`publication_id`) REFERENCES `p_publication`  (`publication_id`)
 ) ENGINE=InnoDB DEFAULT CHARSET=latin1;

	
	
CREATE TABLE `p_author_articles` (
   `author_id` int(20) DEFAULT NULL,
   `article_id` int(20) DEFAULT NULL,
   KEY `author_id` (`author_id`),
   KEY `article_id` (`article_id`),
   CONSTRAINT `p_author_articles_ibfk_1` FOREIGN KEY (`author_id`) REFERENCES `p_author` (`_id`),
   CONSTRAINT `p_author_articles_ibfk_2` FOREIGN KEY (`article_id`) REFERENCES `p_articles` (`article_id`)
 ) ENGINE=InnoDB DEFAULT CHARSET=latin1;



CREATE TABLE `p_customer` ( `cid` int(11) NOT NULL AUTO_INCREMENT,
 `fname` varchar(50) DEFAULT NULL, 
 `lname` varchar(50) DEFAULT NULL, `telephone` int(10) DEFAULT NULL, 
 `streetNo` int(4) DEFAULT NULL, `street_name` varchar(50) DEFAULT NULL, 
 `apt_no` int(4) DEFAULT NULL, `zipcode` varchar(6) DEFAULT NULL, 
 PRIMARY KEY (`cid`) 
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;


CREATE TABLE `p_items` ( `_id` bigint(20) NOT NULL AUTO_INCREMENT,
 `price` float(8,2) NOT NULL,
  PRIMARY KEY (`_id`) 
  ) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=latin1;


 CREATE TABLE `p_transaction` ( `transaction_id` int(11) NOT NULL AUTO_INCREMENT,
`total_price` float DEFAULT NULL, 
`discount_code` int(1) DEFAULT NULL,
`date` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
`cid` int(11) NOT NULL, PRIMARY KEY (`transaction_id`), KEY `cid` (`cid`), 
CONSTRAINT `p_transaction_ibfk_1` FOREIGN KEY (`cid`) REFERENCES `p_customer` (`cid`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=latin1;

 
 CREATE TABLE `p_purchase` ( `transaction_id` int(11) DEFAULT NULL, 
 	`item_id` bigint(20) DEFAULT NULL, 
 	KEY `transaction_id` (`transaction_id`),
 	 KEY `item_id` (`item_id`),
 	  CONSTRAINT `p_purchase_ibfk_1` FOREIGN KEY (`transaction_id`) REFERENCES `p_transaction` (`transaction_id`), 
 	  CONSTRAINT `p_purchase_ibfk_2` FOREIGN KEY (`item_id`) REFERENCES `p_items` (`_id`)
 ) ENGINE=InnoDB DEFAULT CHARSET=latin1;

