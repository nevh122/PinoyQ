using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class EvtIngredient : UnityEvent<Ingredient> { }

public class AddIngredient : MonoBehaviour
{
    public Ingredient Ingredient;
    public AudioSource SoundPlastic;
    public EvtIngredient EvtAddFood;
    [SerializeField] Collider2D Source;
    [SerializeField] bool SwipeLeft;

    void Start()
    {
        if (EvtAddFood == null)
        {
            EvtAddFood = new EvtIngredient();
        }
        SwipeControl.SwipeAction += SwipeAction;
    }

    public void SwipeAction(SwipeDirection _dir)
    {
        //Checks to see if the the initial tap hits from source collider
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Source.OverlapPoint(mousePosition))
        {
            if (_dir == SwipeDirection.Left && SwipeLeft)
            {
                //Debug.Log("added " + Ingredient.IngredientName + " with " + _dir + " direction");
                EvtAddFood.Invoke(Ingredient);
                SoundPlastic.Play();
            }
            else if (_dir == SwipeDirection.Right && !SwipeLeft)
            {
                //Debug.Log("added " + Ingredient.IngredientName + " with " + _dir + " direction");
                EvtAddFood.Invoke(Ingredient);
                SoundPlastic.Play();
            }
        }
    }

}
