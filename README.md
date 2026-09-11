# Aplicación interactiva 2D

Una noche junto al fuego.

Proyecto de la unidad 2 de Optativa Abierta III, Diseño de videojuegos II (IH743), Licenciatura en Desarrollo de Sistemas Web, Universidad de Guadalajara, ciclo 2026-B.

- Alumno: Hiram Agustín Acevedo López.
- Asesor: Oscar Gregorio Silva Mares.
- NRC 215440, sección D01.
- Editor: Unity 6000.5.9f1. Plantilla Universal 2D, con URP e Input System.

## Entregas de la unidad

Cada actividad continúa este mismo proyecto. Las etiquetas identifican el estado de cada entrega.

| Actividad | Contenido | Versión |
|---|---|---|
| 2.1. La primera ventana | Interfaz adaptable, tres botones, cuatro iconos y tres enlaces por costado | [act-2.1](https://github.com/hiramAcevedo/ih743_Aplicacion_Interactiva_2D/tree/act-2.1) |
| 2.2. El primer escenario | "Una noche junto al fuego": escena de día y de noche, navegación entre escenas y páginas, controles anclados | [act-2.2](https://github.com/hiramAcevedo/ih743_Aplicacion_Interactiva_2D/tree/act-2.2) |

## Abrir y probar

1. Clona el repositorio:

   ```bash
   git clone https://github.com/hiramAcevedo/ih743_Aplicacion_Interactiva_2D.git
   ```

2. En Unity Hub, abre Projects > Add > Add project from disk. Selecciona la carpeta clonada, donde están `Assets`, `Packages` y `ProjectSettings`.
3. Ábrela con Unity 6000.5.9f1. La primera importación genera `Library` y puede tardar varios minutos.
4. En la ventana Project, abre `Assets/Scenes/PrimeraVentana.unity` con doble clic. Verifica que Hierarchy diga "PrimeraVentana" antes de ejecutar.
5. Abre Window > General > Console y presiona Play.
6. Prueba los botones Inicio, Ayuda y Créditos. Cada uno cambia el texto central y resalta la sección elegida.
7. Prueba los seis enlaces de los costados. Abren el navegador: perfil de GitHub, código del proyecto, UDG, dos videos de YouTube y manual de Unity. Requieren conexión a internet.
8. Presiona "Escenario" en la esquina inferior derecha. Debe abrir "El claro, de día", con el indicador "1 / 2" y Anterior desactivado.
9. Presiona Siguiente: aparece "La fogata, de noche", con "2 / 2" y Siguiente desactivado. Anterior regresa al día; Menú vuelve a PrimeraVentana.
10. En Game view, prueba 1920x1080, 1024x768 y 900x1200. Se pueden añadir desde el botón "+" del selector de resolución, con Type = Fixed Resolution. Revisa ambas páginas. El fondo debe cubrir la vista y los textos y controles deben permanecer dentro de la ventana, sin superponerse. En vertical se recorta parte del paisaje lateral; el jacal y la fogata permanecen visibles.
11. Presiona Play de nuevo para detener la ejecución.

## Organización

- `Assets/Scenes/PrimeraVentana.unity`: menú de la aplicación (actividad 2.1).
- `Assets/Scenes/Escenario.unity`: el escenario "Una noche junto al fuego", con dos páginas (actividad 2.2).
- `Assets/Scripts/VentanaPrincipal.cs`: contenido y selección de los tres botones.
- `Assets/Scripts/EnlaceWeb.cs`: apertura de las direcciones externas.
- `Assets/Scripts/Navegacion.cs`: carga de PrimeraVentana y Escenario.
- `Assets/Scripts/Paginas.cs`: alternancia de páginas, indicador y límites de navegación.
- `Assets/UI/`: iconos y panel del menú.
- `Assets/UI/Escenario/`: ilustraciones de día y noche a 2400x1350, con formas planas y luz por capas.
- `Assets/Settings/`: configuración de Universal Render Pipeline y entrada de la plantilla.
- `Assets/TextMesh Pro/`: recursos de texto y licencia de la fuente Liberation Sans.

El Canvas usa "Scale With Screen Size", referencia 1920x1080 y ajuste equilibrado entre ancho y alto. Las anclas sitúan los bloques; los grupos de distribución ordenan botones e iconos. TextMeshPro ajusta el tamaño del texto al espacio disponible.

El escenario usa un fondo con "Envelope Parent" para llenar la pantalla conservando su proporción. Los botones se anclan a sus esquinas y los textos al borde superior o inferior. PrimeraVentana y Escenario están registradas en la lista de escenas de compilación. La fogata y las luciérnagas son parte de la ilustración estática en esta entrega.

Se versionan `Assets`, `Packages` y `ProjectSettings`, incluidos los archivos `.meta`. `Library`, `Temp`, `Logs`, `UserSettings` y compilaciones quedan fuera por el `.gitignore`.

## Material consultado

[Febucci: How to create UI for all Resolutions](https://www.febucci.com/2018/10/unity-ui-tutorial/). Se aplican el escalado del Canvas, las anclas y los grupos de distribución descritos en el tutorial.

Natalie C. (2017, 14 de julio). [Interactive book 02 Aspect ratio and Artwork](https://www.youtube.com/watch?v=OsOVmiDY41I) e [Interactive Book 03 Setting up a scene in Unity, Aspect ratios & buttons](https://www.youtube.com/watch?v=6jKU1eVFGqI). Se aplican el encuadre para distintas proporciones, el ajuste de la escena y el anclaje de controles.

La fuente Liberation Sans conserva su licencia en `Assets/TextMesh Pro/Fonts/LiberationSans - OFL.txt`. Los videos se enlazan en YouTube; no se incluyen sus archivos de audio o video.

[Índice de proyectos de la materia](https://github.com/hiramAcevedo/ih743_Optativa_Diseno_Video_Juegos_II).
