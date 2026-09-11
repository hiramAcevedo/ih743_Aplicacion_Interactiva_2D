using UnityEngine;
using UnityEngine.SceneManagement;

public class Navegacion : MonoBehaviour
{
    [SerializeField] private string escenaMenu = "PrimeraVentana";
    [SerializeField] private string escenaEscenario = "Escenario";

    public void IrAlMenu()
    {
        SceneManager.LoadScene(escenaMenu);
    }

    public void IrAlEscenario()
    {
        SceneManager.LoadScene(escenaEscenario);
    }
}
