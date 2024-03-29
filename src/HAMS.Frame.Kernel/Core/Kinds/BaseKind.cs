﻿namespace HAMS.Frame.Kernel.Core
{
    /// <summary>
    /// 根类型
    /// </summary>
    public abstract class BaseKind
    {
        /// <summary>
        /// 标识项,采用ULID编码
        /// </summary>
        /// <remarks>
        /// ULID是JavaScript原生编码，26位字符格式.
        /// 更多信息请参见<seealso cref="ULID" href="https://github.com/ulid"/>
        /// 程序采用ULID-C#实现库：<seealso cref="NUlid" href="https://github.com/RobThree/NUlid"/>
        /// </remarks>
        public virtual string Code { get; set; }

        /// <summary>
        /// 内容项
        /// </summary>
        public virtual string Content { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public virtual string Note { get; set; }

        /// <summary>
        /// 有效标志
        /// </summary>
        /// 
        /// <remarks>
        /// 1：有效 0：无效
        /// </remarks>
        public virtual bool EnabledFlag { get; set; }
    }
}
