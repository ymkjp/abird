using UnityEngine;
using System.Collections;

public class TargetDamage : MonoBehaviour {

    public int hitPoints = 2;
    public Sprite damagedSprite;
    public float damageImpactSpeed;

    private int currentHintPoints;
    private float damageImpactSpeedSqr;
    private SpriteRenderer spriteRenderer;

	void Start () {
        spriteRenderer = GetComponent <SpriteRenderer>();
        currentHintPoints = hitPoints;
        damageImpactSpeedSqr = damageImpactSpeed * damageImpactSpeed;
	}
	
	void OnCollisionEnter2D (Collision2D collision) {
        if (collision.collider.tag != "Damager")
        {
            return;
        }

        if (collision.relativeVelocity.sqrMagnitude < damageImpactSpeedSqr)
        {
            return;
        }

        spriteRenderer.sprite = damagedSprite;
        currentHintPoints --;

        if (currentHintPoints <= 0)
        {
            Kill ();
        }
	}

    void Kill () {
        spriteRenderer.enabled = false;
        collider2D.enabled = false;
        rigidbody2D.isKinematic = true;
    }
}
