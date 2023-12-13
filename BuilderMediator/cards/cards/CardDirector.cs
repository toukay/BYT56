namespace cards;

class CardDirector
{
    public void ConstructBasicCreatureCard(CardBuilder builder)
    {
        builder.SetName("Basic Creature")
            .SetRarity(0)
            .SetManaCost(1)
            .SetAttackDamage(1)
            .SetHealth(2);
    }
    
    public void ConstructBasicHealCard(CardBuilder builder)
    {
        builder.SetName("Basic Heal")
            .SetRarity(0)
            .SetManaCost(1)
            .SetDeployHeal(1);
    }
    
    public void ConstructBasicBuffCard(CardBuilder builder)
    {
        builder.SetName("Basic Buff")
            .SetRarity(0)
            .SetManaCost(1)
            .SetDeployBuff(1);
    }
}