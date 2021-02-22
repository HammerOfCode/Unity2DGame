using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        //GetComponentInChildren += 1;
        Destroy(gameObject);
    }
}
