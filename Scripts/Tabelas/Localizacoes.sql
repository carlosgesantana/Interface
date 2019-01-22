IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Localizacoes'))
BEGIN
  CREATE TABLE Localizacoes
  (
    id_localizacao INT IDENTITY,
    cidade VARCHAR(40) NOT NULL,
    estado VARCHAR(2) NOT NULL,
    PRIMARY KEY(id_localizacao)
  )
END;