using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtoB : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    public float speed;

    private GoingTo State;

    private void Awake()
    {
        State = GoingTo.B;

        if (speed == 0)
        {
            speed = 5f;
        }
    }

    void Update()
    {

        if (Vector3.Distance(this.transform.position, pointA.transform.position) <= 0.001f)
        {
            State = GoingTo.B;
        }
        else
        {
            if (Vector3.Distance(this.transform.position, pointB.transform.position) <= 0.001f)
            {

                State = GoingTo.A;

            }
        }

        switch (State)
        {
            case (GoingTo.A):
                Debug.Log("A");
                this.transform.position = Vector3.MoveTowards(this.transform.position, pointA.transform.position, speed * Time.deltaTime);
                break;
            case (GoingTo.B):
                Debug.Log("B");
                this.transform.position = Vector3.MoveTowards(this.transform.position, pointB.transform.position, speed * Time.deltaTime);
                break;
        }
    }
}



public enum GoingTo
{
    A, B
}
