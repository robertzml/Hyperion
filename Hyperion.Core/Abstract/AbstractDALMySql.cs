using System;
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
    internal abstract class AbstractDALMySql<T> : AbstractDALMySql<T, int> where T : IBaseEntity<int>
    {
        #region Constructor
        /// <summary>
        /// MySQL抽象数据访问类
        /// </summary>
        /// <param name="tableName">数据表名</param>
        /// <param name="primaryKey">主键名称</param>
        public AbstractDALMySql(string tableName, string primaryKey) : base(tableName, primaryKey)
        { }
        #endregion //Constructor
    }
}
