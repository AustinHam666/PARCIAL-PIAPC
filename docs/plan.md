# Plan de intervencion

## Objetivo del plan

Implementar el movimiento vertical de las dos paletas dentro de los limites de la cancha, en pasos pequenos y verificables en Play Mode, sin tocar fisica de pelota ni puntaje (fuera de alcance de esta etapa segun `especificacion.md`).

## Cambios propuestos

| Paso | Cambio minimo | Archivos previstos | Verificacion | Riesgo | Condicion de detencion |
|---:|---|---|---|---|---|
| 1 | Crear el proyecto Unity 2022.3.62f3 (2D) dentro de esta carpeta desde Unity Hub | `Assets/`, `ProjectSettings/`, `Packages/` (generados por el Editor) | Abrir el proyecto y confirmar que Unity Hub no reporta errores | Bajo | Si Unity Hub crea el proyecto en otra ruta o mezcla con otro motor |
| 2 | Agregar `.gitignore` oficial de Unity e inicializar el repositorio git con un primer commit del proyecto vacio | `.gitignore`, commit inicial | `git status` sin archivos de Library/Temp trackeados | Bajo | Si aparecen carpetas generadas (Library, Temp, obj) en `git status` |
| 3 | Crear la escena principal con los limites visuales de la cancha (paredes o marcas) y los dos GameObjects de paleta (izquierda/derecha) sin logica aun | `Assets/Scenes/...`, GameObjects en la escena | Revisar en el Editor que ambas paletas esten visibles en sus extremos | Bajo | Si no hay forma clara de definir limites de cancha en la escena |
| 4 | Escribir el script `PaddleMovement` (o similar) que mueva la paleta en el eje vertical segun input, sin limites aun | `Assets/Scripts/PaddleMovement.cs` | Play Mode: la paleta responde a W/S o flechas arriba/abajo | Bajo | Si el input no responde por configuracion del proyecto |
| 5 | Agregar el clamping de posicion a los limites de cancha (superior/inferior) en el mismo script | `Assets/Scripts/PaddleMovement.cs` | Play Mode: mantener la tecla presionada contra cada borde, la paleta se detiene sin salir ni vibrar | Bajo | Si el clamping produce jitter o la paleta atraviesa el limite |
| 6 | Asignar el mapeo de teclas correcto por instancia (izquierda: W/S, derecha: flechas) y validar reposo sin input | `Assets/Scripts/PaddleMovement.cs`, configuracion en el Inspector | Play Mode: cada paleta responde solo a su propio mapeo; sin input, ninguna paleta se mueve | Bajo | Si ambas paletas comparten mapeo por error |

## Orden de implementacion

El orden respeta la secuencia natural: primero debe existir el proyecto y la escena (pasos 1-3) antes de escribir codigo (paso 4), luego se agrega la restriccion de limites (paso 5) porque depende de que el movimiento basico ya funcione, y por ultimo se ajusta el mapeo por jugador (paso 6) para no confundir bugs de input con bugs de limites durante las pruebas intermedias. Se hace una pausa para commit despues de cada paso verificado en Play Mode.

## Fuera de alcance (Etapa 1)

- Fisica y movimiento de la pelota, rebotes, deteccion de punto y contador: se abordaran en la Etapa 2 de este plan.
- Sonido, menus, IA, condicion de fin de partida: excluidos segun `GDD.md`.

## Etapa 2: Fisica de pelota, rebotes y puntaje

Objetivo: cubrir el resto del comportamiento esperado en `GDD.md` (pelota con velocidad constante, rebote contra paredes y paletas, deteccion de punto, reinicio de ronda), sin tocar el script `PaddleMovement.cs` salvo que un caso limite lo requiera.

