IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Marcas'))
BEGIN
  CREATE TABLE Marcas
  (
    id_marca INT IDENTITY,
    nome VARCHAR(20) NOT NULL,
    descricao VARCHAR(500) NOT NULL,
    PRIMARY KEY(id_marca)
  )
END;