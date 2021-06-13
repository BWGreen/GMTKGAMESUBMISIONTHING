using UnityEngine;

public class ChurchAudioController : MonoBehaviour
{
    public Transform statueTransform;
    public Transform playerTransform;
    private float distanceToChurch;

    private static FMOD.Studio.EventInstance _instance;

    [FMODUnity.EventRef]
    public string BGM;

    void Start()
    {
        _instance = FMODUnity.RuntimeManager.CreateInstance(BGM);
        _instance.start();
    }

    // Update is called once per frame
    void Update()
    {

        distanceToChurch = Vector3.Distance(playerTransform.position, statueTransform.position); 
        _instance.setParameterByName("DistanceToChurch", distanceToChurch);
    }
}
