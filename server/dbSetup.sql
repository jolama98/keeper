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



CREATE TABLE vaults(
  id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  name VARCHAR(255) NOT NULL,
  description VARCHAR(1000) NOT NULL,
  img VARCHAR(1000) NOT NULL,
  isPrivate BOOLEAN NOT NULL,
  creatorId VARCHAR(255) NOT NULL,
  FOREIGN KEY (creatorId) REFERENCES accounts (id) ON DELETE CASCADE
)

CREATE TABLE vaultKeep(
  id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
creatorId VARCHAR(255) NOT NULL,
keepId INT NOT NULL,
vaultId INT NOT NULL,
FOREIGN KEY (vaultId) REFERENCES vaults (id) ON DELETE CASCADE,
FOREIGN KEY (keepId) REFERENCES keeps (id) ON DELETE CASCADE,
FOREIGN KEY (creatorId) REFERENCES accounts (id) ON DELETE CASCADE
)

INSERT INTO
    vaultKeep (vaultId, keepId, creatorId)
VALUES (@vaultId, @keepId, @creatorId);

SELECT vaultKeep.*, accounts.*
FROM vaultKeep
    JOIN accounts ON accounts.id = vaultKeep.creatorId
WHERE
    vaultKeep.id = LAST_INSERT_ID();

    SELECT vaultKeep.*, keeps.*, accounts.*
FROM
    vaultKeep
    JOIN accounts ON accounts.id = vaultKeep.creatorId
    JOIN keeps ON keeps.id = vaultKeep.keepId
WHERE
    vaultKeep.vaultId = 72;



DELETE  FROM vaultKeep WHERE id = @vaultKeepId LIMIT 1;



SELECT * FROM accounts WHERE id = ;



INSERT INTO `vaultKeep`(
  `vaultId`,
  `keepId`,
  `creatorId`
) VALUES(244, 209, "66d109c1258b754bca428053");


SELECT keeps.*, COUNT(vaultKeep.id) AS Kept, accounts.*
FROM
    keeps
    JOIN accounts ON accounts.id = keeps.creatorId
    LEFT JOIN vaultKeep ON vaultKeep.keepId = keeps.id
GROUP BY (keeps.id);

