using System.Collections.Generic;
using TMPro;
using UnityEngine;

// Cambia el tamaño y la tipografía de todos los textos de la escena. Los
// botones "A+", "A-" y "Aa" llaman a Aumentar, Reducir y Alternar desde su
// evento OnClick. Los textos usan ajuste automático de tamaño, así que se
// escalan sus límites, no el tamaño fijo.
public class ControlFuentes : MonoBehaviour
{
    [SerializeField] private TMP_FontAsset[] fuentes;

    private readonly Dictionary<TMP_Text, Vector3> originales = new Dictionary<TMP_Text, Vector3>();

    private void Start()
    {
        Aplicar();
    }

    public void Aumentar()
    {
        AjustesTexto.Escala = Mathf.Min(AjustesTexto.EscalaMaxima, AjustesTexto.Escala + AjustesTexto.Paso);
        Aplicar();
    }

    public void Reducir()
    {
        AjustesTexto.Escala = Mathf.Max(AjustesTexto.EscalaMinima, AjustesTexto.Escala - AjustesTexto.Paso);
        Aplicar();
    }

    public void Alternar()
    {
        if (fuentes.Length == 0) return;
        AjustesTexto.Fuente = (AjustesTexto.Fuente + 1) % fuentes.Length;
        Aplicar();
    }

    public void Aplicar()
    {
        AjustesTexto.Escala = Mathf.Round(AjustesTexto.Escala * 10f) / 10f;
        foreach (var texto in FindObjectsByType<TMP_Text>(FindObjectsInactive.Include))
        {
            if (!originales.TryGetValue(texto, out var original))
            {
                original = new Vector3(texto.fontSizeMin, texto.fontSizeMax, texto.fontSize);
                originales[texto] = original;
            }
            // Al agrandar sube el techo y se conserva el piso: un texto que ya
            // llenaba su caja no se desborda, los demás crecen. Al reducir bajan los dos.
            texto.fontSizeMax = original.y * AjustesTexto.Escala;
            texto.fontSizeMin = original.x * Mathf.Min(1f, AjustesTexto.Escala);
            if (!texto.enableAutoSizing) texto.fontSize = original.z * AjustesTexto.Escala;
            if (fuentes.Length > 0 && AjustesTexto.Fuente < fuentes.Length) texto.font = fuentes[AjustesTexto.Fuente];
        }
    }
}
