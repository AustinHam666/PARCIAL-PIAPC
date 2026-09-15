# Especificacion

## Problema

El prototipo Pong descrito en `GDD.md` no existe todavia: no hay movimiento de paletas, ni fisica de pelota, ni deteccion de punto. Se resuelve para el propio estudiante (Austin Ham), como entrega del parcial de Programacion de IA y Patrones de Comportamiento.

## Resultado esperado

Al finalizar esta etapa: ambas paletas (izquierda y derecha) se mueven verticalmente dentro de los limites de la cancha respondiendo a input de teclado, sin salir de pantalla y sin depender de la logica de la pelota (que se implementa en una etapa posterior segun el plan).

## Alcance

- Incluye: creacion del proyecto Unity 2022.3.62f3 (2D), escena principal con cancha, dos GameObjects de paleta (izquierda y derecha) con script de movimiento vertical limitado a los bordes de cancha, mapeo de input por teclado para cada jugador (Input Manager legacy, `Input.GetAxis`/`GetKey`).
- No incluye en esta etapa: fisica de la pelota, rebotes, deteccion de punto, contador en pantalla, sonido, menus, IA, condicion de fin de partida. Estos se abordaran en pasos posteriores del `plan.md` una vez validado el movimiento.

## Restricciones

- Tecnicas: Unity 2022.3.62f3 LTS, proyecto 2D, logica de movimiento en un MonoBehaviour separado de cualquier logica futura de fisica de pelota o puntaje.
- Operativas: no instalar paquetes/dependencias externas, no usar red, no publicar builds ni hacer push sin autorizacion explicita del estudiante; cada avance relevante se cierra con un commit local revisado por el estudiante.
- De calidad: el movimiento debe ser estable en Play Mode (sin jitter perceptible), la paleta no debe atravesar los limites de cancha bajo ningun input sostenido.

## Casos y criterios de aceptacion

| Caso | Dado | Cuando | Entonces | Evidencia |
|---|---|---|---|---|
| Camino principal | La paleta esta dentro de la cancha | El jugador mantiene presionada la tecla de movimiento | La paleta se desplaza verticalmente de forma continua y fluida | Prueba manual en Play Mode, capturar posicion en tiempo real |
| Caso limite | La paleta esta pegada a un borde de la cancha | El jugador sigue presionando la tecla hacia ese borde | La paleta se detiene exactamente en el limite, sin salir de cancha ni vibrar | Prueba manual en Play Mode contra ambos bordes |
| Error | No hay input activo | El jugador no presiona ninguna tecla | La paleta permanece quieta en su posicion actual, sin deriva | Prueba manual en Play Mode, observar reposo |

## Invariantes

- La posicion horizontal de la paleta siempre permanece entre el limite izquierdo y el limite derecho de la cancha definidos en la escena.
- El script de movimiento de la paleta no depende de la existencia de la pelota ni del sistema de puntaje.

## Decisiones ya tomadas

- Sistema de input: Input Manager legacy de Unity (sin instalar el paquete New Input System).
- Mapeo de teclas: jugador izquierdo usa W (arriba) / S (abajo); jugador derecho usa flecha arriba / flecha abajo.

## Preguntas abiertas

- Velocidad de desplazamiento de la paleta (unidades/segundo) y si sera configurable desde el Inspector.
- Dimensiones exactas de la cancha y de la paleta (para fijar los limites de movimiento); se definiran al crear la escena en Unity y se registraran en `auditoria-repositorio.md`.
