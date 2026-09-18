using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Luciernaga : MonoBehaviour
{
    [SerializeField] private int indice;
    private void OnEnable() { GetComponent<Animator>().Play(0, 0, (indice * .37f) % 1f); }
}
