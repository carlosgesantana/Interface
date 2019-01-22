IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'MarcaFornecedor'))
BEGIN
  CREATE TABLE MarcaFornecedor
  (
    id_marca INT NOT NULL,
    id_fornecedor INT NOT NULL,
    PRIMARY KEY(id_marca, id_fornecedor)
  )
END;