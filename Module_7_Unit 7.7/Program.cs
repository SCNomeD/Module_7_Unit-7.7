using System;

namespace Module_7_Unit_7._7
{
    //Базовый класс доставка
    abstract class Delivery
    {
        public abstract string Address { get; set; } //Задание свойств адреса
        public abstract void ShowCompany(); //Исходный метод с отображением наименования компании
    }
    //Класс-наследник доставка на дом
    class HomeDelivery : Delivery
    {
        private string CompName;
        public int Number;
        private string address;
        public override string Address //Переопределение свойств адреса
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }
        public HomeDelivery() //конструктор для задания наименования компании
        {
            CompName = "'DHL-Express'";
        }
        public override void ShowCompany() //Переопределенный метод с отображением наименования компании
        {
            Console.WriteLine("Заказ будет осуществлен курьерской службой {0} по адресу: {1}", CompName, Address);
        }
    }
    //Класс-наследник доставка в пункт самовывоза
    class PickPointDelivery : Delivery
    {
        private string CompName;
        public int Number;
        private string address;
        public override string Address //Переопределение свойств адреса
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }
        public PickPointDelivery() //конструктор для задания наименования компании
        {
            CompName = "'DHL'";
        }
        public override void ShowCompany() //Переопределенный метод с отображением наименования компании
        {
            Console.WriteLine("Заказ будет доставлен в ближайший пункт выдачи службы {0} по адресу: {1}", CompName, Address);
        }
    }
    //Класс-наследник доставка в магазин
    class ShopDelivery : Delivery
    {
        private string CompName;
        public int Number;
        private string address;
        public override string Address //Переопределение свойств адреса
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }
        public ShopDelivery() //конструктор для задания наименования компании
        {
            CompName = "'Перекресток'";
        }
        public override void ShowCompany() //Переопределенный метод с отображением наименования компании
        {
            Console.WriteLine("Заказ будет доставлен в ближайший магазин {0} по адресу: {1}", CompName, Address);
        }
    }
    //Класс заказа
    public class Order
    {
        public int Number;
        public int CountOrder;

        private Random random = new Random();
        public Order() //конструктор для задания произвольного номера заказа
        {
            Number = random.Next(1000000);
            CountOrder = 0;
        }
        //Класс с данными пользователя
        class User
        {
            public string Name, address;
            public int age;
            public int Age //Задание свойств возраста с ограничением до 18
            {
                get
                {
                    return age;
                }
                set
                {
                    {
                        if (value < 18)
                        {
                            Console.WriteLine("Для осуществления покупок Ваш возраст должен быть не меньше 18 лет");
                        }
                        else
                        {
                            age = value;
                        }
                    }
                }
            }
            public string Address //Задание свойств адреса
            {
                get
                {
                    return address;
                }
                set
                {
                    address = value;
                }
            }
            public void DisplayName() //Метод для отображения данных пользователя
            {
                Console.WriteLine("Ваше имя: {0}. Ваш возраст: {1}. Ваш адрес: {2}. Приятных покупок!", Name, Age, Address);
            }
        }
        // Класс для объекта “Продукты”
        public class Product
        {
            public string Name;
            public int Coast;
        }
        // Класс для объекта “Коллекция продуктов”
        class ProductCollection
        {
            // Закрытое поле, хранящее продукты в виде массива
            private Product[] collection;

            // Конструктор с добавлением массива продуктов
            public ProductCollection(Product[] collection)
            {
                this.collection = collection;
            }

            // Индексатор по массиву
            public Product this[int index]
            {
                get
                {
                    // Проверяем, чтобы индекс был в диапазоне для массива
                    if (index >= 0 && index < collection.Length)
                    {
                        return collection[index];
                    }
                    else
                    {
                        return null;
                    }
                }

                private set
                {
                    // Проверяем, чтобы индекс был в диапазоне для массива
                    if (index >= 0 && index < collection.Length)
                    {
                        collection[index] = value;
                    }
                }
            }
        }
        //Класс для выбора номера продукта из списка
        class NumberOfProduct : Product
        {
            int number;
            public int Number //Задание свойств для номера продукта
            {
                get
                {
                    return number;
                }
                set
                {
                    number = value;
                }
            }
        }
        //Метод для отображения данных сформированного заказа
        public void DisplayOrder()
        {
            Console.WriteLine("Номер заказа {0}, сумма заказа {1} руб.", Number, CountOrder);
        }
        //Метод для подсчета суммы заказа и вывода на экран метода выше
        public void AddProduct(Product p)
        {
            CountOrder += p.Coast;
            DisplayOrder();
        }
        //Метод для отображения сформированного заказа
        public void ListProduct(Product p)
        {
            Console.WriteLine("Заказ оформлен:");
            DisplayOrder();
            Console.WriteLine("Товары вашего заказа:\n{0}, цена {1} руб.", p.Name, p.Coast);
        }

        class Program
        {
            static void Main(string[] args)
            {
                User user = new User();
                NumberOfProduct product = new NumberOfProduct();
                Order order = new Order();

                do
                {
                    Console.WriteLine("Введите Ваш возраст");
                    user.Age = Convert.ToInt32(Console.ReadLine());
                } while (user.Age < 18);

                Console.WriteLine("Введите Ваше имя");
                user.Name = Console.ReadLine();
                Console.WriteLine("Введите Ваше адрес");
                user.Address = Console.ReadLine();
                user.DisplayName();

                var array = new Product[]
                {
                    new Product { Name = "Хлеб", Coast = 50 },
                    new Product { Name = "Вода", Coast = 70 },
                    new Product { Name = "Пельмени 1кг", Coast = 180 },
                    new Product { Name = "Суп гороховый", Coast = 200 },
                    new Product { Name = "Куриная грудка", Coast = 220 },
                };
                ProductCollection collection = new ProductCollection(array);

                Console.WriteLine("Список товаров:\n1. Хлеб(50р.)\n2. Вода(70р.)\n3. Пельмени(180р.)\n4. Суп гороховый(200р.)\n5. Куриная грудка(220р)");

                Console.WriteLine("Введите номер продукта который вы собираетесь купить:");
                product.Number = Convert.ToInt32(Console.ReadLine());

                Product coast = collection[product.Number - 1];
                order.AddProduct(coast);

                Console.WriteLine("Выберите доставку: 1 - курьером, 2 - в пункт выдачи, 3 - получить в магазине");
                int shop = Convert.ToInt32(Console.ReadLine());

                order.ListProduct(coast);

                switch (shop)
                {
                    case 1:
                        HomeDelivery deliver1 = new HomeDelivery { Address = user.Address, Number = order.Number };
                        deliver1.ShowCompany();
                        break;
                    case 2:
                        PickPointDelivery deliver2 = new PickPointDelivery { Address = "Васильковый переулок, д.72", Number = order.Number };
                        deliver2.ShowCompany();
                        break;
                    case 3:
                        ShopDelivery deliver3 = new ShopDelivery { Address = "Цветочный проезд, д.63", Number = order.Number };
                        deliver3.ShowCompany();
                        break;
                }

                Console.ReadLine();
            }
        }
    }
}