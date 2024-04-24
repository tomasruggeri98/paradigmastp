using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int puntaje = 0;
    public Text puntajeText;

    public void ActualizarPuntaje(int puntos)
    {
        puntaje += puntos;
        MostrarPuntaje();
    }

    void MostrarPuntaje()
    {
        puntajeText.text = "Puntaje: " + puntaje.ToString();
    }
}
