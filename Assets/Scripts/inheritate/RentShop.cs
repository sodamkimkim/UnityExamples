using UnityEngine;

public class RentShop : MonoBehaviour
{
    public Menu menu = null;
    public Player222 player = null;
    private void Start()
    {
        //menu.SetOnClickCallback((Menu.EType)0, OnClickCar);
        //menu.SetOnClickCallback((Menu.EType)1, OnClickBoat);
        //menu.SetOnClickCallback(Menu.EType.Bike, OnClickBike);
        for (int i = 0; i < (int)Menu.EType.Len; ++i)
            menu.SetOnClickCallback((Menu.EType)i, OnClickCallback);
    }

    public void OnClickCallback(Menu.EType _type)
    {
        Debug.Log("Ride to " + _type.ToString());
        player.RideTo(VehicleFactory(_type));
    }
    // factory pattern
    private Vehicle VehicleFactory(Menu.EType _type)
    {
        switch (_type)
        {
            case Menu.EType.Bike:
                return new Bike();
            case Menu.EType.Car:
                return new Car();
            case Menu.EType.Boat:
                return new Boat();
        }
        return null;
    }
}
