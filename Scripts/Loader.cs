using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    /*
     * 
     This script is written by Aslak Aarlfot Jønsson in Visual Studio for Unity3D
     Fiverr: https://www.fiverr.com/aslakjonsson
     Homepage: https://aslakjonsson.com/
     *
     */

    //This index manage what page to load first, defult value = 0 
    public int currentTutorialIndex = 0;

    //Add the tutorial pages (empty gameobjects) in the inspector to the array
    public GameObject[] tutorialPages;

    //Made these for a possibility to add more pages further on
    private int currentPageIndex;
    private GameObject[] currentActivePage;

    private void Start()
    {
        //Loads the tutorialPages array and from the defult value 0
        LoadPage(tutorialPages, currentTutorialIndex);
    }

    //Just for debugging
    private void Update()
    {
        Debug.Log(currentPageIndex);
    }

    //Clears the temporary variables
    //Use this for changing to the next scene in the buildIndex (File -> Build Settings)
    public void LoadNextScene()
    {
        currentPageIndex = 0;
        currentActivePage = null;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Loads a pagelist, and the page at the _indexToLoad
    public void LoadPage(GameObject[] _pageList, int _indexToLoad)
    {
        currentPageIndex = _indexToLoad;
        currentActivePage = _pageList;
        currentActivePage[currentPageIndex].SetActive(true);
    }

    //Loads the next page in the array
    public void NextPage()
    {
        currentActivePage[currentPageIndex].gameObject.SetActive(false);
        currentPageIndex++;

        currentActivePage[currentPageIndex].SetActive(true);
    }
}
