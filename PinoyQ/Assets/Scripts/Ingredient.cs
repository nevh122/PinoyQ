using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ingredient", menuName = "Items/Ingredient", order = 1)]
public class Ingredient : ScriptableObject
{
    public int ID;
    public string IngredientName;
    public GameObject IngrdientPiece;
}
