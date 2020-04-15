using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CoderJam
{
    public  class AdditiveScene : MonoBehaviour
    {
        
        public string currentScene = null;
        private string previousScene = null;

        private void Awake()
        {
            currentScene = "Menu";
        }

        private void Update()
        {
            win();
        }

        public void loadLevel01()
        {
            StartCoroutine(LoadAdditiveScene("Level01"));
        }

        public void quitButton()
        {
            StartCoroutine(LoadMenu("Menu"));
        }

        void win()
        {
            if (StaticVariable.Win == 1)
            {
                StartCoroutine(LoadAdditiveScene("Win"));
                StaticVariable.Win = 0;
            }
        }

        IEnumerator LoadAdditiveScene(string scene)
        {
            previousScene = currentScene;
            currentScene = scene;
            SceneManager.LoadScene(scene, LoadSceneMode.Additive);
            yield return new WaitForSeconds(5);

            SceneManager.SetActiveScene(SceneManager.GetSceneByName(scene));
            yield return null;
        }

        IEnumerator LoadMenu(string scene)
        {
            previousScene = currentScene;
            currentScene = scene;
            SceneManager.LoadScene(scene, LoadSceneMode.Additive);
            yield return new WaitForSeconds(5);

            SceneManager.SetActiveScene(SceneManager.GetSceneByName(scene));
            SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName(previousScene));
            yield return null;
        }
    }
}
