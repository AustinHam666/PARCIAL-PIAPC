# Plantilla PIAPC para repositorios individuales

Esta plantilla prepara un repositorio publico e individual para proyectos academicos de videojuegos. Es independiente del motor, lenguaje y tipo de juego.

## Como usarla

1. Crea un repositorio individual desde esta plantilla y conserva el commit inicial.
2. Completa los datos de este archivo y de `GDD.md` cuando la consigna defina el problema de diseno.
3. Agrega el proyecto creado con el motor elegido, sin mezclar archivos de otros motores.
4. Incorpora al `.gitignore` las reglas oficiales o recomendadas para ese motor.
5. Completa los documentos de `docs/` en el orden indicado por `docs/README.md`.
6. Conserva commits pequenos y revisables durante el desarrollo.

## Datos del proyecto

- Estudiante: Austin Ham
- Materia, comision y anio: Programacion de IA y Patrones de Comportamiento - 2026 - 3er Anio
- Nombre del proyecto: Parcial-PIAPC
- Motor y version: Unity 2022.3.62f3 LTS
- Estado: En desarrollo inicial (prototipo aun no implementado)

## Descripcion

Prototipo tipo Pong: arcade de reflejos 1v1 en pantalla fija, vista 2D cenital. Dos jugadores controlan paletas que se mueven en su eje horizontal e intentan devolver una pelota que rebota contra paredes y paletas, anotando punto cuando la pelota cruza la linea de fondo contraria. Ver detalle de diseno en `GDD.md`.

## Requisitos y ejecucion

- Unity Hub con Unity 2022.3.62f3 LTS instalado.
- Abrir el proyecto desde Unity Hub apuntando a esta carpeta.
- Ejecutar la escena principal desde el Editor (Play) una vez creada.

## Controles

- Jugador 1: flechas izquierda/derecha (o A/D, segun mapeo final).
- Jugador 2: A/D (o flechas), segun mapeo final a definir en la especificacion.
- Aun no implementado; se actualizara esta seccion cuando el input este definido en `docs/especificacion.md`.

## Creditos

Proyecto academico individual. No se usan assets, sonidos, tipografias ni plugins de terceros por el momento. Cualquier recurso externo incorporado se declarara aqui con su licencia antes de integrarlo.

## Entrega o demostracion

[PENDIENTE: se agregara enlace a build o video cuando la catedra lo requiera.]
