﻿namespace OVB.Demos.Ecommerce.Microsservices.User.Domain.Models.Entities;

public class UserEntity
{
    public Guid Identifier { get; }
    public string Username { get; }
    public string NameComplete { get; }
    public string TypeUser { get; }

    public UserEntity(Guid identifier, string username, string nameComplete, string typeUser)
    {
        Identifier = identifier;
        Username = username;
        NameComplete = nameComplete;
        TypeUser = typeUser;
    }
}
