using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class MostrarObjetoInventario : MonoBehaviour
{
    public RawImage imagenCrudaPrefab; // Prefab de la imagen cruda que se muestra en el inventario
    public Text contadorTexto; // Referencia al Texto para mostrar el contador
    private int cantidadInventario = 0; // Cantidad de objetos en el inventario
    private List<RawImage> imagenesEnPantalla = new List<RawImage>(); // Lista de imágenes en pantalla
    private RectTransform canvasRectTransform; // RectTransform del Canvas

    void Start()
    {
        // Obtener el RectTransform del Canvas
        canvasRectTransform = FindObjectOfType<Canvas>().GetComponent<RectTransform>();

        ActualizarContador(); // Actualizar el contador al inicio
    }

    void Update()
    {
        // Verificar entrada de teclado para agregar o quitar objetos del inventario
        if (Input.GetKeyDown(KeyCode.X))
        {
            AgregarObjeto();
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            QuitarObjeto();
        }
    }

    void AgregarObjeto()
    {
        // Incrementar la cantidad de objetos en el inventario
        cantidadInventario++;
        ActualizarContador(); // Actualizar el contador después de agregar un objeto
        Debug.Log("Objeto agregado al inventario. Cantidad: " + cantidadInventario);

        // Crear una nueva instancia de la imagen cruda y agregarla a la lista
        RawImage nuevaImagen = Instantiate(imagenCrudaPrefab, transform);

        // Generar una posición aleatoria dentro del RectTransform del Canvas
        Vector2 posicionAleatoria = new Vector2(Random.Range(0, canvasRectTransform.rect.width), Random.Range(0, canvasRectTransform.rect.height));

        // Asignar la posición aleatoria a la imagen cruda
        nuevaImagen.rectTransform.anchoredPosition = posicionAleatoria;

        // Establecer un tamaño aleatorio para la imagen cruda (opcional)
        float escalaAleatoria = Random.Range(0.5f, 1.5f);
        nuevaImagen.rectTransform.localScale = new Vector3(escalaAleatoria, escalaAleatoria, 1f);

        imagenesEnPantalla.Add(nuevaImagen);
    }

    void QuitarObjeto()
    {
        // Verificar si hay objetos en el inventario para quitar
        if (cantidadInventario > 0)
        {
            // Decrementar la cantidad de objetos en el inventario
            cantidadInventario--;
            ActualizarContador(); // Actualizar el contador después de quitar un objeto
            Debug.Log("Objeto quitado del inventario. Cantidad: " + cantidadInventario);

            // Destruir la última imagen cruda y removerla de la lista
            Destroy(imagenesEnPantalla[imagenesEnPantalla.Count - 1].gameObject);
            imagenesEnPantalla.RemoveAt(imagenesEnPantalla.Count - 1);
        }
        else
        {
            Debug.Log("El inventario está vacío. No hay objetos para quitar.");
        }
    }

    void ActualizarContador()
    {
        // Mostrar la cantidad actualizada en el Texto del contador
        contadorTexto.text = cantidadInventario.ToString();
    }
}
