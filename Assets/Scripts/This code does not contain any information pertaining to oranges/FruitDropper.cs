using System.Collections;
using UnityEngine;

public class FruitDropper : MonoBehaviour
{
    [SerializeField] NextFruitVisualizer nextFruitUI;
    [SerializeField] Transform heldFruitParent;
    [SerializeField] Transform droppedFruitParent;
    [Space]
    [SerializeField] int maxBaseFruitIndex;
    [SerializeField] Fruit heldFruit;
    [SerializeField] Fruit nextFruit;

    private void Start()
    {
        heldFruit = FruitManager.GetRandomFruit(maxBaseFruitIndex);
        nextFruit = FruitManager.GetRandomFruit(maxBaseFruitIndex);
        nextFruitUI.UpdateNextFruitUI(nextFruit.Sprite);

        StartCoroutine(FruitShooter());
    }

    private IEnumerator FruitShooter()
    {
        while (true)
        {
            heldFruit = Instantiate(heldFruit, transform.position, Quaternion.identity, heldFruitParent);

            yield return new WaitUntil(() => UserInput.IsThrowPressed);
            heldFruit.transform.parent = droppedFruitParent;
            heldFruit.SimulateFruit();
            yield return new WaitUntil(() => heldFruit.DoneDropping);

            heldFruit = nextFruit;
            nextFruit = FruitManager.GetRandomFruit(maxBaseFruitIndex);
            nextFruitUI.UpdateNextFruitUI(nextFruit.Sprite);
        }
    }
}