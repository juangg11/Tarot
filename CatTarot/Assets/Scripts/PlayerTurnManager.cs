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
    void Start()
    {
        if(gameManager == null){
            gameManager = Object.FindFirstObjectByType<GameManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);


        if (hit.collider != null && hit.collider.gameObject.CompareTag("Carta") && Input.GetMouseButton(0) && !hit.collider.gameObject.GetComponent<CartaFisica>().Seleccionada)
        {
            int numeroCarta = hit.collider.gameObject.GetComponent<CartaFisica>().numeroCarta;
            hit.collider.gameObject.GetComponent<CartaFisica>().Seleccionada = true;
            jugada.Add(gameManager.mazo[numeroCarta]);
            energiaAcumulada = energiaAcumulada + gameManager.mazo[numeroCarta].costo;
        }

        if (Input.GetKey(KeyCode.Space)){
            if(energiaAcumulada > gameManager.energia){
                Reset();
            }
            else{
                for(int i = 0; i < jugada.Count; i++){
                    jugada[i].UsarCarta(battleManager);
                }
                Reset();
                turnManager.IniciarTurnoEnemigo();
            }
        }
    }

    public void ReiniciarEnergia(){
        energiaAcumulada = 0;
    }

    public void Reset()
    {
        jugada.Clear();
        energiaAcumulada = 0;
        gameManager.ResetCartas();
    }
}
