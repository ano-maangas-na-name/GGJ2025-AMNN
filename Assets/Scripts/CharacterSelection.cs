using UnityEngine;


public class CharacterSelection : MonoBehaviour
{
    public Transform[] points; // Array of 3 points forming the triangle
    public Transform[] objects; // Array of 3 objects to move
    public float speed = 5f;


    private int[] targetIndices = { 0, 1, 2 }; // Target indices for each object
    private bool[] moving = { false, false, false }; // Flags to track object movement


    public void MoveLeft()
    {
        if (AllStopped())
        {
            // Update target indices for left movement
            targetIndices[0] = (targetIndices[0] + 2) % 3;
            targetIndices[1] = (targetIndices[1] + 2) % 3;
            targetIndices[2] = (targetIndices[2] + 2) % 3;


            for (int i = 0; i < moving.Length; i++)
            {
                moving[i] = true;
            }
        }
    }


    public void MoveRight()
    {
        if (AllStopped())
        {
            // Update target indices for right movement
            targetIndices[0] = (targetIndices[0] + 1) % 3;
            targetIndices[1] = (targetIndices[1] + 1) % 3;
            targetIndices[2] = (targetIndices[2] + 1) % 3;


            for (int i = 0; i < moving.Length; i++)
            {
                moving[i] = true;
            }
        }
    }


    void Update()
    {
        for (int i = 0; i < objects.Length; i++)
        {
            if (moving[i])
            {
                objects[i].position = Vector3.MoveTowards(objects[i].position, points[targetIndices[i]].position, speed * Time.deltaTime);


                if (objects[i].position == points[targetIndices[i]].position)
                {
                    moving[i] = false;
                }
            }
        }
    }


    private bool AllStopped()
    {
        foreach (bool isMoving in moving)
        {
            if (isMoving) return false;
        }
        return true;
    }


    public void OnNextButtonClicked()
    {
        // Find the object at Point B
        for (int i = 0; i < objects.Length; i++)
        {
            if (objects[i].position == points[1].position) // Point B is at index 1
            {
                string tag = objects[i].tag;
                PlayerPrefs.SetString("SelectedObjectTag", tag); // Save the tag
                Debug.Log($"Object at Point B: {tag}");
                break;
            }
        }


    }
}


