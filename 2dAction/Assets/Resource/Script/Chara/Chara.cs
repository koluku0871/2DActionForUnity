using UnityEngine;
using System.Collections;

public class Chara : MonoBehaviour {
	public float speed = 4f; //歩くスピード
	public float jumpPower = 700; //ジャンプ力
	public LayerMask groundLayer;
	public GameObject mainCamera;
	private Rigidbody2D rigidbody2D;
	private Animator anim;
	private bool isGrounded; //着地判定

	public void Start () {
		anim = GetComponent<Animator>();
		rigidbody2D = GetComponent<Rigidbody2D>();

		Vector3 cameraPos = mainCamera.transform.position;
		cameraPos.x = transform.position.x;
		mainCamera.transform.position = cameraPos;
	}

	public void Update ()
	{
		isGrounded = Physics2D.Linecast (
			transform.position + transform.up * 1,
			transform.position - transform.up * 1,
			groundLayer);
		if (Input.GetKeyDown (KeyCode.Space) && isGrounded) {
			rigidbody2D.AddForce (Vector2.up * jumpPower);
		}
	}
	
	public void FixedUpdate ()
	{
		//左キー: -1、右キー: 1
		float x = Input.GetAxisRaw ("Horizontal");
		//左か右を入力したら  
		if (x != 0) {
			//入力方向へ移動
			rigidbody2D.velocity = new Vector2 (x * speed, rigidbody2D.velocity.y);
			Vector2 temp = transform.localScale;
			temp.x = x;
			transform.localScale = temp;
			Vector3 cameraPos = mainCamera.transform.position;
			cameraPos.x = transform.position.x;
			mainCamera.transform.position = cameraPos;
			anim.SetBool ("move", true);
		} else {
			//横移動の速度を0にしてピタッと止まるようにする
			rigidbody2D.velocity = new Vector2 (0, rigidbody2D.velocity.y);
			anim.SetBool ("move", false);
		}
	}
}
