using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoderJam
{
    public static class StaticVariable 
    {

        private static int life;
        private static int death;

        public static int Life
        {
            get => life;
            set => life = value;
        }

        public static int Death
        {
            get => death;
            set => death = value;
        }

    }
}