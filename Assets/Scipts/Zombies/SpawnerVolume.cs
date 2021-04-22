using UnityEngine;



[RequireComponent(typeof(BoxCollider))]
public class SpawnerVolume : MonoBehaviour
{

    private BoxCollider Collider;
    private void Awake()
    {
        Collider = GetComponent<BoxCollider>();
    }

    public Vector3 GetPositionInBounds()
    {
        Bounds boxBounds = Collider.bounds;
        return new Vector3(
            Random.Range(boxBounds.min.x, boxBounds.max.x), 
            transform.position.y, 
            Random.Range(boxBounds.min.z, boxBounds.max.z)
        );
    }


}
