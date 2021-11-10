using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is the Script that controls most of the functions that player can use with the GolfClub.
/// 
/// Rpatterson 10/27/2021
/// </summary>
public class ClubScript : MonoBehaviour
{
    public ClubAnims cAnims;
    private int animCoolDown = 3;
    private GameObject club;

    // Start is called before the first frame update
    void Start()
    {
        cAnims.animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        RotateClub();
        PlaySwingAnimations();

    }
    IEnumerator swinging()
    { 
        cAnims.isSwinging = true;
        cAnims.animator.SetBool("isSwinging", true);
        yield return new WaitForSeconds(animCoolDown);
        cAnims.isSwinging = false;
        cAnims.animator.SetBool("isSwinging", false);
    }

    private void PlaySwingAnimations() 
    {
        //Play Animation on click
        if (Input.GetButton("Fire1"))
        {
            StartCoroutine(swinging());
        }
    }
    private void RotateClub() 
    {
        //Get Mouse Input
        float mouseClubCntrl = Input.GetAxis("Mouse Y");
        club = this.gameObject;
        // If you move mouse Y in up or down direction, it rotates in alignment of the mouse.
        Debug.Log(mouseClubCntrl);
        //0.333f represents Mouse Deadspace
        if (mouseClubCntrl >= 0.333f)
        {
            club.transform.eulerAngles = new Vector3(0, 45);

        }
        else if (mouseClubCntrl <= -0.333f)
        {
            club.transform.eulerAngles = new Vector3(0, -45);
        }
        else 
        {
            club.transform.eulerAngles = new Vector3(0, 0);
        }
    }
}
