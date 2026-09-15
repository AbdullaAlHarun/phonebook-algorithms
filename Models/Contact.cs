namespace PhonebookAlgorithms.Models;

/// <summary>
/// Represents one contact in the phonebook.
/// </summary>
public class Contact
{
    private string _firstName = string.Empty;
    private string _lastName = string.Empty;
    private string _mobile = string.Empty;
    private string _birthday = string.Empty;
    private string _street = string.Empty;
    private string _city = string.Empty;

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