using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByKeyboard : MonoBehaviour {

    public float speed = 8f; //Tốc độ
    public float maxVelocity = 4f; //Vận tốc

    //[SerializeField] Dùng khi muốn truy xuất ra bên ngoài biến private.
    private Rigidbody2D myBody; // Lấy thông số(Tốc độ, lực đẩy, ..) của nhân vật
    private Animator anim;

    private void Awake() // Hàm lấy thông số.
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
    // FixUpdate khi nhân vật di chuyển cho Fixed
	void FixedUpdate () {
        PlayerMoveKeyboard();
	}

    void PlayerMoveKeyboard()
    {
        float forceX = 0f; // Lực đẩy
        float vel = Mathf.Abs(myBody.velocity.x); // Lấy vận tốc hiện tại
        // Abs để luôn dương

        float h = Input.GetAxisRaw("Horizontal"); // Khi nhấn phím di chuyển nó sẽ chuyển thành số -1(Trái) 0(Không nhấn) 1(Phải)

        if (h > 0)
        {
            if (vel < maxVelocity)
            {
                forceX = speed;
            }

            Vector3 temp = transform.localScale;
            temp.x = 1.3f;
            transform.localScale = temp;

            anim.SetBool("Walk", true);
        }
        else if (h < 0)
        {
            if (vel < maxVelocity)
            {
                forceX = -speed; // Đi trái.
            }

            Vector3 temp = transform.localScale;
            temp.x = -1.3f;
            transform.localScale = temp;

            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false);
        }

        myBody.AddForce(new Vector2(forceX, 0)); // Nhân vật di chuyển trên trục X, Y = 0.
        // Vector2 = 2 đối.
    }
}
