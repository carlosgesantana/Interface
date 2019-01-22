IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Imagens'))
BEGIN
  CREATE TABLE Imagens
  (
    id_imagem VARCHAR(25) NOT NULL,
    url_imagem VARCHAR(30) NOT NULL,
    id_produto VARCHAR(25) NOT NULL,
    PRIMARY KEY(id_imagem)
  )
END;