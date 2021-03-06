﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Script.Serialization;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class ContactsController : ApiController
    {
        public HttpResponseMessage GetAllContacts(string callback)
        {
            Contact[] contacts = new Contact[]
            {
                new Contact{ Name="张三", PhoneNo="123", EmailAddress="zhangsan@gmail.com"},
                new Contact{ Name="李四", PhoneNo="456", EmailAddress="lisi@gmail.com"},
                new Contact{ Name="王五", PhoneNo="789", EmailAddress="wangwu@gmail.com"},
            };
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string content = string.Format("{0}({1})", callback, serializer.Serialize(contacts));
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(content, Encoding.UTF8, "text/javascript")
            };
        }
    }
}
