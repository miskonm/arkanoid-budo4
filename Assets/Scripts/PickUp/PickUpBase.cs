using UnityEngine;

public abstract class PickUpBase : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (!col.gameObject.CompareTag(Tags.Pad))
            return;
        
        PlayMusic();
        PlayParticle();

        ApplyEffect(col);
        
        Destroy(gameObject);
    }

    private void PlayParticle()
    {
        // TODO: Add particle
    }

    private void PlayMusic()
    {
        // TODO: Add sound
    }

    protected abstract void ApplyEffect(Collision2D col);
}