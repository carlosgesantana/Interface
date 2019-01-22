IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Especificacoes'))
BEGIN
  CREATE TABLE Especificacoes
  (
    id_especificacao INT NOT NULL,
    peso_bruto DECIMAL(5, 2) NOT NULL,
	peso_liquido DECIMAL(5, 2) NOT NULL,
	largura DECIMAL(5, 2) NOT NULL,
	altura DECIMAL(5, 2) NOT NULL,
	profundidade DECIMAL(5, 2) NOT NULL,
	data_validade DATETIME DEFAULT '01-01-2099',
	garantia INT DEFAULT 0,
    PRIMARY KEY(id_especificacao)
  )
END;
