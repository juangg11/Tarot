using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public bool jugadorTurno = true; 
    public BattleManager battleManager;
    public PlayerTurnManager playerTurnManager;


    public void IniciarTurno()
    {
        if (jugadorTurno)
        {
            Debug.Log("Turno del Jugador");
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
        playerTurnManager.Reset();
        IniciarTurno();
    }

    public void IniciarTurnoEnemigo()
    {
        // Lógica de ataque del enemigo
        battleManager.EnemigoAtaca();
        TerminarTurno();
    }
}
