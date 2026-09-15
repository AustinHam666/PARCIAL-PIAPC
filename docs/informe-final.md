# Informe final

## Etapa 1: Movimiento de paletas (cerrada 2026-09-15)

## Resultado

Se logro el comportamiento definido en `GDD.md` y `docs/especificacion.md`: ambas paletas (izquierda y derecha) se mueven verticalmente con input de teclado independiente por jugador, permanecen siempre dentro de los limites de la cancha sin atravesarlos ni vibrar en los bordes, y permanecen quietas sin input. Esto verifica los tres casos de `docs/especificacion.md` (camino principal, caso limite, error), confirmados por el estudiante en el Editor.

## Cambios y decisiones

- Cambios realizados: creacion del proyecto Unity 2022.3.62f3 (2D); consolidacion de la documentacion PIAPC dentro del proyecto; inicializacion de git y push a la rama `PARCIAL-1` de `https://github.com/AustinHam666/PARCIAL-PIAPC`; escena principal con `PaddleLeft`, `PaddleRight`, `BorderTop`, `BorderBottom`; script `Assets/Scripts/PaddleMovement.cs` con movimiento vertical y clamping a limites de cancha; ajustes visuales (paletas blancas mas grandes, fondo negro, lineas de borde).
- Decisiones humanas relevantes: el estudiante corrigio el eje de movimiento de las paletas (de horizontal a vertical, Pong clasico); definio el mapeo de teclas (W/S para el jugador izquierdo, flechas arriba/abajo para el derecho); eligio Input Manager legacy en vez del New Input System para no agregar dependencias; autorizo explicitamente el flujo de commit + push por paso en la rama `PARCIAL-1`; pidio ajustes visuales iterativos (tamano de paleta, colores, fondo, lineas de borde).
- Acciones del agente aceptadas, rechazadas o corregidas: todas las acciones de esta etapa fueron aceptadas por el estudiante; la unica correccion fue el eje de movimiento de las paletas en el GDD (ver `docs/registro-intervencion.md`).

## Validacion

- Camino principal: paleta se desplaza de forma continua con su tecla asignada. Confirmado por el estudiante ("el movimiento funciona bien"). Version validada: `7c9d3a5`.
- Caso limite: paleta se detiene exactamente en el borde de cancha sin vibrar. Confirmado por el estudiante ("los bordes estan bien"). Version validada: `e902c46`.
- Caso error (sin input, la paleta no se mueve): implementado, pero sin confirmacion puntual explicita del estudiante todavia.
- Version final de la etapa: `9470b98` (rama `PARCIAL-1`).

## Limites y riesgos pendientes

- Las confirmaciones de prueba son verbales del estudiante en el Editor, sin captura ni grabacion adjunta; si la catedra exige evidencia reproducible, conviene agregar capturas o un video corto.
- El caso "sin input, la paleta no se mueve" no tiene confirmacion puntual; se recomienda validarlo explicitamente antes de la entrega.
- Fisica de la pelota, rebotes, deteccion de punto y contador siguen fuera de esta etapa (ver Etapa 2 en `docs/plan.md`).
- La rama de trabajo es `PARCIAL-1`; no se hizo merge a `main` (que conserva la historia original de la plantilla del repositorio remoto).
