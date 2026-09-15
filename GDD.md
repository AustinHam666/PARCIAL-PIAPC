# GDD simplificado

## Juego y experiencia

- Genero y situacion de juego: Arcade de reflejos 1v1 en pantalla fija, vista 2D cenital. Dos jugadores compiten en tiempo real dentro de una cancha rectangular cerrada.
- Rol del jugador: Cada jugador controla una paleta ubicada en su propio costado de la cancha (izquierda o derecha) que se desplaza verticalmente, intentando devolver la pelota y evitar que cruce su linea de fondo.
- Experiencia buscada: Tension de reaccion rapida y anticipacion. El jugador debe leer la trayectoria de la pelota y reposicionar su paleta a tiempo; cada punto anotado o perdido es una consecuencia clara e inmediata, visible en el contador.

## Comportamiento a resolver

- Entidad: La pelota (sistema de fisica simple) y las dos paletas (control de jugador).
- Problema actual: Prototipo aun no implementado: no existe movimiento de paletas, ni fisica de rebote de la pelota, ni deteccion de punto anotado.
- Comportamiento esperado: Las paletas se mueven en su eje vertical dentro de limites de cancha; la pelota se desplaza a velocidad constante, rebota de forma predecible contra paredes superior/inferior y contra las paletas, y al salir por un extremo se detecta como punto para el jugador contrario, actualizando el contador y reiniciando la posicion de la pelota.

## Reglas

- Estados, condiciones o eventos relevantes: Pelota en juego (moviendose); colision con pared (rebote vertical); colision con paleta (rebote horizontal, con posible cambio de angulo segun punto de impacto); pelota fuera de cancha por izquierda o derecha (evento de punto); reinicio de ronda tras cada punto.
- Accion del jugador o del entorno: El jugador mueve su paleta verticalmente con input de teclado (W/S para el jugador izquierdo, flechas arriba/abajo para el jugador derecho). El entorno mueve la pelota de forma continua segun su vector de velocidad y aplica rebotes al detectar colision.
- Resultado esperado: La paleta permanece siempre dentro de los limites de la cancha. La pelota nunca atraviesa una pared sin rebotar. Al cruzar el limite izquierdo o derecho, se suma un punto al jugador correspondiente, el contador se actualiza en pantalla y la pelota vuelve al centro con una velocidad inicial valida antes de continuar.
- Caso limite: La pelota impacta el borde extremo de una paleta (impacto tangencial) sin quedar atascada, con trayectoria valida que permita continuar el juego; y el momento en que la pelota cruza el limite de cancha en el mismo frame que toca el borde de la paleta se resuelve de forma consistente, sin doble conteo ni rebote fantasma.

## Limites

- Fuera de alcance: Sonido, menus, dificultad progresiva o IA para reemplazar a un jugador humano, marcador de victoria final o condicion de fin de partida, animaciones o efectos visuales adicionales.
- Restricciones tecnicas: Desarrollo en Unity 2022.3.62f3; logica de movimiento y fisica de la pelota separada de la representacion visual; no se agregan dependencias externas ni assets de terceros sin declarar licencia; no se usa red ni se publican builds sin autorizacion.
- Criterios de aceptacion: Ambas paletas se mueven correctamente dentro de sus limites sin salir de cancha; la pelota rebota de forma consistente contra paredes y paletas; al salir la pelota por un extremo se registra el punto correspondiente y el contador lo refleja; tras cada punto la pelota se reposiciona y el juego continua sin quedar en un estado invalido.

El GDD delimita la intencion de diseno. La especificacion y el plan convierten esa intencion en una intervencion tecnica verificable.