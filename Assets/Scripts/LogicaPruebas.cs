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
            Touch touch = Input.GetTouch(0);

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



        time += Time.deltaTime;
        if (time - timeTouch >= 0.35f)
        {
            Debug.Log("tiempo");
            if (cantidadTouch >= 2 && timeTouch != 0)
            {
                print("Doble tap");
                
                cantidadTouch = 0;
                timeTouch = 0;
            }
            else if(cantidadTouch < 2 && timeTouch != 0)
            {
                print("tap");
                Instantiate(objeto);
                cantidadTouch = 0;
                timeTouch = 0;
            }
        }
    }
}
