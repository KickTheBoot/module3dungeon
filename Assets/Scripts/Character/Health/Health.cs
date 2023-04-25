using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

namespace CharVar
{
    public class Health :MonoBehaviour
    {
        [HideInInspector]
        public VisualTreeAsset Inspector;
        public void Initialize(int maxHealth)
        {
            this.maxHealth = maxHealth;
            this.health = maxHealth;
            if(OnHealthChange != null)OnHealthChange.Invoke(maxHealth);
        }

        public int health {get; private set;}
        public int maxHealth {get; private set;}
         
        public void Set(int amount)
        {
            if(amount < maxHealth)
            {
                if(amount < 0)health = 0;
                else health = amount;
            }
            else health = maxHealth;
            OnHealthChange.Invoke(health);
        }

        public void Damage(int amount)
        {
            Set(health - amount);
            OnDamage.Invoke(amount);
        }

        public event HealthChange OnDamage;

        public void Heal(int amount)
        {
            Set(health + amount);
            OnHeal.Invoke(amount);
        }

        public event HealthChange OnHeal;

        public delegate void HealthChange(int amount);
        public event HealthChange OnHealthChange;
    }

    
}