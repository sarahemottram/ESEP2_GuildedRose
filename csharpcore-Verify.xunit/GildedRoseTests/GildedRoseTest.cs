using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        //given example
        [Fact]
        public void foo()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal("foo", Items[0].Name);
        }
        //All items have a SellIn value which denotes the number of days we have to sell the items
        [Fact]
        public void has_sellin_value()
        {
            var sellin = 1;
            var quality = 1;
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = sellin, Quality = quality } };
            GildedRose app = new GildedRose(Items);

            Assert.Equal(sellin, Items[0].SellIn);
        }
        //All items have a Quality value which denotes how valuable the item is
        [Fact]
        public void has_quality_value()
        {
            var sellin = 1;
            var quality = 1;
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = sellin, Quality = quality } };
            GildedRose app = new GildedRose(Items);

            Assert.Equal(quality, Items[0].Quality);
        }
        //At the end of each day our system lowers both values for every item (sellin)
        [Fact]
        public void has_sellin_decreased()
        {
            var sellin = 1;
            var quality = 1;
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = sellin, Quality = quality } };

            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.Equal(sellin-1, Items[0].SellIn);
        }
        //At the end of each day our system lowers both values for every item (quality)
        [Fact]
        public void has_quality_decreased()
        {
            var sellin = 1;
            var quality = 1;
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = sellin, Quality = quality } };

            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.Equal(quality - 1, Items[0].Quality);
        }
        //Once the sell by date has passed, Quality degrades twice as fast
        [Fact]
        public void has_quality_decreases_twice_as_fast_after_sellin()
        {
            var sellin = 0;
            var quality = 2;
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = sellin, Quality = quality } };

            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.Equal(quality - 2, Items[0].Quality);
        }
        //The Quality of an item is never negative
        [Fact]
        public void quality_never_negative()
        {
            var sellin = 0;
            var quality = 0;
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = sellin, Quality = quality } };

            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.Equal(quality, Items[0].Quality);
        }
        //"Aged Brie" actually increases in Quality the older it gets
        [Fact]
        public void aged_brie_increases_quality()
        {
            var sellin = 1;
            var quality = 1;
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = sellin, Quality = quality } };

            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.Equal(quality + 1, Items[0].Quality);
        }
        //The Quality of an item is never more than 50
        [Fact]
        public void quality_never_over_fifty()
        {
            var sellin = 1;
            var quality = 50;
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = sellin, Quality = quality } };

            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.Equal(quality, Items[0].Quality);
        }
        //"Sulfuras", being a legendary item, never has to be sold or decreases in Quality (sellin)
        [Fact]
        public void sulfuras_sellin_doesnt_decrease()
        {
            var sellin = 1;
            var quality = 1;
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = sellin, Quality = quality } };

            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.Equal(sellin, Items[0].SellIn);
        }
        //"Sulfuras", being a legendary item, never has to be sold or decreases in Quality (quality)
        [Fact]
        public void sulfuras_quality_doesnt_decrease()
        {
            var sellin = 1;
            var quality = 1;
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = sellin, Quality = quality } };

            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.Equal(quality, Items[0].Quality);
        }
        //"backstage passes" Quality increases by 2 when there are 10 days or less
        [Fact]
        public void backstatge_pass_10_days()
        {
            var sellin = 10;
            var quality = 1;
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellin, Quality = quality } };

            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.Equal(quality + 2, Items[0].Quality);
        }
        //"backstage passes" Quality increases by 3 when there are 5 days or less
        [Fact]
        public void backstatge_pass_5_days()
        {
            var sellin = 5;
            var quality = 1;
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellin, Quality = quality } };

            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.Equal(quality + 3, Items[0].Quality);
        }
        //"backstage passes" Quality drops to 0 after the concert
        [Fact]
        public void backstatge_pass_0_days()
        {
            var sellin = 0;
            var quality = 10;
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellin, Quality = quality } };

            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.Equal(0, Items[0].Quality);
        }
        //Conjured items degrade in quality twice as fast (sellin > 0)
        [Fact]
        public void conjured_quality_degrade_before_sellin()
        {
            var sellin = 1;
            var quality = 10;
            IList<Item> Items = new List<Item> { new Item { Name = "conjured foo", SellIn = sellin, Quality = quality } };

            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.Equal(quality - 2, Items[0].Quality);
        }
        //Conjured items degrade in quality twice as fast (sellin <= 0)
        [Fact]
        public void conjured_quality_degrade_after_sellin()
        {
            var sellin = 0;
            var quality = 10;
            IList<Item> Items = new List<Item> { new Item { Name = "conjured foo", SellIn = sellin, Quality = quality } };

            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.Equal(quality - 4, Items[0].Quality);
        }
    }
}
