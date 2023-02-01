-- Active: 1675287303490@@SG-south-front-8653-7173-mysql-master.servers.mongodirector.com@3306@Sgroot

CREATE TABLE
    IF NOT EXISTS vault(
        id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
        creatorId VARCHAR(255) NOT NULL,
        name VARCHAR(255) NOT NULL,
        description VARCHAR(255) NOT NULL,
        Img VARCHAR(500) NOT NULL,
        isPrivate TINYINT DEFAULT 0,
        FOREIGN KEY(creatorId) REFERENCES accounts(id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';