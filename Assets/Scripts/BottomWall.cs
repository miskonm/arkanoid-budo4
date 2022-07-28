using UnityEngine;

public class BottomWall : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag(Tags.Ball))
        {
            GameManager.Instance.LoseLife();
        }
        else
        {
            Destroy(col.gameObject);
        }
    }
}