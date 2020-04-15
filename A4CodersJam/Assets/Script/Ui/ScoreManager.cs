using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CoderJam
{
    public class ScoreManager : MonoBehaviour
    {
        public Text textLife;
        public Text textDeath;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            textLife.text = "Life :" + StaticVariable.Life;
            textDeath.text = "Death :" + StaticVariable.Death;
        }
    }
}
