using UnityEngine;

public class CartaFisica : MonoBehaviour
{
    private Vector3 posIni;         // Posición inicial
    public float hoverY = -3f;      // Altura al hacer hover
    public float speed = 5f;        // Velocidad del Lerp

    private Vector3 targetPos;      // Posición objetivo
    public int numeroCarta; // Posicion carta
    public bool Seleccionada = false;
    void Start()
    {
        posIni = transform.position; // Guardamos la posición inicial
        targetPos = posIni;         // La posición objetivo es inicialmente la posición inicial
    }

    void Update()
    {
        // Creamos un rayo desde la posición del mouse en 2D
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        // Comprobamos si golpeamos el objeto
        if (hit.collider != null && hit.collider.gameObject == gameObject && !Seleccionada)
        {
            targetPos = new Vector3(transform.position.x, hoverY, transform.position.z);
        }

        else if (!Seleccionada)
        {
            targetPos = posIni;
        }

        else{
            targetPos = new Vector3(transform.position.x, hoverY, transform.position.z);
        }

        // Suavizamos el movimiento con Lerp
        transform.position = Vector3.Lerp(transform.position, targetPos, speed * Time.deltaTime);
    }
}
