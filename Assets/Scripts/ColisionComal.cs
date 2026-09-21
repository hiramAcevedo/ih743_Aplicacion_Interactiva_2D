using UnityEngine;

[RequireComponent(typeof(BoxCollider2D), typeof(Rigidbody2D))]
public class ColisionComal : MonoBehaviour
{
    [SerializeField] private BoxCollider2D propio, areaFuego;
    [SerializeField] private Fogata fogata;
    [SerializeField] private GameObject llama, llamaBaja;
    [SerializeField] private GameObject[] soportes;
    private Rect rectPropio, rectArea;
    public bool SobreFogata { get; private set; }

    private void Awake() { Sincronizar(); RegistrarCajas("inicio"); }
    private void FixedUpdate() { ActualizarCajas(); Physics2D.SyncTransforms(); }
    private void LateUpdate() { ActualizarCajas(); Physics2D.SyncTransforms(); }

    public void Sincronizar()
    {
        Canvas.ForceUpdateCanvases();
        ActualizarCajas();
        Physics2D.SyncTransforms();
    }

    private void ActualizarCajas()
    {
        var a = ((RectTransform)propio.transform).rect;
        var b = ((RectTransform)areaFuego.transform).rect;
        if (a == rectPropio && b == rectArea) return;
        rectPropio = a; rectArea = b;
        Ajustar(propio, a); Ajustar(areaFuego, b);
        Physics2D.SyncTransforms();
        RegistrarCajas("rectangulo");
    }

    private static void Ajustar(BoxCollider2D caja, Rect rect)
    {
        caja.size = rect.size;
        caja.offset = rect.center;
    }

    private void OnTriggerEnter2D(Collider2D otro)
    {
        if (otro == areaFuego) Cambiar(true, "enter");
    }
    private void OnTriggerExit2D(Collider2D otro)
    {
        if (otro == areaFuego) Cambiar(false, "exit");
    }
    private void Cambiar(bool sobre, string evento)
    {
        SobreFogata = sobre;
        fogata.ColocarComal(sobre);
        int visibles = 0;
        foreach (var soporte in soportes) if (soporte.activeSelf) visibles++;
        Debug.Log($"[ColisionComal] {evento} SobreFogata={SobreFogata}");
        Debug.Log($"[ColisionComal] estado ConComal={fogata.ConComal} Llama={llama.activeSelf} LlamaBaja={llamaBaja.activeSelf} Soportes={visibles}");
    }

    private void RegistrarCajas(string motivo)
    {
        foreach (var caja in new[] { propio, areaFuego })
        {
            var esquinas = new Vector3[4];
            ((RectTransform)caja.transform).GetWorldCorners(esquinas);
            var min = RectTransformUtility.WorldToScreenPoint(null, esquinas[0]);
            var max = RectTransformUtility.WorldToScreenPoint(null, esquinas[2]);
            var bounds = caja.bounds;
            Debug.Log($"[ColisionComal] {motivo} {caja.name} rect={min:F3}..{max:F3} collider={(Vector2)bounds.min:F3}..{(Vector2)bounds.max:F3}");
        }
    }
}
