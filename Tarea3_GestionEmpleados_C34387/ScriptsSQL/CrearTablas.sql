-- Script de creación de tabla Empleados
CREATE TABLE Empleados (
    Id INT NOT NULL PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Apellidos NVARCHAR(100) NOT NULL,
    Departamento NVARCHAR(50) NOT NULL,
    Salario DECIMAL(18, 2) NOT NULL,
    FechaIngreso DATETIME NOT NULL,
    Activo BIT NOT NULL DEFAULT 1
);
GO

-- Ejemplo de restricción de salario (Punto 1 de la guía)
-- El salario debe estar entre 400,000 y 10,000,000
-- ALTER TABLE Empleados ADD CONSTRAINT CHK_Salario CHECK (Salario >= 400000 AND Salario <= 10000000);