| Paso | Cambio minimo | Archivos previstos | Verificacion | Riesgo | Condicion de detencion |
|---:|---|---|---|---|---|
| 7 | Crear GameObject `Ball` (SpriteRenderer + Rigidbody2D + CircleCollider2D) en el centro de la cancha, sin logica aun | `Assets/Scenes/SampleScene.unity` | La pelota es visible en el centro de la cancha en el Editor | Bajo | Si el `Rigidbody2D` interfiere con la fisica 2D por defecto del proyecto (gravedad) |
| 8 | Agregar `BallMovement.cs`: velocidad constante inicial en una direccion aleatoria u oblicua, sin rebote aun | `Assets/Scripts/BallMovement.cs` | Play Mode: la pelota se mueve en linea recta desde el centro | Bajo | Si la velocidad inicial produce una trayectoria puramente vertical u horizontal (rompe el caso limite de esquinas) |
| 9 | Agregar `BoxCollider2D` a `BorderTop`/`BorderBottom` (hoy solo visuales) y logica de rebote vertical al chocar con ellas | `Assets/Scenes/SampleScene.unity`, `Assets/Scripts/BallMovement.cs` | Play Mode: la pelota rebota contra el borde superior e inferior sin atravesarlo | Bajo | Si el rebote invierte mal el eje (rebote horizontal en vez de vertical) |
| 10 | Rebote de la pelota contra las paletas (`PaddleLeft`/`PaddleRight`), con posible cambio de angulo segun el punto de impacto | `Assets/Scripts/BallMovement.cs` | Play Mode: la pelota rebota al tocar cada paleta, incluso en el impacto tangencial del caso limite del GDD | Medio | Si el impacto tangencial produce un rebote fantasma o doble colision en el mismo frame |
| 11 | Deteccion de punto: la pelota sale por el limite izquierdo o derecho de la cancha | `Assets/Scripts/BallMovement.cs` (o un `GameManager.cs` nuevo) | Play Mode: al dejar salir la pelota por un lado, se detecta el evento de punto (log o variable) | Bajo | Si la deteccion se dispara antes de que la pelota realmente cruce el limite |
| 12 | Contador de puntaje en pantalla (UI Text/TextMeshPro) y reinicio de la pelota al centro tras cada punto | `Assets/Scenes/SampleScene.unity`, `Assets/Scripts/GameManager.cs` (nuevo) | Play Mode: el contador se actualiza correctamente y la pelota vuelve al centro con velocidad valida | Medio | Si el reinicio deja la pelota en un estado invalido (velocidad cero, posicion fuera de cancha) |

## Fuera de alcance (Etapa 2)

- Sonido, menus, dificultad progresiva, IA, marcador de victoria final o condicion de fin de partida: excluidos segun `GDD.md`.

## Etapa 3: Puntaje visible, victoria por 10 puntos, particulas y explosion de gol

A pedido del estudiante se amplia el alcance mas alla de `GDD.md` original (que dejaba puntaje/fin de partida fuera). El codigo ya esta preparado (`GameManager.cs`, `BallMovement.cs`); faltan los elementos visuales/nativos de Unity, que se arman en el Editor para evitar repetir el problema de serializacion manual sufrido con `PhysicsMaterial2D` (error "Can't produce abstract class Collider2D").

| Paso | Cambio minimo | Quien lo hace | Verificacion |
|---:|---|---|---|
| 13 | Marcador visible en pantalla | Implementado en codigo: `GameManager.OnGUI()` dibuja el puntaje de cada jugador con `GUI.Label`, sin Canvas/UI nativo | Al anotar un punto en Play Mode, el numero en pantalla se actualiza |
| 14 | ~~Asignar Text en Inspector~~ | No aplica (paso 13 no usa Canvas/Text) | - |
| 15 | Estela de particulas en la pelota | Implementado en codigo: `BallTrailEffect.cs` genera copias fantasma semitransparentes que se desvanecen, sin `ParticleSystem` nativo | La pelota deja una estela visible al moverse en Play Mode |
| 16 | Explosion de gol | Implementado en codigo: `GoalExplosionEffect.cs` genera fragmentos que salen disparados y se desvanecen al anotar, sin `ParticleSystem` nativo ni prefab | Al anotar un gol aparece la explosion en el lugar donde salio la pelota |
| 17 | Verificar reinicio de partida al llegar a 10 puntos | Ya implementado en `GameManager.cs` (Etapa 2/3) | Marcador vuelve a 0-0 y la pelota se reinicia al centro |

Nota: se decidio implementar los pasos 13, 15 y 16 enteramente en codigo C# (sin Canvas/UI ni ParticleSystem nativos de Unity) para no repetir el riesgo de corromper la escena que causo el incidente del `PhysicsMaterial2D` (ver `docs/registro-intervencion.md`). El estudiante pidio explicitamente "hacelo todo vos" en vez de armar los componentes visualmente en el Editor.

## Fuera de alcance (Etapa 3)

- Menus, sonido, animaciones de victoria, guardado de puntajes entre partidas.
