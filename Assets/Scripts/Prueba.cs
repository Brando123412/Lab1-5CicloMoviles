using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class Prueba : MonoBehaviour
{
    private Vector2 pos;
    Touch primerTouch;
    [SerializeField] GameObject instanciaObjeto;

    void Update()
    {
        if (Input.touchCount >0)
        {
            primerTouch = Input.GetTouch(0);
        }
    }
    public void CambioColor(GameObject color)
    {
        instanciaObjeto.GetComponent<SpriteRenderer>().color= color.GetComponent<Image>().color;
    }
    public void CambioImagen(GameObject imagen)
    {
        instanciaObjeto.GetComponent<SpriteRenderer>().sprite = imagen.GetComponent<Image>().sprite;
    }
}
