using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR.WSA.Input;

public class RayCreate : MonoBehaviour
{
    public GameObject arrowPrefab;

    private GestureRecognizer gestureRecognizer;

    void Start()
    {
        // Set up GestureRecognizer to register user's finger taps
        gestureRecognizer = new GestureRecognizer();
        gestureRecognizer.TappedEvent += GestureRecognizerOnTappedEvent;
        gestureRecognizer.SetRecognizableGestures(GestureSettings.Tap);
        gestureRecognizer.StartCapturingGestures();
    }

    // Called whenever a "tap" gesture is registered
    private void GestureRecognizerOnTappedEvent(InteractionSourceKind source, int tapCount, Ray headRay)
    {
        Shoot();
    }

    // This method will be publicly accessible to allow for voice-activated firing later
    public void Shoot()
    {
        GetComponent<AudioSource>().Play();

        var headPosition = Camera.main.transform.position;
        var gazeDirection = Camera.main.transform.forward;
        RaycastHit hitInfo;
        if (Physics.Raycast(transform.position,Vector3.up, out hitInfo))
        {
            Instantiate(arrowPrefab, hitInfo.point, Quaternion.identity);
        }

    }
}
