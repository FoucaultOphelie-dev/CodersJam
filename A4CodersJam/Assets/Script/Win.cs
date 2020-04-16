using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CoderJam
{
    public class Win : MonoBehaviour
    {
        public GameObject win;
        public CameraManager2D _camera;
        public GameObject show;
        private bool isDone;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player" && !isDone)
            {
                collision.gameObject.GetComponent<CoderJam.Player>().stop = true;
                _camera.win = true;
                win.SetActive(true);
            }
        }

        public void ShowMap()
        {
            win.SetActive(false);
            show.SetActive(true);
        }

        public void ShowMenu()
        {
            win.SetActive(true);
            show.SetActive(false);
        }
    }
}
