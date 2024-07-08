using UnityEngine;

public class FruitManager : MonoBehaviour
{
    static FruitManager instance;
    private void Awake()
    {
        instance = this;
    }

    [SerializeField] Fruit[] possibleFruits;
    public static Fruit[] PossibleFruits { get => instance.possibleFruits; }

    public static bool IsLargestFruit(int index)
    {
        return index == PossibleFruits.Length - 1;
    }

    public static Fruit GetRandomFruit()
    {
        return GetRandomFruit(PossibleFruits.Length);
    }
    public static Fruit GetRandomFruit(int maxIndex)
    {
        return PossibleFruits[Random.Range(0, System.Math.Min(maxIndex, PossibleFruits.Length))];
    }
    public static Fruit GetFruit(int index)
    {
        return index < PossibleFruits.Length ? PossibleFruits[index] : null;
    }

    // Made this in case one cannot be bothered to manually set the indexes.
    // . . . I could be bothered, so no reason to use it
    [System.Obsolete]
    public static int GetFruitIndex(Fruit fruit)
    {
        for (int i = 0; i < PossibleFruits.Length; i++)
            if (fruit.Sprite == PossibleFruits[i].Sprite) return i;
        return -1;
    }
}
