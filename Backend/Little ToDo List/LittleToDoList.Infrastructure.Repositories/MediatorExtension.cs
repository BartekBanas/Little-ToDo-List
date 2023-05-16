﻿using LittleToDoList.Business.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LittleToDoList.Infrastructure.Repositories;

internal static class MediatorExtension
{
    public static async Task DispatchDomainEventsAsync(this IMediator mediator, DbContext dbContext)
    {
        var domainEntities = dbContext.ChangeTracker
            .Entries<IEntity>()
            .Where(entry => entry.Entity.DomainEvents != null && entry.Entity.DomainEvents.Any())
            .ToArray();

        var domainEvents = domainEntities
            .SelectMany(entry => entry.Entity.DomainEvents!)
            .ToArray();

        foreach (var entry in domainEntities)
            entry.Entity.ClearDomainEvents();

        foreach (var domainEvent in domainEvents)
            await mediator.Publish(domainEvent);
    }
}