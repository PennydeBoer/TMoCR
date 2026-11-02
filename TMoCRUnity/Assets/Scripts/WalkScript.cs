using UnityEngine;

public class WalkScript : MonoBehaviour
{
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow)||Input.GetKey(KeyCode.D))
        {
            if (gameObject.transform.position.x >= 28.28f) return;  
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            transform.Translate(Vector3.right * Time.deltaTime * .5f);
            animator.SetBool("Walking", true);
        }
        else if (Input.GetKey(KeyCode.LeftArrow)||Input.GetKey(KeyCode.A))
        {
            if (gameObject.transform.position.x <= -2.873f) return;
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            transform.Translate(Vector3.left * Time.deltaTime * .5f);
            animator.SetBool("Walking", true);
        }
        else
        {
            animator.SetBool("Walking", false);
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
    }
}
