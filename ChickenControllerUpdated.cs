using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.PostProcessing;

public class ChickenControllerUpdated : NetworkBehaviour
{
    Camera Active;
    public GameObject SpawnGrenier;
    public PostProcessingProfile lunettesNoires;
    public PostProcessingProfile sansLunette;
    public MeshRenderer m;
    public Transform t;
    [SerializeField] float speed = 5.0f;
    float animationTime = 0;
    float time = 0;
    Vector3 moveDirection;
    Animator animator;
	public AudioSource source;
	public float old_posx;
	public float old_posz;
   

    void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == "Player")
        {
            if (other.name == "Trigger grenier")
            {
                ChangeCamera(FindCamera("Camera Grenier"));
                gameObject.transform.position = new Vector3(-121.2f, 11.7f, 25.8f);
                gameObject.transform.rotation = new Quaternion(0, 152, 0, 0);
            }
            else if (other.name == "Trigger camera lunettes")
                ChangeCamera(FindCamera("Camera Lunettes"));

            else if (other.name == "Trigger camera charette")
                ChangeCamera(FindCamera("Camera Charette"));
            else if (other.name == "binoculars")
            {
                ChangeGlasses();
                Destroy(other.gameObject);
            }
            else
                ChangeCamera();
        }
    }
	public void Start()
	{
		old_posx = transform.position.x;
		old_posz = transform.position.z;
	}
    void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
            ChangeGlasses();
        time += Time.deltaTime;
		if (!isLocalPlayer) {
			return;
		}           
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;
        t.Rotate(0, x, 0);
        t.Translate(0, 0, z);
	if(old_posx != transform.position.x || old_posz != transform.position.z) {
			source = GetComponent<AudioSource> ();
			if (!source.isPlaying) {
				source.Play ();
				Debug.Log ("play");
			}
			old_posx = transform.position.x;
			old_posz = transform.position.z;

		}
		else //(old_posx == transform.position.x && old_posz == transform.position.z)
			{
			source = GetComponent<AudioSource> ();
			if (source.isPlaying) {
				source.Stop ();
				Debug.Log ("stop");
			}
		}

    }
    void ChangeGlasses()
    {
        foreach (Camera c in Camera.allCameras)
            c.GetComponent<PostProcessingBehaviour>().profile = m.enabled ? sansLunette : lunettesNoires;
        
       m.enabled = !m.enabled;
    }
    Camera FindCamera(string name)
    {
        Debug.Log(name);
        Camera NewCam = Camera.allCameras[0];
        foreach(Camera cam in Camera.allCameras)
        {
            if (cam.name == name)
                NewCam = cam;
        }
        return NewCam;
    }


    void ChangeCamera()
    {
        Camera newCam = Camera.allCameras[0];
        float res = float.MaxValue;
        foreach (Camera oldcam in Camera.allCameras)
        {
            float distance = Vector3.Distance(gameObject.transform.position, oldcam.transform.position);
            if (distance < res)
            {
                res = distance;
                newCam = oldcam;
            }
        }
        newCam.enabled = false;
        newCam.enabled = true;
    }

    void ChangeCamera(Camera NewCam)
    {
        NewCam.enabled = false;
        NewCam.enabled = true;
    }

}
