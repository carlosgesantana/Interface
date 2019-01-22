IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'LocalizacaoFornecedor'))
BEGIN
  CREATE TABLE LocalizacaoFornecedor
  (
    id_fornecedor INT NOT NULL,
    id_localizacao INT NOT NULL,
	PRIMARY KEY(id_fornecedor, id_localizacao)    
  )
END;