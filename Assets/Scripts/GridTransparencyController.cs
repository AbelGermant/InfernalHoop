using TMPro;
using UnityEngine;

public class GridTransparencyControl : MonoBehaviour
{
    [SerializeField] Transform[] ballTransforms;
    [SerializeField] float radius = 1.0f;
    [SerializeField] TMP_Text radiusText;
    Material gridMaterial;

    void Start()
    {
        gridMaterial = GetComponent<Renderer>().material;
    }

    void Update()
    {
        if (ballTransforms.Length != 0)
        {
            gridMaterial.SetFloat("_PointCount", ballTransforms.Length);
            Vector4[] points = new Vector4[ballTransforms.Length];
            for (int i = 0; i < ballTransforms.Length; i++)
            {
                Vector3 p = ballTransforms[i].position;
                points[i] = new Vector4(p.x, 0, p.z, 0);
            }
            gridMaterial.SetVectorArray("_Points", points);
            gridMaterial.SetFloat("_Radius", radius);
        }
    }

    public void SetRadius(float radius)
    {
        this.radius = radius;
        radiusText.text = $"Radius : {radius}";
    }
}
