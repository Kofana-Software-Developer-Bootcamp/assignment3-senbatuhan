using System;
using System.Collections.Generic;

namespace CustomerOrderCLI
{
    class Program
    {
        // this isIDValid() function checks the TC Number has 11 digits and has no letter
        static bool isIdValid(String id)
        {
            long i = 0;
            bool result = long.TryParse(id, out i);
            if (result)
            {
                if (id.Length < 11)
                {
                    return false;
                }
                if (id.Length > 11)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
            
        }
        static void Main(string[] args)
        {
            // Some Customers Data ("TC","Name","Surname");
            Customers c1 = new Customers("12345678900", "Batuhan", "ŞEN");
            Customers c2 = new Customers("00123456789", "Serkan", "İnce");
            Customers c3 = new Customers("00123456788", "Elif", "Yılmaz");

            //Adding test customers data in the List which keeps Customer Class Objects
            List<Customers> customers = new List<Customers>();
            customers.Add(c1);
            customers.Add(c2);
            customers.Add(c3);


            // Some Products Data ("Name","Stock");
            Products p1 = new Products("i3 Processors", 2500);
            Products p2 = new Products("i5 Processors", 2000);
            Products p3 = new Products("i7 Processors", 1500);

            //Adding test products data in the List which keeps Product Class Objects
            List<Products> products = new List<Products>();
            products.Add(p1);
            products.Add(p2);
            products.Add(p3);


            // idValid is using to check the TC Number by the user with isIdValid() function in while loop for controlling mechanism
            bool idValid = true;
            // idUnput is the input by the user
            string idInput = "";
            // a customer is new customer, it is using in while loop for controlling mechanism
            bool wantingCustomer = true;
            // customer exists or new that wants to buy some products, it is using in while loop for controlling mechanism
            bool yesWant = false;

            Console.WriteLine("Kofana Software Development Bootcamp - CustomerOrderCLI");
            Console.WriteLine("Lütfen TC Kimlik Numaranızı Giriniz.");
            while (idValid)
            {
                idInput = Console.ReadLine(); // get TC by the user
                switch (isIdValid(idInput)) // isIdValid checks the input TC has 11 digit and has no letter, if false try again, if true idValid will be true and escape from while loop
                {
                    case false:
                        Console.WriteLine("TC Numaranız Hatalıdır. Lütfen 11 Hane Olacak Şekilde veya Harf İçermeden Giriniz");
                        break;
                    case true:
                        Console.WriteLine("Kontroller sağlanıyor.\n");
                        idValid = false;
                        break;
                }

            }

            //idExist will be used for the TC is OK with 11 digit and no letter rule but we have a customer or not in our database. Controlling it.
            bool idExist = false;
            // if customer exist in List Database, we are handling the customer location in the array with using whichCustomer
            int whichCustomer = -1;
            //TC is OK inValid is defined above.
            if (idValid == false)
            {
                //check the customer inside the List
                for(int i = 0; i < customers.Count; i++)
                {
                    if (customers.ToArray()[i].getId() == idInput)
                    {
                        // whichCustomer will be used for getting Name, Surname of customer
                        whichCustomer = i;
                        idExist = true;
                    }
                }
                // if customer exist with TC in List
                if (idExist)
                {
                    Console.WriteLine("Hoşgeldiniz " + customers.ToArray()[whichCustomer].getName() + "\n");
                    // yesWant directs u to buying process
                    yesWant = true;

                }
                // No customer. Do u want to be a customer :)
                else
                {
                    Console.WriteLine("Sistemizde kayıtlı böyle bir TC Numarası bulunmamaktadır.");
                    Console.WriteLine("Üyemiz Olmak İster misiniz?");
                    Console.WriteLine("1-Evet 2-Hayır");
                    while (wantingCustomer)
                    {
                       
                        // get the option. if 1 selected -> Yes, i want to be a customer, if 2 selected - > No, i do not want to buy something in your application :D, else try again
                        int yes = Convert.ToInt32(Console.ReadLine());
                        switch (yes)
                        {
                            case 1:
                                Console.WriteLine("Lütfen Adınızı Giriniz!");
                                string name = Console.ReadLine();
                                Console.WriteLine("Lütfen Soyadınızı Giriniz!");
                                string surname = Console.ReadLine();
                                Customers newc = new Customers(idInput, name, surname);
                                // add the customer in the List Database
                                customers.Add(newc);
                                //whichCustomer is so important because, you are a new customer, the alerts, messages to you, i will use it. Because you are new added in List :)
                                whichCustomer = customers.Count-1;
                                wantingCustomer = false; // escape from loop
                                yesWant = true; // yesWant directs u to buying process
                                break;
                            case 2:
                                Console.Write("Bütün işlem iptal edilmiştir. Tekrar Görüşmek Üzere :)");
                                wantingCustomer = false;
                                break;
                            default:
                                Console.WriteLine("Hatalı Seçim :) 1-Evet 2-Hayır");
                                break;
                        }

                    }

                }

            }

            int whichprod = -1; // this will be used for the product which customer want to buy
            bool goAhead = false;

            //You are buying now
            if (yesWant)
            {
                Console.WriteLine("Ürünler Listelendi "+ customers.ToArray()[whichCustomer].getName());
                for (int i = 0; i < products.Count; i++)
                {
                    Console.WriteLine((i + 1) + "-" + products.ToArray()[i].getName());
                }
                Console.WriteLine("Hangi Ürünü Almak İsterseniz? Vazgeçmek için lütfen 0 a basınız!");
                bool productBuy = true;
                while (productBuy)
                {

                    //select the product
                    int buy = Convert.ToInt32(Console.ReadLine());
                    switch (buy)
                    {
                        case 0:
                            Console.WriteLine(":( Görüşmek Üzere Siparişiniz İptal Edilmiştir :(");
                            goAhead = false;
                            productBuy = false;
                            break;
                        case 1:
                            Console.WriteLine("Tebrikler " + products.ToArray()[0].getName() + " Güzel Bir İşlemci Alıyorsunuz");
                            productBuy = false;
                            whichprod = 0;
                            goAhead = true;
                            break;
                        case 2:
                            Console.WriteLine("Tebrikler " + products.ToArray()[1].getName() + " Güzel Bir İşlemci Alıyorsunuz");
                            productBuy = false;
                            whichprod = 1;
                            goAhead = true;
                            break;
                        case 3:
                            Console.WriteLine("Tebrikler " + products.ToArray()[2].getName() + " Güzel Bir İşlemci Alıyorsunuz");
                            productBuy = false;
                            whichprod = 2;
                            goAhead = true;
                            break;
                        default:
                            Console.WriteLine("Hatalı Seçim :) Ürünler Yukarıda - Vazgeçmek için lütfen 0 a basınız!");
                            break;
                    }

                }
                // howmany will be used for count of buying process. Of course, this must grater than 1
                int howmany = 0;
                //Still Buying, Last Part :)
                while (goAhead)
                {
                    Console.WriteLine(products.ToArray()[whichprod].getName() + " Ürününden Kaç Tane Almak İstiyorsunuz?");
                    howmany = Convert.ToInt32(Console.ReadLine());
                    if (howmany <= 0)
                    {
                        Console.WriteLine("Sepetinize en az 1 ürün ekleyebilirsiniz!");
                    }
                    else
                    {
                        Console.WriteLine("Merhaba " + customers.ToArray()[whichCustomer].getName() + " "+customers.ToArray()[whichCustomer].getSurname() + " " + howmany + " adet " + products.ToArray()[whichprod].getName() + " işlemci siparişini aldık en kısa sürede gönderim sağlanacaktır.");
                        Console.WriteLine("Bizi Tercih Ettiğiniz İçin Teşekkür Ederiz ve Yine Bekleriz :)\n");
                        Console.WriteLine("Kofana Software Development Bootcamp - Batuhan ŞEN");

                        goAhead = false;
                    }
                }




            }

        }
    }
}
