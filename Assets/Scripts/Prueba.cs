using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Prueba : MonoBehaviour
{
    private Vector2 pos;
    Touch primerTouch;
    [SerializeField] GameObject instanciaObjeto;
    [SerializeField] Vector3 positionSpanw;
    Vector3 touchPosition;

    [SerializeField] bool isTouching = false;
    [SerializeField] float timer = 0;
    void Update()
    {
        if (Input.touchCount > 0)
        {
            isTouching = true;
        }
        else
        {
            isTouching = false;
        }
        
        if (isTouching)
        {
            timer = timer + Time.deltaTime;
            if(timer > 1f)
            {
                VerifyRay();
            }
        }
        else
        {
            timer = 0;
        }
        /*
         * 
         * 
            
            Instantiate(instanciaObjeto,new Vector3(positionSpanw.x,positionSpanw.y,0),Quaternion.identity);
         */
    }
    public void CambioColor(GameObject color)
    {
        instanciaObjeto.GetComponent<SpriteRenderer>().color= color.GetComponent<Image>().color;
    }
    public void CambioImagen(GameObject imagen)
    {
        instanciaObjeto.GetComponent<SpriteRenderer>().sprite = imagen.GetComponent<Image>().sprite;
    }
    void VerifyRay()
    {
        primerTouch = Input.GetTouch(0);
        touchPosition = Camera.main.ScreenToWorldPoint(primerTouch.position);

        //Debug.DrawRay(touchPosition, Vector2.up , UnityEngine.Color.green, 1f);
        RaycastHit2D hit = Physics2D.Raycast(touchPosition, Vector2.zero);
        //puedes mover

        if (hit.collider != null )
        {
            //GameObject objetoGolpeado = hit.collider.gameObject;
            Transform otherTransfomr = hit.collider.gameObject.transform;
            otherTransfomr.position = new Vector3(touchPosition.x, touchPosition.y,0);
        }

    }
    void PositionTouch()
    {
        primerTouch = Input.GetTouch(0);
        touchPosition = primerTouch.position;
        positionSpanw = Camera.main.ScreenToWorldPoint(touchPosition);
    }
}
