using System.Text;

namespace cards;

class Card
{
    public string Name { get; private set; }
    public int Rarity { get; private set; }
    public int ManaCost { get; private set; }
    public int AttackDamage { get; set; }
    public int Health { get; set; }
    public int DeployHeal { get; private set; }
    public int DeployBuff { get; private set; }
    
    private IGameMediator _mediator;

    public Card(CardBuilder builder)
    {
        Name = builder.Name;
        Rarity = builder.Rarity;
        ManaCost = builder.ManaCost;
        AttackDamage = builder.AttackDamage;
        Health = builder.Health;
        DeployHeal = builder.DeployHeal;
        DeployBuff = builder.DeployBuff;
    }
    
    public override string ToString()
    {
        var cardDetails = new StringBuilder("[");
        
        cardDetails.Append($"Name: {Name}, Rarity: {Rarity}, ManaCost: {ManaCost}");

        if (AttackDamage > 0) cardDetails.Append($", Attack Damage: {AttackDamage}");
        if (Health > 0) cardDetails.Append($", Health: {Health}");
        if (DeployHeal > 0) cardDetails.Append($", DeployHeal: {DeployHeal}");
        if (DeployBuff > 0) cardDetails.Append($", DeployBuff: {DeployBuff}");

        cardDetails.Append("]");

        return cardDetails.ToString();
    }
    
    public void SetMediator(IGameMediator mediator)
    {
        _mediator = mediator;
    }

    public void ExecuteOn(Card targetCard)
    {
        if (AttackDamage > 0)
        {
            _mediator.HandleAttack(this, targetCard);
        }
        else if (DeployHeal > 0)
        {
            _mediator.HandleHeal(DeployHeal, targetCard);
            _mediator.DiscardCard(this);
        }
        else if (DeployBuff > 0)
        {
            _mediator.HandleBuff(DeployBuff, targetCard);
            _mediator.DiscardCard(this);
        }
    }

    public void TakeDamage(int amount)
    {
        Health -= amount;
        if (Health <= 0)
        {
            _mediator.DiscardCard(this);
        }
    }

    public void Heal(int amount)
    {
        Health += amount;
    }

    public void Buff(int amount)
    {
        AttackDamage += amount;
    }
}