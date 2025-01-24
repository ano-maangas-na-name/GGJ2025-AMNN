using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapRandomizer : MonoBehaviour
{
    public float rotPower;
    public float stopPower;
    public bool rotated;
    public GameObject spinButton;
    Rigidbody2D rb;
    RectTransform rt;
    float rot;
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

        if (rot > 300 && rot < 60)
        {
            StartCoroutine(ChangeScene());
        }
        else if (rot > 60 && rot < 180)
        {
            StartCoroutine(ChangeScene());

        }
        else if (rot > 180 && rot < 300)
        {
            StartCoroutine(ChangeScene());
        }

    }

    public void Spin()
    {
        if (!rotated)
        {
            rb.AddTorque(rotPower);
            rotated = true;
            spinButton.SetActive(false);
        }
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("Change Scene");
        if (rot == 1)
        {
            SceneManager.LoadScene("Soda Map");
        }
        else if (rot == 2)
        {
            SceneManager.LoadScene("Gum Map");
        }
        else if (rot == 3)
        {
            SceneManager.LoadScene("Soap Map");
        }
    }
}
