using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Paginas : MonoBehaviour
{
    [SerializeField] private GameObject[] paginas;
    [SerializeField] private TMP_Text indicador;
    [SerializeField] private Button anterior;
    [SerializeField] private Button siguiente;

    private int actual;

    private void Start()
    {
        Mostrar(0);
    }

    public void Siguiente()
    {
        Mostrar(actual + 1);
    }

    public void Anterior()
    {
        Mostrar(actual - 1);
    }

    private void Mostrar(int indice)
    {
        actual = Mathf.Clamp(indice, 0, paginas.Length - 1);
        for (int i = 0; i < paginas.Length; i++)
        {
            paginas[i].SetActive(i == actual);
        }
        indicador.text = (actual + 1) + " / " + paginas.Length;
        anterior.interactable = actual > 0;
        siguiente.interactable = actual < paginas.Length - 1;
    }
}
