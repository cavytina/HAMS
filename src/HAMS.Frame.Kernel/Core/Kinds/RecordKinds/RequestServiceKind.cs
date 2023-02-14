﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HAMS.Frame.Kernel.Core
{
    public class RequestServiceKind : EventServiceKind
    {
        /// <summary>
        /// 请求服务目标模块名称
        /// </summary>
        /// 
        /// <remarks>
        /// eventJsonSentence.tagt_mod_name
        /// </remarks>
        [JsonProperty(PropertyName = "tagt_mod_name", Order = 6)]
        [JsonConverter(typeof(StringEnumConverter))]
        public FrameModulePart TargetModuleName { get; set; }
    }
}