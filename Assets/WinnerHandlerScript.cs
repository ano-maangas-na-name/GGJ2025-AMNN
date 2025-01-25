using UnityEngine;

public class WinnerHandlerScript : MonoBehaviour
{

    public Winner winner;
    public enum Winner
    {
        None,
        Player_1,
        Player_2,
        Player_3
    }
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
