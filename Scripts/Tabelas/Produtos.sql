IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Produtos'))
BEGIN
  CREATE TABLE Produtos
  (
    id_produto VARCHAR(25) NOT NULL,
    descricao VARCHAR(100) NOT NULL,
    id_fornecedor INT NOT NULL,
    id_marca INT,
    id_localizacao INT NOT NULL,
    id_especificacao INT NOT NULL,
	id_bling VARCHAR(10),
	unidade VARCHAR(2) NOT NULL DEFAULT 'UN',
	ncm VARCHAR(50),
	origem INT NOT NULL DEFAULT 0,
	preco DECIMAL(18,2) NOT NULL,
	valor_ipi_fixo DECIMAL(18,2),
	observacoes VARCHAR(500),
	situacao CHAR(1) NOT NULL DEFAULT 'A',
	quantidade INT NOT NULL,
	custo DECIMAL(18,2) NOT NULL,
	id_fabricacao VARCHAR(25) NOT NULL,
	quantidade_minima INT,
	quantidade_maxima INT,
	codigo_barra VARCHAR(50),
	codigo_barra_embalagem VARCHAR(50),
	descricao_complementar VARCHAR(500) NOT NULL,
	tipo_producao VARCHAR(1) NOT NULL DEFAULT 'T',
	tipo_item VARCHAR(40) NOT NULL DEFAULT 'Mercadoria para revenda',
	tributos DECIMAL(18,2),
	cest VARCHAR(50),
	descricao_curta VARCHAR(200) NOT NULL,
	cross_docking INT,
	condicao VARCHAR(10) NOT NULL DEFAULT 'Novo',
    PRIMARY KEY(id_produto)
  )
END;