    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using TMPro;
public class PlayerController : MonoBehaviour
{
    #region variables
    public float moveSpeed = 5f;    public TextMeshProUGUI countText;    public GameObject winTextObject;    private float xInput; private float zInput;
    public CharacterController playerController; private
    Vector3 moveDirection;
    private int count;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<CharacterController>();
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxis("Horizontal"); zInput = Input.GetAxis("Vertical");
    }
    private Vector3 GetMoveDirection()
    {
        return moveDirection;
    }    void SetCountText()    {
        countText.text = "Count: " + count.ToString();
            if(count >= 11)
        {
            winTextObject.SetActive(true);
        }
    }    private void FixedUpdate()    {
        moveDirection = new Vector3(xInput, 0, zInput);
        playerController.Move(moveSpeed * Time.deltaTime * moveDirection);    }
    private void OnTriggerEnter(Collider other)    {        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }    }
}