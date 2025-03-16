using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class selectionLoader : MonoBehaviour
{

    [SerializeField]
    private GameObject Panel;
    
    private bool loadingStarted =false;
  
    void Update()
    {
        if(!loadingStarted)
        {
            StartCoroutine(LoadingScreen());
            loadingStarted = true;
        }
    }

   
    IEnumerator LoadingScreen()
    {
        yield return new WaitForSeconds(1);
        if (Panel != null)
        {
            Panel.SetActive(true);
        }
        else
        {
            Panel.SetActive(false);
            //Debug.LogError("Panel GameObject is not assigned in the Inspector!");
        }
    }
}
