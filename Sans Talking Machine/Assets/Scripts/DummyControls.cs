using UnityEngine;

public class DummyControls : MonoBehaviour
{
    public float MovementSpeed;

    private bool up, down, left, right;



    // Start is called before the first frame update
    void Start()
    {
        up = down = left = right = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W) && up)
        {
            transform.position += new Vector3(0, 1) * MovementSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A) && left)
        {
            transform.position += new Vector3(-1, 0) * MovementSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S) && down)
        {
            transform.position += new Vector3(0, -1) * MovementSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D) && right)
        {
            transform.position += new Vector3(1, 0) * MovementSpeed * Time.deltaTime;
        }


    }


    //private void OnTriggerStay2D(Collision2D other)
    //{
    //    print(other.tag);
    //    if (other.gameObject.CompareTag("Wall"))
    //    {
    //        if (other.gameObject.name.Equals("Bounds_Up"))
    //        {
    //            up = false;
    //        }
    //        else if (other.gameObject.name.Equals("Bounds_Down"))
    //        {
    //            down = false;
    //        }
    //        else if (other.gameObject.name.Equals("Bounds_Left"))
    //        {
    //            left = false;
    //        }
    //        else if (other.gameObject.name.Equals("Bounds_Right"))
    //        {
    //            right = false;
    //        }
    //    }
    //}


    private void OnTriggerStay2D(Collider2D other)
    {
        print(other.tag);
        if (other.gameObject.CompareTag("Wall"))
        {
            if (other.gameObject.name.Equals("Bounds_Up"))
            {
                up = false;
            }
            else if (other.gameObject.name.Equals("Bounds_Down"))
            {
                down = false;
            }
            else if (other.gameObject.name.Equals("Bounds_Left"))
            {
                left = false;
            }
            else if (other.gameObject.name.Equals("Bounds_Right"))
            {
                right = false;
            }
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Wall"))
        {
            if (other.name.Equals("Bounds_Up"))
            {
                up = true;
            }
            else if (other.name.Equals("Bounds_Down"))
            {
                down = true;
            }
            else if (other.name.Equals("Bounds_Left"))
            {
                left = true;
            }
            else if (other.name.Equals("Bounds_Right"))
            {
                right = true;
            }
        }
    }

    //private void OnCollisionExit2D(Collider2D other)
    //{
    //    if (other.CompareTag("Wall"))
    //    {
    //        if (other.name.Equals("Bounds_Up"))
    //        {
    //            up = true;
    //        }
    //        else if (other.name.Equals("Bounds_Down"))
    //        {
    //            down = true;
    //        }
    //        else if (other.name.Equals("Bounds_Left"))
    //        {
    //            left = true;
    //        }
    //        else if (other.name.Equals("Bounds_Right"))
    //        {
    //            right = true;
    //        }
    //    }
    //}


}
