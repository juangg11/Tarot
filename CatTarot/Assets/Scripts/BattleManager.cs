using UnityEngine;

public class BattleManager : MonoBehaviour
{
    [SerializeField] Jugador jugador;
    [SerializeField] Enemigo enemigo;
    [SerializeField] Hp vida;
    [SerializeField] Hp vidaE;
    void Start()
    {
        vida.SetHealth(jugador.vidaActual, jugador.vidaMaxima);
        vidaE.SetHealth(enemigo.vidaActual, enemigo.vidaMaxima);
    }
    public void AtacarEnemigo(int daño)
    {
        enemigo.vidaActual -= daño + jugador.fuerza;
        vidaE.SetHealth(enemigo.vidaActual, enemigo.vidaMaxima);
        Debug.Log($"Enemigo recibe {daño + jugador.fuerza} de daño. Vida restante: {enemigo.vidaActual}");
    }

    public void EnemigoAtaca()
    {
        int daño = Random.Range(5, 10);
        jugador.DanarJugador(daño);
        vida.SetHealth(jugador.vidaActual, jugador.vidaMaxima);
    }
}
