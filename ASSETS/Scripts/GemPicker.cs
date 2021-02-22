using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemPicker : MonoBehaviour
{
    // Start is called before the first frame update
    private float coin=0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Gem")
        {
            Destroy(collision.gameObject);
            ScoreScript.scoreValue += 400;
        }
    }
}
