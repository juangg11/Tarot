using UnityEngine;

public class BattleManager : MonoBehaviour
{
    [SerializeField] Jugador jugador;
    [SerializeField] Enemigo enemigo;
    [SerializeField] Hp vida;
    public int vidaJugador;
    public int vidaEnemigo;

    void Start()
    {
        jugador.vidaActual = vidaJugador;
        enemigo.vidaActual = vidaEnemigo;
        vida.SetHealth(vidaJugador, jugador.vidaMaxima);
    }
    public void AtacarEnemigo(int daño)
    {
        vidaEnemigo -= daño;
        Debug.Log($"Enemigo recibe {daño} de daño. Vida restante: {vidaEnemigo}");
    }

    public void EnemigoAtaca()
    {
        int daño = Random.Range(5, 10);
        vidaJugador -= daño;
        vida.SetHealth(vidaJugador, jugador.vidaMaxima);
        Debug.Log($"El enemigo ataca y hace {daño} de daño. Vida del jugador: {vidaJugador}");
    }
}
