-- Active: 1666715462927@@SG-fossil-throne-24-6835-mysql-master.servers.mongodirector.com@3306@FossilThrone

CREATE TABLE
    IF NOT EXISTS vaultkeep(
        id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
        creatorId VARCHAR(255) NOT NULL,
        vaultId INT NOT NULL,
        keepId INT NOT NULL,
        FOREIGN KEY (vaultId) REFERENCES vault(id),
        FOREIGN KEY (keepId) REFERENCES keeps(id)
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