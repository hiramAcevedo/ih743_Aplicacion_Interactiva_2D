// Estado del control de fuentes. Es estático para que sobreviva al cambio de
// escena: lo que se elige en el menú sigue vigente al entrar al escenario.
public static class AjustesTexto
{
    public const float EscalaMinima = 0.8f;
    public const float EscalaMaxima = 1.2f;
    public const float Paso = 0.1f;

    public static float Escala = 1f;
    public static int Fuente = 0;
}
