using DevExpress.Xpf.Core;
using Prism.Regions;
using System.Collections.Specialized;
using System.Windows;

namespace LoadingDecoratorWithPrism.Core.RegionAdapters
{
    public class LoadingDecoratorRegionAdapter : RegionAdapterBase<LoadingDecorator>
    {
        public LoadingDecoratorRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory)
            : base(regionBehaviorFactory)
        {
        }

        protected override void Adapt(IRegion region, LoadingDecorator regionTarget)
        {
            region.Views.CollectionChanged += (s, e) =>
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (FrameworkElement view in e.NewItems)
                    {
                        regionTarget.LoadingChild = view;
                    }
                }
                else if (e.Action == NotifyCollectionChangedAction.Remove)
                {
                    foreach (FrameworkElement view in e.OldItems)
                    {
                        regionTarget.LoadingChild = null;
                    }
                }
            };
        }

        protected override IRegion CreateRegion()
        {
            return new SingleActiveRegion();
        }
    }
}