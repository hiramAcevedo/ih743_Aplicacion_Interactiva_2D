using UnityEngine;
using UnityEngine.EventSystems;

// El halo acompaña a la piedra; la sombra sólo aparece en su posición inicial sobre el suelo.
[RequireComponent(typeof(ArrastreSprite))]
public class BrilloPiedra : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject halo, sombra;
    private ArrastreSprite arrastre;
    private void Awake() { arrastre = GetComponent<ArrastreSprite>(); }
    public void OnPointerClick(PointerEventData datos)
    {
        if (datos.button == PointerEventData.InputButton.Left && datos.clickCount == 2 && !arrastre.UltimoFueArrastre)
            halo.SetActive(!halo.activeSelf);
    }
    public void Levantar() { sombra.SetActive(false); }
    public void Soltar()
    {
        // Una colocación libre no asegura contacto con el suelo: no fingir una sombra.
        sombra.SetActive(false);
    }
}
