using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enermy1_Ctrl : MonoBehaviour
{
    public Transform Target;

    public int Speed;
    public int Vec;
    public bool isChase;
    public float MoveMax;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(NotChase());
        Chase();
    }

    IEnumerator NotChase()
    {
        if (!isChase && MoveMax <= 1)
        {
            MoveMax += Time.deltaTime;
            transform.Translate(Vector2.right * Speed * Vec * Time.deltaTime);

            if (MoveMax >= 1)
            {
                yield return new WaitForSecondsRealtime(1);
                Vec *= -1;
                MoveMax = 0;
            }

        }

        yield return null;
    }

    private void Chase()
    {
        if (isChase)
        {
            if (Target.transform.position.x > transform.position.x)
                transform.Translate(Vector2.right * Speed * Time.deltaTime);
            else if (Target.transform.position.x < transform.position.x)
                transform.Translate(Vector2.left * Speed * Time.deltaTime);
        }
    }

    
}
