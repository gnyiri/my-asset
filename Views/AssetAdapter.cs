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
    public class AssetAdapter : RecyclerView.Adapter
    {
        private Services.Database mDatabase;
        private List<Model.Asset> mAssets;

        public AssetAdapter(Services.Database database)
        {
            mDatabase = database;
            mAssets = mDatabase.GetAssets();
        }

        public override int ItemCount => mDatabase.GetAssets().Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            AssetViewHolder vh = holder as AssetViewHolder;

            var asset = mAssets[position];

            vh.Name.Text = asset.Name;
            vh.EstimatedValue.Text = asset.EstimatedValue.ToString("0.00");

            var assetType = mDatabase.AssetTypeById(asset.AssetTypeId);
            vh.Type.Text = assetType.Name;

            vh.StartTime.Text = asset.StartTime.ToString(Constants.DateTimeFormat);
            vh.EndTime.Text = asset.EndTime.ToString(Constants.DateTimeFormat);
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.asset_card_view, parent, false);

            AssetViewHolder vh = new AssetViewHolder(itemView);

            return vh;
        }
    }
}
