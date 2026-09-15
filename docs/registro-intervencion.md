# Registro de intervencion agentica

Registra cada ciclo relevante de herramienta. No copies razonamientos internos del modelo ni datos sensibles.

| Fecha o version | Instruccion resumida | Accion o herramienta | Resultado observable | Decision humana |
|---|---|---|---|---|
| 2026-09-15 | Definir motor, nombre de proyecto, autor y comportamiento a resolver; completar GDD.md | Preguntas al estudiante + edicion de `GDD.md`, `README.md`, `docs/especificacion.md`, `docs/plan.md`, `docs/matriz-permisos.md`, `docs/auditoria-repositorio.md`, `docs/evidencia-pruebas.md` | Documentacion base completa para iniciar el desarrollo del movimiento de paletas (Pong) | Aceptar, con correccion: el estudiante corrigio el eje de movimiento de las paletas de horizontal a vertical en el GDD |
| 2026-09-15 | Crear proyecto Unity 2022.3.62f3 en Unity Hub, consolidar carpeta con la documentacion | Comandos `mv` para unificar `README.md`, `GDD.md`, `AGENTS.md`, `.gitignore`, `docs/` dentro de `Parcial-PIAPC/`; reemplazo de `.gitignore` por el oficial de Unity | Repositorio unico con proyecto Unity + documentacion en la raiz | Aceptar |
| 2026-09-15 | Iniciar git y hacer el primer commit local (Paso 1-2 del plan) | `git init`, `git add -A`, `git commit` | Commit `f3ceb0f` con proyecto Unity vacio + documentacion, sin carpetas generadas (Library/Temp/Logs/UserSettings excluidas) | Aceptar |
| 2026-09-15 | Generar por codigo las paletas en la escena (Paso 3 del plan) | Edicion directa de `Assets/Scenes/SampleScene.unity` (YAML): GameObjects `PaddleLeft`/`PaddleRight` con Transform, SpriteRenderer y BoxCollider2D | El estudiante abrio el proyecto en el Editor, confirmo 0 errores en consola y ambas paletas visibles en la vista Game (captura de pantalla) | Aceptar |
| 2026-09-15 | Commitear y pushear cada paso; autorizacion para usar red y publicar en el remoto | `git remote add origin`, `git fetch`, `git checkout -b PARCIAL-1`, `git commit`, `git push -u origin PARCIAL-1` | Rama `PARCIAL-1` creada y pusheada a `https://github.com/AustinHam666/PARCIAL-PIAPC`, sin tocar `main` (que tiene una historia distinta de la plantilla) | Aceptar: el estudiante autorizo explicitamente commit + push por cada paso, en la rama `PARCIAL-1` |
| 2026-09-15 | Pasos 4 y 6 del plan: crear `PaddleMovement.cs` y asignarlo a cada paleta con su mapeo de teclas | Creacion de `Assets/Scripts/PaddleMovement.cs` (+ `.meta`), edicion de `SampleScene.unity` para agregar el componente `MonoBehaviour` a `PaddleLeft` (W/S) y `PaddleRight` (flechas arriba/abajo) | Commit y push a `PARCIAL-1` pedidos por el estudiante inmediatamente despues del cambio; la verificacion visual en Play Mode (movimiento fluido, sin errores) queda pendiente de confirmacion del estudiante en el proximo ciclo | Aceptar (commit y push realizados a pedido explicito); verificacion funcional pendiente |

## Correcciones y acciones rechazadas

- El GDD inicial describia paletas moviendose en el eje horizontal; el estudiante corrigio a Pong clasico (paletas a los costados, movimiento vertical) al elegir el mapeo de teclas W/S y flechas arriba/abajo. Se corrigio `GDD.md` y `docs/especificacion.md` en consecuencia.
