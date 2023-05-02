using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;

namespace CharVar
{
    public class Health :MonoBehaviour
    {
        public delegate void HealthChange(int amount);
        public delegate void Death();
        public event HealthChange OnHealthChange;
        public event HealthChange OnHeal;
        public event HealthChange OnDamage;
        public event Death OnDeath;
        
        public void Initialize(int health, int maxHealth)
        {
            this.maxHealth = maxHealth;
            this.health = health;
            if(OnHealthChange != null)OnHealthChange.Invoke(maxHealth);
        }

        [SerializeField] int InitialHealth;
        public int health {get; private set;}
        
        [SerializeField] int InitialMaxHealth;
        public int maxHealth {get; private set;}
         
        void Awake()
        {
            Initialize(InitialHealth,InitialMaxHealth);
        }

        public void Set(int amount)
        {
            if(amount < maxHealth)
            {
                if(amount < 0)health = 0;
                else health = amount;
            }
            else health = maxHealth;
            if(OnHealthChange != null)OnHealthChange.Invoke(health);
        }

        public void Damage(int amount)
        {
            Set(health - amount);

            if(OnDamage != null)OnDamage.Invoke(health);
            if(health <= 0 && OnDeath != null) OnDeath.Invoke();
        }


        public void Heal(int amount)
        {
            Set(health + amount);
            if(OnHeal != null)OnHeal.Invoke(health);
        }

    }

    
}