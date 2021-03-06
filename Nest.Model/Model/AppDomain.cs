﻿/*
    Copyright (c) 2017 Inkton.

    Permission is hereby granted, free of charge, to any person obtaining
    a copy of this software and associated documentation files (the "Software"),
    to deal in the Software without restriction, including without limitation
    the rights to use, copy, modify, merge, publish, distribute, sublicense,
    and/or sell copies of the Software, and to permit persons to whom the Software
    is furnished to do so, subject to the following conditions:

    The above copyright notice and this permission notice shall be included in
    all copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
    EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
    OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
    IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY
    CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
    TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE
    OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

using System;
using Newtonsoft.Json;
using Inkton.Nest.Cloud;

namespace Inkton.Nest.Model
{
    [Cloudname("app_domain")]
    public class AppDomain : CloudObject
    {
        private int _id;
        private int _appId;
        private string _tag;
        private string _name;
        private bool _default;
        private bool _primary;
        private string _ip;
        private string _aliases;
        private AppDomainCertificate _cert;

        [JsonIgnore]
        public AppDomainCertificate Certificate
        {
            get { return _cert; }
            set
            {
                _cert = value;
            }
        }

        public override string CloudKey
        {
            get { return _id.ToString(); }
        }

        [JsonProperty("id")]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        [JsonProperty("app_id")]
        public int AppId
        {
            get { return _appId; }
            set { SetProperty(ref _appId, value); }
        }

        [JsonProperty("tag")]
        public string Tag
        {
            get { return _tag; }
            set
            {
                SetProperty(ref _tag, value);
            }
        }

        [JsonProperty("name")]
        public string Name
        {
            get { return _name; }
            set
            {
                SetProperty(ref _name, value);
            }
        }

        [JsonProperty("default")]
        public bool Default
        {
            get { return _default; }
            set
            {
                SetProperty(ref _default, value);
            }
        }

        [JsonProperty("aliases")]
        public string Aliases
        {
            get { return _aliases; }
            set
            {
                SetProperty(ref _aliases, value);
                OnPropertyChanged("Icon");
            }
        }

        public string IPAddress
        {
            get { return _ip; }
            set
            {
                SetProperty(ref _ip, value);
            }
        }

        public bool Primary
        {
            get { return _primary; }
            set
            {
                SetProperty(ref _primary, value);
            }
        }

        public string Icon
        {
            get
            {
                if (_default)
                {
                    return "defaultdomain32.png";
                }
                return "domain32.png";
            }
        }
    }
}

