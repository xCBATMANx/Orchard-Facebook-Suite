﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard;
using Orchard.ContentManagement; // For generic ContentManager methods
using Piedone.Facebook.Suite.Models;
using Facebook.Web;
using Orchard.Mvc;
using Facebook;

namespace Piedone.Facebook.Suite.Services
{
    public class FacebookSuiteService : IFacebookSuiteService
    {
        private readonly IOrchardServices _orchardServices;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public FacebookSuiteService(
            IHttpContextAccessor httpContextAccessor, 
            IOrchardServices orchardServices)
        {
            _httpContextAccessor = httpContextAccessor;
            _orchardServices = orchardServices;
        }

        private FacebookWebContext _facebookWebContextCache;
        public FacebookWebContext FacebookWebContext
        {
            get
            {
                // Lazy loading the Facebook Web Context
                if (_facebookWebContextCache == null)
                {
                    if (!AppSettingsSet) return null;

                    _facebookWebContextCache = new FacebookWebContext(
                        FacebookSuiteSettingsPart,
                        // OR: _contentManager.Get<FacebookSuiteSettingsPart>(1), // Maybe not the most elegant way, but there will be always only one row
                        _httpContextAccessor.Current());

                    //FacebookApplication.SetApplication(FacebookSuiteSettingsPart); // A workaround for a bug: http://facebooksdk.codeplex.com/workitem/5902
                }
                return _facebookWebContextCache;
            }
        }

        private FacebookSuiteSettingsPart _facebookSuiteSettingsPartCache;
        public FacebookSuiteSettingsPart FacebookSuiteSettingsPart
        {
            get
            {
                if (_facebookSuiteSettingsPartCache == null)
                {
                    _facebookSuiteSettingsPartCache = _orchardServices.WorkContext.CurrentSite.As<FacebookSuiteSettingsPart>();
                }
                return _facebookSuiteSettingsPartCache;
            }
        }


        public bool AppSettingsSet
        {
            get
            {
                return !String.IsNullOrEmpty(FacebookSuiteSettingsPart.AppId);
            }
        }
        
    }
}