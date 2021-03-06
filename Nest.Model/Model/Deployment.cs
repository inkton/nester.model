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
    [Cloudname("deployment")]
    public class Deployment : CloudObject
    {
        private int _id;
        private int _appId;
        private int _forestId;
        private int _frameworkVersionId;
        private string _status;
        private bool _makeBackup;

        public Deployment()
        {
            _id = -1;  // _id == -1 is undeployed
            _status = "complete";
            _makeBackup = true;
        }

        public override string CloudKey
        {
            get { return _id.ToString(); }
        }

        public bool IsBusy
        {
            get
            {
                return (_status == "updating");
            }
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

        [JsonProperty("forest_id")]
        public int ForestId
        {
            get { return _forestId; }
            set
            {
                SetProperty(ref _forestId, value);
            }
        }

        [JsonProperty("software_framework_version_id")]
        public int FrameworkVersionId
        {
            get { return _frameworkVersionId; }
            set
            {
                SetProperty(ref _frameworkVersionId, value);
            }
        }

        [JsonProperty("status")]
        public string Status
        {
            get { return _status; }
            set
            {
                SetProperty(ref _status, value);
            }
        }

        [JsonProperty("make_backup")]
        public bool MakeBackup
        {
            get { return _makeBackup; }
            set
            {
                SetProperty(ref _makeBackup, value);
            }
        }

        public string Icon
        {
            get
            {
                switch(_status)
                {
                    case "updating": return "deploymentbusy.png";
                    case "complete": return "deploymentactive.png";
                    // deployment failed icon needed
                    default: return "deploymentactive.png";
                }
            }
        }
    }
}

