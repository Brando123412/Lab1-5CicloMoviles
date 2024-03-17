using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaPruebas : MonoBehaviour
{
    [SerializeField] int cantidadTouch = 0;
    bool isTouch;
    [SerializeField] float time;
    [SerializeField] float timeTouch;
    [SerializeField] GameObject objeto;

    //Position Spanw    and touch
    [SerializeField] Vector3 touchPosition;
    [SerializeField] Vector2 positionSpanw;

    [SerializeField] Touch touch;

    private void Awake()
    {
        isTouch = false;
        time= 0;
        timeTouch= 0;

    }
    void Update()
    {
        // Verificar si hay al menos un toque en la pantalla
        if (Input.touchCount > 0)
        {
            // Obtener el primer toque
            touch = Input.GetTouch(0);

            if (touch.phase != TouchPhase.Moved)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    isTouch = true;
                    if(timeTouch == 0)
                    {
                        timeTouch = time;
                    }
                }
                if (isTouch && touch.phase == TouchPhase.Ended)
                {
                    isTouch = false;
                    cantidadTouch++;
                }
            }      
            if(touch.phase == TouchPhase.Moved)
            {
                isTouch = false;
                print("Moviemiento");
            }
        }

        touchPosition = touch.position;
        positionSpanw = Camera.main.ScreenToWorldPoint(touchPosition);
        RaycastHit2D hit = Physics2D.Raycast(positionSpanw, Vector2.zero);
        if (hit.collider != null)
        {
            Debug.Log("Hola");
            Destroy(hit.collider.gameObject);
        }          else
        {
            Debug.Log("No colision");
        }


        time += Time.deltaTime;
        if (time - timeTouch >= 0.3f)
        {
            Debug.Log("tiempo");
            if (cantidadTouch >= 2 && timeTouch != 0)
            {
                
                
                /*print("Doble tap");
                DeleteObject();*/
                cantidadTouch = 0;
                timeTouch = 0;
            }
            else if(cantidadTouch < 2 && timeTouch != 0)
            {
                print("tap");
                Instantiate(objeto, new Vector3(positionSpanw.x, positionSpanw.y, 0), Quaternion.identity);
                cantidadTouch = 0;
                timeTouch = 0;
            }
        }

        
    }
    /*Vector3 PositionTouch()
    {
        
        Vector3 returmPosition = new Vector3(positionSpanw.x, positionSpanw.y, 0);
        return returmPosition;
    }
    void DeleteObject()
    {
        /*RaycastHit2D hit = Physics2D.Raycast(positionSpanw, Vector2.zero);
        if (hit.collider != null)
        {
            print("Hola");
            Destroy(hit.collider.gameObject);
        }    
    }          */
}
