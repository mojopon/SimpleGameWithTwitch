using UnityEngine;

public class Area : MonoBehaviour
{
    public float Width;
    public float Height;

    public Vector3 GetRandomPosition()
    {
        return new Vector3(Random.Range(-(Width / 2), (Width / 2)), Random.Range(-(Height / 2), (Height / 2)));
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(Width, Height, 1));
    }
}
