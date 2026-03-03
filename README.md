# Simulador Epidemiológico - Autómatas Celulares

Este proyecto es una aplicación de consola desarrollada en **C#** que simula la propagación de enfermedades infecciosas en tejidos celulares. Utiliza el modelo matemático de autómatas celulares (inspirado en el Juego de la Vida de Conway) para predecir si una enfermedad será catalogada como **Leve, Grave o Mortal** detectando patrones cíclicos de contagio.

## Características Principales

* **Gestión de Memoria Manual (POO estricta):** Implementación de Tipos de Datos Abstractos (TDA) propios, incluyendo Listas Enlazadas y Nodos fuertemente tipados, prescindiendo totalmente de clases genéricas (`<T>`) y colecciones nativas del lenguaje.
* **Procesamiento de Archivos XML:** Lectura de parámetros iniciales (tamaño de matriz, períodos, coordenadas) y generación automática de archivos de salida con los diagnósticos y variables predictivas ($N$ y $N_1$).
* **Visualización Dinámica con Graphviz:** Traducción de las estructuras de datos en memoria a sintaxis de tablas HTML para generar imágenes `.png` del estado de los tejidos en tiempo real.
* **Análisis Masivo (Batch Processing):** Capacidad de procesar listas enteras de pacientes secuencialmente, con una interfaz de consola interactiva que utiliza un semáforo de colores para los diagnósticos.

## Requisitos del Sistema

1. **.NET SDK** (Compatible con cualquier versión reciente que soporte C#).
2. **Graphviz:** Debe estar instalado en el sistema y agregado a las variables de entorno (`PATH`) para que la generación de imágenes funcione correctamente.

## Instrucciones de Uso

Al compilar y ejecutar el programa `Program.cs`, se desplegará un menú interactivo:

1. **Cargar archivo XML:** Ingresa la ruta de tu archivo de entrada (ej. `entrada.xml`).
2. **Elegir un paciente:** Selecciona un caso específico de la lista cargada en memoria.
3. **Simulación paso a paso:** Avanza un período y genera la gráfica `.png` del estado actual.
4. **Simulación automática:** El algoritmo evalúa historiales a través de "firmas de estado" hasta encontrar un patrón repetido o agotar los períodos.
5. **Limpiar datos:** Libera la memoria de los TDA.
6. **Generar XML de salida:** Exporta los resultados individuales analizados.
7. **Salir.**
8. **Análisis Masivo:** Procesa todos los pacientes en memoria, muestra resultados por colores en consola, genera todas las gráficas simultáneamente y auto-guarda un archivo `salida_masiva.xml`.

## Historial de Versiones (Releases)

* **v1.0.0:** Implementación de TDAs manuales (Nodos y Listas) y Lector de XML.
* **v1.0.1:** Integración del Motor de Simulación (Autómatas) y lógica de detección de ciclos matemáticos.
* **v1.0.2:** Módulo de Escritura XML y conexión con Graphviz para renderizado visual.
* **v1.0.3:** Incorporación de *Batch Processing* (Análisis Masivo) y semáforo visual en consola.

---
*Desarrollado para el curso de Introducción a la Programación y Computación 2.*
