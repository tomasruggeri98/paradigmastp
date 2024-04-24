using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int puntosPorDerrotar = 100;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager scoreManager = GameObject.FindObjectOfType<ScoreManager>();
            scoreManager.ActualizarPuntaje(puntosPorDerrotar);
            Destroy(gameObject);
        }
    }
}
