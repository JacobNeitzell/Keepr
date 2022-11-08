-- Active: 1666715462927@@SG-fossil-throne-24-6835-mysql-master.servers.mongodirector.com@3306@FossilThrone

CREATE TABLE
    IF NOT EXISTS vault(
        id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
        creatorId VARCHAR(255) NOT NULL,
        name VARCHAR(255) NOT NULL,
        description VARCHAR(255) NOT NULL,
        Img VARCHAR(300) NOT NULL,
        isPrivate TINYINT DEFAULT 0,
        FOREIGN KEY(creatorId) REFERENCES accounts(id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';