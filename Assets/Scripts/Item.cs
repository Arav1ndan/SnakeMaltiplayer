using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    protected float duration = 3f;

    private void Start()
    {
        Destroy(gameObject,duration);
    }
    public virtual void ApplyEffect(snakeController snake)
    {
        Debug.Log("Item effect applied..!");
    }
    public void CollectItem()
    {
        Destroy(gameObject);
    }
}
