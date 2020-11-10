using UnityEngine;

public class MoveCharacter : CarMovement
{
    internal override void SpeedAdd()
    {
        speedCar = 5f;
    }
    internal override void CarMove()
    {
        moveVector = Vector3.zero;
        moveVector.x = mobileController.Horizontal();
        moveVector.z = mobileController.Vertical();

        Vector3 move = transform.right * moveVector.x + transform.forward * moveVector.z;

        characterController.Move(move * speedCar * Time.deltaTime);
    }
}
