namespace PrincessChoicer.model;

public class HusbandChallenger
{
    private Guid _id;
    private string _name;
    private int _rating;

    public string Name
    {
        get
        {
            return this._name;
        }

        set
        {
            this._name = value;
        }
    }
    public Guid Id
    {
        get
        {
            return this._id;
        }
        set
        {
            this._id = Guid.NewGuid();
        }
    }

    public int Rating
    {
        get
        {
            return this._rating;
        }

        set
        {
            this._rating = value;
        }
    }

    public HusbandChallenger(string name, int rating)
    {
        this._id = Guid.NewGuid();
        this._name = name;
        this._rating = rating;
    }
}