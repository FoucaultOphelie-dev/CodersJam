using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoderJam
{
    public class Win : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            StaticVariable.Win = 1;
        }
    }
}
