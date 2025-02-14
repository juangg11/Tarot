using UnityEngine;

public class Jugador : MonoBehaviour
{
    [SerializeField] public float vidaMaxima;
    [SerializeField] public float vidaActual;
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
