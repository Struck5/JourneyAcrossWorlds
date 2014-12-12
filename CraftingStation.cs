using UnityEngine;

public class CraftingStation : MonoBehaviour
{
    public int ActiveWood = 0;
    public int ActiveStone = 0;

    private float _timer = 2f;

    public GameObject SpawnItems;
    public GameObject WoodPlank;
    public GameObject Wood1;
    public GameObject Wood2;
    public GameObject Wood3;

    public Rigidbody wpRigidbo;
    public float speed = 10f;

    public void Awake()
    {
    }


    public void Update()
    {
        if (ActiveWood >= 1)
        {
            Wood1.renderer.enabled = false;
        }
        if (ActiveWood >= 2)
        {
            Wood2.renderer.enabled = false;
        }
        if (ActiveWood >= 3)
        {
            Wood3.renderer.enabled = false;
        }

        if (ActiveWood >= 3 && (_timer -= Time.deltaTime) <= 0.5f)
        {
            Wood1.renderer.enabled = true;
            Wood2.renderer.enabled = true;
            Wood3.renderer.enabled = true;
            ActiveWood -= 3;
            _timer = 2f;
            var woodplank = Instantiate(WoodPlank, SpawnItems.transform.position, SpawnItems.transform.rotation);
        }
    }
}
