using UnityEngine;
using UnityEngine.EventSystems;

// Mantiene el arrastre proporcional al fondo incluso al cambiar la resolución.
[RequireComponent(typeof(RectTransform))]
public class ArrastreSprite : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rect, padre, lienzo;
    private Canvas canvas;
    private Vector2 tamanoLienzo, tamanoPadre;
    public bool Arrastrando { get; private set; }
    public bool UltimoFueArrastre { get; private set; }

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        padre = (RectTransform)rect.parent;
        canvas = GetComponentInParent<Canvas>().rootCanvas;
        lienzo = (RectTransform)canvas.transform;
    }

    private void LateUpdate()
    {
        if (tamanoLienzo == lienzo.rect.size && tamanoPadre == padre.rect.size) return;
        tamanoLienzo = lienzo.rect.size;
        tamanoPadre = padre.rect.size;
        MantenerEnPantalla();
    }

    public void OnPointerDown(PointerEventData datos) { UltimoFueArrastre = false; }

    public void OnBeginDrag(PointerEventData datos)
    {
        if (datos.button != PointerEventData.InputButton.Left) return;
        Arrastrando = UltimoFueArrastre = true;
        rect.SetAsLastSibling();
        GetComponent<EncajeObjeto>()?.Retirar();
        GetComponent<BrilloPiedra>()?.Levantar();
    }

    public void OnDrag(PointerEventData datos)
    {
        if (!Arrastrando) return;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(padre, datos.position, datos.pressEventCamera, out var actual);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(padre, datos.position - datos.delta, datos.pressEventCamera, out var anterior);
        Desplazar(actual - anterior);
        MantenerEnPantalla();
    }

    public void OnEndDrag(PointerEventData datos)
    {
        if (!Arrastrando) return;
        Arrastrando = false;
        MantenerEnPantalla();
        GetComponent<EncajeObjeto>()?.IntentarEncajar();
        GetComponent<BrilloPiedra>()?.Soltar();
    }

    private void Desplazar(Vector2 delta)
    {
        Vector2 proporcion = new Vector2(delta.x / padre.rect.width, delta.y / padre.rect.height);
        rect.anchorMin += proporcion;
        rect.anchorMax += proporcion;
    }

    public void ColocarEn(Vector3 posicion)
    {
        Vector2 delta = padre.InverseTransformPoint(posicion) - padre.InverseTransformPoint(rect.position);
        Desplazar(delta);
    }

    private void MantenerEnPantalla()
    {
        var esquinas = new Vector3[4]; rect.GetWorldCorners(esquinas);
        Vector2 min = new Vector2(float.MaxValue, float.MaxValue), max = new Vector2(float.MinValue, float.MinValue);
        foreach (var e in esquinas)
        {
            Vector2 p = lienzo.InverseTransformPoint(e);
            min = Vector2.Min(min, p); max = Vector2.Max(max, p);
        }
        Rect limites = lienzo.rect;
        Vector2 correccion = Vector2.zero;
        if (min.x < limites.xMin) correccion.x = limites.xMin - min.x;
        else if (max.x > limites.xMax) correccion.x = limites.xMax - max.x;
        if (min.y < limites.yMin) correccion.y = limites.yMin - min.y;
        else if (max.y > limites.yMax) correccion.y = limites.yMax - max.y;
        if (correccion != Vector2.zero) ColocarEn(rect.position + lienzo.TransformVector(correccion));
    }
}
