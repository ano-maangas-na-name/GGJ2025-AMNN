using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicScript : MonoBehaviour
{
    string currentSceneName;
    [SerializeField] int loops = 0;
    AudioSource fizzly;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        fizzly = GetComponent<AudioSource>();

        if (loops < 1)
        {
            fizzly.Play();
        }


    }

    // Update is called once per frame
    void Update()
    {
        currentSceneName = SceneManager.GetActiveScene().name;

        if (currentSceneName == "SoapMap")
        {
            loops = 1;
            fizzly.volume = 0.10f;
        }
        if (currentSceneName == "StartScreen")
        {
            fizzly.volume = 0.6f;
        }
    }
}
