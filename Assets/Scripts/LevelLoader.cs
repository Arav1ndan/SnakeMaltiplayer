using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField]
    private Button StartButton;
    [SerializeField]
    private Button MultiPlayerButton;
    [SerializeField]
    private Button QuitButton;

    [SerializeField]
    private GameObject infoPanel;
    [SerializeField]
    private float waitTimer = 2f;
    [SerializeField]
    private GameObject selectionPanel;
    private int sceneToLoad;
    public void startGame()
    {
        OnClickStart();
    }
    public void multiplayerWindow()
    {
       OnClickMultiPlayer();
    }
    public void quitGame()
    {
        OnClickQuit();
    }
    private void OnClickStart()
    {
        infoPanel.SetActive(true);
        selectionPanel.SetActive(false);    
        StartCoroutine(LoadSceneAfterDelay(1));
    }
    private void OnClickMultiPlayer()
    {
        infoPanel.SetActive(true);
        StartCoroutine(LoadSceneAfterDelay(2));
    }
    private IEnumerator LoadSceneAfterDelay(int sceneindex)
    {
        yield return new WaitForSeconds(waitTimer); // Wait before loading the scene
        infoPanel.SetActive(false); // Hide info panel (optional)
        SceneManager.LoadScene(sceneindex); // Load the stored scene
    }
    private void OnClickQuit()
    {
        Application.Quit();
    }
 


}
