-- Create FKs
ALTER TABLE Fornecedores
    ADD CONSTRAINT FK_FK_LocalForn_Fornecedor
    FOREIGN KEY (id_fornecedor)
    REFERENCES LocalizacaoFornecedor(id_fornecedor)
;
    
ALTER TABLE Localizacoes
    ADD CONSTRAINT FK_FK_LocalForn_Localizacao
    FOREIGN KEY (id_localizacao)
    REFERENCES LocalizacaoFornecedor(id_localizacao)
;
    
ALTER TABLE Marcas
    ADD    FOREIGN KEY (id_marca)
    REFERENCES MarcaFornecedor(id_marca)
;
    
ALTER TABLE Fornecedores
    ADD    FOREIGN KEY (id_fornecedor)
    REFERENCES MarcaFornecedor(id_fornecedor)
;
    
ALTER TABLE Produtos
    ADD    FOREIGN KEY (id_produto)
    REFERENCES Imagens(id_produto)
;
    
ALTER TABLE Fornecedores
    ADD    FOREIGN KEY (id_fornecedor)
    REFERENCES Produtos(id_fornecedor)
;
    
ALTER TABLE Marcas
    ADD    FOREIGN KEY (id_marca)
    REFERENCES Produtos(id_marca)
;
    
ALTER TABLE Localizacoes
    ADD    FOREIGN KEY (id_localizacao)
    REFERENCES Produtos(id_localizacao)
;
    
ALTER TABLE Especificacoes
    ADD    FOREIGN KEY (id_especificacao)
    REFERENCES Produtos(id_especificacao)
;
