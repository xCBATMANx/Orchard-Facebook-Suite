﻿using Orchard.ContentManagement.Handlers;
using Orchard.Data;
using Orchard.Environment.Extensions;
using Piedone.Facebook.Suite.Models;

namespace Piedone.Facebook.Suite.Handlers
{
    [OrchardFeature("Piedone.Facebook.Suite.LikeBox")]
    public class FacebookLikeBoxHandler : ContentHandler
    {
        public FacebookLikeBoxHandler(IRepository<FacebookLikeBoxPartRecord> repository)
        {
            Filters.Add(StorageFilter.For(repository));
        }
    }
}