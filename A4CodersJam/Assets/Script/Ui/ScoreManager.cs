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
        public Text textWin;


        void Update()
        {
            textLife.text = "Life :" + StaticVariable.Life;
            textDeath.text = "Death :" + StaticVariable.Death;
            textWin.text = StaticVariable.Death.ToString();
        }

    }
}
