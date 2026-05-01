# Tarea 3 - Sistema de Gestión de Empleados

**Estudiante:** Keity López Reyes
**Carné:** C34387 
**Curso:** IF4101 Lenguajes para aplicaciones comerciales - 002 - UCR

## Descripción
Este proyecto consiste en un sistema de gestión de personal que implementa el patrón **Repositorio** y **Entity Framework Core**. Permite realizar operaciones CRUD, búsqueda filtrada y paginación de resultados.

## Funcionalidad de Paginación
La paginación se maneja desde el servidor mediante los métodos `Skip()` y `Take()` de LINQ. 
* Se muestran **5 registros por página** para optimizar la carga de datos.
* El repositorio calcula el total de páginas basándose en el conteo de registros filtrados.

## Ejemplo de URL con Búsqueda
Para realizar una búsqueda del departamento "TI", la URL generada por el sistema es:
`https://localhost:[PUERTO]/Empleados?busqueda=TI`

## Instrucciones de Ejecución
1. Clonar el repositorio.
2. Abrir la solución `.sln` en **Visual Studio**.
3. Asegurarse de que los paquetes NuGet estén restaurados.
4. Presionar **F5** para ejecutar. La base de datos se creará automáticamente gracias a `Database.EnsureCreated()`.