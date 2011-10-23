using Orchard.ContentManagement.MetaData;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;
using Orchard.Environment.Extensions;
using Piedone.Facebook.Suite.Models;

namespace Piedone.Facebook.Suite.Migrations
{
    [OrchardFeature("Piedone.Facebook.Suite.CommentsBox")]
    public class FacebookCommentsBoxMigrations : DataMigrationImpl
    {
        public int Create()
        {
            // Creating table FacebookCommentsBoxPartRecord
            SchemaBuilder.CreateTable("FacebookCommentsBoxPartRecord", table => table
                .ContentPartRecord()
                .Column<int>("NumberOfPosts")
                .Column<int>("Width")
                .Column<string>("ColorScheme")
            );

            ContentDefinitionManager.AlterPartDefinition(typeof(FacebookCommentsBoxPart).Name,
                builder => builder.Attachable());

            ContentDefinitionManager.AlterTypeDefinition("FacebookCommentsBoxWidget", cfg => cfg
                .WithPart("FacebookCommentsBoxPart")
                .WithPart("WidgetPart")
                .WithPart("CommonPart")
                .WithSetting("Stereotype", "Widget"));


            return 1;
        }
    }
}