using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Hp : MonoBehaviour
{
    [SerializeField] private Image fillImage;
    [SerializeField] private Gradient healthGradient;
    [SerializeField] private float lerpSpeed = 1f; // Velocidad de la animación

    private float targetHealth;

    public void SetHealth(float currentHealth, float maxHealth)
    {
        targetHealth = currentHealth / maxHealth;
        StartCoroutine(UpdateHealthBar());
    }

    public void SetColor(Color color)
    {
        fillImage.color = color;
    }

    private IEnumerator UpdateHealthBar()
    {
        float startHealth = fillImage.fillAmount; // Valor inicial
        float timeElapsed = 0f;

        // Animación de la barra de salud
        while (timeElapsed < 1f)
        {
            timeElapsed += Time.deltaTime * lerpSpeed;
            fillImage.fillAmount = Mathf.Lerp(startHealth, targetHealth, timeElapsed);
            fillImage.color = healthGradient.Evaluate(fillImage.fillAmount); // Actualiza el color del gradiente
            yield return null;
        }

        // Asegurarse de que la barra se quede en el valor final
        fillImage.fillAmount = targetHealth;
        fillImage.color = healthGradient.Evaluate(targetHealth);
    }
}
