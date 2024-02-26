﻿using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes;

public class EfModuleDal : EfRepositoryBase<Module, Guid, TobetoPlatformContext>, IModuleDal
{
    public EfModuleDal(TobetoPlatformContext context) : base(context)
    {
    }
}
