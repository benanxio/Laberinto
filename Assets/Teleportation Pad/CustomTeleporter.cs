using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CustomTeleporter : MonoBehaviour
{
    public bool delayedTeleport;
    //time it takes to teleport, if not instant
    public float teleportTime = 3;
    //only allow specific tag object? if left empty, any object can teleport
    public string objectTag = "Tag del objeto";
    //Nombre de escena
    public string tEscena = "Nombre de escena";
    //one or more destination pads
    public Vector3[] destinationPad;
    //height offset
    public float teleportationHeightOffset = 1;
    //a private float counting down the time
    private float curTeleportTime;
    //private bool checking if you entered the trigger
    private bool inside;
    //check to wait for arrived object to leave before enabling teleporation again
    [HideInInspector]
    public bool arrived;
    //gameobjects inside the pad
    private Transform subject;
	//public AudioSource[] ct;
    //add a sound component if you want the teleport playing a sound when teleporting
    public AudioSource teleportSound;
	//Add a sound while the teleporter is charging
	public AudioSource teleportChargingSound;
    //add a sound component for the teleport pad, vibrating for example, or music if you want :D
    //also to make it more apparent when the pad is off, stop this component playing with "teleportPadSound.Stop();"
    //PS the distance is set to 10 units, so you only hear it standing close, not from the other side of the map
    public AudioSource teleportPadSound;
    //simple enable/disable function in case you want the teleport not working at some point
    //without disabling the entire script, so receiving objects still works
	public ParticleSystem particle;
    public bool teleportPadOn = true;

    void Start()
    {
        //Set the countdown ready to the time you chose
        curTeleportTime = teleportTime;
		//ct = transform.GetComponents<AudioSource>();
    }


    void Update()
    {
        //check if theres something/someone inside
        if (inside)
        {
            //if that object hasnt just arrived from another pad, teleport it
            if (!arrived && teleportPadOn)
                Teleport();
        }
    }

    void Teleport()
    {
        //if you chose to teleport instantly
        if (delayedTeleport)
        {
            //start the countdown
            curTeleportTime -= 1 * Time.deltaTime;
			teleportChargingSound.volume += 0.01f;
			var ps = particle.main;
			ps.startSize = teleportTime-(int)curTeleportTime;
            //if the countdown reaches zero
            if (curTeleportTime <= 0)
            {
                //reset the countdown
                curTeleportTime = teleportTime;

                int chosenPad = Random.Range(0, destinationPad.Length);
                transform.GetComponent<CargaEscena>().CargarEscenaP(tEscena);
                teleportSound.Play();
            }
        }
    }

    void OnTriggerEnter(Collider trig)
    {
        //Cuando encuentra el tag que no este vacío
        if (objectTag != "")
        {
            //Compara que el tag sea el mismo que especificamos
            if (trig.gameObject.tag == objectTag)
            {
                subject = trig.transform;
                inside = true;
            }
        }
        else
        {
            //set the subject to be the entered object
            subject = trig.transform;
            //and check inside, ready for teleport
            inside = true;
        }
		teleportChargingSound.Play();
    }

    void OnTriggerExit(Collider trig)
    {
        if (objectTag != "")
        {
            if (trig.gameObject.tag == objectTag)
            {
                //set that the object left
                inside = false;
                //reset countdown time
                curTeleportTime = teleportTime;
                //if the object that left the trigger is the same object as the subject
                if (trig.transform == subject)
                {
                    //set arrived to false, so that the pad can be used again
                    arrived = false;
                }
                //remove the subject from the pads memory
                subject = null;
            }
        }
        else //if tags arent important
        {
            //set that the object left
            inside = false;
            //reset countdown time
            curTeleportTime = teleportTime;
            //if the object that left the trigger is the same object as the subject
            if (trig.transform == subject)
            {
                //set arrived to false, so that the pad can be used again
                arrived = false;
            }
            //remove the subject from the pads memory
            subject = null;
        }
		teleportChargingSound.Stop();
		teleportChargingSound.volume = 0.1f;
		var ps = particle.main;
		ps.startSize = 3-(int)curTeleportTime;
    }
}
