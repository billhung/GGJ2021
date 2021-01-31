using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AsyncSceneLoadScript : MonoBehaviour
{
    public Text m_Text;
    public Button m_Button;

    void Start()
    {
        //ASYNC load next scene 非同期でシーンをロードする
        LoadButton();
        //Call the LoadButton() function when the user clicks this Button
        //m_Button.onClick.AddListener(LoadButton);
    }

    void LoadButton()
    {
        //Start loading the Scene asynchronously and output the progress bar
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        yield return null;

        //Begin to load the Scene you specify
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(1);// "Assets/Scenes/DrunkOpeningScene.unity");
        //Don't let the Scene activate until you allow it to
        asyncOperation.allowSceneActivation = false;
        Debug.Log("Pro :" + asyncOperation.progress);
        //When the load is still in progress, output the Text and progress bar
        while (!asyncOperation.isDone)
        {
            //Output the current progress
            m_Text.text = "Loading progress: " + (asyncOperation.progress * 100) + "%";

            // Check if the load has finished
            if (asyncOperation.progress >= 0.9f)
            {
                //Change the Text to show the Scene is ready
                m_Text.text = "スペースキーを押して Press SPACE to start";
                //Wait to you press the space key to activate the Scene
                if (Input.GetKeyDown(KeyCode.Space)) { 
                    //Activate the Scene
                    asyncOperation.allowSceneActivation = true;
                }
            }

            yield return null;
        }
    }
}