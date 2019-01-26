--EXEC SP_InsereProdutoPadrao '3IMS', '3', 'KIT DE TRAVAS COM ALUMINIO BOTA FM TYPHOON BRANCA ( 4 UNIDADES )', 1, 50, 96,'', 0,''   

IF EXISTS(SELECT 1 FROM SYS.procedures WHERE name = 'SP_InsereProdutoPadrao') DROP PROCEDURE SP_InsereProdutoPadrao
GO
CREATE PROCEDURE SP_InsereProdutoPadrao 
	@id_produto VARCHAR(25),
	@id_fabricacao VARCHAR(25), 
	@descricao VARCHAR(100), 
	@id_fornecedor int, 
	@quantidade int, 
	@custo decimal(18,2), 
	@ncm varchar(15), 
	@origem int, 
	@codigobarras varchar(50)  
AS
BEGIN


	DECLARE @id_localizacao INT = (SELECT TOP 1 id_localizacao FROM LocalizacaoFornecedor WHERE id_fornecedor = @id_fornecedor)
	DECLARE @preco DECIMAL(18,2) = 1.5*@custo

	IF @ncm = ''
	 SET @ncm = NULL 
	
	IF @codigobarras = ''
	 SET @codigobarras = NULL 

	INSERT INTO Produtos 
		(	id_produto, descricao, 
			id_fornecedor, id_localizacao, 
			id_especificacao, origem, 
			preco, quantidade, 
			custo, id_fabricacao, 
			descricao_complementar, descricao_curta,
			codigo_barra, codigo_barra_embalagem,
			ncm
		)
	VALUES 
		(	@id_produto, @descricao, 
			@id_fornecedor, @id_localizacao, 
			1, @origem, 
			@preco, @quantidade, 
			@custo, @id_fabricacao, 
			@descricao, @descricao,
			@codigobarras, @codigobarras,
			@ncm
		)

END
GO
GRANT EXEC TO qpuser_db
GO
