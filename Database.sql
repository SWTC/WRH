DROP TABLE ships;

CREATE TABLE ships (
  ship_id int NOT NULL,
  ship_name varchar(100) DEFAULT NULL,
  PRIMARY KEY (ship_id)
) ;

/*Table structure for table user_entry */

DROP TABLE  user_entry;

CREATE TABLE user_entry (
  entry_id int NOT NULL,
  user_id int DEFAULT NULL,
  ship_id int DEFAULT NULL,
  work_date date DEFAULT NULL,
  comments text,
  PRIMARY KEY (entry_id)
) ;

/*Table structure for table user_entry_hours */

DROP TABLE  user_entry_hours;

CREATE TABLE user_entry_hours (
  entry_id int DEFAULT NULL,
  start_time time DEFAULT NULL,
  end_time time DEFAULT NULL
) ;

/*Table structure for table users */

DROP TABLE  users;

CREATE TABLE users (
  user_id int NOT NULL,
  user_name varchar(50) DEFAULT NULL,
  firstname varchar(100) DEFAULT NULL,
  lastname varchar(100) DEFAULT NULL,
  email varchar(100) DEFAULT NULL,
  rankid int DEFAULT NULL,
  signon_date datetime DEFAULT NULL,
  signoff_date datetime DEFAULT NULL,
  PRIMARY KEY (user_id)
) ;
