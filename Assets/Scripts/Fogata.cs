using TMPro;
using UnityEngine;

// La llama y la luz comparten estado; el comal cambia la silueta del fuego.
public class Fogata : MonoBehaviour
{
    [SerializeField] private GameObject llama, llamaBaja, luz;
    [SerializeField] private GameObject humo;
    [SerializeField] private GameObject[] soportes;
    [SerializeField] private TMP_Text etiquetaBoton;
    [SerializeField] private bool encendidaAlIniciar;
    private bool encendida, conComal;
    public bool Encendida => encendida;
    public bool ConComal => conComal;

    private void Awake() { encendida = encendidaAlIniciar; Actualizar(); }
    public void Encender() { encendida = true; Actualizar(); }
    public void Apagar() { encendida = false; Actualizar(); }
    public void Alternar() { encendida = !encendida; Actualizar(); }

    public void ColocarComal(bool colocado)
    {
        conComal = colocado;
        foreach (var soporte in soportes) soporte.SetActive(colocado);
        Actualizar();
    }

    private void Actualizar()
    {
        llama.SetActive(encendida && !conComal);
        if (llamaBaja != null) llamaBaja.SetActive(encendida && conComal);
        if (luz != null) luz.SetActive(encendida);
        if (humo != null) humo.SetActive(encendida);
        if (etiquetaBoton != null) etiquetaBoton.text = encendida ? "Apagar" : "Encender";
    }
}
