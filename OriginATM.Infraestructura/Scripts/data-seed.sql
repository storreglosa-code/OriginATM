USE OriginATMDb; 
IF NOT EXISTS (SELECT 1 FROM Tarjetas WHERE Numero = '1111111111111111')
BEGIN
    INSERT INTO Tarjetas (Numero, Pin, Balance, EstaBloqueada, IntentosFallidos, FechaVencimiento) 
	VALUES ('1111111111111111', '111', 1234, 0, 2, '20250801');
END
IF NOT EXISTS (SELECT 1 FROM Tarjetas WHERE Numero = '2222222222222222')
BEGIN
	INSERT INTO Tarjetas (Numero, Pin, Balance, EstaBloqueada, IntentosFallidos, FechaVencimiento) 
	VALUES ('2222222222222222', '222', 23000, 0, 1, '20270801');
END
IF NOT EXISTS (SELECT 1 FROM Tarjetas WHERE Numero = '3333333333333333')
BEGIN
	INSERT INTO Tarjetas (Numero, Pin, Balance, EstaBloqueada, IntentosFallidos, FechaVencimiento) 
	VALUES ('3333333333333333', '333', 30000, 0, 0, '20250901');
END
IF NOT EXISTS (SELECT 1 FROM Tarjetas WHERE Numero = '4444444444444444')
BEGIN
	INSERT INTO Tarjetas (Numero, Pin, Balance, EstaBloqueada, IntentosFallidos, FechaVencimiento) 
	VALUES ('4444444444444444', '444', 44444, 0, 1, '20251001');
END
IF NOT EXISTS (SELECT 1 FROM Tarjetas WHERE Numero = '5555555555555555')
BEGIN
	INSERT INTO Tarjetas (Numero, Pin, Balance, EstaBloqueada, IntentosFallidos, FechaVencimiento) 
	VALUES ('5555555555555555', '555', 50999, 1, 4, '20251201');
END

