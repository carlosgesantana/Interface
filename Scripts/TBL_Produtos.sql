﻿CREATE TABLE TBL_Produtos (

	ID_PROD VARCHAR(30) NOT NULL PRIMARY KEY,
	ID_BLING VARCHAR(10),
	ID_FORNECEDOR INT NOT NULL,
	NCM VARCHAR(50),
	OBS VARCHAR(150),
	ORIGEM_NAC BIT NOT NULL DEFAULT 1,
	CUSTO DECIMAL(18,2) NOT NULL,
	PRECO DECIMAL(18, 2) NOT NULL,
	STATUS_PROD CHAR(1) NOT NULL DEFAULT 'C',
	ESTOQUE INT NOT NULL,
	GTIN_EAN_EMB VARCHAR(50),
	GTIN_EAN VARCHAR(50),
	CEST VARCHAR(10),
	DESC_CURTA VARCHAR(50) NOT NULL
)