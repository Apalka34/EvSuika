using UnityEngine;

public class Fruit : MonoBehaviour
{
    Rigidbody2D rigidBody;
    SpriteRenderer spriteRenderer;

    public int fruitIndex;
    public Sprite Sprite
    {
        get
        {
            if (spriteRenderer == null) spriteRenderer = GetComponent<SpriteRenderer>();
            return spriteRenderer.sprite;
        }
    }
    public bool DoneDropping { get; private set; }

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.simulated = false;
        DoneDropping = false;
    }
    public void SimulateFruit()
    {
        rigidBody.simulated = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DoneDropping = true;

        // GetInstanceID() is used as some check to make sure that only one of the two gameobjects
        // runs this code. As all instance id's are unique, one must be larger than the other and,
        // in turn, the other must be smaller. This means that with this comparison, one must always
        // return true and one must always return false, thus running the code only once.
        if (GetInstanceID() > collision.gameObject.GetInstanceID()
            && collision.gameObject.TryGetComponent(out Fruit fruit)
            && fruitIndex == fruit.fruitIndex)
        {
            if (FruitManager.IsLargestFruit(fruitIndex))
            {
                // I don't think a point system exists yet. Do that here later.
            }
            else
            {
                Vector3 targetMergePosition = (fruit.transform.position + transform.position) / 2;
                Fruit createdFruit = Instantiate(FruitManager.GetFruit(fruitIndex + 1),
                                                 targetMergePosition,
                                                 Quaternion.identity,
                                                 transform.parent);
                createdFruit.SimulateFruit();
            }

            Destroy(fruit.gameObject);
            Destroy(gameObject);
        }
    }
}