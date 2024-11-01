﻿using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Rumi.Data;

/* This is used if database provider does't define
 * IRumiDbSchemaMigrator implementation.
 */
public class NullRumiDbSchemaMigrator : IRumiDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
