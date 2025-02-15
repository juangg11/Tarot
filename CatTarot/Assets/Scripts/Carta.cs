using UnityEngine;

[CreateAssetMenu(fileName = "NuevaCarta", menuName = "Cartas/Carta", order = 1)]
public class Carta : ScriptableObject
{
    public string nombre;
    public int dano;
    public int costo;
    public int proteccion;
    public int curacion;
    public int agilidad;
    public int duracion;
    public int fuerza;
    public string descripcion;
    public Sprite sprite;

    public virtual void UsarCarta(BattleManager battleManager, Jugador jugador)
    {
        Debug.Log($"Usando carta: {nombre}");
        battleManager.AtacarEnemigo(dano);
        jugador.agilidad += agilidad;
        jugador.escudo += proteccion;
        jugador.fuerza += fuerza;
    }
}