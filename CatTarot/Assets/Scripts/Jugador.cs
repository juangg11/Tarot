using UnityEngine;

public class Jugador : MonoBehaviour
{
    [SerializeField] public int vidaMaxima;
    [SerializeField] public int vidaActual;
    public int fuerza;
    public int escudo;
    public int agilidad;

    void Start()
    {
        vidaActual = vidaMaxima;
        agilidad = 0;
        fuerza = 0;
    }

    void Update()
    {
        
    }

    public void DanarJugador(int danio)
    {
        if (Random.Range(0, 100) < agilidad)
        {
            Debug.Log("El jugador ha esquivado el ataque");
            return;
        }
        else
        {
            if (escudo > 0)
            {
                int danoRestante = danio - escudo;
                escudo -= danio;
                if (escudo < 0)
                    escudo = 0;

                if (danoRestante > 0)
                    vidaActual -= danoRestante;
            }
            else
            {
                vidaActual -= danio;
            }

            Debug.Log("El jugador ha recibido " + danio + " de daño");
        }

        if (vidaActual <= 0)
        {
            Morir();
        }
    }

    public void ResetStats(int stat, int valor, int turno)
    {
        if (turno == GameManager.turno)
        {
            switch (stat)
            {
                case 1:
                    fuerza -= valor;
                    break;
                case 2:
                    agilidad -= valor;
                    break;
                case 3:
                    escudo -= valor;
                    break;
                default:
                    Debug.Log("No se ha encontrado el stat");
                    break;
            }
        }
    }

    public void Morir()
    {
        Debug.Log("El jugador ha muerto");
    }
}