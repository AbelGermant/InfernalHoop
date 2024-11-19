using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHoop : MonoBehaviour
{
    //current spawnHoop
    public static SpawnHoop current;
    // hoop to move
    public GameObject hoop;
    // camera to get position
    public Camera cam;
    // hoop z
    private int z;

    // Start is called before the first frame update
    void Start()
    {
        current = this;
        //z = Random.Range(5, 20);
        z = 3;
    }

    // Update is called once per frame
    void Update()
    {
        MoveHoop();
    }

    // move hoop to random z between 5 and 20
    public void MoveHoop()
    {
        // get position of camera
        Vector3 pos = cam.transform.position;
        hoop.transform.position = new Vector3(pos.x*(10-z)/10, pos.y, z);
        hoop.transform.localScale = Vector3.one * (z*0.1f);
    }

    public void SetZ(int z)
    {
        this.z = z;
    }
}
