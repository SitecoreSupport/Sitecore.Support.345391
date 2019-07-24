using Sitecore.ExperienceEditor.Speak.Server.Contexts;
using Sitecore.ExperienceEditor.Speak.Server.Requests;
using Sitecore.ExperienceEditor.Utils;
using Sitecore.SecurityModel;
using Sitecore.Web;
using Sitecore.Web.UI.HtmlControls;
using System;

namespace Sitecore.Support.ExperienceEditor.Speak.Ribbon.Requests.AddRendering
{
    public class CanAddRendering : PipelineProcessorControlStateRequest<ItemContext>
    {
        public override bool GetControlState()
        {
            if (!base.RequestContext.Site.EnableWebEdit | !Policy.IsAllowed("Page Editor/Can Design"))
            {
                return false;
            }
            base.RequestContext.ValidateContextItem();
            #region sitecore.support.345391
            //if (base.RequestContext.WebEditMode != "edit" || !WebEditUtil.CanDesignItem(base.RequestContext.Item) || base.RequestContext.Item.IsFallback || ItemUtility.RequireLockToEdit(base.RequestContext.Item))
            if ((base.RequestContext.WebEditMode != "edit" || !WebEditUtil.CanDesignItem(base.RequestContext.Item) || base.RequestContext.Item.IsFallback || ItemUtility.RequireLockToEdit(base.RequestContext.Item))&& (base.RequestContext.Item.Name!="Message Root")||base.RequestContext.Item.Branch==null)
            #endregion sitecore.support.345391
            {
                return false;
            }
            string str = "design";
            string @string = Registry.GetString("/Current_User/Page Editor/Capability/" + str, Sitecore.ExperienceEditor.Constants.Registry.CheckboxTickedRegistryValue);
            return !(@string == Sitecore.ExperienceEditor.Constants.Registry.CheckboxUnTickedRegistryValue);
        }
    }
}
