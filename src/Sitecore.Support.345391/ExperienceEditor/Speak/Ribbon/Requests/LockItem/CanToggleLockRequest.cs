using Sitecore.Data.Items;
using Sitecore.Data.Managers;
using Sitecore.ExperienceEditor.Speak.Server.Contexts;
using Sitecore.ExperienceEditor.Speak.Server.Requests;
using System;

namespace Sitecore.Support.ExperienceEditor.Speak.Ribbon.Requests.LockItem
{
    public class CanToggleLockRequest : PipelineProcessorControlStateRequest<ItemContext>
    {
        public override bool GetControlState()
        {
            base.RequestContext.ValidateContextItem();
            return this.CanLock(base.RequestContext.Item);
        }

        private bool CanLock(Item item)
        {
            return !(!TemplateManager.IsFieldPartOfTemplate(FieldIDs.Workflow, item) | !TemplateManager.IsFieldPartOfTemplate(FieldIDs.WorkflowState, item)) && item.Access.CanWrite() && item.Access.CanWriteLanguage() && (Sitecore.Context.IsAdministrator || !item.Locking.IsLocked() || item.Locking.HasLock()) && (item.Locking.CanLock() | item.Locking.CanUnlock()) && !item.Appearance.ReadOnly;
        }
    }
}