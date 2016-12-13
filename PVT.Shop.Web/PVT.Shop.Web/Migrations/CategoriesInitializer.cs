namespace PVT.Shop.Web.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;
    using DAL;
    using Infrastructure.Common;

    public static class CategoriesInitializer
    {
        public static void Initialize(ShopContext context)
        {
            if (!context.Categories.Any())
            {
                var root = new Category()
                           {
                               Name = "Catalog",
                               Description = string.Empty,
                               Icon = "http://image.flaticon.com/icons/svg/274/274719.svg"
                };
                context.Categories.AddOrUpdate(
                    root,
                    new Category
                    {
                        Name = "Electronics",
                        Description = "When it comes to computer tablets and home electronics, the possibilities and products are constantly changing. At Evine, we’re here to help you stay ahead of the curve with the hottest new technology at a fraction of the cost. Find products for personal use, such as headphones and unlocked cell phones, or discover items that benefit the whole family, like audio docking stations, HDTVs, home security cameras and alarms. Buy electronics online at Evine for convenience and affordability – we’re proud to offer high-quality refurbished electronics with stellar performance.",
                        Icon = "http://image.flaticon.com/icons/svg/141/141046.svg",
                        Parent = root
                    },
                    new Category
                    {
                        Name = "Cell-Phones",
                        Description = "Your Phone is Your Most Important Accessory – Make it A Good One Keep your vibrant social life alive and kicking!There’s no way you would know about dinner plans on Tuesday, happy hour on Thursday or that your dentist was able to squeeze you in on a Saturday if you don’t have a properly working phone. Just saying. We aim to bring you a highly impressive selection of mobile phones, since staying connected to our friends and family is so essential.Also, we totally get that you want the latest, flashiest phone available to make them look twice and envy your impeccable taste.",
                        Icon = "http://image.flaticon.com/icons/svg/141/141063.svg",
                        Parent = root
                    },
                    new Category
                    {
                        Name = "3G Modems",
                        Description = "A mobile broadband modem, also known as a connect card or data card, is a type of modem that allows a laptop, a personal computer or a router to receive Internet access via a mobile broadband connection instead of using telephone or cable television lines. A mobile Internet user can connect using a wireless modem to a wireless Internet Service Provider (ISP) to get Internet access.",
                        Icon = "http://image.flaticon.com/icons/svg/141/141015.svg",
                        Parent = root
                    },
                    new Category
                    {
                        Name = "Notebooks",
                        Description = "Stay Connected Day and Night with Your Trusty Computer and TabletIn today’s modern world, we all love(and absolutely have) to stay connected – whether it’s to our loved ones, friends or even to our non - stop work schedules.Our incredible assortment of stylish desktop computers, sleek notebooks and speedy tablets will help keep you in the know while you’re on-the - go!",
                        Icon = "http://image.flaticon.com/icons/svg/141/141078.svg",
                        Parent = root
                    },
                    new Category
                    {
                        Name = "Appliances",
                        Description = "Shop for stylish home appliances and reinvent the way you run your home. New appliances can minimize the time you spend doing chores and allow you to focus on family, friends, fun and all the things that really matter to you. Care for your clothes with an intuitive washer, dryer or steamer. Adjust your indoor temperature according to your comfort level with an air conditioner or heater. Up your floor care game with the latest vacuum, carpet cleaner or steam mop. The right home appliance can add appeal to your home and hours to your life, plus give you the optimum results you want.",
                        Icon = "http://image.flaticon.com/icons/svg/148/148127.svg",
                        Parent = root
                    },
                    new Category
                    {
                        Name = "Refrigerators",
                        Description = "Kitchen appliances usually last for a long time, so you may purchase a refrigerator only a few times in your lifetime. Best Buy offers a variety of models of refrigerators for sale, so take the time to learn which is best for your family and your space. You'll find refrigerator deals with the latest and greatest technology on display, from door-in-door models that let you grab your favorite foods without wasting energy to those with built-in apps or a sparkling water dispenser.",
                        Icon = "http://image.flaticon.com/icons/svg/186/186511.svg",
                        Parent = root
                    },
                    new Category
                    {
                        Name = "Coffee Machines",
                        Description = "Our independent tests have uncovered coffee machines costing hundreds of pounds which make a disappointing espresso. Worse still, some are such a nightmare to clean that it's not long before they'll be gathering dust. Compare models and find your perfect coffee machine with our in-depth reviews. Models from  Delonghi, Dolce Gusto, Nespresso, Tassimo and more reviewed.",
                        Icon = "http://image.flaticon.com/icons/svg/150/150365.svg",
                        Parent = root
                    },
                    new Category
                    {
                        Name = "Vaccum Cleaners",
                        Description = "There are about as many types of vacuums as there are floors. The classic upright vacuum is a great balance of power and portability with lots of helpful accessories always at your fingertips. And new technological innovations from brands like Dyson, Hoover, Bissell, Shark and Eureka mean floors get cleaner, faster, and with less effort.",
                        Icon = "http://image.flaticon.com/icons/svg/186/186504.svg",
                        Parent = root
                    },
                    new Category
                    {
                        Name = "Building and repairing",
                        Description = "We have a vast range of products to choose from, with market leading brands such as Kingspan, Celotex, Rockwool, Velux, Catnic, Keystone and many more. You’ll find a comprehensive range of builders’ supplies, ranging from construction materials like bricks, blocks, cast iron guttering, timber, aggregates and cement, to insulation, damp proofing, building plastics, radiators, plumbing and landscaping products. We even sell ladders, access equipment and safety clothing. From start to finish, we’re here to help you get the job done.",
                        Icon = "http://image.flaticon.com/icons/svg/222/222567.svg",
                        Parent = root
                    },
                    new Category
                    {
                        Name = "Drills",
                        Description = "We proudly feature power tools with the latest technological advances, including lithium ion battery technology. These batteries provide more power, run for longer periods of time and charge faster than regular cordless batteries. If you don’t currently possess any cordless power tools, we carry several lithium ion tool kits that include drills, saws, impact drivers, dual batteries and kit cases.",
                        Icon = "http://image.flaticon.com/icons/svg/222/222607.svg",
                        Parent = root
                    },
                    new Category
                    {
                        Name = "Vinyl Windows",
                        Description = "As a result of years of research, design and testing all focused on feedback direct from customers, for the second year running, VELUX has once again revolutionised the roof windows market. Their Roof Window range has now been redesigned to further enhance an already market leading range of products. The standard range has now been changed from a pine finish to a white painted finish which shows a fine woodgrain. It also incorporates the laminated glass as standard for extra safety.",
                        Icon = "http://image.flaticon.com/icons/svg/222/222661.svg",
                        Parent = root
                    },
                    new Category
                    {
                        Name = "Toolboxes",
                        Description = "Whether at home or in a working garage, having a quality toolbox is key to keeping your gear organized. Adding a set of wheels to the mix means that if your ride is on the other side of the room, you won't have to waste away half of your day trekking back and forth to grab that one odd wrench or socket every five minutes. Here are our top picks for best rolling toolboxes for all budgets.",
                        Icon = "http://image.flaticon.com/icons/svg/290/290141.svg",
                        Parent = root
                    });
            }

            context.SaveChanges();
        }
    }
}