-- Active: 1675287303490@@SG-south-front-8653-7173-mysql-master.servers.mongodirector.com@3306@Sgroot

CREATE TABLE
    IF NOT EXISTS keeps(
        id INT NOT NULL AUTO_INCREMENT primary key,
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        creatorId VARCHAR(255) NOT NULL,
        name VARCHAR(255) NOT NULL,
        description VARCHAR(400) NOT NULL,
        img VARCHAR(350) NOT NULL,
        views INT NOT NULL,
        FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';