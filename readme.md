## Prueba técnica sistema de creación de materias, estudiantes e inscripciones de estudiantes a las materias - ASP.NET Core MVC

#### Despliegue dockerizado y montado sobre imagen de ubuntu en plataforma render, url de acceso público
- URL despliegue: https://technicaltest-q10-kr4r.onrender.com/
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
- Para ejecutar las pruebas unitarias en local se ejecuta el siguiente comando -> dotnet test ./University.Tests/University.Tests.csproj --configuration Release --verbosity normal

- Pruebas unitarias se ejecutan en el Pipeline con el nombre -> 
Build and Test / Run Tests - Se puede evidenciar en la Raiz del repo de github https://github.com/MaicolAADev/TechnicalTest-Q10/

- Log ultima ejecución en github Actions

2025-06-20T00:20:08.0633980Z Test run for /home/runner/work/TechnicalTest-Q10/TechnicalTest-Q10/University.Tests/bin/Release/net8.0/University.Tests.dll (.NETCoreApp,Version=v8.0)
2025-06-20T00:20:08.1217417Z VSTest version 17.11.1 (x64)
2025-06-20T00:20:08.1293469Z 
2025-06-20T00:20:08.2074092Z Starting test execution, please wait...
2025-06-20T00:20:08.2298628Z A total of 1 test files matched the specified pattern.
2025-06-20T00:20:08.6149000Z [xUnit.net 00:00:00.00] xUnit.net VSTest Adapter v2.4.5+1caef2f33e (64-bit .NET 8.0.17)
2025-06-20T00:20:09.2315478Z [xUnit.net 00:00:00.63]   Discovering: University.Tests
2025-06-20T00:20:09.2558490Z [xUnit.net 00:00:00.65]   Discovered:  University.Tests
2025-06-20T00:20:09.2588261Z [xUnit.net 00:00:00.65]   Starting:    University.Tests
2025-06-20T00:20:09.3847986Z [xUnit.net 00:00:00.78]   Finished:    University.Tests
2025-06-20T00:20:09.5065521Z   Passed University.Tests.Services.StudentServiceTests.Delete_DeletesStudent_WhenStudentExists [60 ms]
2025-06-20T00:20:09.5072027Z   Passed University.Tests.Services.StudentServiceTests.Update_UpdatesStudent_WhenValidData [8 ms]
2025-06-20T00:20:09.5073387Z   Passed University.Tests.Services.StudentServiceTests.Delete_ThrowsException_WhenStudentDoesNotExist [2 ms]
2025-06-20T00:20:09.5074719Z   Passed University.Tests.Services.StudentServiceTests.GetById_ReturnsStudent_WhenStudentExists [4 ms]
2025-06-20T00:20:09.5075984Z   Passed University.Tests.Services.StudentServiceTests.Create_ThrowsException_WhenEmailExists [1 ms]
2025-06-20T00:20:09.5076906Z 
2025-06-20T00:20:09.5117828Z Test Run Successful.
2025-06-20T00:20:09.5118236Z Total tests: 5
2025-06-20T00:20:09.5118549Z      Passed: 5
2025-06-20T00:20:09.5127314Z  Total time: 1.2779 Seconds
2025-06-20T00:20:09.5227803Z      1>Done Building Project "/home/runner/work/TechnicalTest-Q10/TechnicalTest-Q10/University.Tests/University.Tests.csproj" (VSTest target(s)).
2025-06-20T00:20:09.5456728Z 
2025-06-20T00:20:09.5457309Z Build succeeded.