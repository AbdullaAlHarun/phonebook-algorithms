namespace PhonebookAlgorithms.Models;

public class Contact
{
    private string _firstName;
    private string _lastName;
    private string _mobile;
    private string _birthday;
    private string _street;
    private string _city;

    public string FirstName
    {
        get { return _firstName; }
        set { _firstName = value; }
    }

    public string LastName
    {
        get { return _lastName; }
        set { _lastName = value; }
    }

    public string Mobile
    {
        get { return _mobile; }
        set { _mobile = value; }
    }

    public string Birthday
    {
        get { return _birthday; }
        set { _birthday = value; }
    }

    public string Street
    {
        get { return _street; }
        set { _street = value; }
    }

    public string City
    {
        get { return _city; }
        set { _city = value; }
    }
}