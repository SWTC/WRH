DROP TABLE ships;

CREATE TABLE ships (
  [ship_id] [int] NOT NULL,
	[ship_name] [varchar](100) NULL,
	[ship_IMO] [int] NULL,
	[serial_number] [int] NULL,
	[licence_key] [varchar](50) NULL,
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
  [user_id] [int] NOT NULL,
	[user_name] [varchar](50) NULL,
	[firstname] [varchar](100) NULL,
	[lastname] [varchar](100) NULL,
	[email] [varchar](100) NULL,
	[rankid] [int] NULL,
	[signon_date] [datetime] NULL,
	[signoff_date] [datetime] NULL,
	[password] [varchar](50) NULL,
	[passport_number] [varchar](50) NULL,
	[cdc_number] [varchar](50) NULL,
  PRIMARY KEY (user_id)
) ;
