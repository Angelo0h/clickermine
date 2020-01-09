[System.Serializable]
public class Block {
    public string id;
    public float cost;
    public int count;
    public string type;

    public Block(string type ,string id, float cost, int count)
    {
        this.type = type;
        this.id = id;
        this.count = count;
        this.cost = cost;
    }

}