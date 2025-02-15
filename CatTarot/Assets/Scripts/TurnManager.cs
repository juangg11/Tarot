using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public bool jugadorTurno = true; 
    public BattleManager battleManager;
    public PlayerTurnManager playerTurnManager;
    public GameManager gameManager;

    void Start()
    {
        if(gameManager == null)
        {
            gameManager = Object.FindFirstObjectByType<GameManager>();
        }
    }
    
    public void IniciarTurno()
    {
        if (jugadorTurno)
        {
            GameManager.turno++;
            Debug.Log("Turno " + GameManager.turno);
            Debug.Log("Turno del Jugador");
            gameManager.SacarCartas();
            gameManager.PonerCartas();
        }
        else
        {
            Debug.Log("Turno del Enemigo");
            IniciarTurnoEnemigo();
        }
    }
    public void TerminarTurno()
    {
        jugadorTurno = !jugadorTurno; 
        IniciarTurno();
    }

    public void IniciarTurnoEnemigo()
    {
        // Lógica de ataque del enemigo
        battleManager.EnemigoAtaca();
        TerminarTurno();
    }
}
