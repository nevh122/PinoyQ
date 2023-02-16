using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layout : MonoBehaviour
{
    public Stick storeStick;
    public Ingredient storeIngredient;
    public Collider2D ColliderSource;
    public GameObject Table;
    public int CurrentlyInGrill;
    [HideInInspector] public GameObject CreatedFood;
    [SerializeField] AddIngredient PileStick;
    [SerializeField] AddIngredient PileBanana;
    [SerializeField] AddIngredient PileKamote;

    private void Start()
    {
        SwipeControl.SwipeAction += SendToFry;
    }

    public void AddStick(Stick _s)
    {
        if (storeIngredient != null)
        {
            Debug.Log("Added " + _s.IngredientName);
            storeStick = _s;
            CreatedFood.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    public void AddFood(Ingredient _i)
    {
        if (storeIngredient == null)
        {
            Debug.Log("Added " + _i.IngredientName);
            CreatedFood = Instantiate(_i.IngrdientPiece, new Vector2(0.2f, -3.3f), Quaternion.identity);
            storeIngredient = _i;
        }
    }

    public void SendToFry(SwipeDirection _dir)
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (ColliderSource.OverlapPoint(mousePosition))
        {
            if (storeStick != null && storeIngredient != null)
            {
                if(CurrentlyInGrill < 3)
                {
                    if (storeIngredient.ID == 1)
                    {
                        Debug.Log("Sent Kamote");
                        CreatedFood.transform.position = new Vector2(Random.Range(-4.08f, 4.68f), Random.Range(-1.29f, 2.21f));
                        CurrentlyInGrill += 1;
                    }
                    else if (storeIngredient.ID == 2)
                    {
                        Debug.Log("Sent Banana");
                        CreatedFood.transform.position = new Vector2(Random.Range(-4.08f, 4.68f), Random.Range(-1.29f, 2.21f));
                        CurrentlyInGrill += 1;
                    }
                    storeIngredient = null;
                    storeStick = null;
                    CreatedFood = null;
                }
                else
                {
                    Debug.Log("Grill is Full");
                }    
            }
            else
            {
                Debug.Log("Incomplete!");
            }
        } 
    }
}