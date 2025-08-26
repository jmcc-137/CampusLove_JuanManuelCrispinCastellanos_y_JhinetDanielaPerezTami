# Campus Love - Sistema de Emparejamiento Universitario

Campus Love es una aplicación de consola en **C# (.NET 8.0)** que simula un sistema de emparejamiento universitario, con lógica de matches, créditos diarios y estadísticas. Permite:

- Registro de usuarios con perfil completo
- Visualización de perfiles y dar Like/Dislike
- Coincidencias (matches) automáticas
- Estadísticas de interacción
- Límite de likes diarios configurable

---

## Objetivos del Proyecto
- Aplicar principios SOLID y Clean Architecture
- Usar patrones de diseño (Factory, Strategy, etc.)
- Simular un flujo realista de emparejamiento con restricciones y estadísticas
- Practicar LINQ, validaciones y control de datos

---

## Funcionalidades Principales
- Registro de usuarios: nombre, edad, género, intereses, carrera, frase de perfil
- Visualización de perfiles: ver usuarios uno por uno y decidir con Like/Dislike
- Coincidencias (matches): cuando dos usuarios se dan Like mutuo
- Límite de Likes diarios: configurable por usuario (`CreditosDiarios`)
- Estadísticas con LINQ: usuarios con más likes, más matches, total de interacciones
- Interfaz de consola amigable y validaciones robustas

---

## Menú Principal
El sistema ofrece un menú interactivo en consola con las siguientes opciones:

1. Registrarse como nuevo usuario
2. Ver perfiles y dar Like o Dislike
3. Ver mis coincidencias (matches)
4. Ver estadísticas del sistema
5. Eliminar cuenta
6. Salir

---

## Arquitectura y Diseño
La aplicación sigue Clean Architecture y principios SOLID:

- **Usuario**: Perfil con datos, intereses y créditos diarios
- **Interaccion**: Registro de likes/dislikes entre usuarios
- **MatchService**: Gestión de coincidencias (matches)
- **InteraccionFactory**: Patrón Factory para crear interacciones
- **Estrategias de emparejamiento**: Por edad, intereses, carrera (Strategy)

### Diagrama de Clases (simplificado)

```text
┌────────────┐      ┌──────────────┐      ┌──────────────┐
│  Usuario   │◄────▶│ Interaccion  │◄────▶│ TiposInterac │
└────────────┘      └──────────────┘      └──────────────┘
     ▲   ▲                │
     │   └──────────────┐ │
     │                  ▼ ▼
┌────────────┐      ┌──────────────┐
│  Carrera   │      │   Interes    │
└────────────┘      └──────────────┘
```

Relaciones:
- Un usuario tiene muchos intereses y puede dar muchas interacciones
- Cada interacción es de un tipo (LIKE/DISLIKE)
- Los matches se detectan cuando dos usuarios se dan like mutuo

---

## Instalación y Ejecución

1. Clona el repositorio:
   ```bash
   git clone https://github.com/jmcc-137/CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.git
   cd CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami
   ```
2. Configura la base de datos MySQL (ver archivo `MySql/dll.sql` para estructura y tablas).
3. Ajusta la cadena de conexión en `appsettings.json` o variable de entorno `MySQL_CONECTION`.
4. Restaura dependencias y ejecuta:
   ```bash
   dotnet restore
   dotnet run
   ```

---

## Ejemplo de Uso

```text
💖 Campus Love 💖
¿Qué deseas hacer?
1. Registrarse como nuevo usuario
2. Ver perfiles y dar Like/Dislike
...

// Registro
Nombre: Juan
Edad: 22
Género: Masculino
...

// Ver perfiles
┌────────────┬─────┬────────────────────┬────────────────────┐
│  Nombre    │Edad │ Frase de perfil    │ Intereses          │
├────────────┼─────┼────────────────────┼────────────────────┤
│  Ana       │ 21  │ "Me gusta la música" │ Música, Cine     │
└────────────┴─────┴────────────────────┴────────────────────┘
¿Qué deseas hacer con este perfil? (Like/Dislike/Salir)
```

---

## Base de Datos

El sistema usa MySQL. Consulta el archivo [`MySql/dll.sql`](MySql/dll.sql) para la estructura completa de tablas y relaciones.

---

## Dependencias
- .NET 8.0
- MySQL
- Spectre.Console (UI consola)
- Entity Framework Core

---

## Créditos y Licencia
Desarrollado por Juan Manuel Crispin Castellanos y Jhinet Daniela Perez Tami.

Licencia MIT.