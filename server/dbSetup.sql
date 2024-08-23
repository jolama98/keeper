CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) UNIQUE COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8mb4 COMMENT '';

CREATE TABLE keeps(
  id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
name VARCHAR(255) NOT NULL,
description VARCHAR(1000) NOT NULL,
img VARCHAR(1000) NOT NULL,
views INT UNSIGNED NOT NULL DEFAULT 0,
creatorId VARCHAR(255) NOT NULL,
FOREIGN KEY (creatorId) REFERENCES accounts (id) ON DELETE CASCADE
)

ALTER TABLE keeps MODIFY COLUMN views INT UNSIGNED NOT NULL DEFAULT 0