﻿using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CZGL.Auth.Interface
{
    /// <summary>
    /// 授权时事件接口，必须使用异步且返回Task
    /// </summary>
    public interface IRoleEventsHadner
    {

        /// <summary>
        /// 授权开始前
        /// </summary>
        /// <param name="httpContext">HttpContext</param>
        /// <returns></returns>
        Task Start(object httpContext);

        /// <summary>
        /// 客户端携带的 Token 不是有效的 Jwt 令牌，将不能被解析
        /// </summary>
        /// <param name="eventsInfo">EventsInfo类型</param>
        /// <returns></returns>
        void TokenEbnormal(object eventsInfo);

        /// <summary>
        /// 令牌解码后，issuer 或 audience不正确
        /// </summary>
        /// <param name="eventsInfo">EventsInfo类型</param>
        /// <returns></returns>
        void TokenIssued(object eventsInfo);

        /// <summary>
        /// 用户所属的角色中，均无访问API的权限，即无访问此API的权限
        /// </summary>
        /// <param name="eventsInfo">EventsInfo类型</param>
        /// <returns></returns>
        void NoPermissions(object eventsInfo);

        /// <summary>
        /// 授权成功
        /// </summary>
        /// <param name="eventsInfo">EventsInfo类型</param>
        /// <returns></returns>
        void Success(object eventsInfo);

        /// <summary>
        /// 授权成功后
        /// </summary>
        /// <param name="httpContext">HttpContext</param>
        /// <returns></returns>
        Task End(object httpContext);
    }

}
