namespace cards;

interface ICardBuilder
{
    // required
    ICardBuilder SetName(string name);
    ICardBuilder SetRarity(int number);
    ICardBuilder SetManaCost(int amount);
    
    // optional
    ICardBuilder SetAttackDamage(int amount);
    ICardBuilder SetHealth(int amount);
    ICardBuilder SetDeployHeal(int amount);
    ICardBuilder SetDeployBuff(int amount);
    
    Card Build();
}