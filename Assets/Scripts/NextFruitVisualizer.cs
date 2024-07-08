using UnityEngine;
using UnityEngine.UI;

public class NextFruitVisualizer : MonoBehaviour
{
    [SerializeField] private Image nextFruitImage;

    // Left as function in case someone wants to make it an animation
    // If not, this might as well just be added onto the FruitDropper?
    public void UpdateNextFruitUI(Sprite nextFruitSprite)
    {
        nextFruitImage.sprite = nextFruitSprite;
    }
}
