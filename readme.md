## Prueba técnica sistema de creación de materias, estudiantes e inscripciones de estudiantes a las materias - ASP.NET Core MVC

#### Despliegue dockerizado y montado sobre imagen de ubuntu en plataforma render, url de acceso público
- URL despliegue: https://technicaltest-q10.onrender.com/

###  Objetivo
Aplicación web para administrar estudiantes, materias y sus inscripciones, desarrollada como prueba técnica.

### Resultado
Se desarrolla aplicación web en ASP .NET Core MVC usando razor pages que cumple con:

- Gestión de estudiantes: Crear, editar, eliminar y listar estudiantes (nombre,
documento, correo).
- Gestión de materias: Crear, editar, eliminar y listar materias (nombre, código,
créditos).
- Inscripción de materias: Permitir asociar materias a estudiantes y validar que
un estudiante no inscriba más de 3 materias con más de 4 créditos cada una.


## Requerimientos tecnicos desarrollados 

- Proyecto desarrollado en .NET 8
- Arquitectura limpia o por capas, aplicando principios SOLID.
 - Uso de Entity Framework Core con base de datos local SQLite.
- Buen manejo de validaciones.
- Frontend implementado con ASP.NET Core MVC con Razor Pages
- Implementación de inyección de dependencias y separación de
responsabilidades.
- Se implementan pruebas unitarias para Servicio de estudiantes


## Instalación

### Requisitos para la instalación

- .Net 8.0

### Pasos para la instalación

- Clonar repositorio -> git clone https://github.com/MaicolAADev/TechnicalTest-Q10.git
- Acceder -> cd TechnicalTest-Q10
- Restaurar dependencias -> dotnet restore
- Configurar base de datos: es SQLite entonces no es necesario cambiar parámetros de conexion, unicamente ejecutar la migración desde la consola de paquetes NuGet, se ejecuta el siguiente comando -> Update-Database


#### Ejecutar el proyecto

- comando -> dotnet run --project University.Web
- ir a la web y ver la ejecución.


# Arquitectura y CI/CD

##  Arquitectura Implementada

### Estructura por Capas

- Web: Vistas Razor y PageModels

- Core: DTOs, entities, utils, exception.

- Infraestructure: Repositorios, migraciones, dbContext

- Services: Servicios, logica de negocio

- Test: Pruebas unitarias


## CI/CD

### Flujos automatizados .github/workflows

GitHub Actions para:

- Build
- Pruebas unitarias
- Auto-deploy a Render en push a main con imagen de Docker 

Cada que se hace push a la main se ejecutan las anteriores tareas, garantizando el funcionamiento correcto de la aplicación de manera automatizada.
- Dentro de repositorio: https://github.com/MaicolAADev/TechnicalTest-Q10/tree/master/.github/workflows se encuentran los flujos encargados de ejecutar las acciones mencionadas.


## Pruebas unitarias

Desarrolladas con xUnit y usando librerias como Moq
- Cobertura actual: para efectos de la prueba tecnica unicamente el servicio de estudiantes.
