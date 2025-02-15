using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TurnManager turnManager;
    public BattleManager battleManager;
    [SerializeField] public TextMeshProUGUI energiaTexto;
    [SerializeField] public List<Carta> mazo = new List<Carta>();
    [SerializeField] public List<Carta> cartasSacadas = new List<Carta>();
    [SerializeField] public GameObject carta1;
    [SerializeField] public GameObject carta2;
    [SerializeField] public GameObject carta3;
    [SerializeField] public GameObject carta4;
    [SerializeField] public Jugador jugador;
    public int energia;
    public static int turno;
    void Start()
    {
        energia = 5;
        PonerEnergia();
        turno = 0;
        CrearMazo();
        SacarCartas();
        PonerCartas();
        turnManager.IniciarTurno();
    }

    void Update()
    {

    }

    public void ResetCartas(){
        carta1.GetComponent<CartaFisica>().Seleccionada = false;
        carta2.GetComponent<CartaFisica>().Seleccionada = false;
        carta3.GetComponent<CartaFisica>().Seleccionada = false;
        carta4.GetComponent<CartaFisica>().Seleccionada = false;
    }
    void CrearMazo()
    {
        Carta Tower = Resources.Load<Carta>("Tower");
        Carta Strength = Resources.Load<Carta>("Strength");
        Carta Magician = Resources.Load<Carta>("Magician");
        Carta Hierophant = Resources.Load<Carta>("Hierophant");

        mazo.Add(Tower);
        mazo.Add(Strength);
        mazo.Add(Hierophant);
        mazo.Add(Magician);
    }

    public void UsarCarta(Carta carta)
    {
        carta.UsarCarta(battleManager, jugador);
        turnManager.TerminarTurno();
    }
    public void PonerEnergia(){
        energiaTexto.text = "" + energia;
    }
    public void SacarCartas()
    {
        cartasSacadas.Clear();
        while (cartasSacadas.Count < 4 && mazo.Count > 0) // Asegurarse de que el mazo no esté vacío
        {
            int random = Random.Range(0, mazo.Count); // Generar un índice aleatorio
            Carta cartaSeleccionada = mazo[random]; // Obtener la carta aleatoria
            cartasSacadas.Add(cartaSeleccionada); // Agregar la carta a la lista de cartas sacadas
        }
    }

    public void PonerCartas()
    {
        carta1.GetComponent<SpriteRenderer>().sprite = cartasSacadas[0].sprite;
        carta2.GetComponent<SpriteRenderer>().sprite = cartasSacadas[1].sprite;
        carta3.GetComponent<SpriteRenderer>().sprite = cartasSacadas[2].sprite;
        carta4.GetComponent<SpriteRenderer>().sprite = cartasSacadas[3].sprite;
    }
}