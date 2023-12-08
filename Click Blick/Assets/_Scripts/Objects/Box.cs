using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] int minLifeTime;
    [SerializeField] int maxLifeTime;

    [SerializeField] int maxScale;

    [SerializeField] GameObject effect;

    SpriteRenderer sprite;
    int lifeTime;

    private void Start()
    {
        transform.localScale =  new Vector3(Random.Range(1, maxScale), 1, 1);
        lifeTime = Random.Range(minLifeTime, maxLifeTime);
        transform.Rotate(new Vector3(0, 0, Random.Range(0, 180))); 

        Invoke("OnDestroy", lifeTime);
        sprite = GetComponent<SpriteRenderer>();
    }

    private void OnDestroy()
    {
        var ef = Instantiate(effect, gameObject.transform.position, gameObject.transform.rotation);

        ef.transform.localScale = transform.localScale;

        //ef.GetComponent<ParticleSystem>().s .shape.scale.x = transform.localScale.x;
        //ef.transform.localScale = transform.localScale;

        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0.5f);        

        Destroy(gameObject, 0.2f);
    }
}