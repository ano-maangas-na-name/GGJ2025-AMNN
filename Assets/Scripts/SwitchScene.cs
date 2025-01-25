using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    public Animator animator; // Reference to the Animator controlling the fade animations
    [SerializeField] string scene; // The name of the scene to load

    void Start()
    {
        // Find the fade UI and Animator component
        GameObject fadeUI = GameObject.Find("BlackFade");
        animator = fadeUI.GetComponent<Animator>();
    }

    // Method to be called when the "Play" button is clicked
    public void OnPlayButtonClicked()
    {
        StartCoroutine(LoadSceneAfterFade(scene));
    }

    IEnumerator LoadSceneAfterFade(string sceneName)
    {
        // Trigger the fade-out animation
        animator.SetBool("FadeOut", true);

        // Wait for the fade animation to complete
        yield return new WaitForSeconds(animator.GetCurrentAnimatorClipInfo(0).Length);

        // Load the specified scene
        SceneManager.LoadScene(sceneName);
    }
}
