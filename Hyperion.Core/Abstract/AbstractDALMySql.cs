﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyperion.Core.Abstract
{
    using Poseidon.Base.Framework;
    using Poseidon.Data;

    /// <summary>
    /// MySQL抽象数据访问类,默认主键类型int
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    public abstract class AbstractDALMySql<T> : AbstractDALMySql<T, int> where T : IBaseEntity<int>
    {
    }
}