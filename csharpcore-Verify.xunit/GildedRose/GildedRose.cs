using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Reflection.Metadata;

namespace GildedRoseKata
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }
        const string brie = "Aged Brie";
        const string tickets = "Backstage passes to a TAFKAL80ETC concert";
        const string sulfuras = "Sulfuras, Hand of Ragnaros";

        public void UpdateQuality()
        {
            foreach (Item item in Items)
            {
                switch (item.Name)
                {
                    case brie:
                        {
                            if (item.Quality < 50) item.Quality++;
                            break;
                        }
                    case tickets:
                        {
                            if (item.SellIn < 11 && item.SellIn > 5) item.Quality += 2;
                            else if (item.SellIn > 0) item.Quality += 3;
                            else item.Quality = 0;
                            break;
                        }
                    case sulfuras:
                        {
                            break;
                        }
                    case string conjured when conjured.Contains("Conjured", StringComparison.OrdinalIgnoreCase):
                        {
                            if (item.Quality != 0)
                            {
                                if (item.SellIn <= 0) item.Quality -= 4;
                                else item.Quality -= 2;
                            }
                            item.SellIn--;
                            break;
                        }
                    default:
                        {
                            if (item.Quality != 0)
                                {
                                    if (item.SellIn <= 0) item.Quality -= 2;
                                        else item.Quality--;
                                }
                            item.SellIn--;
                            break;
                        }
                }
            }
        }
    }
}
