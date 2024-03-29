﻿using System.Threading.Tasks;
using Messages.Commands;
using Messages.Events;
using NServiceBus;
using NServiceBus.Logging;

namespace Opportunity
{
    internal class LinkContactToOpportunityHandler : IHandleMessages<LinkContactToOpportunity>
    {
        private static ILog log = LogManager.GetLogger<LinkContactToOpportunityHandler>();

        public async Task Handle(LinkContactToOpportunity message, IMessageHandlerContext context)
        {
            log.Info($"LinkContactToOpportunityHandler: ContactId [{message.ContactId}] OpportunityId [{message.OpportunityId}]");

            await context.Send(new ChangeLeadLifeCycleState()
            {
                OpportunityId = message.OpportunityId,
                ContactId = message.ContactId,
                AccountId = message.AccountId,
                LeadId = message.LeadId
            });
        }
    }
}