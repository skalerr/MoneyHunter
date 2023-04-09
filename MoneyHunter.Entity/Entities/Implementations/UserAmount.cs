﻿using MoneyHunter.Entities.Entities.BaseEntity;

namespace MoneyHunter.Entities.Entities.Implementations;

public class UserAmount : Entity<ulong>
{
    public decimal Amount { get; set; }

    public Guid UserEntityId { get; set; }
    public UserEntity UserEntity { get; set; }
}