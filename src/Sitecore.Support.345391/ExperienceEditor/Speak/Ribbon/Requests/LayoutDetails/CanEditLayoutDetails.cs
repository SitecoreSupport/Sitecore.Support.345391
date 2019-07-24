using Sitecore.Data.Items;
using Sitecore.Data.Managers;
using Sitecore.ExperienceEditor.Speak.Server.Contexts;
using Sitecore.ExperienceEditor.Speak.Server.Requests;
using Sitecore.ExperienceEditor.Utils;
using System;

namespace Sitecore.Support.ExperienceEditor.Speak.Ribbon.Requests.LayoutDetails
{
    public class CanEditLayoutDetailsRequest : PipelineProcessorControlStateRequest<ItemContext>
    {
        public override bool GetControlState()
        {
            base.RequestContext.ValidateContextItem();
            return this.GetCommandState();
        }

        public virtual bool GetCommandState()
        {
            Item item = base.RequestContext.Item;
            #region sitecore.support.345391
            //return TemplateManager.IsFieldPartOfTemplate(FieldIDs.LayoutField, item) && !(base.RequestContext.WebEditMode == "preview") && !base.RequestContext.Item.IsFallback && item.Access.CanWrite() && item.Access.CanWriteLanguage() && !ItemUtility.RequireLockToEdit(item);
            return (TemplateManager.IsFieldPartOfTemplate(FieldIDs.LayoutField, item) && !(base.RequestContext.WebEditMode == "preview") && !base.RequestContext.Item.IsFallback && item.Access.CanWrite() && item.Access.CanWriteLanguage() && !ItemUtility.RequireLockToEdit(item)) || System.Web.HttpContext.Current.Request.Path.Contains("sitecore/client/Applications/ECM/");
            #endregion sitecore.support.345391
        }
    }
}
