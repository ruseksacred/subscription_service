using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SubscriptionService.Models
{
    public class SubscriberContext:DbContext
    {
        public SubscriberContext()
            :base("SubscriptionService")
        {

        }

        public DbSet<Subscriber> Subscribers { get; set; }

    }
}