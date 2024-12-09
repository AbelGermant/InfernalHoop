using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpawnHoop : MonoBehaviour
{
    //current spawnHoop
    public static SpawnHoop current;
    
    // hoop to move
    [SerializeField] GameObject hoop;

    [SerializeField] TMP_Text zDisplay;
    [SerializeField] Slider zSlider;
    
    // camera to get position
    Camera cam;
    // hoop z
    int z;

    // Start is called before the first frame update
    void Start()
    {
        current = this;
        cam = Camera.main;
        //z = Random.Range(5, 20);
        SetZ(3);
    }

    // Update is called once per frame
    void Update()
    {
        MoveHoop();
    }

    // move hoop to random z between 5 and 20
    void MoveHoop()
    {
        // get position of camera
        Vector3 pos = cam.transform.position;
        hoop.transform.position = new Vector3(pos.x * (10 - z) / 10, pos.y * (10 - z) / 10, z);
        float distance = Vector3.Distance(pos, hoop.transform.position);
        hoop.transform.localScale = Vector3.one * (distance / 10);
    }

    public void SetZ(int z)
    {
        this.z = z;
        zDisplay.text = $"Hoop's Z : {z}";
        zSlider.value = z;
    }

    public void SliderHandler(float value)
    {
        z = (int) value;
        zDisplay.text = $"Hoop's Z : {z}";
    }
}
