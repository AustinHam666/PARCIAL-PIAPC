# Matriz de permisos

Completa esta matriz antes de habilitar acciones de un agente. Una accion no declarada debe considerarse prohibida hasta consultar.

| Accion | Estado | Alcance o justificacion |
|---|---|---|
| Leer archivos del proyecto | Permitida | Necesaria para auditar y seguir el avance. |
| Buscar rutas y simbolos | Permitida | Necesaria para ubicar scripts y assets existentes. |
| Editar archivos previstos | Permitida | Limitada a `Assets/Scripts/*`, escenas de la carpeta del proyecto y los documentos de `docs/`, `README.md`, `GDD.md`, segun el paso activo del plan. |
| Ejecutar scripts documentados | Permitida | Comandos de git (status, add, commit, push, log) para el flujo de commits acordado; no se ejecutan builds ni scripts de Unity por linea de comandos sin pedirlo antes. |
| Instalar dependencias | Prohibida | El plan usa Input Manager legacy; no se instalan paquetes sin autorizacion explicita nueva. |
| Usar red | Permitida (acotada) | Unicamente para `git push` al remoto ya autorizado (`origin`, rama `PARCIAL-1`); no se usa red para otro fin sin pedirlo. |
| Publicar o subir cambios | Permitida (acotada) | El estudiante autorizo el 2026-09-15 hacer commit y push de cada paso a `https://github.com/AustinHam666/PARCIAL-PIAPC`, rama `PARCIAL-1` (no `main`). No se hace merge a `main` ni se toca otra rama sin pedirlo. |
| Acceder a secretos o credenciales | Prohibida | No corresponde al trabajo. |

## Condiciones de detencion

- El paso del plan requiere una decision de diseno no definida (ej. velocidad de paleta, dimensiones de cancha) y no fue confirmada por el estudiante.
- Unity Hub genera una estructura de proyecto distinta a la esperada (otra ubicacion, otro tipo de proyecto).
- Aparecen carpetas generadas por Unity (Library, Temp, obj, Logs, UserSettings) en `git status` antes de aplicar el `.gitignore` oficial.
- Cualquier prueba en Play Mode falla de forma no explicable por el cambio recien hecho.
