IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Fornecedores'))
BEGIN
  CREATE TABLE Fornecedores
  (
    id_fornecedor INT IDENTITY,
    nome VARCHAR(20) NOT NULL,
    PRIMARY KEY(id_fornecedor)
  )
END;