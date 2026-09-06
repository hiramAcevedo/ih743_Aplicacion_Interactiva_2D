# Aplicación interactiva 2D

Proyecto de la unidad 2 de Optativa V (IH745), Licenciatura en Desarrollo de Sistemas Web, Universidad de Guadalajara, ciclo 2026-B.

- Alumno: Hiram Agustín Acevedo López.
- Asesora: Nancy Ruiz Monroy.
- NRC 215267, sección D01.
- Editor: Unity 6000.5.9f1. Plantilla Universal 2D, con URP e Input System.

## Entregas de la unidad

Cada actividad continúa este mismo proyecto. Las etiquetas identifican el estado de cada entrega.

| Actividad | Contenido | Versión |
|---|---|---|
| 2.1. La primera ventana | Interfaz adaptable, tres botones, cuatro iconos y tres enlaces por costado | [act-2.1](https://github.com/hiramAcevedo/ih745_Aplicacion_Interactiva_2D/tree/act-2.1) |

## Abrir y probar

1. Clona el repositorio:

   ```bash
   git clone https://github.com/hiramAcevedo/ih745_Aplicacion_Interactiva_2D.git
   ```

2. En Unity Hub, abre Projects > Add > Add project from disk. Selecciona la carpeta clonada, donde están `Assets`, `Packages` y `ProjectSettings`.
3. Ábrela con Unity 6000.5.9f1. La primera importación genera `Library` y puede tardar varios minutos.
4. En la ventana Project, abre `Assets/Scenes/PrimeraVentana.unity` con doble clic. Verifica que Hierarchy diga "PrimeraVentana" antes de ejecutar.
5. Abre Window > General > Console y presiona Play.
6. Prueba los botones Inicio, Ayuda y Créditos. Cada uno cambia el texto central y resalta la sección elegida.
7. Prueba los seis enlaces de los costados. Abren el navegador: perfil de GitHub, código del proyecto, UDG, dos videos de YouTube y manual de Unity. Requieren conexión a internet.
8. En Game view, prueba 1920x1080, 1024x768 y 900x1200. Se pueden añadir desde el botón "+" del selector de resolución, con Type = Fixed Resolution. Los textos y controles deben permanecer dentro de la ventana y sin superponerse.
9. Presiona Play de nuevo para detener la ejecución.

## Organización

- `Assets/Scenes/PrimeraVentana.unity`: escena de la actividad.
- `Assets/Scripts/VentanaPrincipal.cs`: contenido y selección de los tres botones.
- `Assets/Scripts/EnlaceWeb.cs`: apertura de las direcciones externas.
- `Assets/UI/`: cuatro iconos y fondo de panel creados para esta ventana.
- `Assets/Settings/`: configuración de Universal Render Pipeline y entrada de la plantilla.
- `Assets/TextMesh Pro/`: recursos de texto y licencia de la fuente Liberation Sans.

El Canvas usa "Scale With Screen Size", referencia 1920x1080 y ajuste equilibrado entre ancho y alto. Las anclas sitúan los bloques; los grupos de distribución ordenan botones e iconos. TextMeshPro ajusta el tamaño del texto al espacio disponible.

Se versionan `Assets`, `Packages` y `ProjectSettings`, incluidos los archivos `.meta`. `Library`, `Temp`, `Logs`, `UserSettings` y compilaciones quedan fuera por el `.gitignore`.

## Material consultado

[Febucci: How to create UI for all Resolutions](https://www.febucci.com/2018/10/unity-ui-tutorial/). Se aplican el escalado del Canvas, las anclas y los grupos de distribución descritos en el tutorial.

La fuente Liberation Sans conserva su licencia en `Assets/TextMesh Pro/Fonts/LiberationSans - OFL.txt`. Los videos se enlazan en YouTube; no se incluyen sus archivos de audio o video.

[Índice de proyectos de la materia](https://github.com/hiramAcevedo/ih745_Optativa_Diseno_Video_Juegos_II).
