
    # Campus Love - Sistema de Emparejamiento

Campus Love es una aplicación de consola en **C# (.NET 8.0)** que simula un sistema de emparejamiento universitario.  
El proyecto implementa un flujo completo donde los usuarios pueden:

- Registrarse con su perfil  
- Visualizar perfiles de otras personas  
- Dar Like o Dislike  
- Revisar coincidencias (matches)  
- Consultar estadísticas de interacción  

Además, el sistema incluye un **mecanismo de créditos diarios** que limita la cantidad de interacciones disponibles.

---

## Objetivos del Proyecto
- Aplicar principios SOLID y arquitectura limpia en una aplicación de consola.  
- Utilizar patrones de diseño (Factory, Strategy, etc.) para separar responsabilidades.  
- Simular un flujo realista de emparejamiento con restricciones y estadísticas.  
- Practicar colecciones genéricas, LINQ, validaciones y control de datos.

---

## Funcionalidades Principales
- Registro de usuarios: nombre, edad, género, intereses, carrera, frase de perfil.  
- Visualización de perfiles: ver usuarios uno por uno y decidir con Like/Dislike.  
- Coincidencias (matches): cuando dos usuarios se dan Like mutuo.  
- Límite de Likes diarios: gestionado con lógica de `Math.Min` y créditos de interacción.  
- Estadísticas con LINQ:  
  - Usuario con más likes recibidos.  
  - Usuario con más matches.  
  - Total de interacciones.  
- Interfaz de consola amigable y validaciones robustas.

---

## Menú Principal
El sistema ofrece un menú interactivo en consola con las siguientes opciones:

1. Registrarse como nuevo usuario  
2. Ver perfiles y dar Like o Dislike  
3. Ver mis coincidencias (matches)  
4. Ver estadísticas del sistema  
5. Salir  

---

## Arquitectura y Diseño
La aplicación sigue **Clean Architecture** y principios **SOLID**:

- `Usuario` → Representa un perfil dentro del sistema.  
- `Interaccion` → Registro de likes/dislikes entre usuarios.  
- `GestorUsuarios` → Manejo centralizado de usuarios y sus perfiles.  
- `MatchService` → Gestión de coincidencias (matches).  
- `InteraccionFactory` → Patrón Factory para crear interacciones.  
- Estrategias de emparejamiento (edad, intereses, carrera) → Patrón Strategy.  

### Diagrama de Clases (simplificado)