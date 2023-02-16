using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextScript : MonoBehaviour
{
    public AudioSource cashSound;
    public float DestroyTime;
    public Vector3 Offset = new Vector3 (0, 0, 0);

    public void Start()
    {
        cashSound.Play();
        Destroy(this.gameObject, DestroyTime);
        transform.localPosition += Offset;
    }
}
