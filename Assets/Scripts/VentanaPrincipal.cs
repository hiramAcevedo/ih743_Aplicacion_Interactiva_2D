using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VentanaPrincipal : MonoBehaviour
{
    [SerializeField] private TMP_Text titulo;
    [SerializeField] private TMP_Text descripcion;
    [SerializeField] private Image[] fondos;
    [SerializeField] private TMP_Text[] etiquetas;
    [SerializeField] private Color seleccionado = new Color32(104, 225, 195, 255);
    [SerializeField] private Color normal = new Color32(38, 57, 70, 255);
    [SerializeField] private Color textoOscuro = new Color32(14, 28, 38, 255);
    [SerializeField] private Color textoClaro = new Color32(239, 245, 242, 255);

    private void Start()
    {
        MostrarInicio();
    }

    public void MostrarInicio()
    {
        Mostrar(0, "Un espacio para explorar", "Elige una sección o visita los enlaces de los costados.");
    }

    public void MostrarAyuda()
    {
        Mostrar(1, "Tú eliges cómo recorrerlo", "Usa el mouse o las flechas y Enter. Los enlaces se abren en tu navegador.");
    }

    public void MostrarCreditos()
    {
        Mostrar(2, "Hecho por Hiram", "Hiram Agustín Acevedo López\nOptativa Abierta III · Universidad de Guadalajara\n2026-B");
    }

    private void Mostrar(int indice, string encabezado, string contenido)
    {
        titulo.text = encabezado;
        descripcion.text = contenido;
        for (int i = 0; i < fondos.Length; i++)
        {
            fondos[i].color = i == indice ? seleccionado : normal;
            etiquetas[i].color = i == indice ? textoOscuro : textoClaro;
        }
    }
}
