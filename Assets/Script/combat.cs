using UnityEngine;

public class Menyerang : MonoBehaviour
{

    public Animator animator;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            attack();
        }

        void attack()
        {
            animator.SetTrigger("attack");
        }
        
    }
}
