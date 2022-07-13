using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enermy1_Range : MonoBehaviour
{
    private Enermy1_Ctrl enermy1;
    // Start is called before the first frame update
    void Start()
    {
        enermy1 = GameObject.Find("Enermy").GetComponent<Enermy1_Ctrl>();
    }

    private void Update()
    {
        transform.position = enermy1.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.CompareTag("Player"))
            enermy1.isChase = true;
    }
}
