﻿using Orchard.ContentManagement.Handlers;
using Orchard.Data;
using Orchard.Environment.Extensions;
using Piedone.Facebook.Suite.Models;

namespace Piedone.Facebook.Suite.Handlers
{
    [OrchardFeature("Piedone.Facebook.Suite.LikeButton")]
    public class FacebookLikeButtonHandler : ContentHandler
    {
        public FacebookLikeButtonHandler(IRepository<FacebookLikeButtonPartRecord> repository)
        {
            Filters.Add(StorageFilter.For(repository));
        }
    }
}