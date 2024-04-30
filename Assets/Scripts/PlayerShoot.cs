using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectManipulator : MonoBehaviour
{
    public GameObject prefabToInstantiate;
    private GameObject spawnedObject;
    private PlayerControls input = null;

    void Start()
    {
        input = new PlayerControls();

        input.Player.Shoot.started += ctx => SpawnObject();
    }

    void SpawnObject()
    {
        Vector3 spawnPosition = new Vector3(0f, 2f, 0f); // change to player 1 location
        Quaternion spawnRotation = Quaternion.identity;
        spawnedObject = Instantiate(prefabToInstantiate, spawnPosition, spawnRotation);

        spawnedObject.name = "MySpawnedObject";
        spawnedObject.transform.SetParent(transform);
    }
}
