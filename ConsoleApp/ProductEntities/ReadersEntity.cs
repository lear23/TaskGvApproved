﻿using System;
using System.Collections.Generic;

namespace ConsoleApp.ProductEntities;

public partial class ReadersEntity
{
    public int Id { get; set; }

    public string? ReaderName { get; set; }

    public virtual ICollection<ClientsEntity> ClientsEntities { get; set; } = new List<ClientsEntity>();
}
