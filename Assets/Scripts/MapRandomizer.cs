using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class MapRandomizer : MonoBehaviour
{
    public float rotPower;
    public float stopPower;
    public bool rotated;
    public GameObject spinButton;
    public GameObject[] maps;


    Rigidbody2D rb;
    RectTransform rt;
    float rot;

    int mapChange;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rt = GetComponent<RectTransform>();
        rotated = false;


    }

    // Update is called once per frame
    void Update()
    {
        if (rb.angularVelocity == 0 && rotated)
        {
            GetMap();
        }

        if (rb.angularVelocity > 0)
        {
            rb.angularVelocity -= stopPower * Time.deltaTime;
            rb.angularVelocity = Mathf.Clamp(rb.angularVelocity, 0, 1440);
        }

    }

    private void GetMap()
    {
        rot = transform.eulerAngles.z;
        Debug.Log(rot);

        if ((rot > 300 && rot < 360) || (rot > 0 && rot < 60))
        {
            mapChange = 1;
            StartCoroutine(ChangeScene());
        }
        else if (rot > 60 && rot < 180)
        {
            mapChange = 2;

            StartCoroutine(ChangeScene());

        }
        else if (rot > 180 && rot < 300)
        {
            mapChange = 3;

            StartCoroutine(ChangeScene());
        }

    }

    public void Spin()
    {
        if (!rotated)
        {
            // Randomize the rotation power and stopping power
            rotPower = Random.Range(100f, 500f); // Random rotation power between 1000 and 3000
            stopPower = Random.Range(50f, 80f); // Random stopping power between 5 and 15

            // Apply torque with the randomized power
            rb.AddTorque(rotPower);

            rotated = true;
            spinButton.SetActive(false);
        }
    }

    IEnumerator ChangeScene()
    {
        // Ensure mapChange corresponds to the correct index in the maps array
        GameObject selectedMap = maps[mapChange - 1]; // Arrays are zero-indexed, so subtract 1 from mapChange

        // Ensure the map is visible and reset its initial properties
        selectedMap.SetActive(true);
        selectedMap.transform.localScale = Vector3.zero; // Start at scale 0
        CanvasGroup canvasGroup = selectedMap.GetComponent<CanvasGroup>();
        if (!canvasGroup)
        {
            canvasGroup = selectedMap.AddComponent<CanvasGroup>(); // Add CanvasGroup if not already present
        }
        canvasGroup.alpha = 0; // Start fully transparent

        // Animate scale and fade-in over 1 second
        selectedMap.transform.DOScale(Vector3.one, 1f).SetEase(Ease.OutBack); // Smooth scale-in
        canvasGroup.DOFade(1, 1f); // Fade in

        // Wait for 5 seconds (1 second for animation, 4 seconds to hold)
        yield return new WaitForSeconds(5f);

        // Transition to the appropriate scene
        Debug.Log("Change Scene");
        if (mapChange == 1)
        {
            
            SceneManager.LoadScene("SoapMap");
        }
        else if (mapChange == 2)
        {
            SceneManager.LoadScene("SoapMap");
        }
        else if (mapChange == 3)
        {
            SceneManager.LoadScene("SoapMap");
        }
    }

}
