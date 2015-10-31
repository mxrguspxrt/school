  CREATE SEQUENCE seq1 AS INTEGER START WITH 1;
  
  CREATE TABLE customer (
         id BIGINT NOT NULL PRIMARY KEY,
         first_name VARCHAR(255) NOT NULL,
         surname VARCHAR(255) NOT NULL,
         code VARCHAR(255) NOT NULL,
  );
  
  INSERT INTO customer VALUES(NEXT VALUE FOR seq1,'Jane','Doe','123');
  INSERT INTO customer VALUES(NEXT VALUE FOR seq1,'John','Doe','456');
  INSERT INTO customer VALUES(NEXT VALUE FOR seq1,'Jack','Smith','789');
  