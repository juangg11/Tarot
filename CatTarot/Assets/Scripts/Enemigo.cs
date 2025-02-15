using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [SerializeField] public int vidaMaxima;
    [SerializeField] public int vidaActual;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vidaActual = vidaMaxima;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
