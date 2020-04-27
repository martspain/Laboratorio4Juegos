using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehavior : MonoBehaviour
{

    public GameObject gun;
    public Text score;
    private int Points = 0;
    private AudioSource shotSFX;

    Animator doer;

    // Start is called before the first frame update
    void Start()
    {
        if (gun) 
        {
            doer = gun.GetComponent<Animator>();
            shotSFX = gun.GetComponent<AudioSource>();
        }            

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (shotSFX && !shotSFX.isPlaying)
            {
                doer.SetTrigger("Shot1");
                shotSFX.Play();

                if (Physics.Raycast(myRay, out hitInfo))
                {
                    if (hitInfo.collider.CompareTag("Enemy"))
                    {
                        Destroy(hitInfo.collider.gameObject);
                        Points += 1;
                    }
                }
            }
        }
        if (score)
            score.text = "Score: " + Points.ToString();
    }
}
