using UnityEngine;


public class LoadSelectedCharacter : MonoBehaviour
{
    void Start()
    {
       
        Debug.Log("load the objec");
        // Retrieve the saved tag
        string selectedTag = PlayerPrefs.GetString("SelectedObjectTag", null);


        if (!string.IsNullOrEmpty(selectedTag))
        {
           
            GameObject[] objectsWithTag = Resources.FindObjectsOfTypeAll<GameObject>();
            foreach (GameObject obj in objectsWithTag)
            {
                if (obj.CompareTag(selectedTag))
                {
                    obj.SetActive(true);
                    Debug.Log("Loaded object with tag: " + selectedTag);
                    return;
                }
            }
            Debug.LogError("No object found with tag: " + selectedTag);


        }
        else
        {
            Debug.LogError("No object tag was saved.");
        }
    }
}



