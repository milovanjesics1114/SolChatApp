USE [master]
GO

DROP DATABASE IF EXISTS ChatDB
GO

CREATE DATABASE ChatDB
GO


DROP SCHEMA IF EXISTS ChatDB
USE ChatDB
GO

CREATE SCHEMA ChatDB AUTHORIZATION dbo;
GO



CREATE TABLE ChatDB.korisnik
(
	korisnikID INT IDENTITY(1,1) PRIMARY KEY
	,korisnik_ime NVARCHAR(100) NOT NULL
	,korisnik_korisnicko_ime NVARCHAR(100) UNIQUE NOT NULL
	,korisnik_sifra NVARCHAR(30) NOT NULL
	,korisnik_email NVARCHAR(100) NOT NULL
	,korisnik_logo NVARCHAR(255) NULL
	,korisnik_status TINYINT NOT NULL

)
SET IDENTITY_INSERT ChatDB.korisnik ON;
INSERT INTO ChatDB.korisnik (korisnikID, korisnik_ime, korisnik_korisnicko_ime, korisnik_sifra, korisnik_email, korisnik_logo, korisnik_status)
VALUES (2, N'misa', N'lordwolf', N'2505995', N'misajesic@gmail.com', N'/img/slika1.jpg', 0 )
SET IDENTITY_INSERT ChatDB.korisnik OFF;
SELECT * FROM ChatDB.korisnik;

CREATE TABLE ChatDB.grupa
(
	grupaID INT IDENTITY(1,1) PRIMARY KEY
	,datum_kreiranja DATE NOT NULL
	,ime_grupe NVARCHAR(50) NOT NULL
)
--SELECT CAST( GETDATE() AS Date ) ;

SET IDENTITY_INSERT ChatDB.grupa ON;
INSERT INTO ChatDB.grupa (grupaID, datum_kreiranja, ime_grupe)
VALUES (1,  CAST( GETDATE() AS Date ), N'Nasa grupa')
SET IDENTITY_INSERT ChatDB.grupa OFF;
SELECT * FROM ChatDB.grupa





CREATE TABLE ChatDB.poruka
( 
	porukaID INT IDENTITY(1,1) PRIMARY KEY
	,sadrzaj NVARCHAR(MAX) NOT NULL
	,vreme_poruke TIME(7) NOT NULL
	,korisnik_korisnikID INT NOT NULL
	,INDEX fk_poruka_korisnik1_inx (korisnik_korisnikID ASC)
	,CONSTRAINT fk_poruka_korisnik1
	FOREIGN KEY (korisnik_korisnikID)
	REFERENCES ChatDB.korisnik(korisnikID)
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
)

SET IDENTITY_INSERT ChatDB.poruka ON;
INSERT INTO ChatDB.poruka (porukaID, sadrzaj, vreme_poruke, korisnik_korisnikID)
VALUES (1, N'Ovde ide sadrzaj poruke sa nekim txtom',  CAST( GETDATE() AS Time ), 2 )

SET IDENTITY_INSERT ChatDB.poruka OFF;
SELECT * FROM ChatDB.poruka



CREATE TABLE ChatDB.korisnicke_grupe (
  korisnik_korisnikID INT NOT NULL
  ,grupa_GrupaID INT NOT NULL
  ,poruka_porukaID INT NOT NULL
  ,PRIMARY KEY (korisnik_korisnikID, grupa_GrupaID)
  ,INDEX fk_korisnik_has_grupa_grupa1_idx (grupa_GrupaID ASC)
  ,INDEX fk_korisnik_has_grupa_korisnik_idx (korisnik_korisnikID ASC)
  ,INDEX fk_korisnicke_grupe_poruka1_idx (poruka_porukaID ASC)
  ,CONSTRAINT fk_korisnik_has_grupa_korisnik
    FOREIGN KEY (korisnik_korisnikID)
    REFERENCES ChatDB.korisnik (korisnikID)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
  ,CONSTRAINT fk_korisnik_has_grupa_grupa1
    FOREIGN KEY (grupa_GrupaID)
    REFERENCES ChatDB.grupa (GrupaID)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
  ,CONSTRAINT fk_korisnicke_grupe_poruka1
    FOREIGN KEY (poruka_porukaID)
    REFERENCES ChatDB.poruka (porukaID)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
)

--SET IDENTITY_INSERT ChatDB.korisnicke_grupe ON;
INSERT INTO ChatDB.korisnicke_grupe (korisnik_korisnikID, grupa_grupaID, poruka_porukaID)
VALUES (2,  1,1)

--SET IDENTITY_INSERT ChatDB.korisnicke_grupe OFF;
SELECT * FROM  ChatDB.korisnicke_grupe
