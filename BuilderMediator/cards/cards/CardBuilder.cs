namespace cards;

class CardBuilder : ICardBuilder
{
    public string Name { get; private set; }
    public int Rarity { get; private set; }
    public int ManaCost { get; private set; }
    
    public int AttackDamage { get; private set; }
    public int Health { get; private set; }
    public int DeployHeal { get; private set; }
    public int DeployBuff { get; private set; }
    
    public void Reset()
    {
        Name = null;
        Rarity = 0;
        ManaCost = 0;
        AttackDamage = 0;
        Health = 0;
        DeployHeal = 0;
        DeployBuff = 0;
    }
    
    public ICardBuilder SetName(string name)
    {
        Name = name;
        return this;
    }
    
    public ICardBuilder SetRarity(int number)
    {
        Rarity = number;
        return this;
    }

    public ICardBuilder SetManaCost(int amount)
    {
        ManaCost = amount;
        return this;
    }

    public ICardBuilder SetAttackDamage(int amount)
    {
        AttackDamage = amount;
        return this;
    }

    public ICardBuilder SetHealth(int amount)
    {
        Health = amount;
        return this;
    }

    public ICardBuilder SetDeployHeal(int amount)
    {
        DeployHeal = amount;
        return this;
    }

    public ICardBuilder SetDeployBuff(int amount)
    {
        DeployBuff = amount;
        return this;
    }

    public Card Build()
    {
        return new Card(this);
    }
}