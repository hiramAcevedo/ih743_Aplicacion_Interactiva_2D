using UnityEngine;

public class EnlaceWeb : MonoBehaviour
{
    [SerializeField] private string direccion;

    public void Abrir()
    {
        Application.OpenURL(direccion);
    }
}
