using UnityEngine;
using UnityEngine.UI;

public class CarMovement : MonoBehaviour
{
    internal float speedCar;
    public GameObject SpeedSlider;
    private Slider slider;
    internal Vector3 moveVector;
    internal CharacterController characterController;
    internal MobileController mobileController;
    private Vector3 startPos = new Vector3(-0.47f, 0.015f, -2.6f);

    private void Awake()
    {
        SpeedAdd();
    }

    private void Start()
    {
        slider = SpeedSlider.GetComponent<Slider>();
        characterController = GetComponent<CharacterController>();
        mobileController = GameObject.FindGameObjectWithTag("Joystick").GetComponent<MobileController>();
    }

    void Update()
    {
        speedCar = slider.value;
        CarMove();
    }

    internal virtual void CarMove()
    {
        moveVector = Vector3.zero;
        moveVector.x =  mobileController.Horizontal() * speedCar;
        moveVector.z = mobileController.Vertical() * speedCar;

        if (Vector3.Angle(Vector3.forward, moveVector) > 1f || Vector3.Angle(Vector3.forward, moveVector) == 0)
        {
            Vector3 direct = Vector3.RotateTowards(transform.forward, moveVector, 0.09f, 0.0f);
            transform.rotation = Quaternion.LookRotation(direct);
        }

        characterController.Move(moveVector * Time.deltaTime);
    }

    internal virtual void SpeedAdd()
    {
        gameObject.transform.position = startPos;
        if (FlagSelectionTriger.startCarPos == Vector3.zero)
        {
            gameObject.transform.position = startPos;
        }
        else
        {
            gameObject.transform.position = FlagSelectionTriger.startCarPos;
            FlagSelectionTriger.startCarPos = startPos;
        }

        speedCar = 0.5f;
    }
}
