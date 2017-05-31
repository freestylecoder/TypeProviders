-- NOTE: The segmented sections of this SQL script denote the logical steps I use in the demo
-- This script should be able to run as a whole in a SQL Server script window

USE master;
GO

CREATE DATABASE TypeProviders;
GO

USE TypeProviders

--------------------------------------------------------------------------

CREATE TABLE TopTable (
	Id				INTEGER		IDENTITY(1,1)	NOT NULL,
	TopTableData	VARCHAR(16)					NOT NULL,

	CONSTRAINT TopTable_PK PRIMARY KEY ( Id )
);

--------------------------------------------------------------------------

INSERT TopTable ( TopTableData ) VALUES
	( 'TopTableData 1' ),
	( 'TopTableData 2' ),
	( 'TopTableData 3' );

--------------------------------------------------------------------------

CREATE TABLE LookupTable (
	Id				INTEGER		IDENTITY(1,1)	NOT NULL,
	LookupTableData	VARCHAR(32)					NOT NULL,

	CONSTRAINT LookupTable_PK PRIMARY KEY ( Id )
);

--------------------------------------------------------------------------

INSERT LookupTable ( LookupTableData ) VALUES
	( 'LookupTableData 1' ),
	( 'LookupTableData 2' ),
	( 'LookupTableData 3' );

--------------------------------------------------------------------------

ALTER TABLE TopTable ADD LookupTableId INTEGER NULL;
GO
UPDATE TopTable SET LookupTableId = 1;
ALTER TABLE TopTable ALTER COLUMN LookupTableId INTEGER NOT NULL;
ALTER TABLE TopTable ADD CONSTRAINT TopTable_LookupTable_FK FOREIGN KEY ( LookupTableId ) REFERENCES LookupTable( Id );

UPDATE TopTable SET LookupTableId = 2 WHERE Id = 1;

--------------------------------------------------------------------------

CREATE TABLE OtherTable (
	Id				INTEGER		IDENTITY(1,1)	NOT NULL,
	OtherTableData	VARCHAR(32)					NOT NULL,

	CONSTRAINT OtherTable_PK PRIMARY KEY ( Id )
);

--------------------------------------------------------------------------

INSERT OtherTable ( OtherTableData ) VALUES
	( 'OtherTableData 1' ),
	( 'OtherTableData 2' ),
	( 'OtherTableData 3' );

--------------------------------------------------------------------------

CREATE TABLE JoinTable (
	TopTableId		INTEGER						NOT NULL,
	OtherTableId	INTEGER						NOT NULL,

	CONSTRAINT JoinTable_PK PRIMARY KEY ( TopTableId, OtherTableId ),
	CONSTRAINT JoinTable_TopTable_FK FOREIGN KEY ( TopTableId ) REFERENCES TopTable( Id ),
	CONSTRAINT JoinTable_OtherTable_FK FOREIGN KEY ( OtherTableId ) REFERENCES OtherTable( Id )
);

--------------------------------------------------------------------------

INSERT JoinTable ( TopTableId, OtherTableId ) VALUES
	( 1, 3 ),
	( 2, 1 ),
	( 2, 2 ),
	( 2, 3 ),
	( 3, 1 );
