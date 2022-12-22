namespace PrincessChoicer.model;

public class HusbandChallenger
{
    private Guid id;
    private int rating;

    public Guid Id
    {
        get
        {
            return this.id;
        }
        set
        {
            this.id = Guid.NewGuid();
        }
    }

    public int Rating
    {
        get
        {
            return this.rating;
        }

        set
        {
            this.rating = value;
        }
    }

    public HusbandChallenger(int rating)
    {
        this.id = Guid.NewGuid();
        this.rating = rating;
    }
}