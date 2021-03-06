﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EddiEvents
{
    public class DataVoucherRedeemedEvent : Event
    {
        public const string NAME = "Data voucher redeemed";
        public const string DESCRIPTION = "Triggered when you redeem a data voucher";
        public const string SAMPLE = @"{ ""timestamp"":""2016-12-29T10:10:11Z"", ""event"":""RedeemVoucher"", ""Type"":""settlement"",""Amount"":1000,""Factions"":[{""Faction"":""The Pilots Federation"",""Amount"":1000}] }";

        public static Dictionary<string, string> VARIABLES = new Dictionary<string, string>();

        static DataVoucherRedeemedEvent()
        {
            VARIABLES.Add("rewards", "The rewards obtained broken down by faction");
            VARIABLES.Add("amount", "The amount rewarded (after any broker fees)");
        }

        [JsonProperty("rewards")]
        public List<Reward> rewards { get; private set; }

        [JsonProperty("amount")]
        public long amount { get; private set; }

        public DataVoucherRedeemedEvent(DateTime timestamp, List<Reward> rewards, long amount) : base(timestamp, NAME)
        {
            this.rewards = rewards;
            this.amount = amount;
        }
    }
}
