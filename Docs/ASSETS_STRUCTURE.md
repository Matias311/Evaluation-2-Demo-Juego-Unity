# Estructura de Assets

Esta estructura sigue la convención estándar de Unity para mantener el proyecto ordenado y fácil de navegar.

## Carpetas principales

- `Assets/Scenes`: escenas del proyecto (`.unity`).
- `Assets/Scripts`: scripts C# propios del proyecto.
- `Assets/Models`: modelos 3D y archivos asociados.
- `Assets/Materials`: materiales reutilizables.
- `Assets/Animations`: clips y controllers de animación.
- `Assets/Prefabs`: prefabs reutilizables.
- `Assets/Terrain`: assets y data del terreno.
- `Assets/UI`: recursos y prefabs de interfaz.

## Reglas básicas

- Mantener cada asset dentro de la carpeta de su tipo.
- No mezclar assets propios con paquetes de terceros.
- Evitar archivos sueltos en `Assets/` (todo dentro de carpetas).
- Conservar los `.meta` junto a cada asset.

## Terceros

Los paquetes importados se dejan dentro de su carpeta original (por ejemplo `Assets/Polytope Studio/`) para evitar romper dependencias.
