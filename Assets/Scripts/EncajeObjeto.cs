using UnityEngine;

// Encaje por una zona de UI. Conserva el arrastre libre fuera de ella.
[RequireComponent(typeof(ArrastreSprite))]
public class EncajeObjeto : MonoBehaviour
{
    [SerializeField] private RectTransform zona, destino;
    [SerializeField] private Fogata fogata;
    [SerializeField] private EncajeObjeto[] seguidores;
    private ArrastreSprite arrastre;
    public bool Colocado { get; private set; }
    private void Awake() { arrastre = GetComponent<ArrastreSprite>(); }

    public void Retirar()
    {
        Colocado = false;
        if (fogata != null) fogata.ColocarComal(false);
        foreach (var seguidor in seguidores)
            if (seguidor.Colocado) seguidor.transform.SetAsLastSibling();
    }

    public void IntentarEncajar()
    {
        Vector2 punto = RectTransformUtility.WorldToScreenPoint(null, transform.position);
        if (!RectTransformUtility.RectangleContainsScreenPoint(zona, punto, null)) return;
        Colocado = true;
        arrastre.ColocarEn(destino.position);
        if (fogata != null) fogata.ColocarComal(true);
    }

    private void LateUpdate()
    {
        if (Colocado) arrastre.ColocarEn(destino.position);
    }
}
