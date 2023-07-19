using UnityEngine;

public class Mov_Barrer : MonoBehaviour
{   
    public float speed;
    public Vector3 dir;
    public float timeLife;
    
    void Update()
    {
            transform.position += dir * speed * Time.deltaTime;
            Invoke(nameof(Desativar), timeLife);
    }

    void Desativar()
    {
        Destroy(gameObject);
    }

}