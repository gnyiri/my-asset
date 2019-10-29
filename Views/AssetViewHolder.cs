using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace MyAsset.Views
{
    public class AssetViewHolder : RecyclerView.ViewHolder
    {
        public TextView Name { get; private set; }
        public TextView Type { get; private set; }
        public TextView EstimatedValue { get; private set; }
        public TextView StartTime { get; set; }
        public TextView EndTime { get; set; }
        public AssetViewHolder(View itemView) : base(itemView)
        {
            Name = itemView.FindViewById<TextView>(Resource.Id.asset_name);
            Type = itemView.FindViewById<TextView>(Resource.Id.asset_type);
            EstimatedValue = itemView.FindViewById<TextView>(Resource.Id.asset_estimated_value);
            StartTime = itemView.FindViewById<TextView>(Resource.Id.asset_start_time);
            EndTime = itemView.FindViewById<TextView>(Resource.Id.asset_end_time);
        }
    }
}
