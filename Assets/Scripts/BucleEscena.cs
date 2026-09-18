using TMPro;
using UnityEngine;

public class BucleEscena : MonoBehaviour
{
    [SerializeField] private TMP_Text etiquetaBoton;
    private Animator[] animadores;
    private RectTransform[] humos;
    private Vector2[] posiciones;
    private float tiempo;
    public bool EnPausa { get; private set; }

    private void Awake()
    {
        animadores = GetComponentsInChildren<Animator>(true);
        var lista = new System.Collections.Generic.List<RectTransform>();
        foreach (var animador in animadores)
            if (animador.name == "Humo") lista.Add((RectTransform)animador.transform);
        humos = lista.ToArray();
        posiciones = new Vector2[humos.Length];
        for (int i = 0; i < humos.Length; i++) posiciones[i] = humos[i].anchoredPosition;
    }

    private void Update()
    {
        if (EnPausa) return;
        tiempo += Time.deltaTime;
        AplicarVelocidad();
        for (int i = 0; i < humos.Length; i++)
            humos[i].anchoredPosition = posiciones[i] + new Vector2(Mathf.Sin(tiempo * .8f) * 8f, 0);
    }

    private void AplicarVelocidad()
    {
        foreach (var animador in animadores)
            animador.speed = EnPausa ? 0 :
                (animador.name == "Llama" || animador.name == "LlamaBaja")
                ? Mathf.Lerp(.85f, 1.15f, Mathf.PerlinNoise(tiempo * 1.7f, .3f)) : 1;
    }
    public void Pausar() { EnPausa = true; AplicarVelocidad(); etiquetaBoton.text = "Reanudar"; }
    public void Reanudar() { EnPausa = false; AplicarVelocidad(); etiquetaBoton.text = "Pausar"; }
    public void Alternar() { if (EnPausa) Reanudar(); else Pausar(); }
}
