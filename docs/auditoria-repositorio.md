# Auditoria del repositorio

## Objetivo

Registrar hechos verificables sobre la estructura, arquitectura y validacion del proyecto antes de proponer cambios.

## Rutas y simbolos relevantes

| Ruta o simbolo | Rol observado | Evidencia |
|---|---|---|
| `README.md`, `GDD.md`, `docs/*.md` | Documentacion de proceso de la plantilla PIAPC, completada para este proyecto (Pong) | Lectura directa de cada archivo |
| `Assets/Scripts/` (aun no existe) | Contendra los scripts de movimiento de paletas | Se creara en el Paso 1-4 del `plan.md` |

Esta tabla se actualizara con rutas reales de `Assets/` una vez Unity Hub genere el proyecto (Paso 1 del plan) y se agreguen los scripts.

## Flujo observado

Aun no hay flujo de ejecucion real: no existe proyecto Unity en el repositorio. El flujo previsto (a verificar cuando exista codigo) es: input de teclado (W/S o flechas arriba/abajo) leido en `Update()` de un script por paleta, que traduce el input en un desplazamiento vertical y lo aplica al `Transform` (o `Rigidbody2D`) de esa paleta, con un clamping final a los limites de la cancha.

## Pruebas y comandos disponibles

| Comando o prueba | Que verifica | Resultado inicial |
|---|---|---|
| Play Mode manual en el Editor | Que la paleta se mueva con su tecla asignada y respete los limites | Pendiente: no hay escena ni script todavia |

No hay Unity Test Framework configurado; para este alcance (movimiento simple) la verificacion se hace por Play Mode manual segun `evidencia-pruebas.md`.

## Hechos, supuestos y preguntas abiertas

- Hechos comprobados: no existe carpeta `Assets/` ni proyecto Unity en el repositorio al momento de esta auditoria; el repositorio no tenia control de versiones git inicializado antes de este trabajo.
- Supuestos por verificar: Unity Hub creara el proyecto directamente en la raiz de este repositorio sin mezclar con otra estructura.
- Preguntas para consultar: dimensiones definitivas de cancha y paleta, y velocidad de movimiento (ver `especificacion.md`, seccion Preguntas abiertas).
