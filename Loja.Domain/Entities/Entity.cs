using System;
using Flunt.Notifications;

namespace Loja.Domain.Entities
{
    public class Entity : Notifiable
    {
        public Entity(){
            Id = Guid.NewGuid();
        }

        public Guid Id {get; private set;}
    }
}