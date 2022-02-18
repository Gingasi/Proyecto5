using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    private float lifeTime = 4f;
    private GameManager gameManagerScript;


    void Start()
    {
        Destroy(gameObject, lifeTime); //Autodestrucción tras 2 segundos
        gameManagerScript = FindObjectOfType<GameManager>();

    }


    void Update()
    {

    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
        if(gameObject.CompareTag("Bad"))
        {
            gameManagerScript.isGameOver = true;
        }
    }

    private void OnDestroy()
    {
        gameManagerScript.targetPosition.Remove(transform.position);
    }
}
