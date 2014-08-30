using System;
using OneSolutionV3.Domain.Models;

namespace OneSolutionV3.Domain.DTO.Activity
{
    public class ActivityViewModel
    {
        public string Description { get; set; }
        public int ActivityType { get; set; }
        public DateTime DateCreated { get; set; }

        public string ActivityTypeIcon
        {
            get
            {
                switch (ActivityType)
                {
                    case (int)OneSolutionV3.Domain.Models.Activity.ActivityTypes.Transaction:
                        return "icofont-retweet color-orange";
                    case (int)OneSolutionV3.Domain.Models.Activity.ActivityTypes.Registration:
                        return "icofont-check color-win8";
                    case (int)OneSolutionV3.Domain.Models.Activity.ActivityTypes.MoneyCount:
                        return "icofont-envelope color-green";
                    case (int)OneSolutionV3.Domain.Models.Activity.ActivityTypes.FundTransfer:
                        return "icofont-briefcase color-blue";
                    case (int)OneSolutionV3.Domain.Models.Activity.ActivityTypes.Debt:
                        return "icofont-credit-card color-purple";
                    case (int)OneSolutionV3.Domain.Models.Activity.ActivityTypes.DebtPayment:
                        return "icofont-envelope color-red";
                    default :
                        return "";

                }
            }
        }
    }
}
