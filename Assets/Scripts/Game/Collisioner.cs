using UnityEngine;

public class Collisioner : MonoBehaviour
{
    [SerializeField] private CollisionSender2D trigger;
    [SerializeField] private MonoBehaviour collidable; // as ICollidable

    private ICollidable Collidable => (ICollidable) collidable;

    void OnEnable()
    {
        trigger.OnEnter += OnEnter;
    }

    void OnDisable()
    {
        trigger.OnEnter -= OnEnter;
    }

    private void OnEnter(Collision2D obj)
    {
        if ((Collidable.CollidableLayer & 1 << obj.gameObject.layer) > 0)
        {
            Collidable.OnCollide();
        }
    }
}
