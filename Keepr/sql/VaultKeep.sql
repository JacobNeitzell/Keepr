-- Active: 1675287303490@@SG-south-front-8653-7173-mysql-master.servers.mongodirector.com@3306@Sgroot

CREATE TABLE
    IF NOT EXISTS vaultkeep(
        id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
        creatorId VARCHAR(255) NOT NULL,
        vaultId INT NOT NULL,
        keepId INT NOT NULL,
        FOREIGN KEY (vaultId) REFERENCES vault(id) ON DELETE CASCADE,
        FOREIGN KEY (keepId) REFERENCES keeps(id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';

SELECT
    keeps.*,
    vaultkeep.id AS vaultkeepId,
    accounts.*
FROM vaultkeep
    JOIN keeps ON keeps.id = vaultkeep.keepId
    JOIN vault ON vault.id = vaultkeep.vaultId
    JOIN accounts ON accounts.id = keeps.creatorId
WHERE vaultkeep.id = 50;