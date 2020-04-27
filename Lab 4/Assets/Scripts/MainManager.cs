using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(myRay, out hitInfo)) 
            {
                if (hitInfo.collider.CompareTag("Prop")) 
                {
                    rb = hitInfo.collider.GetComponent<Rigidbody>();

                    if (rb)
                        rb.AddForce(-hitInfo.normal * 5, ForceMode.Impulse);
                }
            }
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

}
