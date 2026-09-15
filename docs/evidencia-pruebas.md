# Evidencia de pruebas

Relaciona cada criterio de aceptacion con una prueba o secuencia manual que otra persona pueda repetir.

| Criterio | Version validada | Metodo o comando | Pasos | Resultado esperado | Resultado observado | Evidencia |
|---|---|---|---|---|---|---|
| Camino principal: la paleta se mueve de forma continua con su tecla | `7c9d3a5` (movimiento) / `faa32da` (visual final) | Play Mode manual en el Editor | 1) Abrir la escena principal. 2) Entrar en Play. 3) Mantener presionada la tecla de movimiento de cada paleta (W/S izquierda, flechas arriba/abajo derecha). | La paleta se desplaza sin saltos ni detenciones | Confirmado por el estudiante: "el movimiento funciona bien" | Confirmacion verbal del estudiante en el Editor (sin captura adjunta) |
| Caso limite: la paleta se detiene en el borde de cancha | `e902c46` (clamping) / `faa32da` (visual final) | Play Mode manual en el Editor | 1) Mover la paleta hasta el borde superior. 2) Mantener la tecla presionada. 3) Repetir en el borde inferior. | La paleta se detiene exactamente en el limite, sin vibrar ni salir de cancha | Confirmado por el estudiante: "los bordes estan bien" | Confirmacion verbal del estudiante en el Editor (sin captura adjunta) |
| Error: sin input, la paleta no se mueve | `7c9d3a5` | Play Mode manual en el Editor | 1) Entrar en Play sin presionar teclas. 2) Observar la posicion de la paleta durante varios segundos. | La paleta permanece en su posicion inicial | No confirmado explicitamente por el estudiante todavia | Pendiente: pedir confirmacion puntual de este caso |

## Fallos y limites pendientes

- Reproduccion: ninguna encontrada hasta el momento en el movimiento y clamping de paletas.
- Impacto: no aplica.
- Decision: no aplica. Pendiente confirmar puntualmente el caso "sin input" y reemplazar las confirmaciones verbales por capturas o grabaciones si la catedra lo exige como evidencia.
