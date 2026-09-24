using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Animator))]
public class AnimacionPorSeleccion : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private string parametro, estadoReposo, estadoActivo;
    private Animator animador;
    private ArrastreSprite arrastre;
    public int Interacciones { get; private set; }
    public string Parametro => parametro;

    private void Awake()
    {
        animador = GetComponent<Animator>();
        arrastre = GetComponent<ArrastreSprite>();
    }

    public void OnPointerClick(PointerEventData datos)
    {
        if (datos.button != PointerEventData.InputButton.Left || datos.dragging ||
            (arrastre != null && arrastre.UltimoFueArrastre)) return;
        bool activo = !animador.GetBool(parametro);
        string antes = animador.GetBool(parametro) ? estadoActivo : estadoReposo;
        animador.SetBool(parametro, activo);
        Interacciones++;
        Debug.Log($"[AnimacionPorSeleccion] {name} clic={Interacciones} {parametro}={activo} estado={antes}->{(activo ? estadoActivo : estadoReposo)}");
    }
}
