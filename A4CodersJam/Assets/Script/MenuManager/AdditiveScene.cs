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

        public void loadLevel02()
        {
            StartCoroutine(LoadAdditiveScene("Level02"));
        }

        public void Return()
        {
            StartCoroutine(LoadMenu("Menu"));
        }
        public void quitButton()
        {
            Application.Quit();
        }

        public void win()
        {
            StartCoroutine(LoadAdditiveScene("Win"));
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
