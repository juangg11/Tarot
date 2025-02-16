using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerTurnManager : MonoBehaviour
{
    [SerializeField] public List<Carta> jugada = new List<Carta>();
    public int energiaAcumulada;
    private GameManager gameManager;
    public BattleManager battleManager;
    public TurnManager turnManager;
    public Jugador jugador;

    void Start()
    {
        if (gameManager == null)
        {
            gameManager = Object.FindFirstObjectByType<GameManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (turnManager.jugadorTurno)
            TurnoJugador();
    }

    public void TurnoJugador()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        if (hit.collider != null && hit.collider.gameObject.CompareTag("Carta") && Input.GetMouseButtonDown(0))
        {
            var cartaFisica = hit.collider.gameObject.GetComponent<CartaFisica>();

            if (!cartaFisica.Seleccionada)
            {
                int numeroCarta = cartaFisica.numeroCarta;
                cartaFisica.Seleccionada = true;
                jugada.Add(gameManager.cartasSacadas[numeroCarta]);
                energiaAcumulada += gameManager.cartasSacadas[numeroCarta].costo;
            }
            else
            {
                int numeroCarta = cartaFisica.numeroCarta;
                cartaFisica.Seleccionada = false;
                jugada.Remove(gameManager.cartasSacadas[numeroCarta]);
                energiaAcumulada -= gameManager.cartasSacadas[numeroCarta].costo;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (energiaAcumulada > gameManager.energia)
            {
                Reset();
            }
            else
            {
                for (int i = 0; i < jugada.Count; i++)
                {
                    jugada[i].UsarCarta(battleManager, jugador);
                }
                Reset();
                turnManager.TerminarTurno();
            }
        }
    }

    public void ReiniciarEnergia()
    {
        energiaAcumulada = 0;
    }

    public void Reset()
    {
        jugada.Clear();
        energiaAcumulada = 0;
        gameManager.ResetCartas();
    }
}
