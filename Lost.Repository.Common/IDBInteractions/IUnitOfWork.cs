﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lost.Repository.Common
{
    public interface IUnitOfWork
    {
        bool Commit();
    }
}