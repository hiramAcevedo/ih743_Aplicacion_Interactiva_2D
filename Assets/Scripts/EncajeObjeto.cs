using UnityEngine;

// El comal consulta la física; las tortillas conservan su zona de UI.
[RequireComponent(typeof(ArrastreSprite))]
public class EncajeObjeto : MonoBehaviour
{
    [SerializeField] private RectTransform zona, destino;
    [SerializeField] private Fogata fogata;
    [SerializeField] private EncajeObjeto[] seguidores;
    private ArrastreSprite arrastre;
    private ColisionComal colision;
    private Coroutine espera;
    public bool Colocado { get; private set; }
    private void Awake() { arrastre = GetComponent<ArrastreSprite>(); colision = GetComponent<ColisionComal>(); }

    public void Retirar()
    {
        Colocado = false;
        if (espera != null) { StopCoroutine(espera); espera = null; }
        if (colision == null && fogata != null) fogata.ColocarComal(false);
        foreach (var seguidor in seguidores)
            if (seguidor.Colocado) seguidor.transform.SetAsLastSibling();
    }

    public void IntentarEncajar()
    {
        if (colision != null)
        {
            if (espera != null) StopCoroutine(espera);
            colision.Sincronizar();
            espera = StartCoroutine(EsperarColision());
            return;
        }
        Vector2 punto = RectTransformUtility.WorldToScreenPoint(null, transform.position);
        if (!RectTransformUtility.RectangleContainsScreenPoint(zona, punto, null)) return;
        Colocado = true;
        arrastre.ColocarEn(destino.position);
        if (fogata != null) fogata.ColocarComal(true);
    }

    private System.Collections.IEnumerator EsperarColision()
    {
        // SyncTransforms actualiza las cajas; los eventos llegan en el paso de física.
        yield return new WaitForFixedUpdate();
        yield return null;
        espera = null;
        if (arrastre.Arrastrando || !colision.SobreFogata) yield break;
        Colocado = true;
        arrastre.ColocarEn(destino.position);
        colision.Sincronizar();
    }

    private void OnDisable()
    {
        if (espera != null) { StopCoroutine(espera); espera = null; }
    }

    private void LateUpdate()
    {
        if (Colocado) arrastre.ColocarEn(destino.position);
    }
}
