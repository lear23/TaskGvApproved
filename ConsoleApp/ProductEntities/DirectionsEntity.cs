using System;
using System.Collections.Generic;

namespace ConsoleApp.ProductEntities;

public partial class DirectionsEntity
{
    public int Id { get; set; }

    public string? StreetName { get; set; }

    public string? PostalCode { get; set; }

    public string? City { get; set; }

    public virtual ICollection<ClientsEntity> ClientsEntities { get; set; } = new List<ClientsEntity>();
}
