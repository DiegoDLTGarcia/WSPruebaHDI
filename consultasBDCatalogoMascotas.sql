-- Consulta sin el índice
SELECT * FROM [dbo].[Razas] WHERE [nombre_raza] = 'Labrador Retriever';

-- Consulta con el índice
SELECT * FROM [dbo].[Razas] WITH(INDEX(IX_Razas_NombreRaza)) WHERE [nombre_raza] = 'Labrador Retriever';

SELECT M.*
FROM [dbo].[Mascotas] AS M
INNER JOIN [dbo].[Razas] AS R ON M.[id_raza] = R.[id_raza]
WHERE R.[nombre_raza] = 'Labrador Retriever';

-- procedimiento almacenado
CREATE PROCEDURE BuscarMascotasPorRaza
    @nombre_raza VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT M.*
    FROM [dbo].[Mascotas] AS M
    INNER JOIN [dbo].[Razas] AS R ON M.[id_raza] = R.[id_raza]
    WHERE R.[nombre_raza] = @nombre_raza;
END;

-- ejecuntar procedimiento 
EXEC BuscarMascotasPorRaza 'Labrador Retriever';

CREATE PROCEDURE MostrarPerros
AS
BEGIN
    SET NOCOUNT ON;

    SELECT M.*
    FROM [dbo].[Mascotas] AS M
    INNER JOIN [dbo].[Razas] AS R ON M.[id_raza] = R.[id_raza]
    INNER JOIN [dbo].[Especies] AS E ON R.[id_especie] = E.[id_especie]
    WHERE E.[nombre_especie] = 'Perro';
END;

EXEC MostrarPerros;

use CatalogoMascotas

select * from Especies;
select * from Mascotas;
select * from Propietarios;
select * from Razas;

SELECT m.nombre,m.edad,p.nombre,p.apellido,r.nombre_raza,e.id_especie FROM Mascotas m
INNER JOIN Propietarios p ON m.id_propietario = p.id_propietario
INNER JOIN Razas r ON m.id_raza = r.id_raza
INNER JOIN Especies e ON r.id_especie = e.id_especie;